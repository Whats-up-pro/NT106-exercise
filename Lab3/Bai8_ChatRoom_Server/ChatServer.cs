using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using Bai8_ChatRoom_Server.Models;

namespace Bai8_ChatRoom_Server
{
    public class ChatServer
    {
        private TcpListener listener;
        private Dictionary<string, TcpClient> clients;  // username -> client
        private bool isRunning;
        private object lockObject = new object();

        public event Action<string> OnLogMessage;

        public ChatServer(int port)
        {
            listener = new TcpListener(IPAddress.Any, port);
            clients = new Dictionary<string, TcpClient>();
        }

        public void Start()
        {
            listener.Start();
            isRunning = true;
            Log("Chat Server started!");

            Thread acceptThread = new Thread(AcceptClients);
            acceptThread.IsBackground = true;
            acceptThread.Start();
        }

        public void Stop()
        {
            isRunning = false;
            listener?.Stop();

            lock (lockObject)
            {
                foreach (var client in clients.Values)
                {
                    client?.Close();
                }
                clients.Clear();
            }

            Log("Chat Server stopped!");
        }

        private void AcceptClients()
        {
            while (isRunning)
            {
                try
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
                catch (Exception ex)
                {
                    if (isRunning)
                    {
                        Log($"Accept error: {ex.Message}");
                    }
                }
            }
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = null;
            string username = null;

            try
            {
                stream = client.GetStream();

                while (isRunning && client.Connected)
                {
                    if (stream.DataAvailable)
                    {
                        // Read length prefix
                        byte[] lengthBuffer = new byte[4];
                        int bytesRead = 0;
                        while (bytesRead < 4)
                        {
                            int read = stream.Read(lengthBuffer, bytesRead, 4 - bytesRead);
                            if (read == 0) break;
                            bytesRead += read;
                        }

                        if (bytesRead < 4) break;

                        int messageLength = BitConverter.ToInt32(lengthBuffer, 0);

                        // Read message data
                        byte[] buffer = new byte[messageLength];
                        int totalBytesRead = 0;
                        while (totalBytesRead < messageLength)
                        {
                            int read = stream.Read(buffer, totalBytesRead, messageLength - totalBytesRead);
                            if (read == 0) break;
                            totalBytesRead += read;
                        }

                        if (totalBytesRead < messageLength) break;

                        // Deserialize message
                        ChatMessage message = JsonSerializer.Deserialize<ChatMessage>(buffer);

                        if (message != null)
                        {
                            // Handle different message types
                            switch (message.Type)
                            {
                                case "JOIN":
                                    username = message.SenderName;
                                    lock (lockObject)
                                    {
                                        if (!clients.ContainsKey(username))
                                        {
                                            clients.Add(username, client);
                                            Log($"{username} joined the chat");
                                            BroadcastMessage(message);
                                            SendUserList();
                                        }
                                    }
                                    break;

                                case "PUBLIC":
                                    Log($"[PUBLIC] {username}: {message.Content}");
                                    BroadcastMessage(message);
                                    break;

                                case "PRIVATE":
                                    Log($"[PRIVATE] {username} -> {message.ReceiverName}: {message.Content}");
                                    SendPrivateMessage(message);
                                    break;

                                case "FILE":
                                case "IMAGE":
                                    Log($"[{message.Type}] {username} sent {message.FileName}");
                                    if (string.IsNullOrEmpty(message.ReceiverName))
                                    {
                                        BroadcastMessage(message);
                                    }
                                    else
                                    {
                                        SendPrivateMessage(message);
                                    }
                                    break;
                            }
                        }
                    }

                    Thread.Sleep(10);
                }
            }
            catch (Exception ex)
            {
                Log($"Client error: {ex.Message}");
            }
            finally
            {
                // Client disconnected
                if (username != null)
                {
                    lock (lockObject)
                    {
                        if (clients.ContainsKey(username))
                        {
                            clients.Remove(username);
                            Log($"{username} left the chat");

                            // Broadcast leave message
                            ChatMessage leaveMsg = new ChatMessage
                            {
                                Type = "LEAVE",
                                SenderName = username,
                                Content = $"{username} left the chat"
                            };
                            BroadcastMessage(leaveMsg);
                            SendUserList();
                        }
                    }
                }

                client?.Close();
            }
        }

        private void BroadcastMessage(ChatMessage message)
        {
            byte[] data = JsonSerializer.SerializeToUtf8Bytes(message);
            byte[] lengthPrefix = BitConverter.GetBytes(data.Length);

            lock (lockObject)
            {
                List<string> disconnectedUsers = new List<string>();

                foreach (var kvp in clients)
                {
                    try
                    {
                        NetworkStream stream = kvp.Value.GetStream();
                        stream.Write(lengthPrefix, 0, 4);
                        stream.Write(data, 0, data.Length);
                        stream.Flush();
                    }
                    catch
                    {
                        disconnectedUsers.Add(kvp.Key);
                    }
                }

                // Remove disconnected clients
                foreach (var username in disconnectedUsers)
                {
                    clients.Remove(username);
                    Log($"{username} disconnected (error)");
                }
            }
        }

        private void SendPrivateMessage(ChatMessage message)
        {
            byte[] data = JsonSerializer.SerializeToUtf8Bytes(message);
            byte[] lengthPrefix = BitConverter.GetBytes(data.Length);

            lock (lockObject)
            {
                // Send to receiver
                if (clients.TryGetValue(message.ReceiverName, out TcpClient receiverClient))
                {
                    try
                    {
                        NetworkStream stream = receiverClient.GetStream();
                        stream.Write(lengthPrefix, 0, 4);
                        stream.Write(data, 0, data.Length);
                        stream.Flush();
                    }
                    catch
                    {
                        Log($"Failed to send private message to {message.ReceiverName}");
                    }
                }

                // Send confirmation back to sender
                if (clients.TryGetValue(message.SenderName, out TcpClient senderClient))
                {
                    try
                    {
                        NetworkStream stream = senderClient.GetStream();
                        stream.Write(lengthPrefix, 0, 4);
                        stream.Write(data, 0, data.Length);
                        stream.Flush();
                    }
                    catch
                    {
                        Log($"Failed to send confirmation to {message.SenderName}");
                    }
                }
            }
        }

        private void SendUserList()
        {
            lock (lockObject)
            {
                ChatMessage userListMsg = new ChatMessage
                {
                    Type = "USER_LIST",
                    UserList = clients.Keys.ToArray()
                };

                BroadcastMessage(userListMsg);
            }
        }

        public int GetOnlineCount()
        {
            lock (lockObject)
            {
                return clients.Count;
            }
        }

        private void Log(string message)
        {
            string logMessage = $"[{DateTime.Now:HH:mm:ss}] {message}";
            OnLogMessage?.Invoke(logMessage);
        }
    }
}

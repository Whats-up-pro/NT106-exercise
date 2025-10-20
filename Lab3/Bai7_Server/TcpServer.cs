using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Bai7_Server.Database;
using Bai7_Server.Models;
using System.Text.Json;

namespace Bai7_Server
{
    public class TcpServer
    {
        private TcpListener listener;
        private DatabaseHelper dbHelper;
        private bool isRunning;
        private List<TcpClient> clients;
        private object lockObject = new();

        public event Action<string> OnLogMessage;

        public TcpServer(int port)
        {
            listener = new TcpListener(IPAddress.Any, port);
            dbHelper = new DatabaseHelper();
            clients = new List<TcpClient>();
        }

        public void Start()
        {
            isRunning = true;
            listener.Start();
            Log($"Server started on port {((IPEndPoint)listener.LocalEndpoint).Port}");

            Thread acceptThread = new Thread(AcceptClients);
            acceptThread.IsBackground = true;
            acceptThread.Start();
        }

        public void Stop()
        {
            isRunning = false;
            
            lock (lockObject)
            {
                foreach (var client in clients)
                {
                    client?.Close();
                }
                clients.Clear();
            }

            listener?.Stop();
            Log("Server stopped");
        }

        private void AcceptClients()
        {
            while (isRunning)
            {
                try
                {
                    TcpClient client = listener.AcceptTcpClient();
                    
                    lock (lockObject)
                    {
                        clients.Add(client);
                    }

                    Log($"New client connected: {((IPEndPoint)client.Client.RemoteEndPoint).Address}");

                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
                catch (Exception ex)
                {
                    if (isRunning)
                        Log($"Error accepting client: {ex.Message}");
                }
            }
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = null;

            try
            {
                stream = client.GetStream();

                while (isRunning && client.Connected)
                {
                    if (stream.DataAvailable)
                    {
                        // Read the length prefix
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

                        // Read the message data
                        byte[] buffer = new byte[messageLength];
                        int totalBytesRead = 0;
                        while (totalBytesRead < messageLength)
                        {
                            int read = stream.Read(buffer, totalBytesRead, messageLength - totalBytesRead);
                            if (read == 0) break;
                            totalBytesRead += read;
                        }

                        // Deserialize request
                        Message request = JsonSerializer.Deserialize<Message>(buffer);

                        Message response = ProcessRequest(request, buffer);

                        // Serialize response
                        byte[] responseData = JsonSerializer.SerializeToUtf8Bytes(response);

                        // Write length prefix and response data
                        byte[] responseLength = BitConverter.GetBytes(responseData.Length);
                        stream.Write(responseLength, 0, 4);
                        stream.Write(responseData, 0, responseData.Length);

                        Log($"Processed request: {request.Action}");
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
                lock (lockObject)
                {
                    clients.Remove(client);
                }
                client?.Close();
                Log("Client disconnected");
            }
        }

        private Message ProcessRequest(Message request, byte[] rawData)
        {
            Message response = new Message();
            response.Action = request.Action;

            try
            {
                switch (request.Action)
                {
                    case "GET_ALL_MONAN":
                        response.Data = dbHelper.GetAllMonAn();
                        break;

                    case "GET_MY_MONAN":
                        response.Data = dbHelper.GetMonAnByUser(request.UserID);
                        break;

                    case "ADD_MONAN":
                        // Deserialize lại để lấy đúng type MonAn
                        var addMonAnRequest = JsonSerializer.Deserialize<MessageWithMonAn>(rawData);
                        dbHelper.AddMonAn(addMonAnRequest.Data);
                        response.Data = "Thêm món ăn thành công!";
                        break;

                    case "GET_NGUOIDUNG":
                        response.Data = dbHelper.GetNguoiDungById(request.UserID);
                        break;

                    case "GET_ALL_NGUOIDUNG":
                        response.Data = dbHelper.GetAllNguoiDung();
                        break;

                    case "ADD_NGUOIDUNG":
                        // Deserialize lại để lấy đúng type NguoiDung
                        var addNguoiDungRequest = JsonSerializer.Deserialize<MessageWithNguoiDung>(rawData);
                        int newId = dbHelper.AddNguoiDung(addNguoiDungRequest.Data);
                        response.Data = newId;
                        break;

                    default:
                        response.Success = false;
                        response.ErrorMessage = "Unknown action";
                        break;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                Log($"Error processing request: {ex.Message}");
            }

            return response;
        }

        // Helper classes để deserialize đúng type
        private class MessageWithMonAn
        {
            public string Action { get; set; }
            public MonAn Data { get; set; }
            public int UserID { get; set; }
        }

        private class MessageWithNguoiDung
        {
            public string Action { get; set; }
            public NguoiDung Data { get; set; }
            public int UserID { get; set; }
        }

        private void Log(string message)
        {
            string logMessage = $"[{DateTime.Now:HH:mm:ss}] {message}";
            OnLogMessage?.Invoke(logMessage);
        }
    }
}

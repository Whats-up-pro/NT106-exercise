using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text.Json;
using Bai7_Client.Models;

namespace Bai7_Client.Network
{
    public class TcpClientHelper
    {
        private TcpClient client;
        private NetworkStream stream;
        private string serverIP;
        private int serverPort;

        public bool IsConnected => client != null && client.Connected;

        public TcpClientHelper(string ip, int port)
        {
            serverIP = ip;
            serverPort = port;
        }

        public bool Connect()
        {
            try
            {
                client = new TcpClient();
                client.Connect(serverIP, serverPort);
                stream = client.GetStream();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Disconnect()
        {
            stream?.Close();
            client?.Close();
        }

        public List<MonAn> GetAllMonAn()
        {
            Message request = new Message { Action = "GET_ALL_MONAN" };
            byte[] responseData = SendRequestRaw(request);

            if (responseData != null)
            {
                var response = JsonSerializer.Deserialize<MessageWithListMonAn>(responseData);
                if (response != null && response.Success)
                {
                    return response.Data ?? new List<MonAn>();
                }
            }

            return new List<MonAn>();
        }

        public List<MonAn> GetMyMonAn(int userId)
        {
            Message request = new Message 
            { 
                Action = "GET_MY_MONAN",
                UserID = userId
            };
            byte[] responseData = SendRequestRaw(request);

            if (responseData != null)
            {
                var response = JsonSerializer.Deserialize<MessageWithListMonAn>(responseData);
                if (response != null && response.Success)
                {
                    return response.Data ?? new List<MonAn>();
                }
            }

            return new List<MonAn>();
        }

        public bool AddMonAn(MonAn monAn)
        {
            Message request = new Message 
            { 
                Action = "ADD_MONAN",
                Data = monAn
            };
            Message response = SendRequest(request);

            return response != null && response.Success;
        }

        public NguoiDung GetNguoiDung(int userId)
        {
            Message request = new Message 
            { 
                Action = "GET_NGUOIDUNG",
                UserID = userId
            };
            byte[] responseData = SendRequestRaw(request);

            if (responseData != null)
            {
                var response = JsonSerializer.Deserialize<MessageWithNguoiDung>(responseData);
                if (response != null && response.Success)
                {
                    return response.Data;
                }
            }

            return null;
        }

        public List<NguoiDung> GetAllNguoiDung()
        {
            Message request = new Message { Action = "GET_ALL_NGUOIDUNG" };
            byte[] responseData = SendRequestRaw(request);

            if (responseData != null)
            {
                var response = JsonSerializer.Deserialize<MessageWithListNguoiDung>(responseData);
                if (response != null && response.Success)
                {
                    return response.Data ?? new List<NguoiDung>();
                }
            }

            return new List<NguoiDung>();
        }

        public int AddNguoiDung(NguoiDung nguoiDung)
        {
            Message request = new Message 
            { 
                Action = "ADD_NGUOIDUNG",
                Data = nguoiDung
            };
            byte[] responseData = SendRequestRaw(request);

            if (responseData != null)
            {
                var response = JsonSerializer.Deserialize<MessageWithInt>(responseData);
                if (response != null && response.Success)
                {
                    return response.Data;
                }
            }

            return -1;
        }

        private Message SendRequest(Message request)
        {
            byte[] responseData = SendRequestRaw(request);
            if (responseData != null)
            {
                return JsonSerializer.Deserialize<Message>(responseData);
            }
            return null;
        }

        private byte[] SendRequestRaw(Message request)
        {
            try
            {
                if (!IsConnected)
                {
                    if (!Connect())
                        return null;
                }

                byte[] requestData = JsonSerializer.SerializeToUtf8Bytes(request);
                byte[] lengthPrefix = BitConverter.GetBytes(requestData.Length);
                stream.Write(lengthPrefix, 0, 4);
                stream.Write(requestData, 0, requestData.Length);
                stream.Flush();

                byte[] responseLengthBuffer = new byte[4];
                int bytesRead = 0;
                while (bytesRead < 4)
                {
                    int read = stream.Read(responseLengthBuffer, bytesRead, 4 - bytesRead);
                    if (read == 0) return null;
                    bytesRead += read;
                }
                int responseLength = BitConverter.ToInt32(responseLengthBuffer, 0);

                byte[] responseBuffer = new byte[responseLength];
                bytesRead = 0;
                while (bytesRead < responseLength)
                {
                    int read = stream.Read(responseBuffer, bytesRead, responseLength - bytesRead);
                    if (read == 0) return null;
                    bytesRead += read;
                }

                return responseBuffer;
            }
            catch
            {
                return null;
            }
        }

        private class MessageWithListMonAn
        {
            public string Action { get; set; }
            public List<MonAn> Data { get; set; }
            public bool Success { get; set; }
            public string ErrorMessage { get; set; }
        }

        private class MessageWithListNguoiDung
        {
            public string Action { get; set; }
            public List<NguoiDung> Data { get; set; }
            public bool Success { get; set; }
            public string ErrorMessage { get; set; }
        }

        private class MessageWithNguoiDung
        {
            public string Action { get; set; }
            public NguoiDung Data { get; set; }
            public bool Success { get; set; }
            public string ErrorMessage { get; set; }
        }

        private class MessageWithInt
        {
            public string Action { get; set; }
            public int Data { get; set; }
            public bool Success { get; set; }
            public string ErrorMessage { get; set; }
        }
    }
}

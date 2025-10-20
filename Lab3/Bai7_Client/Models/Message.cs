using System;

namespace Bai7_Client.Models
{
    [Serializable]
    public class Message
    {
        public string Action { get; set; }
        public object Data { get; set; }
        public int UserID { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        public Message()
        {
            Success = true;
        }
    }
}

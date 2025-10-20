using System;

namespace Bai7_Server.Models
{
    [Serializable]
    public class Message
    {
        public string Action { get; set; }  // GET_ALL, ADD_MONAN, RANDOM, GET_MY_MONAN, RANDOM_MY
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

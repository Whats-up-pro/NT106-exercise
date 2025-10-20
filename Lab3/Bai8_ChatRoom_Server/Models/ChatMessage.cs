using System;

namespace Bai8_ChatRoom_Server.Models
{
    [Serializable]
    public class ChatMessage
    {
        public string Type { get; set; }  // JOIN, LEAVE, PUBLIC, PRIVATE, FILE, IMAGE, USER_LIST
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }  // Null nếu là tin nhắn public
        public string Content { get; set; }
        public byte[] FileData { get; set; }  // Dữ liệu file/hình ảnh
        public string FileName { get; set; }
        public DateTime Timestamp { get; set; }
        public string[] UserList { get; set; }  // Danh sách user online

        public ChatMessage()
        {
            Timestamp = DateTime.Now;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Lab02
{
    [Serializable]
    public class NetworkMessage
    {
        public MessageType Type { get; set; }
        public string Data { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }

    public enum MessageType
    {
        Connect,
        GetMovies,
        BookTicket,
        RefreshData,
        Disconnect
    }

    [Serializable]
    public class BookingRequest
    {
        public string TenPhim { get; set; }
        public int SoLuongVe { get; set; }
        public string ClientName { get; set; }
    }

    [Serializable]
    public class MovieData
    {
        public string TenPhim { get; set; }
        public double GiaVeChuan { get; set; }
        public string PhongChieu { get; set; }
        public int SoLuongVeBan { get; set; }
        public int SoLuongVeTon { get; set; }
        public double DoanhThu { get; set; }
        public string TiLeBan { get; set; }
    }
}

using System.Collections.Generic;

namespace Lab02
{
    public class Phim
    {
        public string TenPhim { get; set; }
        public double GiaVeChuan { get; set; }
        public List<int> PhongChieu { get; set; }
        public int SoLuongVeBan { get; set; }
        public int SoLuongVeTon { get; set; }

        public double DoanhThu => SoLuongVeBan * GiaVeChuan;
        public double TiLeBan => (SoLuongVeBan + SoLuongVeTon) == 0 ? 0 : (double)SoLuongVeBan / (SoLuongVeBan + SoLuongVeTon);
    }
}

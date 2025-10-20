using System;

namespace Bai6_HomNayAnGi_SQLite.Models
{
    public class NguoiDung
    {
        public int IDNCC { get; set; }
        public string HoVaTen { get; set; }
        public string QuyenHan { get; set; }

        public NguoiDung()
        {
        }

        public NguoiDung(int idncc, string hoVaTen, string quyenHan)
        {
            IDNCC = idncc;
            HoVaTen = hoVaTen;
            QuyenHan = quyenHan;
        }

        public override string ToString()
        {
            return $"{HoVaTen} ({QuyenHan})";
        }
    }
}

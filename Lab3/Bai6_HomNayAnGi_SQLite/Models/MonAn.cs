using System;

namespace Bai6_HomNayAnGi_SQLite.Models
{
    public class MonAn
    {
        public int IDMA { get; set; }
        public string TenMonAn { get; set; }
        public string HinhAnh { get; set; }
        public int IDNCC { get; set; }

        public MonAn()
        {
        }

        public MonAn(int idma, string tenMonAn, string hinhAnh, int idncc)
        {
            IDMA = idma;
            TenMonAn = tenMonAn;
            HinhAnh = hinhAnh;
            IDNCC = idncc;
        }

        public override string ToString()
        {
            return $"[{IDMA}] {TenMonAn}";
        }
    }
}

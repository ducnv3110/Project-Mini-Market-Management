using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyBachHoa
{
    public class DTO_PrintBarcode
    {
        public string Barcode { get; set; }
        public string  TenHH { get; set; }
        public float DonGia { get; set; }
        public int? SoTem { get; set; }

        public DTO_PrintBarcode() { }

        public DTO_PrintBarcode(string barcode, string tenhh, float dongia, int sotem)
        {
            this.Barcode = barcode;
            this.TenHH = tenhh;
            this.DonGia = dongia;
            this.SoTem = sotem;
        }
    }
}

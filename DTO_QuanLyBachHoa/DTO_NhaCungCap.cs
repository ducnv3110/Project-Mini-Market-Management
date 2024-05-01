using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyBachHoa
{
    public class DTO_NhaCungCap
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }

        public DTO_NhaCungCap()
        {

        }

        public DTO_NhaCungCap(string mancc, string tenncc, string diachi)
        {
            this.MaNCC = mancc;
            this.TenNCC = tenncc;
            this.DiaChi = diachi;
        }
    }
}

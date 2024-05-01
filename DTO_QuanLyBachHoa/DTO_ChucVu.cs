using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyBachHoa
{
    public class DTO_ChucVu
    {
        public string MaCV { get; set; }
        public string TenCV { get; set; }

        public DTO_ChucVu()
        {

        }

        public DTO_ChucVu(string macv, string tencv)
        {
            this.MaCV = macv;
            this.TenCV = tencv;
        }
    }
}

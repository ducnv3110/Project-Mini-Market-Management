using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyBachHoa
{
    public class DTO_TaiKhoan : DTO_NhanVien
    {
        public string ID { get; set; }

        public string Password { get; set; }

        
        public DTO_TaiKhoan()
        {

        }

        public DTO_TaiKhoan(string id, string mk, string manv)
        {
            this.ID = id;
            this.Password = mk;
            this.MaNV = manv;
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DTO_QuanLyBachHoa;
using BUS_QuanLyBachHoa;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;


namespace GUI_QuanLyBachHoa
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        #region Bo tròn viền form
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
               (
                   int nLeftRect,
                   int nTopRect,
                   int nRightRect,
                   int nBottomRect,
                   int nWith,
                   int nHeight
               );
        #endregion

        public delegate void AfterLogin(User user);
        public AfterLogin lg = null;
        public frmLogin()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
        #region Sự kiện cho nút đăng nhập
        public void DangNhap()
        {

            if (txtTenDangNhap.Text == "")
            {
                XtraMessageBox.Show("Bạn chưa nhập tên đăng nhập", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }
            if (txtMatKhau.Text == "")
            {
                XtraMessageBox.Show("Bạn chưa nhập mật khẩu", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }
            DangNhapModel dangnhapModel = new DangNhapModel();
            User currentUser = dangnhapModel.DangNhap(txtTenDangNhap.Text.Trim(), txtMatKhau.Text.Trim());

            if (currentUser == null)
            {
                XtraMessageBox.Show("Sai tên tài khoản hoặc mật khẩu.\nVui lòng thử lại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lg(currentUser);
            this.Dispose();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }
        #endregion


        private void txtTenDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DangNhap();
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DangNhap();
        }
        private void showPass_MouseUp(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void showPass_MouseDown(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
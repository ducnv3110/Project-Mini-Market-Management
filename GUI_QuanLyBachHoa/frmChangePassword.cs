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
using BUS_QuanLyBachHoa;
using BUS_QuanLyBachHoa.Functions;

namespace GUI_QuanLyBachHoa
{
    public partial class frmChangePassword : DevExpress.XtraEditors.XtraForm
    {
        private DoiMatKhauModel model = new DoiMatKhauModel();
        public frmChangePassword()
        {
            InitializeComponent();
            txtMatKhauCu.UseSystemPasswordChar = true;
            txtMatKhauMoi.UseSystemPasswordChar = true;
            txtNhapLaiMatKhau.UseSystemPasswordChar = true;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void showPassMKcu_MouseUp(object sender, MouseEventArgs e)
        {
            txtMatKhauCu.UseSystemPasswordChar = true;
        }

        private void showPassMKcu_MouseDown(object sender, MouseEventArgs e)
        {
            txtMatKhauCu.UseSystemPasswordChar = false;
        }

        private void showPassMKmoi_MouseDown(object sender, MouseEventArgs e)
        {
            txtMatKhauMoi.UseSystemPasswordChar = false;
        }

        private void showPassMKmoi_MouseUp(object sender, MouseEventArgs e)
        {
            txtMatKhauMoi.UseSystemPasswordChar = true;
        }

        private void showPassNhapLai_MouseDown(object sender, MouseEventArgs e)
        {
            txtNhapLaiMatKhau.UseSystemPasswordChar = false;
        }

        private void showPassNhapLai_MouseUp(object sender, MouseEventArgs e)
        {
            txtNhapLaiMatKhau.UseSystemPasswordChar = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string mkCu = model.LayMatKhauCu(CurrentUser.ID);

            if (txtMatKhauCu.Text.Trim() == "")
            {
                XtraMessageBox.Show("Vui lòng nhập mật khẩu cũ.","Chú ý",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtMatKhauCu.Focus();
                return;
            }
            if (txtMatKhauMoi.Text.Trim() == "")
            {
                XtraMessageBox.Show("Vui lòng nhập mật khẩu mới.", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Focus();
                return;
            }
            if (!txtMatKhauMoi.Text.Trim().Equals(txtNhapLaiMatKhau.Text.Trim()))
            {
                XtraMessageBox.Show("Mật khẩu không giống nhau.", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapLaiMatKhau.Focus();
                return;
            }
            if (!mkCu.Equals(txtMatKhauCu.Text.Trim()))
            {
                XtraMessageBox.Show("Mật khẩu cũ sai.", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhauCu.Focus();
                return;
            }
            if (model.DoiMatKhau(CurrentUser.ID, txtMatKhauMoi.Text.Trim()) < 1)
            {
                XtraMessageBox.Show("Có lỗi, Cập nhật mật khẩu thất bại. Vui lòng thử lại.", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            XtraMessageBox.Show("Cập nhật mật khẩu thành công", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
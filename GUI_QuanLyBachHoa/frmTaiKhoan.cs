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
using BUS_QuanLyBachHoa.Functions;

namespace GUI_QuanLyBachHoa
{
    public partial class frmTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        // khởi tạo bus layer
        BUS_TaiKhoan busAC = new BUS_TaiKhoan();
        BUS_Function func = new BUS_Function();
        // khởi tạo bindingsource
        BindingSource bs = new BindingSource();
        bool them = false;
        public frmTaiKhoan()
        {
            InitializeComponent();


            gvTaiKhoan.OptionsBehavior.Editable = false; // k cho sửa dữ liệu trực tiếp trên gridview
            func.FillCombo("tblNhanVien", cboMaNV, "TenNV", "MaNV"); // load combobox
        }

        void loadDatabinding()
        {
            gvTaiKhoan.BeginUpdate();
            bs.DataSource = busAC.getLogin();
            gvTaiKhoan.EndUpdate();

            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("text", bs, "ID", true);

            txtMK.DataBindings.Clear();
            txtMK.DataBindings.Add("text", bs, "Password", true);

            cboMaNV.DataBindings.Clear();
            cboMaNV.DataBindings.Add("text", bs, "TenNV", true);

            bindingNavigatorChung.BindingSource = bs;
            gcTaiKhoan.DataSource = bs;
            
        }
        void enableButton(bool b)
        {
            btnThem.Enabled = b;
            btnSua.Enabled = b;
            btnXoa.Enabled = b;
            btnLuu.Enabled = !b;
            btnBoQua.Enabled = !b;
            btnTim.Enabled = b;
            txtTim.Enabled = b;
        }
        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            bs.EndEdit(); //reset bindingsource
            enableButton(true);
            txtID.Enabled = false;
            loadDatabinding();
        }

        #region Các chức năng nút
        public void btThem()
        {
            bs.AddNew();
            them = true;

            txtID.Focus();
            enableButton(false);
        }
        void btSua()
        {
            txtMK.Focus();
            enableButton(false);
        }


        #endregion

        private void btnThem_Click(object sender, EventArgs e)
        {
            btThem();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btSua();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xoá dòng này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (busAC.xoaLogin(txtID.Text) != 0)
                {
                    XtraMessageBox.Show("Xoá dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Xoá dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            frmTaiKhoan_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!KiemTraID() || !KiemTraPassword() || !KiemTraMaNV() )
            {
                return;
            }

            DTO_TaiKhoan lg = new DTO_TaiKhoan(txtID.Text, txtMK.Text, cboMaNV.SelectedValue.ToString());
            if (them == true) // tiến hành lưu thông tin tài khoản khi thêm mới
            {
                if (busAC.themLogin(lg) != 0)
                {
                    XtraMessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Thêm dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                them = false;
            }
            else // tiến hành lưu thông tin tài khoản khi sửa
            {
                if (busAC.suaLogin(lg) != 0)
                {
                    XtraMessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Cập nhật dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            frmTaiKhoan_Load(sender, e);
        }
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();//reset bindingsource
            them = false;
            frmTaiKhoan_Load(sender, e);
        }
        void loadDatatim()
        {
            gvTaiKhoan.BeginUpdate();
            bs.DataSource = busAC.timLogin(txtTim.Text);
            gvTaiKhoan.EndUpdate();

            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("text", bs, "ID", true);

            txtMK.DataBindings.Clear();
            txtMK.DataBindings.Add("text", bs, "Password", true);

            cboMaNV.DataBindings.Clear();
            cboMaNV.DataBindings.Add("text", bs, "TenNV", true);

            bindingNavigatorChung.BindingSource = bs;
            gcTaiKhoan.DataSource = bs;
            
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            loadDatatim();
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            loadDatatim();
        }
        #region Kiểm tra dữ liệu
        private bool KiemTraRong(Control ct, string message)
        {
            if (ct.Text.Trim() == "")
            {
                ct.Focus();
                XtraMessageBox.Show(message, "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            return false;
        }

        private bool KiemTraID()
        {
            if (KiemTraRong(txtID, "Tên tài khoản không được để trống"))
            {
                return false;
            }
            return true;
        }

        private bool KiemTraPassword()
        {
            if (KiemTraRong(txtMK, "Mật khẩu không được để trống"))
            {
                return false;
            }
            return true;
        }

        private bool KiemTraMaNV()
        {
            if (KiemTraRong(cboMaNV, "Mã nhân viên không được để trống"))
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
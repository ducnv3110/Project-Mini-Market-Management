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
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace GUI_QuanLyBachHoa
{
    public partial class frmKhachHang : DevExpress.XtraEditors.XtraForm
    {
        BUS_KhachHang busKH = new BUS_KhachHang();// khởi tạo BUS layer
        BindingSource bs = new BindingSource();// khởi tạo bindingsource
        BUS_Function func = new BUS_Function();
        bool them = false;
        public frmKhachHang()
        {
            InitializeComponent();

            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // khi click trên datagridview thì xanh cả hàng đó

        }

        

        void loadDatabinding()
        {
            
            bs.DataSource = busKH.getKhachHang();

            txtMaKH.DataBindings.Clear();
            txtMaKH.DataBindings.Add("text", bs, "MaKH", true);

            txtTenKH.DataBindings.Clear();
            txtTenKH.DataBindings.Add("text", bs, "TenKH", true);

            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("text", bs, "SDT", true);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("text", bs, "DiaChi", true);

            bindingNavigatorChung.BindingSource = bs;
            dgvKhachHang.DataSource = bs;
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
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            enableButton(true);
            txtMaKH.Enabled = false;
            loadDatabinding();
        }
        #region Các chức năng nút
        public void btThem()
        {
            bs.AddNew();
            them = true;
            
            txtTenKH.Focus();
            enableButton(false);
        }
        void btSua()
        {
            txtTenKH.Focus();
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
                if (busKH.xoaKhachHang(txtMaKH.Text) != 0)
                {
                    XtraMessageBox.Show("Xoá dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Xoá dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            frmKhachHang_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!KiemTraTenKH() || !KiemTraSDT() || !KiemTraDiaChi() )
            {
                return;
            }

            DTO_KhachHang kh = new DTO_KhachHang(txtMaKH.Text, txtTenKH.Text, txtSDT.Text, txtDiaChi.Text);
            if (them) // tiến hành lưu thông tin khách hàng
            {
                if (busKH.themKhachHang(kh) != 0)
                {
                    XtraMessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Thêm dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                them = false;
            }
            else // tiến hành khi sửa các thông tin khách hàng
            {
                if (busKH.suaKhachHang(kh) != 0)
                {
                    XtraMessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Cập nhật dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            frmKhachHang_Load(sender, e);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
            them = false;
            frmKhachHang_Load(sender, e);
        }
        #region Xử lý chức năng tìm
        void loadDatatim()
        {
            bs.DataSource = busKH.timKhachHang(txtTim.Text);

            txtMaKH.DataBindings.Clear();
            txtMaKH.DataBindings.Add("text", bs, "MaKH", true);

            txtTenKH.DataBindings.Clear();
            txtTenKH.DataBindings.Add("text", bs, "TenKH", true);

            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("text", bs, "SDT", true);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("text", bs, "DiaChi", true);

            bindingNavigatorChung.BindingSource = bs;
            dgvKhachHang.DataSource = bs;
        }
        #endregion


        private void btnTim_Click(object sender, EventArgs e)
        {
            loadDatatim();
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if (txtTim.Text == "")
            {
                loadDatabinding();
                return;
            }
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

        private bool KiemTraTenKH()
        {
            if (KiemTraRong(txtTenKH, "Tên khách hàng không được để trống"))
            {
                return false;
            }
            return true;
        }

        private bool KiemTraSDT()
        {
            if (KiemTraRong(txtSDT, "Số điện thoại không được để trống"))
            {
                return false;
            }
            if (!func.Check(BUS_Function.ValidateType.PHONENUMBER, txtSDT.Text.Trim()))
            {
                XtraMessageBox.Show("Số điện thoại không hợp lệ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return false;
            }

            
             return true;
        }

        private bool KiemTraDiaChi()
        {
            if (KiemTraRong(txtDiaChi, "Địa chỉ không được để trống"))
            {
                return false;
            }
            return true;
        }




        #endregion

        private void dgvKhachHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

       
    }
}
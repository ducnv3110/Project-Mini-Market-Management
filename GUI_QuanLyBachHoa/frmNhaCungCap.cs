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
    public partial class frmNhaCungCap : DevExpress.XtraEditors.XtraForm
    {
        BUS_NhaCungCap busNhaCC = new BUS_NhaCungCap(); // khởi tạo bus layer
        BindingSource bs = new BindingSource();// khởi tạo bindingsource
        bool them = false;
        public frmNhaCungCap()
        {
            InitializeComponent();
            gvNhaCungCap.OptionsBehavior.Editable = false;// k cho sửa dữ liệu trực tiếp trên gridview
        }

        void loadDatabinding()
        {
            gvNhaCungCap.BeginUpdate();
            bs.DataSource = busNhaCC.getNhaCungCap();
            gvNhaCungCap.EndUpdate();

            txtMaNhaCC.DataBindings.Clear();
            txtMaNhaCC.DataBindings.Add("text", bs, "MaNCC", true);

            txtTenNhaCC.DataBindings.Clear();
            txtTenNhaCC.DataBindings.Add("text", bs, "TenNCC", true);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("text", bs, "DiaChi", true);

            bindingNavigatorChung.BindingSource = bs;
            gcNhaCungCap.DataSource = bs;
            
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
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            bs.EndEdit();// reset bingdingsource
            enableButton(true);
            txtMaNhaCC.Enabled = false;
            loadDatabinding();
        }

        #region Các chức năng nút
        public void btThem()
        {
            bs.AddNew();
            them = true;
            txtMaNhaCC.Enabled = true;
            txtMaNhaCC.Focus();
            enableButton(false);
        }
        void btSua()
        {
            txtTenNhaCC.Focus();
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
                if (busNhaCC.xoaNhaCungCap(txtMaNhaCC.Text) != 0)
                {
                    XtraMessageBox.Show("Xoá dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Xoá dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            frmNhaCungCap_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!KiemTraMaNhaCC() || !KiemTraTenNhaCC())
            {
                return;
            }

            DTO_NhaCungCap ncc = new DTO_NhaCungCap(txtMaNhaCC.Text,txtTenNhaCC.Text,txtDiaChi.Text);

            if (!busNhaCC.kiemTraTrungMa(txtMaNhaCC.Text))
            {
                txtMaNhaCC.Focus();
                return;
            }

            if (them == true) // tiến hành lưu thông tin nhà cung cấp khi thêm mới
            {
                if (busNhaCC.themNhaCungCap(ncc) != 0)
                {
                    XtraMessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Thêm dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                them = false;
            }
            else // tiến hàng sửa các thông tin nhà cung cấp
            {
                if (busNhaCC.suaNhaCungCap(ncc) != 0)
                {
                    XtraMessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Cập nhật dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            frmNhaCungCap_Load(sender, e);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            them = false;
            bs.CancelEdit();// reset bindingsource
            frmNhaCungCap_Load(sender, e);
        }
        #region Xử lý chức năng tìm
        void loadDatatim()
        {
            gvNhaCungCap.BeginUpdate();
            bs.DataSource = busNhaCC.timNhaCungCap(txtTim.Text);
            gvNhaCungCap.EndUpdate();

            txtMaNhaCC.DataBindings.Clear();
            txtMaNhaCC.DataBindings.Add("text", bs, "MaNCC", true);

            txtTenNhaCC.DataBindings.Clear();
            txtTenNhaCC.DataBindings.Add("text", bs, "TenNCC", true);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("text", bs, "DiaChi", true);

            bindingNavigatorChung.BindingSource = bs;
            gcNhaCungCap.DataSource = bs;
            
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

        private bool KiemTraMaNhaCC()
        {
            if (KiemTraRong(txtMaNhaCC, "Mã nhà cung cấp không được để trống"))
            {
                return false;
            }
            return true;
        }

        private bool KiemTraTenNhaCC()
        {
            if (KiemTraRong(txtTenNhaCC, "Tên nhà cung cấp không được để trống"))
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
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
using System.Collections.ObjectModel;

namespace GUI_QuanLyBachHoa
{
    public partial class frmChucVu : DevExpress.XtraEditors.XtraForm
    {
        BUS_ChucVu busCV = new BUS_ChucVu();// khởi tạo bus layer
        BindingSource bs = new BindingSource();// khởi tạo bindingsource
        bool them = false;
        public ObservableCollection<DTO_ChucVu> _List = new ObservableCollection<DTO_ChucVu>();
        public frmChucVu()
        {
            InitializeComponent();
            gvChucVu.OptionsBehavior.Editable = false;// k cho sửa dữ liệu trực tiếp trên gridview
        }
        void loadDatabinding()
        {
            gvChucVu.BeginUpdate();
            bs.DataSource = busCV.getChucVu();
            gvChucVu.EndUpdate();

            txtMaCV.DataBindings.Clear();
            txtMaCV.DataBindings.Add("text", bs, "MaCV", true);

            txtTenCV.DataBindings.Clear();
            txtTenCV.DataBindings.Add("text", bs, "TenCV", true);


            bindingNavigatorChung.BindingSource = bs;
            gcChucVu.DataSource = bs;

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
        private void frmChucVu_Load(object sender, EventArgs e)
        {
            bs.EndEdit();// reset bindingsource
            enableButton(true);
            txtMaCV.Enabled = false;
            loadDatabinding();
            GetAllData();
        }

        #region Các chức năng nút
        public void btThem()
        {
            bs.AddNew();
            them = true;
            txtMaCV.Enabled = true;
            txtMaCV.Focus();
            enableButton(false);
        }
        void btSua()
        {
            txtTenCV.Focus();
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
                if (busCV.xoaChucVu(txtMaCV.Text) != 0)
                {
                    XtraMessageBox.Show("Xoá dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Xoá dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }     
            }

            frmChucVu_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!KiemTraMaCV() || !KiemTraTenCV())
            {
                return;
            }

            DTO_ChucVu cv = new DTO_ChucVu(txtMaCV.Text.ToString(), txtTenCV.Text.ToString());

            if (!busCV.kiemTraTrungMa(txtMaCV.Text))
            {
                txtMaCV.Focus();
                return;
            }

            if (them) // tiến hành lưu thông tin chức vụ khi thêm mới
            {
                if (busCV.themChucVu(cv) != 0)
                {
                    XtraMessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Thêm dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                them = false;
            }
            else // tiến hành lưu thông tin chức vụ khi sửa
            {
                if (busCV.suaChucVu(cv) != 0)
                {
                    XtraMessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Cập nhật dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            frmChucVu_Load(sender, e);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            them = false;
            bs.CancelEdit();//reset bindingsource
            frmChucVu_Load(sender, e);
        }
        #region Xử lý chức năng tìm
        void loadDatatim()
        {
            gvChucVu.BeginUpdate();
            bs.DataSource = busCV.timChucVu(txtTim.Text);
            gvChucVu.EndUpdate();

            txtMaCV.DataBindings.Clear();
            txtMaCV.DataBindings.Add("text", bs, "MaCV", true);

            txtTenCV.DataBindings.Clear();
            txtTenCV.DataBindings.Add("text", bs, "TenCV", true);

            bindingNavigatorChung.BindingSource = bs;
            gcChucVu.DataSource = bs;
            
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
                XtraMessageBox.Show(message,"Chú ý",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return true;
            }

            return false;
        }

        private bool KiemTraMaCV()
        {
            if (KiemTraRong(txtMaCV, "Mã chức vụ không được để trống"))
            {
                return false;
            }
            return true;
        }

        private bool KiemTraTenCV()
        {
            if (KiemTraRong(txtTenCV, "Tên chức vụ không được để trống"))
            {
                return false;
            }
            return true;
        }
        #endregion

        public void GetAllData()
        {
            _List = busCV.GetAllDataChucVu();
        }
    }
}
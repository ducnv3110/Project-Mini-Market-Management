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
    public partial class frmLoaiHang : DevExpress.XtraEditors.XtraForm
    {
        BUS_LoaiHang busLH = new BUS_LoaiHang(); // khởi tạo BUS Layer
        BindingSource bs = new BindingSource();// khởi tạo bindingsource
        bool them = false;
        public frmLoaiHang()
        {
            InitializeComponent();
            gvLoaiHang.OptionsBehavior.Editable = false;// k cho sửa dữ liệu trực tiếp trên gridview
            
        }
        void loadDatabinding()
        {
            gvLoaiHang.BeginUpdate();
            bs.DataSource = busLH.getLoaiHang();
            gvLoaiHang.EndUpdate();

            txtMaLoai.DataBindings.Clear();
            txtMaLoai.DataBindings.Add("Text", bs, "MaLoai", true);

            txtTenLoai.DataBindings.Clear();
            txtTenLoai.DataBindings.Add("Text", bs, "TenLoai", true);

            bindingNavigatorChung.BindingSource = bs;
            gcLoaiHang.DataSource = bs;

            
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
        private void frmLoaiHang_Load(object sender, EventArgs e)
        {
            bs.EndEdit(); // reset bingdingsource
            enableButton(true);
            txtMaLoai.Enabled = false;
            loadDatabinding();
        }
        #region Các chức năng nút
        public void btThem()
        {
            bs.AddNew();
            them = true;
            txtMaLoai.Enabled = true;
            txtMaLoai.Focus();
            enableButton(false);
        }
        void btSua()
        {
            txtTenLoai.Focus();
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
                if (busLH.xoaLoaiHang(txtMaLoai.Text) != 0)
                {
                    XtraMessageBox.Show("Xoá dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmLoaiHang_Load(sender, e);
                    
                }
                else
                {
                    XtraMessageBox.Show("Xoá dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frmLoaiHang_Load(sender, e);
                }
            }
            else
            {
                frmLoaiHang_Load(sender, e);
            }
                
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!KiemTraMaLoai() || !KiemTraTenLoai())
            {
                return;
            }

            DTO_LoaiHang lh = new DTO_LoaiHang(txtMaLoai.Text, txtTenLoai.Text);

            if (them == true) // tiến hành lưu thông tin loại hàng
            {
                if (busLH.themLoaiHang(lh) != 0)
                {
                    XtraMessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Thêm dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                them = false;
            }
            else // tiến hành sửa các thông tin loại hàng
            {
                if (busLH.suaLoaiHang(lh) != 0)
                {
                    XtraMessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Cập nhật dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            frmLoaiHang_Load(sender, e);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            them = false; 
            bs.CancelEdit(); // reset bingdingsource
            frmLoaiHang_Load(sender, e);
        }

        #region Xử lý chức năng tìm
        void loadDatatim()
        {
            gvLoaiHang.BeginUpdate();
            bs.DataSource = busLH.timLoaiHang(txtTim.Text);

            txtMaLoai.DataBindings.Clear();
            txtMaLoai.DataBindings.Add("text", bs, "MaLoai", true);

            txtTenLoai.DataBindings.Clear();
            txtTenLoai.DataBindings.Add("text", bs, "TenLoai", true);

            bindingNavigatorChung.BindingSource = bs;

            gcLoaiHang.DataSource = bs;
            gvLoaiHang.EndUpdate();
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


        private bool KiemTraMaLoai()
        {
            if (KiemTraRong(txtMaLoai, "Mã loại không được để trống"))
            {
                return false;
            }

            return true;
        }

        private bool KiemTraTenLoai()
        {
            if (KiemTraRong(txtTenLoai, "Tên loại không được để trống"))
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
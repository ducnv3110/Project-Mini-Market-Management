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
using System.IO;

namespace GUI_QuanLyBachHoa
{
    public partial class frmHang : DevExpress.XtraEditors.XtraForm
    {
        //khởi tạo bus layer
        BUS_Hang busH = new BUS_Hang();
        BUS_Function func = new BUS_Function();
        //khởi tạo bindingsource
        BindingSource bs = new BindingSource();
        
        bool them = false;
        public string maHang = "";
        public frmHang()
        {
            InitializeComponent();

            func.FillCombo("tblLoaiHang", cboMaLoai, "TenLoai", "MaLoai"); // load combobox

            gvHang.OptionsBehavior.Editable = false; // k cho sửa trực tiếp trên gridview

            txtAnh.Enabled = false;
            txtValue.Enabled = false;

            cboMaLoai.DropDownStyle = ComboBoxStyle.DropDownList; // chỉ cho kéo thả combobox k cho nhập liệu

            //định dạng datetimepicker theo vùng Việt Nam
            dtpNgayHH.Format = DateTimePickerFormat.Custom;
            dtpNgayHH.CustomFormat = "dd/MM/yyyy";

            dtpNgaySX.Format = DateTimePickerFormat.Custom;
            dtpNgaySX.CustomFormat = "dd/MM/yyyy";
        }
        
        void loadDatabinding()
        {
            gvHang.BeginUpdate();
            bs.DataSource = busH.getHang();
            gvHang.EndUpdate();

            txtMaHang.DataBindings.Clear();
            txtMaHang.DataBindings.Add("text", bs, "MaHH", true);

            txtTenHang.DataBindings.Clear();
            txtTenHang.DataBindings.Add("text", bs, "TenHH", true);

            cboMaLoai.DataBindings.Clear();
            cboMaLoai.DataBindings.Add("text", bs, "TenLoai", true);

            txtAnh.DataBindings.Clear();
            txtAnh.DataBindings.Add("text", bs, "HinhMinhHoa", true);

            txtDVT.DataBindings.Clear();
            txtDVT.DataBindings.Add("text", bs, "DVT",true);

            txtSoLT.DataBindings.Clear();
            txtSoLT.DataBindings.Add("text", bs, "SoLuongTon", true);

            txtDonGiaBan.DataBindings.Clear();
            txtDonGiaBan.DataBindings.Add("text", bs, "DonGiaBan", true);

            txtDonGiaNhap.DataBindings.Clear();
            txtDonGiaNhap.DataBindings.Add("text", bs, "DonGiaNhap", true);

            dtpNgayHH.DataBindings.Clear();
            dtpNgayHH.DataBindings.Add("value", bs, "NgayHetHan", true);

            dtpNgaySX.DataBindings.Clear();
            dtpNgaySX.DataBindings.Add("value", bs, "NgaySanXuat", true);

            txtValue.DataBindings.Clear();
            txtValue.DataBindings.Add("text", bs, "Value", true);

            txtBaoQuan.DataBindings.Clear();
            txtBaoQuan.DataBindings.Add("text", bs, "BaoQuan", true);

            txtVAT.DataBindings.Clear();
            txtVAT.DataBindings.Add("text", bs, "VAT", true);

            bindingNavigatorChung.BindingSource = bs;
            gcHang.DataSource = bs;

            if (gcHang.DataSource != null)
            {
                gvHang.Columns[3].Visible = false; // ẩn cột HinhMinhHoa
            }
            
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
        private void frmHang_Load(object sender, EventArgs e)
        {
            bs.EndEdit();
            enableButton(true);
            btnOpen.Enabled = false;
            txtMaHang.Enabled = false;

            loadDatabinding();
        }
        #region Các chức năng nút
        public void btThem()
        {
            bs.AddNew();

            cboMaLoai.SelectedIndex = -1; // xoá trắng combobox

            them = true;
            btnOpen.Enabled = true;

            busH.tangValue("HH"); // tăng giá trị value để tạo mã hàng
            txtValue.Text = busH.getFinalValue().ToString(); // lấy giá trị cuối cùng của mã hàng
            txtMaHang.Text = busH.taoBarcode(); // có giá trị cuối cùng từ đó tạo ra mã vạch

            txtTenHang.Focus();
            txtSoLT.Text = "0";
            enableButton(false);
        }
        void btSua()
        {
            btnOpen.Enabled = true;
            txtTenHang.Focus();
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
                if (busH.xoaHang(txtMaHang.Text) != 0)
                {
                    XtraMessageBox.Show("Xoá dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    busH.giamValue();
                    xoaImage();
                }
                else
                {
                    XtraMessageBox.Show("Xoá dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            frmHang_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {


            if (!KiemTraMaHang() || !KiemTraTenHang() || !KiemTraMaLoai() || !KiemTraDVT() || !KiemTraDonGiaNhap() || !KiemTraDonGiaBan() || !KiemTraHinhMinhHoa() ||
                !KiemTraNgaysx_Ngayhh() || !KiemTraTrungImageinFolder())
            {
                return;
            }


            DTO_Hang h = new DTO_Hang(txtMaHang.Text, txtTenHang.Text, cboMaLoai.SelectedValue.ToString(), txtAnh.Text, txtDVT.Text, int.Parse(txtSoLT.Value.ToString()), 
                 float.Parse(txtDonGiaNhap.Value.ToString()), float.Parse(txtDonGiaBan.Value.ToString()), dtpNgaySX.Value, dtpNgayHH.Value, txtBaoQuan.Text, int.Parse(txtValue.Text), int.Parse(txtVAT.Value.ToString()));
            if (them) // lưu thông tin hàng hoá khi thêm mới
            {
                if (busH.themHang(h) != 0)
                {
                    XtraMessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    saveImage();
                }
                else
                {
                    XtraMessageBox.Show("Thêm dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                them = false;
            }
            else // lưu thông tin hàng hoá khi sửa
            {
                if (busH.suaHang(h) != 0)
                {
                    XtraMessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    saveImage();
                }
                else
                {
                    XtraMessageBox.Show("Cập nhật dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            frmHang_Load(sender, e);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
            if (them)
            {
                busH.giamValue(); // sự kiện bấm thêm là tăng value vậy khi bấm nút bỏ qua khi đã bấm nút thêm là giảm value
            }
            them = false;
            frmHang_Load(sender, e);
        }
        #region Xử lý chức năng tìm
        void loadDatatim()
        {
            gvHang.BeginUpdate();
            bs.DataSource = busH.timHang(txtTim.Text);
            gvHang.EndUpdate();

            txtMaHang.DataBindings.Clear();
            txtMaHang.DataBindings.Add("text", bs, "MaHH", true);

            txtTenHang.DataBindings.Clear();
            txtTenHang.DataBindings.Add("text", bs, "TenHH", true);

            cboMaLoai.DataBindings.Clear();
            cboMaLoai.DataBindings.Add("text", bs, "TenLoai", true);

            txtAnh.DataBindings.Clear();
            txtAnh.DataBindings.Add("text", bs, "HinhMinhHoa", true);

            txtDVT.DataBindings.Clear();
            txtDVT.DataBindings.Add("text", bs, "DVT", true);

            txtSoLT.DataBindings.Clear();
            txtSoLT.DataBindings.Add("text", bs, "SoLuongTon", true);

            txtDonGiaBan.DataBindings.Clear();
            txtDonGiaBan.DataBindings.Add("text", bs, "DonGiaBan", true);

            txtDonGiaNhap.DataBindings.Clear();
            txtDonGiaNhap.DataBindings.Add("text", bs, "DonGiaNhap", true);

            dtpNgayHH.DataBindings.Clear();
            dtpNgayHH.DataBindings.Add("value", bs, "NgayHetHan", true);

            dtpNgaySX.DataBindings.Clear();
            dtpNgaySX.DataBindings.Add("value", bs, "NgaySanXuat", true);

            txtValue.DataBindings.Clear();
            txtValue.DataBindings.Add("text", bs, "Value", true);

            txtBaoQuan.DataBindings.Clear();
            txtBaoQuan.DataBindings.Add("text", bs, "BaoQuan", true);

            bindingNavigatorChung.BindingSource = bs;
            gcHang.DataSource = bs;

            if (gcHang.DataSource != null)
            {
                gvHang.Columns[3].Visible = false; // ẩn cột HinhMinhHoa
            }
            
        }
        #endregion


        private void btnTim_Click(object sender, EventArgs e)
        {
            loadDatatim();
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            loadDatatim();
        }

        private void txtAnh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtAnh.Text == "")
                {
                    picAnh.Image = null;
                }
                else if (txtAnh.Text != "")
                {
                    picAnh.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\Images Hang Hoa\\" + txtAnh.Text.Substring(txtAnh.Text.LastIndexOf("\\") + 1)); // lấy đường dẫn image và hiện image lên picturebox
                }
            }
            catch (Exception)
            { }
 
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog(); 
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*"; // đặt giá trị đuôi file ảnh
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName); // load pic từ file chọn trong ổ đĩa
                txtAnh.Text = dlgOpen.FileName; // lấy đường dẫn file ảnh
            }
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            DataRowView currentRow = (DataRowView)bs.Current;
            maHang = currentRow["MaHH"].ToString();

            this.Close();
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

        private bool KiemTraMaHang()
        {
            if (KiemTraRong(txtMaHang, "Mã hàng không được để trống"))
            {
                return false;
            }
            return true;
        }
        private bool KiemTraTenHang()
        {
            if (KiemTraRong(txtTenHang, "Tên hàng không được để trống"))
            {
                return false;
            }
            return true;
        }

        private bool KiemTraHinhMinhHoa()
        {
            if (KiemTraRong(txtAnh, "Chọn ảnh minh hoạ cho sản phẩm"))
            {
                btnOpen.Focus();
                return false;
            }

            return true;
        }

        private bool KiemTraDVT()
        {
            if (KiemTraRong(txtDVT, "Đơn vị tính không được để trống"))
            {
                return false;
            }
            return true;
        }

        private bool KiemTraDonGiaNhap()
        {
            if (KiemTraRong(txtDonGiaNhap, "Đơn giá nhập không được để trống"))
            {
                return false;
            }
            if (float.Parse(txtDonGiaNhap.Value.ToString()) <= 0)
            {
                XtraMessageBox.Show("Đơn giá nhập phải lớn hơn 0", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool KiemTraDonGiaBan()
        {
            if (KiemTraRong(txtDonGiaBan, "Đơn giá bán không được để trống"))
            {
                return false;
            }
            if (float.Parse(txtDonGiaBan.Value.ToString()) <= 0)
            {
                XtraMessageBox.Show("Đơn giá bán phải lớn hơn 0", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (float.Parse(txtDonGiaNhap.Value.ToString()) > float.Parse(txtDonGiaBan.Value.ToString()))
            {
                XtraMessageBox.Show("Giá bán phải lớn hơn giá nhập", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGiaBan.Focus();
                return false;
            }
            return true;
        }

        private bool KiemTraMaLoai()
        {
            if (KiemTraRong(cboMaLoai, "Mã loại không được để trống"))
            {
                return false;
            }
            return true;
        }

        private bool KiemTraNgaysx_Ngayhh()
        {
            if (dtpNgaySX.Value > dtpNgayHH.Value)
            {
                XtraMessageBox.Show("Ngày hết hạn phải lớn hơn ngày sản xuất", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayHH.Focus();
                return false;
            }
            return true;    
        }
        private bool kiemTraNgayHH()
        {
            DateTime dateTimeNow = DateTime.Now;
            if (dtpNgayHH.Value >= dateTimeNow)
            {
                XtraMessageBox.Show("Hàng hoá đã hết hạn, Vui lòng kiểm tra lại", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayHH.Focus();
                return false;
            }
            return true;
        }
        private bool KiemTraTrungImageinFolder()
        {
            var filepath = System.Windows.Forms.Application.StartupPath + "\\Images Hang Hoa\\" + txtAnh.Text.Substring(txtAnh.Text.LastIndexOf("\\") + 1);
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
                return false;
            }
            return true;
        }
        #endregion

        #region lưu ảnh và xoá ảnh
        void saveImage()
        {
            FileInfo fi = new FileInfo(txtAnh.Text.Substring(txtAnh.Text.LastIndexOf("\\") + 1));
            Image tempImage = Image.FromFile(txtAnh.Text);
            tempImage.Save(System.Windows.Forms.Application.StartupPath + "\\Images Hang Hoa\\" + fi.Name); // thao tác lưu ảnh vào folder
        }
        void xoaImage()
        {
            var filepath = System.Windows.Forms.Application.StartupPath + "\\Images Hang Hoa\\" + txtAnh.Text.Substring(txtAnh.Text.LastIndexOf("\\") + 1);
            File.Delete(filepath); // thao tác xoá ảnh
        }

        #endregion

       
    }
}
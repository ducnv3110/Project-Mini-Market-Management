using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QuanLyBachHoa;
using BUS_QuanLyBachHoa;
using BUS_QuanLyBachHoa.Functions;

namespace GUI_QuanLyBachHoa
{
    public partial class frmHoaDonNhap : DevExpress.XtraEditors.XtraForm
    {
        #region Khởi tạo
        // khởi tạo các BUS Layer
        BUS_HoaDonNhap busHDN = new BUS_HoaDonNhap();
        BUS_ChiTietHoaDonNhap busCT = new BUS_ChiTietHoaDonNhap();
        BUS_Hang busH = new BUS_Hang();
        BUS_Function func = new BUS_Function();

        // khởi tạo các bindingsource
        BindingSource bs = new BindingSource();
        BindingSource bsCT = new BindingSource();
        BindingSource bsH = new BindingSource();

        bool them = false, suaHang = false, themHang = false;
        float _tongtien = 0;
        #endregion

        public frmHoaDonNhap()
        {
            InitializeComponent();
            #region onLoad
            // load combobox
            func.FillCombo("tblNhaCungCap", cboMaNhaCC, "TenNCC", "MaNCC");
            func.FillCombo("tblNhanVien", cboMaNV, "TenNV", "MaNV");

            func.FillCombo("tblNhaCungCap", cboNhaCC_CT, "TenNCC", "MaNCC");
            func.FillCombo("tblNhanVien", cboMaNV_CT, "TenNV", "MaNV");

            // k cho sửa trực tiếp trên gridview
            gvChiTiet.OptionsBehavior.Editable = false;
            gvHD.OptionsBehavior.Editable = false;

            cboMaNV_CT.Enabled = false;
            // combobox ở dạng readonly
            cboNhaCC_CT.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaNV.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaNhaCC.DropDownStyle = ComboBoxStyle.DropDownList;

            txtDonGiaNhap.Enabled = false;
            txtThanhTien.Enabled = false;
            txtTongTien.Enabled = false;
            txtTenHang.Enabled = false;

            // định dạng datetimepicker theo vùng Việt Nam
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";

            dtpNgayNhap.Format = DateTimePickerFormat.Custom;
            dtpNgayNhap.CustomFormat = "dd/MM/yyyy";

            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            #endregion
        }

        #region loadData
        void loadDatabindingHDN()
        {
            gvHD.BeginUpdate();
            bs.DataSource = busHDN.getHoaDonNhap(dtpTuNgay.Value, dtpDenNgay.Value, cboMaNhaCC.SelectedValue.ToString(), cboMaNV.SelectedValue.ToString());
            gvHD.EndUpdate();

            txtMaHD.DataBindings.Clear();
            txtMaHD.DataBindings.Add("text", bs, "MaHDN", true);

            dtpNgayNhap.DataBindings.Clear();
            dtpNgayNhap.DataBindings.Add("value", bs, "NgayNhap", true);

            cboNhaCC_CT.DataBindings.Clear();
            cboNhaCC_CT.DataBindings.Add("text", bs, "TenNCC", true);

            cboMaNV_CT.DataBindings.Clear();
            cboMaNV_CT.DataBindings.Add("text", bs, "TenNV", true);


            txtTongTien.DataBindings.Clear();
            txtTongTien.DataBindings.Add("text", bs, "TongTien", true);

            bindingNavigatorHD.BindingSource = bs;
            gcHD.DataSource = bs;

        }

        void loadDatabindingCT(string ma)
        {
            gvChiTiet.BeginUpdate();
            bsCT.DataSource = busCT.getChiTietHoaDonNhap(ma);
            gvChiTiet.EndUpdate();

            txtMaHang.DataBindings.Clear();
            txtMaHang.DataBindings.Add("text", bsCT, "MaHH", true);

            txtTenHang.DataBindings.Clear();
            txtTenHang.DataBindings.Add("text", bsCT, "TenHH", true);

            txtSoLuongNhap.DataBindings.Clear();
            txtSoLuongNhap.DataBindings.Add("text", bsCT, "SoLuongNhap", true);

            txtDonGiaNhap.DataBindings.Clear();
            txtDonGiaNhap.DataBindings.Add("text", bsCT, "DonGiaNhap", true);

            txtThanhTien.DataBindings.Clear();
            txtThanhTien.DataBindings.Add("text", bsCT, "ThanhTien", true);

            bindingNavigatorCT.BindingSource = bsCT;
            gcChiTiet.DataSource = bsCT;

            
        }

        void loadInfoHang(string ma)
        {
            bsH.DataSource = busH.getHang(ma);

            txtTenHang.DataBindings.Clear();
            txtTenHang.DataBindings.Add("text", bsH, "TenHH", true);

            txtDonGiaNhap.DataBindings.Clear();
            txtDonGiaNhap.DataBindings.Add("text", bsH, "DonGiaNhap", true);

        }

        void loadDatatim()
        {
            gvChiTiet.BeginUpdate();
            bs.DataSource = busHDN.timHoaDonNhap(txtTim.Text);
            gvChiTiet.EndUpdate();

            txtMaHD.DataBindings.Clear();
            txtMaHD.DataBindings.Add("text", bs, "MaHDN", true);

            dtpNgayNhap.DataBindings.Clear();
            dtpNgayNhap.DataBindings.Add("value", bs, "NgayNhap", true);

            cboNhaCC_CT.DataBindings.Clear();
            cboNhaCC_CT.DataBindings.Add("text", bs, "TenNCC", true);

            cboMaNV_CT.DataBindings.Clear();
            cboMaNV_CT.DataBindings.Add("text", bs, "TenNV", true);


            txtTongTien.DataBindings.Clear();
            txtTongTien.DataBindings.Add("text", bs, "TongTien", true);

            bindingNavigatorHD.BindingSource = bs;
            gcHD.DataSource = bs;
            
        }
        #endregion
        #region enableBtn
        void enableButton(bool isAdd, bool isTim, bool isTxtTim)
        {
            btnThem.Enabled = isAdd;
            btnTim.Enabled = isTim;
            txtTim.Enabled = isTxtTim;
        }
        void enableButton(bool b)
        {
            btnThem.Enabled = b;
            btnTim.Enabled = b;
            txtTim.Enabled = b;
        }
        void enableButtonCT(bool isAdd,bool isEdit,bool isXoa, bool isSave, bool isSkip, bool isIn)
        {
           

        }
        void enableButtonCT(bool b)
        {
            btnThemHang.Enabled = b;
            btnSua.Enabled = b;
            btnXoa.Enabled = b;
            btnLuu.Enabled = !b;
            btnSkip.Enabled = !b;
            btnPrint.Enabled = b;
        }
        #endregion
        private void frmHoaDonNhap_Load(object sender, EventArgs e)
        {
            //reset bingdingsoure
            bs.EndEdit();
            bsCT.EndEdit();

            // đặt giá trị datetimepicker từ đầu tháng
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            // đặt giá trị datetimepicker vào ngày hôm sau
            dtpDenNgay.Value = DateTime.Now.AddDays(1);

            txtMaHD.Text = "";
            loadDatabindingCT(txtMaHD.Text);

            txtMaHD.Enabled = false;
            groupControlHangHoa.Enabled = false;

            loadDatabindingHDN();

            enableButton(true);
            enableButtonCT(true);
        }

        /// <summary>
        /// thống kê hoá đơn theo combobox nhà cung cấp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMaNhaCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (gcHD.DataSource != null)
                {
                    loadDatabindingHDN();
                }

            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// thống kê hoá đơn theo combobox mã nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDatabindingHDN();
        }

        /// <summary>
        /// thông kê hoá đơn theo ngày
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            loadDatabindingHDN();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bs.AddNew();
            

            tabChungTu.SelectedTabPage = pageChiTiet; // tabcontrol tự động chuyển sang 1 tabpage khác

            cboMaNV_CT.SelectedValue = CurrentUser.MaNV; // comboboxNV nhận giá trị từ user đăng nhập

            txtMaHD.Text = busHDN.taoMaHD();// tạo mã hoá đơn tự động
            bsCT.DataSource = busCT.getChiTietHoaDonNhap(txtMaHD.Text);
            gcChiTiet.DataSource = bsCT;

            them = true;
            enableButtonCT(false);
        }

        private void btnThemHang_Click(object sender, EventArgs e)
        {
            bsCT.AddNew();
            groupControlHangHoa.Enabled = true;
            enableButtonCT(false);
            themHang = true;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            suaHang = true;
            groupControlHangHoa.Enabled = true;
            enableButtonCT(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xoá hoá đơn này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (busCT.xoaChiTietHoaDonNhap(txtMaHD.Text) != 0 && busHDN.xoaHoaDonNhap(txtMaHD.Text) != 0 )
                {
                    XtraMessageBox.Show("Xoá dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabChungTu.SelectedTabPage = pageDanhSach;
                }
                else
                {
                    XtraMessageBox.Show("Xoá dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            frmHoaDonNhap_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!KiemTraNhaCC() || !KiemTraMaNV())
            {
                return;
            }

            DTO_HoaDonNhap hdn = new DTO_HoaDonNhap(txtMaHD.Text, cboMaNV_CT.SelectedValue.ToString(), cboNhaCC_CT.SelectedValue.ToString(), dtpNgayNhap.Value, float.Parse(txtTongTien.Value.ToString()));

            string tenNV = cboMaNV_CT.SelectedValue.ToString();
            string tenNCC = cboNhaCC_CT.SelectedValue.ToString();
           
            if (them) // lưu thông tin hoá đơn khi thêm mới
            {
                if (busHDN.themHoaDonNhap(hdn) != 0)
                {
                    XtraMessageBox.Show("Thêm hoá đơn mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bs.EndEdit();// reset bingdingsource
                    // đặt giá trị combox ở hoá đơn để loaddata theo combobox
                    cboMaNV.SelectedValue = tenNV; 
                    cboMaNhaCC.SelectedValue = tenNCC;
                    enableButtonCT(true);
                    loadDatabindingHDN(); // load data theo combobox ở trên
                }     
                else
                {
                    XtraMessageBox.Show("Thêm hoá đơn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabChungTu.SelectedTabPage = pageDanhSach; // tabcontrol tự động chuyển sang 1 tabpage khác
                    frmHoaDonNhap_Load(sender, e);
                }
                    
                them = false;
                return;
            }
            // lưu thông tin hoá đơn khi sửa
            DataRowView currentRow = (DataRowView)bs.Current;
            DateTime dt = (DateTime)currentRow["NgayNhap"];

            // điều kiện để sửa thông tin hoá đơn là mã nhân viên , nhà cung cấp , ngày nhập khác nhau giữa 2 tabpage
            if (cboMaNV_CT.SelectedValue.ToString() != cboMaNV.SelectedValue.ToString() || cboNhaCC_CT.SelectedValue.ToString() != cboMaNhaCC.SelectedValue.ToString() || 
                                dt.ToString("dd/MM/yyyy") != dtpNgayNhap.Value.ToString("dd/MM/yyyy") ) 
            {
                if (busHDN.suaHoaDonNhap(hdn) != 0)
                {
                    XtraMessageBox.Show("Cập nhật hoá đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bs.EndEdit();// reset bingdingsource
                    cboMaNV.SelectedValue = tenNV;
                    cboMaNhaCC.SelectedValue = tenNCC;
                    enableButtonCT(true);
                    loadDatabindingHDN();
                }
                else
                {
                    XtraMessageBox.Show("Cập nhật hoá đơn thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tabChungTu.SelectedTabPage = pageDanhSach; // tabcontrol tự động chuyển sang 1 tabpage khác
                    frmHoaDonNhap_Load(sender, e);
                }
                return;
            }

            if (!KiemTraMaHang() || !KiemTraSoLuongNhap())
            {
                return;
            }

            //thêm hoá đơn xong thì lưu các mặt hàng vào chi tiết hoá đơn khi thêm mới
            DTO_ChiTietHoaDonNhap cthdn = new DTO_ChiTietHoaDonNhap(txtMaHD.Text, txtMaHang.Text, int.Parse(txtSoLuongNhap.Value.ToString()), float.Parse(txtDonGiaNhap.Value.ToString()), 
                            float.Parse(txtThanhTien.Value.ToString()));

            if (themHang)
            {
                if (busCT.themChiTietHoaDonNhap(cthdn) != 0)
                {
                    XtraMessageBox.Show("Thêm hàng hoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Thêm hàng hoá thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                  
                themHang = false;
            }
            //lưu các mặt hàng vào chi tiết hoá đơn khi sửa
            if (suaHang) 
            {
                if (busCT.suaChiTietHoaDonNhap(cthdn) != 0)
                {
                    XtraMessageBox.Show("Cập nhật hàng hoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Cập nhật hàng hoá thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }   
                suaHang = false;
            }

            bsCT.EndEdit();//reset bindingsource
            loadDatabindingCT(txtMaHD.Text);
            groupControlHangHoa.Enabled = false;
            enableButtonCT(true);

            // cập nhật lại tổng tiền
            _tongtien = 0;
            for (int i = 0; i < gvChiTiet.RowCount; i++)
            {
                if (gvChiTiet.GetRowCellValue(i, "TenHH") == null)
                    return;
                _tongtien += float.Parse(gvChiTiet.GetRowCellValue(i, gvChiTiet.Columns["ThanhTien"]).ToString());
            }

            txtTongTien.Text = _tongtien.ToString();

            busHDN.capNhatTongTien(txtMaHD.Text, txtTongTien.Text);
        }

        private void gcChiTiet_MouseClick(object sender, MouseEventArgs e)
        {
            // tạo 1 menustrip mới
            ContextMenuStrip ctx = new ContextMenuStrip();

            // tạo các menu item
            ToolStripMenuItem xoaDong = new ToolStripMenuItem();
            xoaDong.Text = "Xoá dòng";
            xoaDong.Image = Properties.Resources.eraser;
            xoaDong.Click += new EventHandler(this.xoaDong_Click);

            ToolStripMenuItem xoaChiTiet = new ToolStripMenuItem();
            xoaChiTiet.Text = "Xoá chi tiết";
            xoaChiTiet.Image = Properties.Resources.delete;
            xoaChiTiet.Click += new EventHandler(this.xoaChiTiet_Click);

            // tiến hành add menuitem vào menustrip
            ctx.Items.Insert(0, xoaDong);
            ctx.Items.Insert(1, xoaChiTiet);
            // bắt sự kiện chuột phải chuột để hiện menu , con trỏ chuột ở đâu thì thanh menu hiện ở đó
            if (e.Button == MouseButtons.Right)
            {
                Point p = new Point(e.X, e.Y);
                ctx.Show(gcChiTiet, p);
            }

            
        }

        private void xoaDong_Click(object sender, EventArgs e)
        {
            DataRowView currentRow = (DataRowView)bsCT.Current;
            string strMaHang = currentRow["MaHH"].ToString();
            string strMaHD = currentRow["MaHDN"].ToString();
            if (XtraMessageBox.Show("Bạn có muốn xoá dòng chứa mã: " + strMaHang + " này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (busCT.xoaChiTietHoaDonNhap(strMaHD,strMaHang) != 0)
                {
                    XtraMessageBox.Show("Xoá thành công dòng chứa mã: "+ strMaHang, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bsCT.EndEdit();
                    loadDatabindingCT(txtMaHD.Text);
                }
                else
                {
                    XtraMessageBox.Show("Xoá dòng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bsCT.EndEdit();
                    loadDatabindingCT(txtMaHD.Text);
                    return;
                }
            }
            else
            {
                loadDatabindingCT(txtMaHD.Text);
                return;
            }
            // cập nhật lại tổng tiền
            _tongtien = 0;
            for (int i = 0; i < gvChiTiet.RowCount; i++)
            {
                if (gvChiTiet.GetRowCellValue(i, "TenHH") == null)
                    return;
                _tongtien += float.Parse(gvChiTiet.GetRowCellValue(i, gvChiTiet.Columns["ThanhTien"]).ToString());
            }

            txtTongTien.Text = _tongtien.ToString();

            busHDN.capNhatTongTien(txtMaHD.Text, txtTongTien.Text);

        }
        private void xoaChiTiet_Click(object sender, EventArgs e)
        {
            DataRowView currentRow = (DataRowView)bsCT.Current;
            string strMaHD = currentRow["MaHDN"].ToString();

            if (XtraMessageBox.Show("Bạn có muốn xoá tất cả mặt hàng này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (busCT.xoaChiTietHoaDonNhap(strMaHD) != 0)
                {
                    XtraMessageBox.Show("Xoá tất cả mặt hàng thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bsCT.EndEdit();
                    loadDatabindingCT(txtMaHD.Text);
                    
                }
                else
                {
                    XtraMessageBox.Show("Xoá tất cả mặt hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bsCT.EndEdit();
                    loadDatabindingCT(txtMaHD.Text);
                    return;
                }
            }
            else
            {
                loadDatabindingCT(txtMaHD.Text);
                return;
            }

            // cập nhật lại tổng tiền
            _tongtien = 0;
            txtTongTien.Text = _tongtien.ToString();

            busHDN.capNhatTongTien(txtMaHD.Text, txtTongTien.Text);
        }

        private void cboHang_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// tự động tính thành tiên khi thay đổi số lượng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSoLuongNhap_TextChanged(object sender, EventArgs e)
        {
            txtThanhTien.Text= (float.Parse(txtDonGiaNhap.Value.ToString()) * float.Parse(txtSoLuongNhap.Value.ToString())).ToString();
        }
        /// <summary>
        /// tạo sự kiện double click trên gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvHD_DoubleClick(object sender, EventArgs e)
        {
            if (bs.Count > 0)
            {
                DataRowView currentRow = (DataRowView)bs.Current;
                string strMaHD = currentRow["MaHDN"].ToString();

                tabChungTu.SelectedTabPage = pageChiTiet;
                enableButtonCT(true);
                loadDatabindingCT(strMaHD);
                
            }
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

        private bool KiemTraNhaCC()
        {
            if (KiemTraRong(cboNhaCC_CT, "Nhà cung cấp không được để trống"))
            {
                return false;
            }
            return true;
        }

        private bool KiemTraMaNV()
        {
            if (KiemTraRong(cboMaNV_CT, "Nhân viên không được để trống"))
            {
                return false;
            }
            return true;
        }

        private bool KiemTraMaHang()
        {
            if (KiemTraRong(txtMaHang, "Hàng không được để trống"))
            {
                return false;
            }
            return true;
        }

        private bool KiemTraSoLuongNhap()
        {
            if (txtSoLuongNhap.Text == "0")
            {
                XtraMessageBox.Show("Số lượng nhập phải lớn hơn 0", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuongNhap.Focus();
                return false;
            }
            return true;
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
                loadDatabindingHDN();
                return;
            }
            loadDatatim();
        }

        private void txtMaHang_TextChanged(object sender, EventArgs e)
        {
            if (themHang)
            {
                loadInfoHang(txtMaHang.Text);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string soTien = func.NumberToText(float.Parse(txtTongTien.Text)); // chuyển giá tiền từ số thành chữ

            Report.frmRpHDN f = new Report.frmRpHDN(txtMaHD.Text, soTien);
            f.WindowState = FormWindowState.Maximized;
            f.ShowDialog();
        }

        private void tabChungTu_Click(object sender, EventArgs e)
        {
            // load data null khi click trên tabcontrol
            if (tabChungTu.SelectedTabPage == pageDanhSach)
            {
                loadDatabindingHDN();

            }
            else if (tabChungTu.SelectedTabPage == pageChiTiet)
            {
                bsCT.EndEdit();
                txtMaHD.Text = "";
                cboNhaCC_CT.SelectedIndex = -1;
                cboMaNV_CT.SelectedIndex = -1;
                txtTongTien.Text = "0";
                dtpNgayNhap.Value = DateTime.Now;
                loadDatabindingCT(txtMaHD.Text);
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
            bsCT.CancelEdit();

            DataRowView currentRow = (DataRowView)bs.Current;
            string strMaHD = currentRow["MaHDN"].ToString();
            enableButtonCT(true);
            groupControlHangHoa.Enabled = false;
            them = false;
            themHang = false;
            suaHang = false;
            loadDatabindingCT(strMaHD);
         
        }
        private void btnOpenHang_Click(object sender, EventArgs e)
        {
            frmHang f = new frmHang();
            f.ShowDialog();
            txtMaHang.Text = f.maHang; // lấy dữ liệu từ form hàng xuống textbox mã hàng
        }


    }
}
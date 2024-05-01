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
    public partial class frmHoaDonBan : DevExpress.XtraEditors.XtraForm
    {
        #region Khởi tạo
        // khởi tạo bus layer
        BUS_HoaDonBan busHDB = new BUS_HoaDonBan();
        BUS_ChiTietHoaDonBan busCT = new BUS_ChiTietHoaDonBan();
        BUS_Bill busBill = new BUS_Bill();
        BUS_ChiTietBill busBillCT = new BUS_ChiTietBill();
        BUS_Function func = new BUS_Function();

        //khởi tạo bindingsource
        BindingSource bs = new BindingSource();
        BindingSource bsCT = new BindingSource();
        #endregion
        public frmHoaDonBan()
        {
            InitializeComponent();
            #region onLoad
            // load combobox
            func.FillCombo("tblKhachHang", cboMaKH, "TenKH", "MaKH");
            func.FillCombo("tblNhanVien", cboMaNV, "TenNV", "MaNV");

            func.FillCombo("tblKhachHang", cboMaKH_CT, "TenKH", "MaKH");
            func.FillCombo("tblNhanVien", cboMaNV_CT, "TenNV", "MaNV");

            // k cho sửa trực tiếp trên gridview
            gvChiTiet.OptionsBehavior.Editable = false;
            gvHD.OptionsBehavior.Editable = false;

            // cho combobox ở dạng readonly
            cboMaKH_CT.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaNV_CT.Enabled = false;
            cboMaKH.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaNV.DropDownStyle = ComboBoxStyle.DropDownList;


            txtDonGiaBan.Enabled = false;
            txtThanhTien.Enabled = false;
            txtTongTien.Enabled = false;
            txtThue.Enabled = false;
            txtTenHang.Enabled = false;

            // định dạng datetimepicker theo vùng Việt Nam
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";

            dtpNgayBan.Format = DateTimePickerFormat.Custom;
            dtpNgayBan.CustomFormat = "dd/MM/yyyy";

            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            #endregion
        }
        #region loadData
        void loadDatabindingHDB()
        {
            gvHD.BeginUpdate();
            bs.DataSource = busHDB.getHoaDonBan(dtpTuNgay.Value, dtpDenNgay.Value, cboMaKH.SelectedValue.ToString(), cboMaNV.SelectedValue.ToString());
            gvHD.EndUpdate();

            txtMaHD.DataBindings.Clear();
            txtMaHD.DataBindings.Add("text", bs, "MaHDB", true);

            dtpNgayBan.DataBindings.Clear();
            dtpNgayBan.DataBindings.Add("value", bs, "NgayBan", true);

            cboMaKH_CT.DataBindings.Clear();
            cboMaKH_CT.DataBindings.Add("text", bs, "TenKH", true);

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
            bsCT.DataSource = busCT.getChiTietHoaDonBan(ma);
            gvChiTiet.EndUpdate();

            txtMaHang.DataBindings.Clear();
            txtMaHang.DataBindings.Add("text", bsCT, "MaHH", true);

            txtTenHang.DataBindings.Clear();
            txtTenHang.DataBindings.Add("text", bsCT, "TenHH", true);

            txtSoLuongBan.DataBindings.Clear();
            txtSoLuongBan.DataBindings.Add("text", bsCT, "SoLuongBan", true);

            txtDonGiaBan.DataBindings.Clear();
            txtDonGiaBan.DataBindings.Add("text", bsCT, "DonGiaBan", true);

            txtThanhTien.DataBindings.Clear();
            txtThanhTien.DataBindings.Add("text", bsCT, "ThanhTien", true);

            txtThue.DataBindings.Clear();
            txtThue.DataBindings.Add("text", bsCT, "VAT", true);

            bindingNavigatorCT.BindingSource = bsCT;
            gcChiTiet.DataSource = bsCT;

        }
        void loadInfoBill(string ma)
        {
            BindingSource bsBill = new BindingSource();
            

            bsBill.DataSource = busBill.timBill(ma);

            dtpNgayBan.DataBindings.Clear();
            dtpNgayBan.DataBindings.Add("value", bsBill, "NgayBan", true);

            cboMaNV_CT.DataBindings.Clear();
            cboMaNV_CT.DataBindings.Add("text", bsBill, "TenNV", true);

            txtTongTien.DataBindings.Clear();
            txtTongTien.DataBindings.Add("text", bsBill, "TongTien", true); 
        }
        void loadInfoBillCT(string ma)
        {
            BindingSource bsBillCT = new BindingSource();
            gvChiTiet.BeginUpdate();
            bsBillCT.DataSource = busBillCT.getChiTietBill(ma);
            gvChiTiet.EndUpdate();
            
            txtMaHang.DataBindings.Clear();
            txtMaHang.DataBindings.Add("text", bsBillCT, "MaHH", true);

            txtTenHang.DataBindings.Clear();
            txtTenHang.DataBindings.Add("text", bsBillCT, "TenHH", true);

            txtSoLuongBan.DataBindings.Clear();
            txtSoLuongBan.DataBindings.Add("text", bsBillCT, "SoLuongBan", true);

            txtDonGiaBan.DataBindings.Clear();
            txtDonGiaBan.DataBindings.Add("text", bsBillCT, "DonGiaBan", true);

            txtThanhTien.DataBindings.Clear();
            txtThanhTien.DataBindings.Add("text", bsBillCT, "ThanhTien", true);

            txtThue.DataBindings.Clear();
            txtThue.DataBindings.Add("text", bsBillCT, "VAT", true);

            bindingNavigatorCT.BindingSource = bsBillCT;
            gcChiTiet.DataSource = bsBillCT;
        }
        void loadDataTim()
        {
            gvChiTiet.BeginUpdate();
            bs.DataSource = busHDB.timHoaDonBan(txtTim.Text);
            gvHD.EndUpdate();

            txtMaHD.DataBindings.Clear();
            txtMaHD.DataBindings.Add("text", bs, "MaHDB", true);

            dtpNgayBan.DataBindings.Clear();
            dtpNgayBan.DataBindings.Add("value", bs, "NgayBan", true);

            cboMaKH_CT.DataBindings.Clear();
            cboMaKH_CT.DataBindings.Add("text", bs, "TenKH", true);

            cboMaNV_CT.DataBindings.Clear();
            cboMaNV_CT.DataBindings.Add("text", bs, "TenNV", true);

            txtTongTien.DataBindings.Clear();
            txtTongTien.DataBindings.Add("text", bs, "TongTien", true);

            bindingNavigatorHD.BindingSource = bs;
            gcHD.DataSource = bs;

            
        }
        #endregion
        #region enableButton
            
        void enableButton(bool b)
        {
            btnThem.Enabled = b;
            btnTim.Enabled = b;
            txtTim.Enabled = b;
        }
        void enableButtonCT(bool b)
        {
            btnXoa.Enabled = b;
            btnLuu.Enabled = !b;
            btnSkip.Enabled = !b;
            btnPrint.Enabled = b;
        }
        #endregion
        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            // reset bindingsource
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

            loadDatabindingHDB();

            enableButton(true);
            enableButtonCT(true);
        }

        /// <summary>
        /// thống kê hoá đơn theo ngày
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            loadDatabindingHDB();
        }

        /// <summary>
        /// thống kê hoá đơn theo mã khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (gcHD.DataSource != null)
                {
                    loadDatabindingHDB();
                }

            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// thống kê hoá đơn theo mã nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDatabindingHDB();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            tabChungTu.SelectedTabPage = pageChiTiet; // tabcontrol tự động chuyển sang 1 tabpage khác
            txtMaHD.Enabled = true;
            resetValue(); // hàm xoá trắng các textbox
            bsCT.DataSource = busCT.getChiTietHoaDonBan(txtMaHD.Text);
            enableButtonCT(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xoá hoá đơn này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busCT.xoaChiTietHoaDonBan(txtMaHD.Text) != 0 && busHDB.xoaHoaDonBan(txtMaHD.Text) != 0 )
                {
                    XtraMessageBox.Show("Xoá dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabChungTu.SelectedTabPage = pageDanhSach;
                }
                else
                {
                    XtraMessageBox.Show("Xoá dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            frmHoaDonBan_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!KiemTraMaKH() || !KiemTraMaNV())
            {
                return;
            }

            DTO_HoaDonBan hdb = new DTO_HoaDonBan(txtMaHD.Text, cboMaNV_CT.SelectedValue.ToString(),cboMaKH_CT.SelectedValue.ToString(), dtpNgayBan.Value, float.Parse(txtTongTien.Value.ToString()));

            busHDB.themHoaDonBan(hdb); // lưu thông tin hoá đơn bán

            // lưu thông tin tất cả hàng hoá vào chi tiết hoá đơn
            if(gcChiTiet.DataSource != null)
            {
                for (int i = 0; i < gvChiTiet.RowCount; i++)
                {
                    DTO_ChiTietHoaDonBan ct = new DTO_ChiTietHoaDonBan();
                    ct.MaHDB = txtMaHD.Text;
                    ct.MaHH = gvChiTiet.GetRowCellValue(i, "MaHH").ToString();
                    ct.SoLuongBan = int.Parse(gvChiTiet.GetRowCellValue(i, "SoLuongBan").ToString());
                    ct.DonGiaBan = float.Parse(gvChiTiet.GetRowCellValue(i, "DonGiaBan").ToString());
                    ct.ThanhTien = int.Parse(gvChiTiet.GetRowCellValue(i, "ThanhTien").ToString());

                    busCT.themChiTietHoaDonBan(ct);
                    
                }
            }

            bsCT.EndEdit(); //reset bindingsource
            loadDatabindingCT(txtMaHD.Text);
            loadDatabindingHDB();
            groupControlHangHoa.Enabled = false;
            enableButtonCT(true);

            // cập nhật lại tổng tiền
            busHDB.capNhatTongTien(txtMaHD.Text, txtTongTien.Value.ToString());

            XtraMessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gcHD_DoubleClick(object sender, EventArgs e)
        {
            if (bs.Count > 0)
            {
                DataRowView currentRow = (DataRowView)bs.Current;
                string strMaHD = currentRow["MaHDB"].ToString();

                tabChungTu.SelectedTabPage = pageChiTiet;// tabcontrol tự động chuyển sang 1 tabpage khác
                enableButtonCT(true);
                loadDatabindingCT(strMaHD);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            loadDataTim();
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if (txtTim.Text == "")
            {
                loadDatabindingHDB();
                return;
            }
            loadDataTim();
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            //reset bingdingsource
            bs.CancelEdit();
            bsCT.CancelEdit();

            resetValue();// hàm xoá trắng các textbox
            frmHoaDonBan_Load(sender, e);
        }


        private void btnOpenKH_Click(object sender, EventArgs e)
        {
            frmKhachHang f = new frmKhachHang();
            f.ShowDialog();
        }

        #region kiểm tra dữ liệu
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

        private bool KiemTraMaKH()
        {
            if (KiemTraRong(cboMaKH_CT, "Tên khách hàng không được để trống"))
            {
                return false;
            }
            return true;
        }

        private bool KiemTraMaNV()
        {
            if (KiemTraRong(cboMaNV_CT,"Nhân viên không được để trống"))
            {
                return false;
            }
            return true;
        }
        #endregion
      

        private void tabChungTu_Click(object sender, EventArgs e)
        {
            // load data null khi click 1 tabpage khác
            if (tabChungTu.SelectedTabPage == pageDanhSach) 
            {
                loadDatabindingHDB();
                
            }
            else if (tabChungTu.SelectedTabPage == pageChiTiet)
            {
                bsCT.EndEdit();
                resetValue();
                loadDatabindingCT(txtMaHD.Text);
            }
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            loadInfoBill(txtMaHD.Text); // load tất cả thông tin ở phiếu thanh toán
            loadInfoBillCT(txtMaHD.Text); // load tất cả thông tin ở chi tiết phiếu thanh toán
        }

    
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string soTien = func.NumberToText(float.Parse(txtTongTien.Text));// chuyển từ số sang chữ

            Report.frmRpHDB f = new Report.frmRpHDB(txtMaHD.Text, soTien);
            f.WindowState = FormWindowState.Maximized;
            f.ShowDialog();
        }

        void resetValue()
        {
            txtMaHD.Text = "";
            cboMaKH_CT.SelectedIndex = -1;
            cboMaNV_CT.SelectedIndex = -1;
            txtTongTien.Text = "0";
            dtpNgayBan.Value = DateTime.Now;
            loadDatabindingCT(txtMaHD.Text);
        }
    }
}
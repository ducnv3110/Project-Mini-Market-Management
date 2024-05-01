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
using CrystalDecisions.Windows.Forms;

namespace GUI_QuanLyBachHoa
{
    public partial class frmBill : DevExpress.XtraEditors.XtraForm
    {
        #region Khởi tạo
        // khởi tạo các BUS Layer
        BUS_Bill busBill = new BUS_Bill();
        BUS_ChiTietBill busCT = new BUS_ChiTietBill();
        BUS_Hang busH = new BUS_Hang();
        BUS_Function func = new BUS_Function();

        // khởi tạo các bindingsource
        BindingSource bs = new BindingSource();
        BindingSource bsCT = new BindingSource();
        BindingSource bsH = new BindingSource();

        bool suaHang = false, themHang = false;
        float _tongtien = 0;
        string _maHD = "";
        #endregion

        public frmBill()
        {
            InitializeComponent();
            func.FillCombo("tblNhanVien", cboMaNV, "TenNV", "MaNV");

            // k cho người dùng edit trực tiếp vào gridview
            gvChiTiet.OptionsBehavior.Editable = false;
            gvHD.OptionsBehavior.Editable = false;

            //enable text
            txtDonGiaBan.Enabled = false;
            txtThanhTien.Enabled = false;
            txtTongTien.Enabled = false;
            txtTenHang.Enabled = false;

            // định dạng datetimepicker : dd/MM/yyyy
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";

            dtpNgayBan.Format = DateTimePickerFormat.Custom;
            dtpNgayBan.CustomFormat = "dd/MM/yyyy";

            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
        }
        #region loadData
        void loadDatabindingBill()
        {
            gvHD.BeginUpdate();
            bs.DataSource = busBill.getBill(dtpTuNgay.Value, dtpDenNgay.Value);
            gvHD.EndUpdate();

            txtSoHD.DataBindings.Clear();
            txtSoHD.DataBindings.Add("text", bs, "SoHD", true);

            dtpNgayBan.DataBindings.Clear();
            dtpNgayBan.DataBindings.Add("value", bs, "NgayBan", true);

            cboMaNV.DataBindings.Clear();
            cboMaNV.DataBindings.Add("text", bs, "TenNV", true);

            txtTongTien.DataBindings.Clear();
            txtTongTien.DataBindings.Add("text", bs, "TongTien", true);

            bindingNavigatorHD.BindingSource = bs;
            gcHD.DataSource = bs;

            
        }
        void loadDatabindingCT(string ma)
        {
            gvChiTiet.BeginUpdate();
            bsCT.DataSource = busCT.getChiTietBill(ma);
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
            txtThanhTien.DataBindings.Add("text",bsCT, "ThanhTien" ,true);

            txtThue.DataBindings.Clear();
            txtThue.DataBindings.Add("text", bsCT, "VAT", true);

            bindingNavigatorCT.BindingSource = bsCT;
            gcChiTiet.DataSource = bsCT;

            
        }
        void loadInfoHang(string ma)
        {
            bsH.DataSource = busH.getHang(ma);

            txtTenHang.DataBindings.Clear();
            txtTenHang.DataBindings.Add("text", bsH, "TenHH", true);

            txtThue.DataBindings.Clear();
            txtThue.DataBindings.Add("text", bsH, "VAT", true);

            txtDonGiaBan.DataBindings.Clear();
            txtDonGiaBan.DataBindings.Add("text", bsH, "DonGiaBan", true);


        }
        void loadDataTim() 
        {
            gvHD.BeginUpdate();
            bs.DataSource = busBill.timBill(txtTim.Text);
            gvHD.EndUpdate();

            txtSoHD.DataBindings.Clear();
            txtSoHD.DataBindings.Add("text", bs, "SoHD", true);

            dtpNgayBan.DataBindings.Clear();
            dtpNgayBan.DataBindings.Add("value", bs, "NgayBan", true);

            cboMaNV.DataBindings.Clear();
            cboMaNV.DataBindings.Add("text", bs, "TenNV", true);

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
            btnThemHang.Enabled = b;
            btnSua.Enabled = b;
            btnXoa.Enabled = b;
            btnLuu.Enabled = !b;
            btnSkip.Enabled = !b;
            btnPrint.Enabled = b;
        }
        #endregion

        private void frmBill_Load(object sender, EventArgs e)
        {
            // reset bindingsource
            bs.EndEdit();
            bsCT.EndEdit();

            // định dạng datetimepicker vào đầu tháng
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            // định dạng datatimepicker ngày hôm sau
            dtpDenNgay.Value = DateTime.Now.AddDays(1);

            cboMaNV.Enabled = false;

            //txtSoHD.Text = "";
            loadDatabindingCT(_maHD);

            txtSoHD.Enabled = false;
            groupControlHangHoa.Enabled = false;

            loadDatabindingBill();

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
            loadDatabindingBill();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bs.AddNew();

            // tạo mã hoá đơn tự động
            _maHD = busBill.taoSoPhieu();

            // lấy mã nhân viên từ nhân viên khi đăng nhập tài khoản vào phần mềm
            cboMaNV.SelectedValue = CurrentUser.MaNV;
            dtpNgayBan.Value = DateTime.Now;

            bsCT.DataSource = busCT.getChiTietBill(_maHD);
            gcChiTiet.DataSource = bsCT;

            #region lưu thông tin Bill
            DTO_Bill dtoBill = new DTO_Bill(_maHD, cboMaNV.SelectedValue.ToString(), dtpNgayBan.Value, float.Parse(txtTongTien.Text));

            if (busBill.themBill(dtoBill) != 0)
            {
                XtraMessageBox.Show("Tạo hoá đơn mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDatabindingCT(_maHD);
                loadDatabindingBill();
                tabChungTu.SelectedTabPage = pageChiTiet;
                txtSoHD.Text = _maHD;
            }
            else
            {
                XtraMessageBox.Show("Tạo hoá đơn mới thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmBill_Load(sender, e);
            }
            #endregion

        }
        private void btnThemHang_Click(object sender, EventArgs e)
        {
            bsCT.AddNew();
            groupControlHangHoa.Enabled = true;
            enableButtonCT(false);
            themHang = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xoá hoá đơn này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (busCT.xoaChiTietBill(txtSoHD.Text) != 0 && busBill.xoaBill(txtSoHD.Text) != 0)
                {
                    XtraMessageBox.Show("Xoá dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabChungTu.SelectedTabPage = pageDanhSach;
                }
                else
                {
                    XtraMessageBox.Show("Xoá dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }
            else
            {
                loadDatabindingCT(txtSoHD.Text);
            } 

            frmBill_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            suaHang = true;
            groupControlHangHoa.Enabled = true;
            enableButtonCT(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!kiemTraMaHang() || !kiemTraSoLuongTon())
            {
                return;
            }
            // gán giá trị từ các textbox vào các enities của bảng chi tiết
            DTO_ChiTietBill chiTietBill = new DTO_ChiTietBill(txtSoHD.Text, txtMaHang.Text, int.Parse(txtSoLuongBan.Value.ToString()), float.Parse(txtDonGiaBan.Value.ToString()), 
                float.Parse(txtThanhTien.Value.ToString()));

            if (themHang) // lưu thông tin hàng vào chi tiết hoá đơn khi thêm mới
            {
                if (busCT.themChiTietBill(chiTietBill) != 0)
                {
                    XtraMessageBox.Show("Thêm hàng hoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Thêm hàng hoá thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                themHang = false;
            }

            if (suaHang) // lưu thông tin hàng vào chi tiết hoá đơn khi sửa
            {
                if (busCT.suaChiTietBill(chiTietBill) != 0)
                {
                    XtraMessageBox.Show("Cập nhật hàng hoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Cập nhật hàng hoá thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                suaHang = false;
            }

            bs.EndEdit();// reset bingdingsource
            bsCT.EndEdit();// reset bingdingsource
            loadDatabindingCT(txtSoHD.Text); 
            loadDatabindingBill(); 
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

            busBill.capNhatTongTien(txtSoHD.Text, txtTongTien.Text);
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
            string strMaHD = currentRow["SoHD"].ToString();

            if (XtraMessageBox.Show("Bạn có muốn xoá dòng chứa mã: " + strMaHang + " này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (busCT.xoaChiTietBill(strMaHD, strMaHang) != 0)
                {
                    XtraMessageBox.Show("Xoá thành công dòng chứa mã: " + strMaHang, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bsCT.EndEdit();
                    loadDatabindingCT(txtSoHD.Text);
                }
                else
                {
                    XtraMessageBox.Show("Xoá dòng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bsCT.EndEdit();
                    loadDatabindingCT(txtSoHD.Text);
                    return;
                }
            }
            else
            {
                loadDatabindingCT(txtSoHD.Text);
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

            busBill.capNhatTongTien(txtSoHD.Text, txtTongTien.Text);
        }

        private void xoaChiTiet_Click(object sender, EventArgs e)
        {
            DataRowView currentRow = (DataRowView)bsCT.Current;
            string strMaHD = currentRow["MaHDBan"].ToString();

            if (XtraMessageBox.Show("Bạn có muốn xoá tất cả mặt hàng này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (busCT.xoaChiTietBill(strMaHD) != 0)
                {
                    XtraMessageBox.Show("Xoá tất cả mặt hàng thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bsCT.EndEdit();
                    loadDatabindingCT(txtSoHD.Text);
                }
                else
                {
                    XtraMessageBox.Show("Xoá tất cả mặt hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bsCT.EndEdit();
                    loadDatabindingCT(txtSoHD.Text);
                    return;
                }
            }
            else
            {
                loadDatabindingCT(txtSoHD.Text);
                return;
            }

            // cập nhật lại tổng tiền
            _tongtien = 0;
            txtTongTien.Text = _tongtien.ToString();

            busBill.capNhatTongTien(txtSoHD.Text, txtTongTien.Text);
        }
        /// <summary>
        /// tự động tính thành tiên khi thay đổi số lượng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSoLuongBan_TextChanged(object sender, EventArgs e)
        {
            float _tienThue = 0, _tienHang = 0;
            _tienHang = float.Parse(txtDonGiaBan.Value.ToString()) * float.Parse(txtSoLuongBan.Value.ToString());
            _tienThue = _tienHang * (float.Parse(txtThue.Value.ToString()) / 100);
            txtThanhTien.Text = (_tienHang + _tienThue).ToString();
        }

        private void txtMaHang_TextChanged(object sender, EventArgs e)
        {
            if (themHang) // chỉ cần nhập mã hàng và các chi tiết của mặt hàng sẽ tự động load
            {
                loadInfoHang(txtMaHang.Text);
                txtSoLuongBan.Text = "1";
            }
            if(txtMaHang.Text == "")
            {
                txtSoLuongBan.Text = "0";
            }
        }
        /// <summary>
        /// tạo sự kiện double click trên gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gcHD_DoubleClick(object sender, EventArgs e)
        {
            if (bs.Count > 0)
            {
                DataRowView currentRow = (DataRowView)bs.Current;
                string strMaHD = currentRow["SoHD"].ToString();

                tabChungTu.SelectedTabPage = pageChiTiet; // tự động chuyển 1 tabpage khác
                enableButtonCT(true);
                loadDatabindingCT(strMaHD);
            }
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if (txtTim.Text == "")
            {
                loadDatabindingBill();
                return;
            }
            loadDataTim();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            loadDataTim();
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            //reset bindingsource
            bs.CancelEdit();
            bsCT.CancelEdit();

            DataRowView currentRow = (DataRowView)bs.Current;
            string strMaHD = currentRow["SoHD"].ToString();
            loadDatabindingCT(strMaHD);

            themHang = false;
            suaHang = false;

            enableButtonCT(true);
            groupControlHangHoa.Enabled = false;
        }
        private void btnOpenHang_Click(object sender, EventArgs e)
        {
            frmHang f = new frmHang();
            f.ShowDialog();
            txtMaHang.Text = f.maHang; // lấy dữ liệu từ form hàng xuống textbox mã hàng
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

        private bool kiemTraMaHang()
        {
            if(KiemTraRong(txtMaHang,"Mã hàng không được để trống"))
            {
                return false;
            }
            return true;
        }

        private bool kiemTraSoLuongTon()
        {
            if (!busCT.kiemTraSoLuongTon(txtMaHang.Text, txtSoLuongBan.Text))
            {
                XtraMessageBox.Show("Số lượng mặt hàng này chỉ còn: " + busCT.laySoLuongTon(txtMaHang.Text), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuongBan.Focus();
                return false;
            }
            return true;
        }
        #endregion

        private void tabChungTu_Click(object sender, EventArgs e)
        {
            // load các data null khi click trên tabcontrol
            if (tabChungTu.SelectedTabPage == pageDanhSach)
            {
                loadDatabindingBill();

            }
            else if (tabChungTu.SelectedTabPage == pageChiTiet)
            {
                bsCT.EndEdit();
                txtSoHD.Text = "";
                cboMaNV.SelectedIndex = -1;
                txtTongTien.Text = "0";
                dtpNgayBan.Value = DateTime.Now;
                loadDatabindingCT(txtSoHD.Text);
            }

        }

        private void btnPrintGTGT_Click(object sender, EventArgs e)
        {
            frmHoaDonBan f = new frmHoaDonBan();
            f.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //tạo 1 report mới
            CrystalReportViewer cRVBill = new CrystalReportViewer();
            Report.rpBill bill = new Report.rpBill();

            bill.SetParameterValue("paraSoBill", txtSoHD.Text); // lấy giá trị report

            cRVBill.ReportSource = bill; 
            cRVBill.PrintReport(); // tự động in report 
            cRVBill.Refresh();
        }
    }
}
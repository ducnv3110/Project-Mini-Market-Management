using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DTO_QuanLyBachHoa;
using BUS_QuanLyBachHoa;
using BUS_QuanLyBachHoa.Functions;
using DevExpress.XtraEditors;

namespace GUI_QuanLyBachHoa
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        
        public frmMain()
        {
            InitializeComponent();
            ribbonPageDanhMuc.Visible = false;
            ribbonPageThongKe.Visible = false;
            ribbonPageGroupBackup.Visible = false;

            this.WindowState = FormWindowState.Maximized;
        }
        void OpenForm(Type typeForm)
        {
            foreach(Form frm in MdiChildren)
            {
                if (frm.GetType() == typeForm)
                {
                    frm.Activate();
                    return;
                }
                    
            }
             
            Form f = (Form)Activator.CreateInstance(typeForm);
            f.MdiParent =this;
            f.Show();
        }

        void CloseForm(Type typeForm)
        {
            foreach (Form frm in MdiChildren)
            {
                if (frm.GetType() == typeForm)
                {
                    frm.Activate();
                    frm.Close();
                    return;
                }

            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            
            timer1.Start();
            lblDate.Caption = "Ngày: " + DateTime.Now.ToLongDateString();
            EnableControl(false);
            btnDangNhap.PerformClick();
        }

        private void btnDangNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CurrentUser.ID == null)
            {
                frmLogin lg = new frmLogin();
                
                lg.lg = new frmLogin.AfterLogin(delegate (User user)
                {
                    CurrentUser.MaNV = user.MaNV;
                    CurrentUser.ID = user.ID;
                    CurrentUser.HoTen = user.HoTen;
                    CurrentUser.MaCV = user.MaCV;
                    CurrentUser.TenCV = user.TenCV;
                    EnableControl(true);
                    lblCurrentUser.Caption = "Chào bạn: " + CurrentUser.HoTen + " - Chức vụ: " + CurrentUser.TenCV;
                    
                    
                    phanQuyen(CurrentUser.MaCV);
                    
                });
                lg.ShowDialog();
            }
        }
        #region enable
        void EnableControl(bool b)
        {
            btnDangNhap.Enabled = !b;
            btnDoiMatKhau.Enabled = b;
            btnDangXuat.Enabled = b;
            btnBackup.Enabled = b;
            btnRestore.Enabled = b;

        }
        void enableButton(bool isHang, bool isLoaiH, bool isNhaCC, bool isBarcode, bool isKH, bool isNV, bool isHDN, bool isHDB, bool isCV, bool isAccount)
        {
            this.btnHangHoa.Enabled = isHang;
            this.btnLoaiHang.Enabled = isLoaiH;
            this.btNhaCC.Enabled = isNhaCC;
            this.btnPrintBarcode.Enabled = isBarcode;
            this.btnKhachHang.Enabled = isKH;
            this.btnNhanVien.Enabled = isNV;
            this.btnHoaDonNhap.Enabled = isHDN;
            this.barHoaDon.Enabled = isHDB;
            this.btnChucVu.Enabled = isCV;
            this.btnTaiKhoan.Enabled = isAccount;
        }
        void enableRibbonPage(bool isDM, bool isTKe)
        {
            this.ribbonPageDanhMuc.Visible = isDM;
            this.ribbonPageThongKe.Visible = isTKe;
        }
        void enableRibbonPageGroup(bool isHH, bool isKH, bool isAccount, bool isBackup, bool isNoibo)
        {
            this.ribbonPageGroupKhachHang.Visible = isKH;
            this.ribbonPageGroupHangHoa.Visible = isHH;
            this.ribbonPageGroupTaiKhoan.Visible = isAccount;
            this.ribbonPageGroupBackup.Visible = isBackup;
            this.ribbonPageGroupNoiBo.Visible = isNoibo;
        }
        #endregion
        #region Phân quyền đăng nhập
        void phanQuyen(string ma)
        {
            if (ma == "TN")
            {
                btnHoaDonBan.Enabled = false;
                enableButton(false, false, false, false, false, false, false, true, false, false);

                enableRibbonPage(true, false);

                enableRibbonPageGroup(false, false, false, false, true);
            }
            else if (ma == "QLK")
            {
                enableButton(true, true, true, true, false, false, true, false, false, true);

                enableRibbonPage(true, false);

                enableRibbonPageGroup(true, false, false, false, true);
            }
            else if (ma == "NV")
            {
                enableButton(true, true, true, true, true, true, false, false, true, false);

                enableRibbonPage(true, true);

                enableRibbonPageGroup(true, true, true, true, true);
            }
            else if (ma == "KT")
            {
                enableButton(true, false, false, false, false, false, true, true, false, false);

                enableRibbonPage(true, true);

                enableRibbonPageGroup(true, true, false, false, true);
            }
            else
            {
                enableButton(true, true, true, true, true, true, true, true, true, true);

                enableRibbonPage(true, true);

                enableRibbonPageGroup(true, true, true, true, true);
            }
        }
        #endregion

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (XtraMessageBox.Show("Bạn có chắc muốn thoát ứng dụng?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn đăng xuất tài khoản không ?","Chú ý",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
                return;
            }
            ribbonPageDanhMuc.Visible = false;
            ribbonPageThongKe.Visible = false;
            ribbonPageGroupBackup.Visible = false;

            CurrentUser.ID = null;
            CurrentUser.HoTen = null;
            
            EnableControl(false);
            lblCurrentUser.Caption = "Chào bạn: Khách";

            CloseForm(typeof(frmHang));
            CloseForm(typeof(frmChucVu));
            CloseForm(typeof(frmKhachHang));
            CloseForm(typeof(frmLoaiHang));
            CloseForm(typeof(frmNhaCungCap));
            CloseForm(typeof(frmNhanVien));
            CloseForm(typeof(frmTaiKhoan));
            CloseForm(typeof(frmHoaDonNhap));
            CloseForm(typeof(frmHoaDonBan));
            CloseForm(typeof(frmBill));
            CloseForm(typeof(Report.frmRpDTNgay));
            CloseForm(typeof(Report.frmRpDTThang));
            CloseForm(typeof(Report.frmRpDTNam));
            CloseForm(typeof(Report.frmRpDSHangHH));
            CloseForm(typeof(Report.frmRpDSSoLuongTon));
            CloseForm(typeof(frmPrintBarcode));
            CloseForm(typeof(Report.frmTienNhapHH));
            CloseForm(typeof(Report.frmLaiGop));
        }

        private void btnDoiMatKhau_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmChangePassword f = new frmChangePassword();
            f.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Caption = "Giờ: " + DateTime.Now.ToString("T");
        }

        private void btnLoaiHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(frmLoaiHang));
        }

        private void btNhaCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(frmNhaCungCap));
        }

        private void btnChucVu_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(frmChucVu));
        }

        private void btnKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(frmKhachHang));
        }

        private void btnNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(frmNhanVien));
        }

        private void btnTaiKhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(frmTaiKhoan));
        }

        private void btnHangHoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(frmHang));
        }

        private void btnHoaDonNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(frmHoaDonNhap));
        }

        private void btnHoaDonBan_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(frmHoaDonBan));
        }

        private void btnBill_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(frmBill));
        }

        private void btnThuNgay_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(Report.frmRpDTNgay));
        }

        private void btnThuThang_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(Report.frmRpDTThang));
        }

        private void btnThuNam_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(Report.frmRpDTNam));
        }

        private void btnDSHangHH_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(Report.frmRpDSHangHH));
        }

        private void btnSLton_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(Report.frmRpDSSoLuongTon));
        }

        private void btnBackup_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmBackup f = new frmBackup();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }

        private void btnRestore_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRestore f = new frmRestore();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
        }
        private void btnPrintBarcode_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(frmPrintBarcode));
        }

        private void btnChiNhapHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(Report.frmTienNhapHH));
        }

        private void btnLaiGop_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenForm(typeof(Report.frmLaiGop));
        }
    }
}
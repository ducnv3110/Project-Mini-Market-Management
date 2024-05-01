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
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.XtraSplashScreen;

namespace GUI_QuanLyBachHoa
{
    public partial class frmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        BUS_NhanVien busNV = new BUS_NhanVien(); // khởi tạo bus layer
        BindingSource bs = new BindingSource();// khởi tạo bindingsource
        BUS_Function func = new BUS_Function(); // khởi tạo bus layer
        List<DTO_NhanVien> lstNV = new List<DTO_NhanVien>(); // khởi tạo list<> chứ entity Nhân Viên
        bool them = false;
        public frmNhanVien()
        {
            InitializeComponent();

            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;// chọn 1 hàng trên datagridview

            func.FillCombo("tblChucVu", cboMaCV, "TenCV", "MaCV"); // load combobox

            dgvNhanVien.CellFormatting += dgvNhanVien_CellFormatting;// format dữ liệu của datagridview

            //định dạng datetimepicker theo vùng Việt Nam
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
        }

        

        void loadDatabinding()
        {
            bs.DataSource = busNV.getNhanVien();

            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("text", bs, "MaNV", true);

            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("text", bs, "TenNV", true);

            txtCMND.DataBindings.Clear();
            txtCMND.DataBindings.Add("text", bs, "CMND", true);

            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("text", bs, "SDT", true);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("text", bs, "DiaChi", true);

            dtpNgaySinh.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Add("value", bs, "NgaySinh", true);

            ckPhai.DataBindings.Clear();
            ckPhai.DataBindings.Add("checked", bs, "Phai", true);

            cboMaCV.DataBindings.Clear();
            cboMaCV.DataBindings.Add("text", bs, "TenCV", true);

            bindingNavigatorChung.BindingSource = bs;
            dgvNhanVien.DataSource = bs;

            lstNV = busNV.getListNV();
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
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            enableButton(true);
            txtMaNV.Enabled = false;
            loadDatabinding();
        }

        #region Các chức năng nút
        public void btThem()
        {
            bs.AddNew();
            them = true;
          
            txtTenNV.Focus();
            enableButton(false);
        }
        void btSua()
        {
            txtTenNV.Focus();
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
                if (busNV.xoaNhanVien(txtMaNV.Text) != 0)
                {
                    XtraMessageBox.Show("Xoá dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Xoá dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            frmNhanVien_Load(sender, e);
                
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!KiemTraTenNV() || !KiemTraCMND() ||  !KiemTraNgaySinh() || !KiemTraMaChucVu() || !KiemTraSDT() || !KiemTraDiaChi())
            {
                return;
            }
            DTO_NhanVien nv = new DTO_NhanVien(txtMaNV.Text, txtTenNV.Text, txtCMND.Text, dtpNgaySinh.Value, ckPhai.Checked, txtSDT.Text, txtDiaChi.Text, cboMaCV.SelectedValue.ToString());
            if (them == true)// tiến hành lưu thông tin nhân viên khi thêm mới
            {
                if (busNV.themNhanVien(nv) != 0)
                {
                    XtraMessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Thêm dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                them = false;
            }
            else // tiến hành lưu thông tin nhân viên khi sửa
            {
                if (busNV.suaNhanVien(nv) != 0)
                {
                    XtraMessageBox.Show("Cập nhật dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Cập nhật dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            frmNhanVien_Load(sender, e);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            bs.CancelEdit(); // reset bindingsource
            them = false;
            frmNhanVien_Load(sender, e);
        }
        #region Xử lý chức năng tìm
        void loadDatatim()
        {
            bs.DataSource = busNV.timNhanVien(txtTim.Text);

            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("text", bs, "MaNV", true);

            txtTenNV.DataBindings.Clear();
            txtTenNV.DataBindings.Add("text", bs, "TenNV", true);

            txtCMND.DataBindings.Clear();
            txtCMND.DataBindings.Add("text", bs, "CMND", true);

            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("text", bs, "SDT", true);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("text", bs, "DiaChi", true);

            dtpNgaySinh.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Add("value", bs, "NgaySinh", true);

            ckPhai.DataBindings.Clear();
            ckPhai.DataBindings.Add("checked", bs, "Phai", true);

            cboMaCV.DataBindings.Clear();
            cboMaCV.DataBindings.Add("text", bs, "TenCV", true);

            bindingNavigatorChung.BindingSource = bs;
            dgvNhanVien.DataSource = bs;
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
        /// <summary>
        /// format các dữ liệu sang dạng text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (e.Value.ToString().Equals("True"))
                    e.Value = "Nữ";
                else
                    e.Value = "Nam";
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

        private bool KiemTraTenNV()
        {
            if (KiemTraRong(txtTenNV, "Tên nhân viên không được để trống"))
            {
                return false;
            }
            return true;
        }

        private bool KiemTraCMND()
        {
            if (KiemTraRong(txtCMND, "CMND không được để trống"))
            {
                return false;
            }
            if (!func.Check(BUS_Function.ValidateType.CMND, txtCMND.Text.Trim()))
            {
                XtraMessageBox.Show("CMND không hợp lệ");
                txtCMND.Focus();
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
            if(KiemTraRong(txtDiaChi, "Địa chỉ không được để trống"))
            {
                return false;
            }
            return true;
        }

        private bool KiemTraMaChucVu()
        {
            if (KiemTraRong(cboMaCV,"Mã chức vụ không được để trống"))
            {
                return false;
            }
            return true;
        }

        private bool KiemTraNgaySinh()
        {
            DateTime ngayHienTai = DateTime.Now;
            DateTime ngaySinh = dtpNgaySinh.Value;

            if (ngayHienTai < ngaySinh)
            {
                XtraMessageBox.Show("Ngày sinh không thể lớn hơn ngày hiện tại", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return false;
            }
            else if (ngayHienTai.AddYears(-18) < ngaySinh)
            {
                XtraMessageBox.Show("Nhân viên chưa đủ tuổi", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return false;
            }
            return true;
        }
        #endregion

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            _exportExcel();
        }
        #region export to Excel
        void _exportExcel()
        {
            string tenFile = "";
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel 2007 or higher (.xlsx)|*.xlsx|Excel 2000-2003 (.xls)|*.xls";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                SplashScreenManager.ShowForm(this, typeof(frmWaiting), true, true, false);
                tenFile = saveFile.FileName;
            }

            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
            Excel._Worksheet sheet = null;

            try
            {
                sheet = wb.ActiveSheet;
                //Đặt tên sheet
                sheet.Name = "Danh sách nhân viên";
                sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, 8]].Merge();
                //Canh lề text
                sheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                //border
                sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, 8]].BorderAround(Type.Missing, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic);
                sheet.Cells[1, 1].Value = "DANH SÁCH NHÂN VIÊN";
                sheet.Cells[1, 1].Font.Size = 20;

                sheet.Cells[2, 1].Value = "Mã nhân viên";
                sheet.Cells[2, 2].Value = "Tên nhân viên";
                sheet.Cells[2, 3].Value = "CMND";
                sheet.Cells[2, 4].Value = "Ngày sinh";
                sheet.Cells[2, 5].Value = "Giới tính";
                sheet.Cells[2, 6].Value = "Tên chức vụ";
                sheet.Cells[2, 7].Value = "Số điện thoại";
                sheet.Cells[2, 8].Value = "Địa chỉ";

                //format CMND 12 digits
                Excel.Range formatRangeCMND = sheet.get_Range("c1", "c999");
                formatRangeCMND.NumberFormat = "#";

                //fortmat sdt
                Excel.Range formatRangeSDT = sheet.get_Range("g1", "g999");
                formatRangeSDT.NumberFormat = "@";
                //xuất dữ liệu

                for (int i = 1; i <= lstNV.Count; i++)
                {
                    sheet.Cells[i + 2, 1].Value = lstNV.ElementAt(i - 1).MaNV;
                    sheet.Cells[i + 2, 2].Value = lstNV.ElementAt(i - 1).TenNV;
                    sheet.Cells[i + 2, 3].Value = lstNV.ElementAt(i - 1).CMND;

                    DateTime dateOfBirthNV = lstNV.ElementAt(i - 1).NgaySinh;
                    sheet.Cells[i + 2, 4].Value = dateOfBirthNV.ToString("dd/MM/yyyy");

                    bool gt = lstNV.ElementAt(i - 1).Phai;
                    if (gt)
                    {
                        sheet.Cells[i + 2, 5].Value = "Nữ";
                    }
                    else
                    {
                        sheet.Cells[i + 2, 5].Value = "Nam";
                    }

                    sheet.Cells[i + 2, 6].Value = lstNV.ElementAt(i - 1).MaCV;
                    sheet.Cells[i + 2, 7].Value = lstNV.ElementAt(i - 1).SDT;
                    sheet.Cells[i + 2, 8].Value = lstNV.ElementAt(i - 1).DiaChi;
                }
                sheet.Columns.AutoFit();
                //save vào file
                wb.SaveAs(tenFile);
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(true);
                XtraMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                wb.Close(true);
                app.Quit();
                releaseObject(wb);
                releaseObject(app);
                SplashScreenManager.CloseForm(true);
                XtraMessageBox.Show("Xuất file thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                XtraMessageBox.Show("Exception occured while releasing object " + ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion

    }
}
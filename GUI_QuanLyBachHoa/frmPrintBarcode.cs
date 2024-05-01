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
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;

namespace GUI_QuanLyBachHoa
{
    public partial class frmPrintBarcode : DevExpress.XtraEditors.XtraForm
    {
        BUS_Function func = new BUS_Function();
        BUS_Hang busH = new BUS_Hang();
        public frmPrintBarcode()
        {
            InitializeComponent();

            func.FillCombo("tblLoaiHang", cboLoai, "TenLoai", "MaLoai"); 
        }
        void loadData()
        {
            gcHH.DataSource = busH.getDMPrintBarcode(cboLoai.SelectedValue.ToString());
        }
        private void frmPrintBarcode_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(frmWaiting), true, true, false);
            List<DTO_PrintBarcode> lst1 = new List<DTO_PrintBarcode>();
            DTO_PrintBarcode dtobar;
            for (int i = 0; i < gvHH.RowCount; i++)
            {
                if (gvHH.GetRowCellValue(i,"SoTem") != null )
                {
                    for (int j = 0; j < int.Parse(gvHH.GetRowCellValue(i, "SoTem").ToString()); j++)
                    {
                        dtobar = new DTO_PrintBarcode();
                        dtobar.Barcode = gvHH.GetRowCellValue(i, "Barcode").ToString();
                        dtobar.TenHH = gvHH.GetRowCellValue(i, "TenHH").ToString();
                        dtobar.DonGia = float.Parse(gvHH.GetRowCellValue(i, "DonGia").ToString());
                        lst1.Add(dtobar);
                    }
                }
            }
            Report.rptPrintBarcode rpt = new Report.rptPrintBarcode();
            rpt.DataSource =lst1;
            SplashScreenManager.CloseForm(true);
            rpt.ShowPreviewDialog();
            
        }

        private void cboLoai_SelectedValueChanged(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
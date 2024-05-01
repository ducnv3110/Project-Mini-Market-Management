using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace GUI_QuanLyBachHoa.Report
{
    public partial class rptPrintBarcode : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPrintBarcode()
        {
            InitializeComponent();
            xrTen.DataBindings.Add("Text",  this.DataSource, "TenHH");
            xr_BarCode.DataBindings.Add("Text", this.DataSource, "Barcode");
            xrGia.DataBindings.Add("Text", this.DataSource, "DonGia");

        }

        private void xrGia_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = sender as XRLabel;
            string fileName = label.DataBindings[0].DataMember;
            double value = Convert.ToDouble(GetCurrentColumnValue(fileName));

            if (value == 0)
            {
                label.Text = "0 đ";
            }
            else
            {
                label.Text = string.Format("Giá : {0:N0} đ", value);
            }
        }
    }
}


namespace GUI_QuanLyBachHoa.Report
{
    partial class rptPrintBarcode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.EAN13Generator eaN13Generator1 = new DevExpress.XtraPrinting.BarCode.EAN13Generator();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrGia = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTen = new DevExpress.XtraReports.UI.XRLabel();
            this.xr_BarCode = new DevExpress.XtraReports.UI.XRBarCode();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1});
            this.TopMargin.Name = "TopMargin";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 63.45833F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(650F, 36.54167F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "BARCODE";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrGia,
            this.xrTen,
            this.xr_BarCode});
            this.Detail.HeightF = 173.9583F;
            this.Detail.MultiColumn.ColumnWidth = 200F;
            this.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnWidth;
            this.Detail.Name = "Detail";
            // 
            // xrGia
            // 
            this.xrGia.LocationFloat = new DevExpress.Utils.PointFloat(0F, 110.375F);
            this.xrGia.Multiline = true;
            this.xrGia.Name = "xrGia";
            this.xrGia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrGia.SizeF = new System.Drawing.SizeF(200F, 23.00002F);
            this.xrGia.StylePriority.UseTextAlignment = false;
            this.xrGia.Text = "xrGia";
            this.xrGia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrGia.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrGia_BeforePrint);
            // 
            // xrTen
            // 
            this.xrTen.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTen.LocationFloat = new DevExpress.Utils.PointFloat(0F, 12.375F);
            this.xrTen.Multiline = true;
            this.xrTen.Name = "xrTen";
            this.xrTen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTen.SizeF = new System.Drawing.SizeF(200F, 23F);
            this.xrTen.StylePriority.UseFont = false;
            this.xrTen.StylePriority.UseTextAlignment = false;
            this.xrTen.Text = "xrTen";
            this.xrTen.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xr_BarCode
            // 
            this.xr_BarCode.AutoModule = true;
            this.xr_BarCode.LocationFloat = new DevExpress.Utils.PointFloat(0F, 35.37499F);
            this.xr_BarCode.Name = "xr_BarCode";
            this.xr_BarCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.xr_BarCode.SizeF = new System.Drawing.SizeF(200F, 75F);
            this.xr_BarCode.StylePriority.UseTextAlignment = false;
            this.xr_BarCode.Symbology = eaN13Generator1;
            this.xr_BarCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            // 
            // rptPrintBarcode
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail});
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Version = "19.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrTen;
        private DevExpress.XtraReports.UI.XRBarCode xr_BarCode;
        private DevExpress.XtraReports.UI.XRLabel xrGia;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
    }
}

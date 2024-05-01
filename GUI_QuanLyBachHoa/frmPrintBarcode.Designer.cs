
namespace GUI_QuanLyBachHoa
{
    partial class frmPrintBarcode
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintBarcode));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gcHH = new DevExpress.XtraGrid.GridControl();
            this.gvHH = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenHH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DonGiaBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SoTem = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcHH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHH)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnPrint,
            this.btnExit});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 2;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrint)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = " Print Barcode";
            this.btnPrint.Id = 0;
            this.btnPrint.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPrint.ImageOptions.SvgImage")));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(785, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 577);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(785, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 551);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(785, 26);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 551);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Exit";
            this.btnExit.Id = 1;
            this.btnExit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExit.ImageOptions.SvgImage")));
            this.btnExit.Name = "btnExit";
            this.btnExit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboLoai);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 42);
            this.panel1.TabIndex = 4;
            // 
            // cboLoai
            // 
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.Location = new System.Drawing.Point(264, 6);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(328, 27);
            this.cboLoai.TabIndex = 1;
            this.cboLoai.SelectedValueChanged += new System.EventHandler(this.cboLoai_SelectedValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(192, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Loại hàng :";
            // 
            // gcHH
            // 
            this.gcHH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcHH.Location = new System.Drawing.Point(0, 68);
            this.gcHH.MainView = this.gvHH;
            this.gcHH.MenuManager = this.barManager1;
            this.gcHH.Name = "gcHH";
            this.gcHH.Size = new System.Drawing.Size(785, 509);
            this.gcHH.TabIndex = 5;
            this.gcHH.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHH});
            // 
            // gvHH
            // 
            this.gvHH.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaHang,
            this.TenHH,
            this.DonGiaBan,
            this.SoTem});
            this.gvHH.GridControl = this.gcHH;
            this.gvHH.Name = "gvHH";
            this.gvHH.OptionsFind.AlwaysVisible = true;
            // 
            // MaHang
            // 
            this.MaHang.Caption = "Barcode";
            this.MaHang.FieldName = "Barcode";
            this.MaHang.MaxWidth = 120;
            this.MaHang.Name = "MaHang";
            this.MaHang.OptionsColumn.AllowEdit = false;
            this.MaHang.Visible = true;
            this.MaHang.VisibleIndex = 0;
            // 
            // TenHH
            // 
            this.TenHH.Caption = "Tên Hàng";
            this.TenHH.FieldName = "TenHH";
            this.TenHH.MaxWidth = 300;
            this.TenHH.Name = "TenHH";
            this.TenHH.OptionsColumn.AllowEdit = false;
            this.TenHH.Visible = true;
            this.TenHH.VisibleIndex = 1;
            // 
            // DonGiaBan
            // 
            this.DonGiaBan.Caption = "Đơn giá";
            this.DonGiaBan.DisplayFormat.FormatString = "{0:N0}";
            this.DonGiaBan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.DonGiaBan.FieldName = "DonGia";
            this.DonGiaBan.MaxWidth = 120;
            this.DonGiaBan.Name = "DonGiaBan";
            this.DonGiaBan.OptionsColumn.AllowEdit = false;
            this.DonGiaBan.Visible = true;
            this.DonGiaBan.VisibleIndex = 2;
            // 
            // SoTem
            // 
            this.SoTem.AppearanceCell.Options.UseTextOptions = true;
            this.SoTem.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SoTem.Caption = "Số Lượng Tem";
            this.SoTem.FieldName = "SoTem";
            this.SoTem.Name = "SoTem";
            this.SoTem.Visible = true;
            this.SoTem.VisibleIndex = 3;
            // 
            // frmPrintBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(785, 600);
            this.Controls.Add(this.gcHH);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmPrintBarcode";
            this.Text = "Print Barcode";
            this.Load += new System.EventHandler(this.frmPrintBarcode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcHH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvHH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboLoai;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gcHH;
        private DevExpress.XtraGrid.Views.Grid.GridView gvHH;
        private DevExpress.XtraGrid.Columns.GridColumn MaHang;
        private DevExpress.XtraGrid.Columns.GridColumn TenHH;
        private DevExpress.XtraGrid.Columns.GridColumn DonGiaBan;
        private DevExpress.XtraGrid.Columns.GridColumn SoTem;
    }
}
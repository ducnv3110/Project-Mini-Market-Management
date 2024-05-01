namespace GUI_QuanLyBachHoa
{
    partial class frmChucVu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChucVu));
            this.txtMaCV = new System.Windows.Forms.TextBox();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.btnThem = new System.Windows.Forms.ToolStripButton();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.btnLuu = new System.Windows.Forms.ToolStripButton();
            this.btnBoQua = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.btnTim = new System.Windows.Forms.ToolStripButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtTenCV = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtTim = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorChung = new System.Windows.Forms.BindingNavigator(this.components);
            this.gcChucVu = new DevExpress.XtraGrid.GridControl();
            this.gvChucVu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaCV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenCV = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorChung)).BeginInit();
            this.bindingNavigatorChung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcChucVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChucVu)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaCV
            // 
            this.txtMaCV.Location = new System.Drawing.Point(98, 42);
            this.txtMaCV.Name = "txtMaCV";
            this.txtMaCV.Size = new System.Drawing.Size(184, 26);
            this.txtMaCV.TabIndex = 7;
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(32, 35);
            this.bindingNavigatorMoveFirstItem.Text = "Đầu";
            this.bindingNavigatorMoveFirstItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(40, 35);
            this.bindingNavigatorMovePreviousItem.Text = "Trước";
            this.bindingNavigatorMovePreviousItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(36, 35);
            this.bindingNavigatorMoveLastItem.Text = "Cuối";
            this.bindingNavigatorMoveLastItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnThem
            // 
            this.btnThem.Image = global::GUI_QuanLyBachHoa.Properties.Resources.add;
            this.btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(41, 35);
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Image = global::GUI_QuanLyBachHoa.Properties.Resources.edit;
            this.btnSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(30, 35);
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = global::GUI_QuanLyBachHoa.Properties.Resources.delete;
            this.btnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(31, 35);
            this.btnXoa.Text = "Xoá";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = global::GUI_QuanLyBachHoa.Properties.Resources.save_file;
            this.btnLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(31, 35);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnBoQua
            // 
            this.btnBoQua.Image = global::GUI_QuanLyBachHoa.Properties.Resources.refresh_button;
            this.btnBoQua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(48, 35);
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(30, 35);
            this.bindingNavigatorMoveNextItem.Text = "Sau";
            this.bindingNavigatorMoveNextItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnTim
            // 
            this.btnTim.Image = global::GUI_QuanLyBachHoa.Properties.Resources.search;
            this.btnTim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(31, 35);
            this.btnTim.Text = "Tìm";
            this.btnTim.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 45);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mã chức vụ :";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtTenCV);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtMaCV);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 38);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(297, 610);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "Thông tin";
            // 
            // txtTenCV
            // 
            this.txtTenCV.Location = new System.Drawing.Point(98, 89);
            this.txtTenCV.Name = "txtTenCV";
            this.txtTenCV.Size = new System.Drawing.Size(184, 26);
            this.txtTenCV.TabIndex = 9;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 92);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(82, 19);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Tên chức vụ :";
            // 
            // txtTim
            // 
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(100, 38);
            this.txtTim.TextChanged += new System.EventHandler(this.txtTim_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 38);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(29, 35);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorChung
            // 
            this.bindingNavigatorChung.AddNewItem = null;
            this.bindingNavigatorChung.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigatorChung.CountItemFormat = "/ {0}";
            this.bindingNavigatorChung.DeleteItem = null;
            this.bindingNavigatorChung.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.btnThem,
            this.btnSua,
            this.btnXoa,
            this.toolStripSeparator1,
            this.btnLuu,
            this.btnBoQua,
            this.toolStripSeparator2,
            this.btnTim,
            this.txtTim});
            this.bindingNavigatorChung.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigatorChung.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigatorChung.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigatorChung.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigatorChung.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigatorChung.Name = "bindingNavigatorChung";
            this.bindingNavigatorChung.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigatorChung.Size = new System.Drawing.Size(784, 38);
            this.bindingNavigatorChung.TabIndex = 5;
            // 
            // gcChucVu
            // 
            this.gcChucVu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcChucVu.Location = new System.Drawing.Point(300, 38);
            this.gcChucVu.MainView = this.gvChucVu;
            this.gcChucVu.Name = "gcChucVu";
            this.gcChucVu.Size = new System.Drawing.Size(484, 610);
            this.gcChucVu.TabIndex = 7;
            this.gcChucVu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvChucVu});
            // 
            // gvChucVu
            // 
            this.gvChucVu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaCV,
            this.TenCV});
            this.gvChucVu.GridControl = this.gcChucVu;
            this.gvChucVu.Name = "gvChucVu";
            this.gvChucVu.OptionsView.ShowGroupPanel = false;
            // 
            // MaCV
            // 
            this.MaCV.Caption = "Mã Chức Vụ";
            this.MaCV.FieldName = "MaCV";
            this.MaCV.MaxWidth = 100;
            this.MaCV.MinWidth = 100;
            this.MaCV.Name = "MaCV";
            this.MaCV.Visible = true;
            this.MaCV.VisibleIndex = 0;
            this.MaCV.Width = 100;
            // 
            // TenCV
            // 
            this.TenCV.Caption = "Tên Chức Vụ";
            this.TenCV.FieldName = "TenCV";
            this.TenCV.Name = "TenCV";
            this.TenCV.Visible = true;
            this.TenCV.VisibleIndex = 1;
            this.TenCV.Width = 150;
            // 
            // frmChucVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 648);
            this.Controls.Add(this.gcChucVu);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.bindingNavigatorChung);
            this.Name = "frmChucVu";
            this.Text = "Thông tin chức vụ";
            this.Load += new System.EventHandler(this.frmChucVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorChung)).EndInit();
            this.bindingNavigatorChung.ResumeLayout(false);
            this.bindingNavigatorChung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcChucVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChucVu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtMaCV;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripButton btnThem;
        private System.Windows.Forms.ToolStripButton btnSua;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripButton btnLuu;
        private System.Windows.Forms.ToolStripButton btnBoQua;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton btnTim;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.ToolStripTextBox txtTim;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.BindingNavigator bindingNavigatorChung;
        private System.Windows.Forms.TextBox txtTenCV;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl gcChucVu;
        private DevExpress.XtraGrid.Views.Grid.GridView gvChucVu;
        private DevExpress.XtraGrid.Columns.GridColumn MaCV;
        private DevExpress.XtraGrid.Columns.GridColumn TenCV;
    }
}
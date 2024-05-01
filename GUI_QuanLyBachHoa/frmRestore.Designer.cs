
namespace GUI_QuanLyBachHoa
{
    partial class frmRestore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRestore));
            this.btnRestore = new DevExpress.XtraEditors.SimpleButton();
            this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.txtURL = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtURL.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRestore
            // 
            this.btnRestore.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBackup.ImageOptions.SvgImage")));
            this.btnRestore.Location = new System.Drawing.Point(257, 44);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(111, 37);
            this.btnRestore.TabIndex = 7;
            this.btnRestore.Text = "Restore";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBrowse.ImageOptions.SvgImage")));
            this.btnBrowse.Location = new System.Drawing.Point(374, 14);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(111, 24);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(72, 12);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(296, 26);
            this.txtURL.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 19);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Chọn file :";
            // 
            // frmRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 97);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmRestore";
            this.Text = "Data Restore";
            this.Load += new System.EventHandler(this.frmRestore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtURL.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnRestore;
        private DevExpress.XtraEditors.SimpleButton btnBrowse;
        private DevExpress.XtraEditors.TextEdit txtURL;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
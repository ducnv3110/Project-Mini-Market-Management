
namespace GUI_QuanLyBachHoa
{
    partial class frmBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackup));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtURL = new DevExpress.XtraEditors.TextEdit();
            this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.btnBackup = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtURL.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(119, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Đường dẫn lưu file :";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(137, 9);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(296, 26);
            this.txtURL.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.btnBrowse.Location = new System.Drawing.Point(439, 11);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(111, 24);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage1")));
            this.btnBackup.Location = new System.Drawing.Point(273, 41);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(111, 37);
            this.btnBackup.TabIndex = 3;
            this.btnBackup.Text = "Backup";
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // frmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 95);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmBackup";
            this.Text = "Data Backup";
            this.Load += new System.EventHandler(this.frmBackup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtURL.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtURL;
        private DevExpress.XtraEditors.SimpleButton btnBrowse;
        private DevExpress.XtraEditors.SimpleButton btnBackup;
    }
}
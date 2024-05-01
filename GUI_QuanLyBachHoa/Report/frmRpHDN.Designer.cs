
namespace GUI_QuanLyBachHoa.Report
{
    partial class frmRpHDN
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
            this.cRVHDN = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVHDN
            // 
            this.cRVHDN.ActiveViewIndex = -1;
            this.cRVHDN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVHDN.Cursor = System.Windows.Forms.Cursors.Default;
            this.cRVHDN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVHDN.Location = new System.Drawing.Point(0, 0);
            this.cRVHDN.Name = "cRVHDN";
            this.cRVHDN.Size = new System.Drawing.Size(727, 555);
            this.cRVHDN.TabIndex = 0;
            this.cRVHDN.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmRpHDN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 555);
            this.Controls.Add(this.cRVHDN);
            this.Name = "frmRpHDN";
            this.Text = "Hoá đơn nhập mua";
            this.Load += new System.EventHandler(this.frmRpHDN_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVHDN;
    }
}
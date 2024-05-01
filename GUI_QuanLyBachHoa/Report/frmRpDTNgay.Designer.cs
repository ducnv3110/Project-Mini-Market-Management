
namespace GUI_QuanLyBachHoa.Report
{
    partial class frmRpDTNgay
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
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cRVdTN = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // dtpNgay
            // 
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgay.Location = new System.Drawing.Point(326, 12);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(126, 26);
            this.dtpNgay.TabIndex = 0;
            this.dtpNgay.ValueChanged += new System.EventHandler(this.dtpNgay_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(260, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ngày :";
            // 
            // cRVdTN
            // 
            this.cRVdTN.ActiveViewIndex = -1;
            this.cRVdTN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cRVdTN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVdTN.Cursor = System.Windows.Forms.Cursors.Default;
            this.cRVdTN.Location = new System.Drawing.Point(-1, 44);
            this.cRVdTN.Name = "cRVdTN";
            this.cRVdTN.Size = new System.Drawing.Size(714, 489);
            this.cRVdTN.TabIndex = 2;
            this.cRVdTN.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmRpDTNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 534);
            this.Controls.Add(this.cRVdTN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpNgay);
            this.Name = "frmRpDTNgay";
            this.Text = "Doanh thu ngày";
            this.Load += new System.EventHandler(this.frmRpDTNgay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVdTN;
    }
}
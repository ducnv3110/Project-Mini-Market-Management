
namespace GUI_QuanLyBachHoa.Report
{
    partial class frmRpDTThang
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.cRVdTT = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(239, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng :";
            // 
            // cboThang
            // 
            this.cboThang.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Location = new System.Drawing.Point(298, 9);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(175, 27);
            this.cboThang.TabIndex = 1;
            this.cboThang.SelectedValueChanged += new System.EventHandler(this.cboThang_SelectedValueChanged);
            // 
            // cRVdTT
            // 
            this.cRVdTT.ActiveViewIndex = -1;
            this.cRVdTT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cRVdTT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVdTT.Cursor = System.Windows.Forms.Cursors.Default;
            this.cRVdTT.Location = new System.Drawing.Point(0, 49);
            this.cRVdTT.Name = "cRVdTT";
            this.cRVdTT.Size = new System.Drawing.Size(716, 530);
            this.cRVdTT.TabIndex = 2;
            this.cRVdTT.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmRpDTThang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 576);
            this.Controls.Add(this.cRVdTT);
            this.Controls.Add(this.cboThang);
            this.Controls.Add(this.label1);
            this.Name = "frmRpDTThang";
            this.Text = "Doanh thu tháng";
            this.Load += new System.EventHandler(this.frmRpDTThang_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboThang;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVdTT;
    }
}
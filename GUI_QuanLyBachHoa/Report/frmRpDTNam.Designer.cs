
namespace GUI_QuanLyBachHoa.Report
{
    partial class frmRpDTNam
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
            this.txtNam = new System.Windows.Forms.TextBox();
            this.cRVdTN = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Năm :";
            // 
            // txtNam
            // 
            this.txtNam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNam.Location = new System.Drawing.Point(347, 10);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(118, 26);
            this.txtNam.TabIndex = 1;
            this.txtNam.TextChanged += new System.EventHandler(this.txtNam_TextChanged);
            this.txtNam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNam_KeyPress);
            // 
            // cRVdTN
            // 
            this.cRVdTN.ActiveViewIndex = -1;
            this.cRVdTN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cRVdTN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVdTN.Cursor = System.Windows.Forms.Cursors.Default;
            this.cRVdTN.Location = new System.Drawing.Point(1, 42);
            this.cRVdTN.Name = "cRVdTN";
            this.cRVdTN.Size = new System.Drawing.Size(759, 521);
            this.cRVdTN.TabIndex = 2;
            this.cRVdTN.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmRpDTNam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 560);
            this.Controls.Add(this.cRVdTN);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.label1);
            this.Name = "frmRpDTNam";
            this.Text = "Doanh thu theo năm";
            this.Load += new System.EventHandler(this.frmRpDTNam_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNam;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVdTN;
    }
}
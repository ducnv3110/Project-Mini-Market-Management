
namespace GUI_QuanLyBachHoa.Report
{
    partial class frmRpHDB
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
            this.cRVhDB = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cRVhDB
            // 
            this.cRVhDB.ActiveViewIndex = -1;
            this.cRVhDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cRVhDB.Cursor = System.Windows.Forms.Cursors.Default;
            this.cRVhDB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRVhDB.Location = new System.Drawing.Point(0, 0);
            this.cRVhDB.Name = "cRVhDB";
            this.cRVhDB.Size = new System.Drawing.Size(734, 511);
            this.cRVhDB.TabIndex = 0;
            this.cRVhDB.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmRpHDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 511);
            this.Controls.Add(this.cRVhDB);
            this.Name = "frmRpHDB";
            this.Text = "Hoá đơn GTGT";
            this.Load += new System.EventHandler(this.frmRpHDB_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer cRVhDB;
    }
}
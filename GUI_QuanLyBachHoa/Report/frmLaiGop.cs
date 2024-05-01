using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLyBachHoa.Report
{
    public partial class frmLaiGop : DevExpress.XtraEditors.XtraForm
    {
        rpLaiGop laiGop = new rpLaiGop();
        public frmLaiGop()
        {
            InitializeComponent();
            cboThang.Items.Insert(0, "Chọn tháng...");
            for (int i = 1; i < 13; i++)
            {
                cboThang.Items.Insert(i, i);
            }
        }

        private void cboThang_SelectedValueChanged(object sender, EventArgs e)
        {
            laiGop.SetParameterValue("paraMonth", cboThang.SelectedIndex.ToString());
            crystalReportViewer1.ReportSource = laiGop;
        }

        private void frmLaiGop_Load(object sender, EventArgs e)
        {
            cboThang.SelectedIndex = 0;
            cboThang.DropDownStyle = ComboBoxStyle.DropDownList;
            crystalReportViewer1.ReportSource = laiGop;
        }
    }
}
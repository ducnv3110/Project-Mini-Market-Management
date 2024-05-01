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
    public partial class frmRpDTNam : DevExpress.XtraEditors.XtraForm
    {
        rpDoanhThuNam dtn = new rpDoanhThuNam();
        public frmRpDTNam()
        {
            InitializeComponent();

            dtn.SetParameterValue("paraYear", txtNam.Text);
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void frmRpDTNam_Load(object sender, EventArgs e)
        {
            cRVdTN.ReportSource = dtn;
        }

        private void txtNam_TextChanged(object sender, EventArgs e)
        {
            dtn.SetParameterValue("paraYear", txtNam.Text);

            if (txtNam.Text.Length == 4)
            {
                cRVdTN.ReportSource = dtn;
            }
            
        }
    }
}
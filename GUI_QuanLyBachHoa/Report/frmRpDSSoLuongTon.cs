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
    public partial class frmRpDSSoLuongTon : DevExpress.XtraEditors.XtraForm
    {
        rpSoLuongTon slt = new rpSoLuongTon();
        public frmRpDSSoLuongTon()
        {
            InitializeComponent();
        }

        private void frmRpDSSoLuongTon_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = slt;
        }
    }
}
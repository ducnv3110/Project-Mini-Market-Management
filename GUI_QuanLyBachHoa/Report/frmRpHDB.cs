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
    public partial class frmRpHDB : DevExpress.XtraEditors.XtraForm
    {
        rpHDBan hdb = new rpHDBan();
        public frmRpHDB(string ma , string tien)
        {
            InitializeComponent();
            hdb.SetParameterValue("paraHD", ma);
            hdb.SetParameterValue("paraTien", tien);
        }

        private void frmRpHDB_Load(object sender, EventArgs e)
        {
            cRVhDB.ReportSource = hdb;
        }
    }
}
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
    public partial class frmRpDTNgay : DevExpress.XtraEditors.XtraForm
    {
        rpDoanhThuNgay dtn = new rpDoanhThuNgay();
        public frmRpDTNgay()
        {
            InitializeComponent();
            dtn.SetParameterValue("paraNgay", dtpNgay.Value.ToString("MM/dd/yyyy"));
        }

        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            dtn.SetParameterValue("paraNgay", dtpNgay.Value.ToString("MM/dd/yyyy"));
            cRVdTN.ReportSource = dtn;
        }

        private void frmRpDTNgay_Load(object sender, EventArgs e)
        {
            cRVdTN.ReportSource = dtn;
        }
    }
}
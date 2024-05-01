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
    public partial class frmRpDTThang : DevExpress.XtraEditors.XtraForm
    {
        rpDoanhThuThang dtt = new rpDoanhThuThang();
        public frmRpDTThang()
        {
            InitializeComponent();
            cboThang.Items.Insert(0, "Chọn tháng...");
            for (int i = 1; i < 13; i++)
            {
                cboThang.Items.Insert(i,i);
            }
            //dtt.SetParameterValue("paraMonth", DateTime.Now.ToString("MM"));
        }

        private void frmRpDTThang_Load(object sender, EventArgs e)
        {
            cboThang.SelectedIndex = 0;
            cboThang.DropDownStyle = ComboBoxStyle.DropDownList;
            cRVdTT.ReportSource = dtt;
        }

        private void cboThang_SelectedValueChanged(object sender, EventArgs e)
        {
            dtt.SetParameterValue("paraMonth", cboThang.SelectedIndex.ToString());
            cRVdTT.ReportSource = dtt;
        }

       
    }
}
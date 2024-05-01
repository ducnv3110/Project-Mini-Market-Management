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
using System.Data.SqlClient;
using DevExpress.XtraSplashScreen;

namespace GUI_QuanLyBachHoa
{
    public partial class frmBackup : DevExpress.XtraEditors.XtraForm
    {
        public frmBackup()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source = localhost\sqlexpress;Initial Catalog = QLBachHoa; Integrated Security = True");
        private void frmBackup_Load(object sender, EventArgs e)
        {
            txtURL.Enabled = false;
            btnBackup.Enabled = false;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                txtURL.Text = fb.SelectedPath;
                btnBackup.Enabled = true;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string db = conn.Database.ToString();
            if (string.IsNullOrEmpty(txtURL.Text))
            {
                XtraMessageBox.Show("Vui lòng chọn đường dẫn lưu file", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SplashScreenManager.ShowForm(this, typeof(frmWaiting), true, true, false);
                string sql = "BACKUP DATABASE [" + db + "] TO DISK = '" + txtURL.Text + "\\" + db + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") +".bak'";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                SplashScreenManager.CloseForm(true);
                XtraMessageBox.Show("Backup dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBackup.Enabled = false;
            }
        }
    }
}
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLyBachHoa
{
    public partial class frmRestore : DevExpress.XtraEditors.XtraForm
    {
        public frmRestore()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source = localhost\sqlexpress;Initial Catalog = QLBachHoa; Integrated Security = True");
        private void frmRestore_Load(object sender, EventArgs e)
        {
            txtURL.Enabled = false;
            btnRestore.Enabled = false;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Backup file (.bak)|*.bak";
            openFile.Title = "Phục hồi dữ liệu";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtURL.Text = openFile.FileName;
                btnRestore.Enabled = true;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            string db = conn.Database.ToString();

            try
            {
                SplashScreenManager.ShowForm(this, typeof(frmWaiting), true, true, false);

                conn.Open();

                string sql1 = "ALTER DATABASE [" + db + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.ExecuteNonQuery();

                string sql2 = "USE MASTER RESTORE DATABASE [" + db + "] FROM DISK='" + txtURL.Text + "' WITH REPLACE";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.ExecuteNonQuery();

                string sql3 = "ALTER DATABASE [" + db + "] SET MULTI_USER";
                SqlCommand cmd3 = new SqlCommand(sql3, conn);
                cmd3.ExecuteNonQuery();

                conn.Close();

                SplashScreenManager.CloseForm(true);

                XtraMessageBox.Show("Khôi phục dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRestore.Enabled = false;
            }
            catch (Exception)
            {
                btnRestore.Enabled = false;
                XtraMessageBox.Show("Khôi phục dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
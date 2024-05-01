using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DTO_QuanLyBachHoa;
using BUS_QuanLyBachHoa;
using BUS_QuanLyBachHoa.Functions;
using System.Data.SqlClient;

namespace GUI_QuanLyBachHoa
{
    public partial class frmConnect : DevExpress.XtraEditors.XtraForm
    {
        public frmConnect()
        {
            InitializeComponent();
        }

        private void frmConnect_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "Kết nối đến CSDL thất bại.\nVui lòng thiết lập lại thông số kết nối đến CSDL.";
            cbbAuthen.Items.Add("Windows Authentication");
            cbbAuthen.Items.Add("SQL Server Authentication");
            cbbAuthen.SelectedIndex = 0;
        }

        private void frmConnect_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void EnableSqlAuthenticationMode(bool b)
        {
            lblUserName.Enabled = b;
            lblPassword.Enabled = b;
            txtUserName.Enabled = b;
            txtPassword.Enabled = b;
        }

        private void cbbAuthen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbAuthen.SelectedIndex == 0)
                EnableSqlAuthenticationMode(false);
            else
                EnableSqlAuthenticationMode(true);
        }

        private void btnLayDS_Click(object sender, EventArgs e)
        {
            string conn;
            if (cbbAuthen.SelectedIndex == 0)
                conn = @"Data Source=" + txtServerName.Text.Trim() + ";Initial Catalog=master;Integrated Security=True";
            else
                conn = @"Data Source=" + txtServerName.Text.Trim() + ";Initial Catalog=master;User ID=" + txtUserName.Text.Trim() + ";password=" + txtPassword.Text.Trim();

            SqlConnection cnn = new SqlConnection(conn);
            try
            {
                cnn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT name FROM sys.databases WHERE name NOT IN ('master','model','msdb','tempdb')", cnn);

                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                cnn.Close();

                cbbDS.DataSource = dt;
                cbbDS.DisplayMember = "name";
                cbbDS.ValueMember = "name";

                lblChonCSDL.Enabled = true;
                cbbDS.Enabled = true;

                btnLayDS.Enabled = false;
                btnKetNoi.Enabled = true;

                lblServerName.Enabled = false;
                txtServerName.Enabled = false;

                cbbAuthen.Enabled = false;

                EnableSqlAuthenticationMode(false);
            }
            catch (Exception ex)
            {
                btnKetNoi.Enabled = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            if (cbbDS.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn 1 cơ sở dữ liệu.");
                return;
            }
            string cnnstr;
            if (cbbAuthen.SelectedIndex == 0)
                cnnstr = @"Data Source=" + txtServerName.Text.Trim() + "; Initial Catalog=" + cbbDS.SelectedValue.ToString() + ";Integrated Security=True";
            else
                cnnstr = @"Data Source=" + txtServerName.Text.Trim() + "; Initial Catalog=" + cbbDS.SelectedValue.ToString() + ";User ID=" + txtUserName.Text.Trim() + ";password=" + txtPassword.Text.Trim();

            SqlConnection cnn = new SqlConnection(cnnstr);
            cnn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_kiem_tra_ket_noi", cnn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                bool flag = (bool)cmd.ExecuteScalar();

                cmd.Dispose();
                cnn.Close();

                if (flag)
                {
                    System.IO.File.WriteAllText("connectionString.txt", cnnstr);
                    this.Hide();
                    new frmMain().Show();
                }
                else
                    XtraMessageBox.Show("Vui lòng chọn đúng cơ sở dữ liệu. Mặc định là QLBachHoa.");



            }
            catch
            {
                cnn.Close();
                XtraMessageBox.Show("Vui lòng chọn đúng cơ sở dữ liệu. Mặc định là QLBachHoa.");
                return;

            }
        }
    }
}

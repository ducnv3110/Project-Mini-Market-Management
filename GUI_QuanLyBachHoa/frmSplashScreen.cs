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
using System.Threading;
using DTO_QuanLyBachHoa;
using BUS_QuanLyBachHoa;
using BUS_QuanLyBachHoa.Functions;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace GUI_QuanLyBachHoa
{
    public partial class frmSplashScreen : DevExpress.XtraEditors.XtraForm
    {
        #region create form Rounded Corner
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
               (
                   int nLeftRect,
                   int nTopRect,
                   int nRightRect,
                   int nBottomRect,
                   int nWith,
                   int nHeight
               );
        #endregion
        public frmSplashScreen()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            timer1.Start();
        }

        private void frmSplashScreen_Load(object sender, EventArgs e)
        {
           
            lblMessage.Text = "Đang khởi chạy...";
            Thread th = new Thread(new ThreadStart(ThreadFunction))
            {
                IsBackground = true
            };
            th.Start();
        }
        void ThreadFunction()
        {
            Thread.Sleep(2000);
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    lblMessage.Text = "Đang kiểm tra kết nối đến CDSL...";
                });
            }
            else
            {
                lblMessage.Text = "Đang kiểm tra kết nối đến CSDL. Vui lòng chờ...";
            }
                

            Thread.Sleep(1500);
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    TestConnectDatabase();
                });
            }
            else
                TestConnectDatabase();
        }
        void OpenMainForm()
        {
            Thread.Sleep(1500);
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    new frmMain().Show();
                    this.Visible = false;
                });
            }
            else
            {
                new frmMain().Show();
                this.Visible = true;
            }
        }
        void TestConnectDatabase()
        {
            KiemTraKetNoi test = new KiemTraKetNoi();

            if (!test.KiemTra())
            {
                this.Visible = true;
                new frmConnect().Show();
            }
            else
            {
                lblMessage.Text = "Kết nối thành công . Đang mở ứng dụng";
                Thread th = new Thread(new ThreadStart(OpenMainForm))
                {
                    IsBackground = true
                };
                th.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            loading.Width += 8;
            if (loading.Width >= 315)
            {
                timer1.Stop();
            }
        }
    }
}
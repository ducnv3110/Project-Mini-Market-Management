namespace GUI_QuanLyBachHoa
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.showPass = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDangNhap = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.showPass)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập :";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.BackColor = System.Drawing.SystemColors.Control;
            this.txtTenDangNhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTenDangNhap.Location = new System.Drawing.Point(26, 139);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(207, 19);
            this.txtTenDangNhap.TabIndex = 0;
            this.txtTenDangNhap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenDangNhap_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Location = new System.Drawing.Point(26, 159);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 1);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Location = new System.Drawing.Point(26, 217);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(207, 1);
            this.panel2.TabIndex = 4;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.BackColor = System.Drawing.SystemColors.Control;
            this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatKhau.Location = new System.Drawing.Point(26, 197);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(207, 19);
            this.txtMatKhau.TabIndex = 2;
            this.txtMatKhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMatKhau_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mật khẩu :";
            // 
            // showPass
            // 
            this.showPass.Image = global::GUI_QuanLyBachHoa.Properties.Resources.eye__1_;
            this.showPass.Location = new System.Drawing.Point(235, 196);
            this.showPass.Name = "showPass";
            this.showPass.Size = new System.Drawing.Size(28, 23);
            this.showPass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.showPass.TabIndex = 7;
            this.showPass.TabStop = false;
            this.showPass.MouseDown += new System.Windows.Forms.MouseEventHandler(this.showPass_MouseDown);
            this.showPass.MouseUp += new System.Windows.Forms.MouseEventHandler(this.showPass_MouseUp);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::GUI_QuanLyBachHoa.Properties.Resources.Dark_Ocean;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(-10, -6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(289, 118);
            this.panel3.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::GUI_QuanLyBachHoa.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(83, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Location = new System.Drawing.Point(17, 224);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(91, 37);
            this.btnDangNhap.TabIndex = 10;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(142, 224);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(91, 37);
            this.btnHuy.TabIndex = 11;
            this.btnHuy.Text = "Huỷ";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmLogin
            // 
            this.ActiveGlowColor = System.Drawing.SystemColors.Control;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 282);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.showPass);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDangNhap";
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showPass)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox showPass;
        private DevExpress.XtraEditors.SimpleButton btnDangNhap;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
    }
}
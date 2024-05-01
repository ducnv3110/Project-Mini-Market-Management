namespace GUI_QuanLyBachHoa
{
    partial class frmChangePassword
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
            this.txtMatKhauCu = new System.Windows.Forms.TextBox();
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNhapLaiMatKhau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.showPassMKcu = new System.Windows.Forms.PictureBox();
            this.showPassMKmoi = new System.Windows.Forms.PictureBox();
            this.showPassNhapLai = new System.Windows.Forms.PictureBox();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.showPassMKcu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showPassMKmoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showPassNhapLai)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật khẩu cũ :";
            // 
            // txtMatKhauCu
            // 
            this.txtMatKhauCu.Location = new System.Drawing.Point(171, 32);
            this.txtMatKhauCu.Name = "txtMatKhauCu";
            this.txtMatKhauCu.Size = new System.Drawing.Size(235, 26);
            this.txtMatKhauCu.TabIndex = 1;
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.Location = new System.Drawing.Point(171, 78);
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.Size = new System.Drawing.Size(235, 26);
            this.txtMatKhauMoi.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu mới :";
            // 
            // txtNhapLaiMatKhau
            // 
            this.txtNhapLaiMatKhau.Location = new System.Drawing.Point(171, 120);
            this.txtNhapLaiMatKhau.Name = "txtNhapLaiMatKhau";
            this.txtNhapLaiMatKhau.Size = new System.Drawing.Size(235, 26);
            this.txtNhapLaiMatKhau.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nhập lại mật khẩu :";
            // 
            // showPassMKcu
            // 
            this.showPassMKcu.Image = global::GUI_QuanLyBachHoa.Properties.Resources.eye__1_;
            this.showPassMKcu.Location = new System.Drawing.Point(407, 33);
            this.showPassMKcu.Name = "showPassMKcu";
            this.showPassMKcu.Size = new System.Drawing.Size(36, 25);
            this.showPassMKcu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.showPassMKcu.TabIndex = 6;
            this.showPassMKcu.TabStop = false;
            this.showPassMKcu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.showPassMKcu_MouseDown);
            this.showPassMKcu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.showPassMKcu_MouseUp);
            // 
            // showPassMKmoi
            // 
            this.showPassMKmoi.Image = global::GUI_QuanLyBachHoa.Properties.Resources.eye__1_;
            this.showPassMKmoi.Location = new System.Drawing.Point(407, 79);
            this.showPassMKmoi.Name = "showPassMKmoi";
            this.showPassMKmoi.Size = new System.Drawing.Size(36, 25);
            this.showPassMKmoi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.showPassMKmoi.TabIndex = 7;
            this.showPassMKmoi.TabStop = false;
            this.showPassMKmoi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.showPassMKmoi_MouseDown);
            this.showPassMKmoi.MouseUp += new System.Windows.Forms.MouseEventHandler(this.showPassMKmoi_MouseUp);
            // 
            // showPassNhapLai
            // 
            this.showPassNhapLai.Image = global::GUI_QuanLyBachHoa.Properties.Resources.eye__1_;
            this.showPassNhapLai.Location = new System.Drawing.Point(407, 120);
            this.showPassNhapLai.Name = "showPassNhapLai";
            this.showPassNhapLai.Size = new System.Drawing.Size(36, 25);
            this.showPassNhapLai.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.showPassNhapLai.TabIndex = 8;
            this.showPassNhapLai.TabStop = false;
            this.showPassNhapLai.MouseDown += new System.Windows.Forms.MouseEventHandler(this.showPassNhapLai_MouseDown);
            this.showPassNhapLai.MouseUp += new System.Windows.Forms.MouseEventHandler(this.showPassNhapLai_MouseUp);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(195, 151);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(91, 37);
            this.btnLuu.TabIndex = 11;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(315, 151);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(91, 37);
            this.btnHuy.TabIndex = 12;
            this.btnHuy.Text = "Huỷ";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 200);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.showPassNhapLai);
            this.Controls.Add(this.showPassMKmoi);
            this.Controls.Add(this.showPassMKcu);
            this.Controls.Add(this.txtNhapLaiMatKhau);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMatKhauMoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMatKhauCu);
            this.Controls.Add(this.label1);
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi mật khẩu";
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showPassMKcu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showPassMKmoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showPassNhapLai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMatKhauCu;
        private System.Windows.Forms.TextBox txtMatKhauMoi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNhapLaiMatKhau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox showPassMKcu;
        private System.Windows.Forms.PictureBox showPassMKmoi;
        private System.Windows.Forms.PictureBox showPassNhapLai;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
    }
}
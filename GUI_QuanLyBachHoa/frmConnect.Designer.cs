namespace GUI_QuanLyBachHoa
{
    partial class frmConnect
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
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnKetNoi = new System.Windows.Forms.Button();
            this.cbbDS = new System.Windows.Forms.ComboBox();
            this.btnLayDS = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.cbbAuthen = new System.Windows.Forms.ComboBox();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.lblChonCSDL = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(297, 336);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(71, 32);
            this.btnHuy.TabIndex = 27;
            this.btnHuy.Text = "Huỷ";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.Location = new System.Drawing.Point(178, 336);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(113, 32);
            this.btnKetNoi.TabIndex = 26;
            this.btnKetNoi.Text = "Kết nối CSDL";
            this.btnKetNoi.UseVisualStyleBackColor = true;
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // cbbDS
            // 
            this.cbbDS.FormattingEnabled = true;
            this.cbbDS.Location = new System.Drawing.Point(161, 277);
            this.cbbDS.Name = "cbbDS";
            this.cbbDS.Size = new System.Drawing.Size(207, 27);
            this.cbbDS.TabIndex = 25;
            // 
            // btnLayDS
            // 
            this.btnLayDS.Location = new System.Drawing.Point(200, 213);
            this.btnLayDS.Name = "btnLayDS";
            this.btnLayDS.Size = new System.Drawing.Size(169, 30);
            this.btnLayDS.TabIndex = 24;
            this.btnLayDS.Text = "Lấy danh sách Database";
            this.btnLayDS.UseVisualStyleBackColor = true;
            this.btnLayDS.Click += new System.EventHandler(this.btnLayDS_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(162, 172);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(207, 26);
            this.txtPassword.TabIndex = 23;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(162, 139);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(207, 26);
            this.txtUserName.TabIndex = 22;
            this.txtUserName.Text = "sa";
            // 
            // cbbAuthen
            // 
            this.cbbAuthen.FormattingEnabled = true;
            this.cbbAuthen.Location = new System.Drawing.Point(162, 105);
            this.cbbAuthen.Name = "cbbAuthen";
            this.cbbAuthen.Size = new System.Drawing.Size(207, 27);
            this.cbbAuthen.TabIndex = 21;
            this.cbbAuthen.SelectedIndexChanged += new System.EventHandler(this.cbbAuthen_SelectedIndexChanged);
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(162, 71);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(207, 26);
            this.txtServerName.TabIndex = 20;
            // 
            // lblChonCSDL
            // 
            this.lblChonCSDL.AutoSize = true;
            this.lblChonCSDL.Location = new System.Drawing.Point(54, 280);
            this.lblChonCSDL.Name = "lblChonCSDL";
            this.lblChonCSDL.Size = new System.Drawing.Size(92, 19);
            this.lblChonCSDL.TabIndex = 19;
            this.lblChonCSDL.Text = "Chọn CSDL :";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(71, 175);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(76, 19);
            this.lblPassword.TabIndex = 18;
            this.lblPassword.Text = "Password :";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(61, 142);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(86, 19);
            this.lblUserName.TabIndex = 17;
            this.lblUserName.Text = "User Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "Authentication :";
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(50, 74);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(97, 19);
            this.lblServerName.TabIndex = 15;
            this.lblServerName.Text = "Server Name :";
            // 
            // lblMessage
            // 
            this.lblMessage.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMessage.Location = new System.Drawing.Point(53, 16);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(309, 34);
            this.lblMessage.TabIndex = 14;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 396);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnKetNoi);
            this.Controls.Add(this.cbbDS);
            this.Controls.Add(this.btnLayDS);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.cbbAuthen);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.lblChonCSDL);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblServerName);
            this.Controls.Add(this.lblMessage);
            this.Name = "frmConnect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết nối CSDL";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmConnect_FormClosed);
            this.Load += new System.EventHandler(this.frmConnect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnKetNoi;
        private System.Windows.Forms.ComboBox cbbDS;
        private System.Windows.Forms.Button btnLayDS;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.ComboBox cbbAuthen;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label lblChonCSDL;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Label lblMessage;
    }
}
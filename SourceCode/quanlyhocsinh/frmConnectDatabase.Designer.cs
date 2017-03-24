namespace QuanLyHocSinh
{
    partial class frmConnectDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConnectDatabase));
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTenServer = new System.Windows.Forms.ComboBox();
            this.cbKieuXacThuc = new System.Windows.Forms.ComboBox();
            this.txbTenTaiKhoan = new System.Windows.Forms.TextBox();
            this.txbMatKhau = new System.Windows.Forms.TextBox();
            this.chbHienThiMatKhau = new System.Windows.Forms.CheckBox();
            this.txbThongTinKetNoiServer = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txbThongTinKetNoiCSDL = new System.Windows.Forms.TextBox();
            this.pnKetNoiServer = new System.Windows.Forms.Panel();
            this.btnKetNoi = new System.Windows.Forms.Button();
            this.pnKetNoiCSDL = new System.Windows.Forms.Panel();
            this.btnTaoDuLieuMau = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txbTaoCSDLMoi = new System.Windows.Forms.TextBox();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.cbTenCSDL = new System.Windows.Forms.ComboBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTaoMoi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnKetNoiServer.SuspendLayout();
            this.pnKetNoiCSDL.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("UVN Ba Le", 30F);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(189, 54);
            this.lblTitle.TabIndex = 32;
            this.lblTitle.Text = "SQL Server";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(41, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 21);
            this.label1.TabIndex = 33;
            this.label1.Text = "Tên máy chủ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(41, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 21);
            this.label2.TabIndex = 34;
            this.label2.Text = "Kiểu xác thực";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(41, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 21);
            this.label3.TabIndex = 35;
            this.label3.Text = "Người dùng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(41, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 21);
            this.label4.TabIndex = 36;
            this.label4.Text = "Mật khẩu";
            // 
            // cbTenServer
            // 
            this.cbTenServer.FormattingEnabled = true;
            this.cbTenServer.Location = new System.Drawing.Point(161, 99);
            this.cbTenServer.Name = "cbTenServer";
            this.cbTenServer.Size = new System.Drawing.Size(202, 21);
            this.cbTenServer.TabIndex = 55;
            this.cbTenServer.SelectedIndexChanged += new System.EventHandler(this.cbTenServer_SelectedIndexChanged);
            // 
            // cbKieuXacThuc
            // 
            this.cbKieuXacThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKieuXacThuc.FormattingEnabled = true;
            this.cbKieuXacThuc.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
            this.cbKieuXacThuc.Location = new System.Drawing.Point(161, 138);
            this.cbKieuXacThuc.Name = "cbKieuXacThuc";
            this.cbKieuXacThuc.Size = new System.Drawing.Size(202, 21);
            this.cbKieuXacThuc.TabIndex = 56;
            this.cbKieuXacThuc.SelectedIndexChanged += new System.EventHandler(this.cbKieuXacThuc_SelectedIndexChanged);
            // 
            // txbTenTaiKhoan
            // 
            this.txbTenTaiKhoan.Location = new System.Drawing.Point(161, 192);
            this.txbTenTaiKhoan.Name = "txbTenTaiKhoan";
            this.txbTenTaiKhoan.Size = new System.Drawing.Size(202, 20);
            this.txbTenTaiKhoan.TabIndex = 57;
            this.txbTenTaiKhoan.TextChanged += new System.EventHandler(this.txbTenTaiKhoan_TextChanged);
            // 
            // txbMatKhau
            // 
            this.txbMatKhau.Location = new System.Drawing.Point(161, 231);
            this.txbMatKhau.Name = "txbMatKhau";
            this.txbMatKhau.Size = new System.Drawing.Size(202, 20);
            this.txbMatKhau.TabIndex = 58;
            this.txbMatKhau.TextChanged += new System.EventHandler(this.txbMatKhau_TextChanged);
            // 
            // chbHienThiMatKhau
            // 
            this.chbHienThiMatKhau.AutoSize = true;
            this.chbHienThiMatKhau.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic);
            this.chbHienThiMatKhau.ForeColor = System.Drawing.SystemColors.Window;
            this.chbHienThiMatKhau.Location = new System.Drawing.Point(378, 231);
            this.chbHienThiMatKhau.Name = "chbHienThiMatKhau";
            this.chbHienThiMatKhau.Size = new System.Drawing.Size(127, 21);
            this.chbHienThiMatKhau.TabIndex = 60;
            this.chbHienThiMatKhau.Text = "Hiển thị mật khẩu";
            this.chbHienThiMatKhau.UseVisualStyleBackColor = true;
            this.chbHienThiMatKhau.CheckedChanged += new System.EventHandler(this.chbHienThiMatKhau_CheckedChanged);
            // 
            // txbThongTinKetNoiServer
            // 
            this.txbThongTinKetNoiServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txbThongTinKetNoiServer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txbThongTinKetNoiServer.Location = new System.Drawing.Point(6, 19);
            this.txbThongTinKetNoiServer.Multiline = true;
            this.txbThongTinKetNoiServer.Name = "txbThongTinKetNoiServer";
            this.txbThongTinKetNoiServer.Size = new System.Drawing.Size(312, 57);
            this.txbThongTinKetNoiServer.TabIndex = 62;
            this.txbThongTinKetNoiServer.TextChanged += new System.EventHandler(this.txbThongTinKetNoiServer_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbThongTinKetNoiServer);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(45, 270);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 82);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhật ký trạng thái kết nối đến SQL Server:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("UVN Ba Le", 30F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(235, 54);
            this.label5.TabIndex = 64;
            this.label5.Text = "Cơ Sở Dữ Liệu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.ForeColor = System.Drawing.SystemColors.Window;
            this.label6.Location = new System.Drawing.Point(23, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 21);
            this.label6.TabIndex = 65;
            this.label6.Text = "Chọn cơ sở dữ liệu";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txbThongTinKetNoiCSDL);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(45, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 85);
            this.groupBox2.TabIndex = 64;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nhật ký trạng thái kết nối đến cơ sở dữ liệu:";
            // 
            // txbThongTinKetNoiCSDL
            // 
            this.txbThongTinKetNoiCSDL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txbThongTinKetNoiCSDL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txbThongTinKetNoiCSDL.Location = new System.Drawing.Point(6, 19);
            this.txbThongTinKetNoiCSDL.Multiline = true;
            this.txbThongTinKetNoiCSDL.Name = "txbThongTinKetNoiCSDL";
            this.txbThongTinKetNoiCSDL.Size = new System.Drawing.Size(312, 60);
            this.txbThongTinKetNoiCSDL.TabIndex = 62;
            // 
            // pnKetNoiServer
            // 
            this.pnKetNoiServer.BackColor = System.Drawing.Color.Transparent;
            this.pnKetNoiServer.Controls.Add(this.lblTitle);
            this.pnKetNoiServer.Controls.Add(this.label1);
            this.pnKetNoiServer.Controls.Add(this.label2);
            this.pnKetNoiServer.Controls.Add(this.label3);
            this.pnKetNoiServer.Controls.Add(this.label4);
            this.pnKetNoiServer.Controls.Add(this.cbTenServer);
            this.pnKetNoiServer.Controls.Add(this.cbKieuXacThuc);
            this.pnKetNoiServer.Controls.Add(this.txbTenTaiKhoan);
            this.pnKetNoiServer.Controls.Add(this.txbMatKhau);
            this.pnKetNoiServer.Controls.Add(this.chbHienThiMatKhau);
            this.pnKetNoiServer.Controls.Add(this.groupBox1);
            this.pnKetNoiServer.Controls.Add(this.btnKetNoi);
            this.pnKetNoiServer.Location = new System.Drawing.Point(-3, -27);
            this.pnKetNoiServer.Name = "pnKetNoiServer";
            this.pnKetNoiServer.Size = new System.Drawing.Size(548, 353);
            this.pnKetNoiServer.TabIndex = 73;
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnKetNoi.BackgroundImage = global::QuanLyHocSinh.Properties.Resources.server;
            this.btnKetNoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKetNoi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKetNoi.Location = new System.Drawing.Point(381, 280);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(73, 66);
            this.btnKetNoi.TabIndex = 61;
            this.btnKetNoi.UseVisualStyleBackColor = false;
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // pnKetNoiCSDL
            // 
            this.pnKetNoiCSDL.BackColor = System.Drawing.Color.Transparent;
            this.pnKetNoiCSDL.Controls.Add(this.btnTaoDuLieuMau);
            this.pnKetNoiCSDL.Controls.Add(this.label7);
            this.pnKetNoiCSDL.Controls.Add(this.txbTaoCSDLMoi);
            this.pnKetNoiCSDL.Controls.Add(this.btnKiemTra);
            this.pnKetNoiCSDL.Controls.Add(this.cbTenCSDL);
            this.pnKetNoiCSDL.Controls.Add(this.label5);
            this.pnKetNoiCSDL.Controls.Add(this.label6);
            this.pnKetNoiCSDL.Controls.Add(this.btnLuu);
            this.pnKetNoiCSDL.Controls.Add(this.btnXoa);
            this.pnKetNoiCSDL.Controls.Add(this.groupBox2);
            this.pnKetNoiCSDL.Controls.Add(this.btnTaoMoi);
            this.pnKetNoiCSDL.Controls.Add(this.btnThoat);
            this.pnKetNoiCSDL.Location = new System.Drawing.Point(-3, 331);
            this.pnKetNoiCSDL.Name = "pnKetNoiCSDL";
            this.pnKetNoiCSDL.Size = new System.Drawing.Size(548, 258);
            this.pnKetNoiCSDL.TabIndex = 74;
            // 
            // btnTaoDuLieuMau
            // 
            this.btnTaoDuLieuMau.BackColor = System.Drawing.Color.Maroon;
            this.btnTaoDuLieuMau.BackgroundImage = global::QuanLyHocSinh.Properties.Resources.tao_server;
            this.btnTaoDuLieuMau.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTaoDuLieuMau.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTaoDuLieuMau.Location = new System.Drawing.Point(460, 30);
            this.btnTaoDuLieuMau.Name = "btnTaoDuLieuMau";
            this.btnTaoDuLieuMau.Size = new System.Drawing.Size(73, 68);
            this.btnTaoDuLieuMau.TabIndex = 76;
            this.btnTaoDuLieuMau.UseVisualStyleBackColor = false;
            this.btnTaoDuLieuMau.Click += new System.EventHandler(this.btnTaoDuLieuMau_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.ForeColor = System.Drawing.SystemColors.Window;
            this.label7.Location = new System.Drawing.Point(35, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 21);
            this.label7.TabIndex = 75;
            this.label7.Text = "Tên cơ sở dử liệu";
            // 
            // txbTaoCSDLMoi
            // 
            this.txbTaoCSDLMoi.Location = new System.Drawing.Point(161, 119);
            this.txbTaoCSDLMoi.Name = "txbTaoCSDLMoi";
            this.txbTaoCSDLMoi.Size = new System.Drawing.Size(202, 20);
            this.txbTaoCSDLMoi.TabIndex = 74;
            this.txbTaoCSDLMoi.TextChanged += new System.EventHandler(this.txbTaoCSDLMoi_TextChanged);
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.BackColor = System.Drawing.Color.Crimson;
            this.btnKiemTra.BackgroundImage = global::QuanLyHocSinh.Properties.Resources.server_check;
            this.btnKiemTra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKiemTra.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKiemTra.Location = new System.Drawing.Point(381, 30);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(73, 68);
            this.btnKiemTra.TabIndex = 72;
            this.btnKiemTra.UseVisualStyleBackColor = false;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // cbTenCSDL
            // 
            this.cbTenCSDL.FormattingEnabled = true;
            this.cbTenCSDL.Location = new System.Drawing.Point(161, 77);
            this.cbTenCSDL.Name = "cbTenCSDL";
            this.cbTenCSDL.Size = new System.Drawing.Size(202, 21);
            this.cbTenCSDL.TabIndex = 72;
            this.cbTenCSDL.SelectedIndexChanged += new System.EventHandler(this.cbTenCSDL_SelectedIndexChanged);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnLuu.BackgroundImage = global::QuanLyHocSinh.Properties.Resources.Luu;
            this.btnLuu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLuu.Location = new System.Drawing.Point(460, 103);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(73, 68);
            this.btnLuu.TabIndex = 71;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnXoa.BackgroundImage = global::QuanLyHocSinh.Properties.Resources.Xoa;
            this.btnXoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXoa.Location = new System.Drawing.Point(381, 174);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(73, 68);
            this.btnXoa.TabIndex = 70;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnTaoMoi
            // 
            this.btnTaoMoi.BackColor = System.Drawing.Color.DarkGreen;
            this.btnTaoMoi.BackgroundImage = global::QuanLyHocSinh.Properties.Resources.Them;
            this.btnTaoMoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTaoMoi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTaoMoi.Location = new System.Drawing.Point(381, 103);
            this.btnTaoMoi.Name = "btnTaoMoi";
            this.btnTaoMoi.Size = new System.Drawing.Size(73, 68);
            this.btnTaoMoi.TabIndex = 69;
            this.btnTaoMoi.UseVisualStyleBackColor = false;
            this.btnTaoMoi.Click += new System.EventHandler(this.btnTaoMoi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Brown;
            this.btnThoat.BackgroundImage = global::QuanLyHocSinh.Properties.Resources.Thoat;
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThoat.Location = new System.Drawing.Point(460, 174);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(73, 68);
            this.btnThoat.TabIndex = 67;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmConnectDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(0)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(544, 588);
            this.Controls.Add(this.pnKetNoiCSDL);
            this.Controls.Add(this.pnKetNoiServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmConnectDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết Nối Đến SQL Server";
            this.Load += new System.EventHandler(this.frmConnectDatabase_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnKetNoiServer.ResumeLayout(false);
            this.pnKetNoiServer.PerformLayout();
            this.pnKetNoiCSDL.ResumeLayout(false);
            this.pnKetNoiCSDL.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTenServer;
        private System.Windows.Forms.ComboBox cbKieuXacThuc;
        private System.Windows.Forms.TextBox txbTenTaiKhoan;
        private System.Windows.Forms.TextBox txbMatKhau;
        private System.Windows.Forms.CheckBox chbHienThiMatKhau;
        private System.Windows.Forms.Button btnKetNoi;
        private System.Windows.Forms.TextBox txbThongTinKetNoiServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txbThongTinKetNoiCSDL;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnTaoMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.Panel pnKetNoiServer;
        private System.Windows.Forms.Panel pnKetNoiCSDL;
        private System.Windows.Forms.ComboBox cbTenCSDL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbTaoCSDLMoi;
        private System.Windows.Forms.Button btnTaoDuLieuMau;
    }
}
namespace QuanLyHocSinh
{
    partial class frmChungChi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvBangDiem = new System.Windows.Forms.DataGridView();
            this.grbNhapLop = new System.Windows.Forms.GroupBox();
            this.combo_nienKhoa = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_dotkhaigiang = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lbMaHV = new System.Windows.Forms.Label();
            this.lbHoTen = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.gbThongTinHocSinh = new System.Windows.Forms.GroupBox();
            this.lblMaHS = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.btnXemDiem = new System.Windows.Forms.Button();
            this.btnNhapDiem = new System.Windows.Forms.Button();
            this.btnTinhDiem = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.picturebox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDiem)).BeginInit();
            this.grbNhapLop.SuspendLayout();
            this.gbThongTinHocSinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBangDiem
            // 
            this.dgvBangDiem.AllowUserToAddRows = false;
            this.dgvBangDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBangDiem.Location = new System.Drawing.Point(21, 160);
            this.dgvBangDiem.Name = "dgvBangDiem";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dgvBangDiem.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBangDiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBangDiem.Size = new System.Drawing.Size(727, 216);
            this.dgvBangDiem.TabIndex = 42;
            // 
            // grbNhapLop
            // 
            this.grbNhapLop.Controls.Add(this.combo_nienKhoa);
            this.grbNhapLop.Controls.Add(this.label4);
            this.grbNhapLop.Controls.Add(this.cb_dotkhaigiang);
            this.grbNhapLop.Controls.Add(this.label11);
            this.grbNhapLop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grbNhapLop.ForeColor = System.Drawing.Color.White;
            this.grbNhapLop.Location = new System.Drawing.Point(21, 80);
            this.grbNhapLop.Name = "grbNhapLop";
            this.grbNhapLop.Size = new System.Drawing.Size(275, 74);
            this.grbNhapLop.TabIndex = 41;
            this.grbNhapLop.TabStop = false;
            this.grbNhapLop.Text = "Thông tin khóa học - lớp học";
            // 
            // combo_nienKhoa
            // 
            this.combo_nienKhoa.FormattingEnabled = true;
            this.combo_nienKhoa.Location = new System.Drawing.Point(10, 51);
            this.combo_nienKhoa.Name = "combo_nienKhoa";
            this.combo_nienKhoa.Size = new System.Drawing.Size(108, 23);
            this.combo_nienKhoa.TabIndex = 61;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 21);
            this.label4.TabIndex = 60;
            this.label4.Text = "Niên khóa";
            // 
            // cb_dotkhaigiang
            // 
            this.cb_dotkhaigiang.FormattingEnabled = true;
            this.cb_dotkhaigiang.Location = new System.Drawing.Point(149, 51);
            this.cb_dotkhaigiang.Name = "cb_dotkhaigiang";
            this.cb_dotkhaigiang.Size = new System.Drawing.Size(108, 23);
            this.cb_dotkhaigiang.TabIndex = 59;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label11.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Location = new System.Drawing.Point(145, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 21);
            this.label11.TabIndex = 58;
            this.label11.Text = "Đợt khai giảng";
            // 
            // lbMaHV
            // 
            this.lbMaHV.AutoSize = true;
            this.lbMaHV.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaHV.Location = new System.Drawing.Point(386, 28);
            this.lbMaHV.Name = "lbMaHV";
            this.lbMaHV.Size = new System.Drawing.Size(0, 23);
            this.lbMaHV.TabIndex = 20;
            // 
            // lbHoTen
            // 
            this.lbHoTen.AutoSize = true;
            this.lbHoTen.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHoTen.Location = new System.Drawing.Point(115, 28);
            this.lbHoTen.Name = "lbHoTen";
            this.lbHoTen.Size = new System.Drawing.Size(0, 23);
            this.lbHoTen.TabIndex = 19;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.lblHoTen.Location = new System.Drawing.Point(6, 28);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(118, 23);
            this.lblHoTen.TabIndex = 1;
            this.lblHoTen.Text = "Tên chứng chỉ";
            // 
            // gbThongTinHocSinh
            // 
            this.gbThongTinHocSinh.Controls.Add(this.lbMaHV);
            this.gbThongTinHocSinh.Controls.Add(this.lbHoTen);
            this.gbThongTinHocSinh.Controls.Add(this.lblHoTen);
            this.gbThongTinHocSinh.Controls.Add(this.lblMaHS);
            this.gbThongTinHocSinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.gbThongTinHocSinh.ForeColor = System.Drawing.Color.White;
            this.gbThongTinHocSinh.Location = new System.Drawing.Point(306, 80);
            this.gbThongTinHocSinh.Name = "gbThongTinHocSinh";
            this.gbThongTinHocSinh.Size = new System.Drawing.Size(442, 74);
            this.gbThongTinHocSinh.TabIndex = 38;
            this.gbThongTinHocSinh.TabStop = false;
            this.gbThongTinHocSinh.Text = "Thông tin điểm thi của học viên";
            // 
            // lblMaHS
            // 
            this.lblMaHS.AutoSize = true;
            this.lblMaHS.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHS.Location = new System.Drawing.Point(258, 28);
            this.lblMaHS.Name = "lblMaHS";
            this.lblMaHS.Size = new System.Drawing.Size(143, 23);
            this.lblMaHS.TabIndex = 0;
            this.lblMaHS.Text = "Mã mã chứng chỉ";
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("UVN Ba Le", 30F);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(68, 7);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(278, 54);
            this.lblTieuDe.TabIndex = 39;
            this.lblTieuDe.Text = "Thông tin chứng chỉ";
            // 
            // btnXemDiem
            // 
            this.btnXemDiem.BackColor = System.Drawing.Color.BlueViolet;
            this.btnXemDiem.BackgroundImage = global::QuanLyHocSinh.Properties.Resources.btnXemDiem;
            this.btnXemDiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnXemDiem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXemDiem.Location = new System.Drawing.Point(510, 382);
            this.btnXemDiem.Name = "btnXemDiem";
            this.btnXemDiem.Size = new System.Drawing.Size(73, 68);
            this.btnXemDiem.TabIndex = 48;
            this.btnXemDiem.UseVisualStyleBackColor = false;
            // 
            // btnNhapDiem
            // 
            this.btnNhapDiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(117)))), ((int)(((byte)(230)))));
            this.btnNhapDiem.BackgroundImage = global::QuanLyHocSinh.Properties.Resources.btnNhapDiem_ok;
            this.btnNhapDiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNhapDiem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNhapDiem.Location = new System.Drawing.Point(273, 382);
            this.btnNhapDiem.Name = "btnNhapDiem";
            this.btnNhapDiem.Size = new System.Drawing.Size(73, 68);
            this.btnNhapDiem.TabIndex = 47;
            this.btnNhapDiem.UseVisualStyleBackColor = false;
            // 
            // btnTinhDiem
            // 
            this.btnTinhDiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnTinhDiem.BackgroundImage = global::QuanLyHocSinh.Properties.Resources.btnTinhDiem2;
            this.btnTinhDiem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTinhDiem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTinhDiem.Location = new System.Drawing.Point(431, 382);
            this.btnTinhDiem.Name = "btnTinhDiem";
            this.btnTinhDiem.Size = new System.Drawing.Size(73, 68);
            this.btnTinhDiem.TabIndex = 46;
            this.btnTinhDiem.UseVisualStyleBackColor = false;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(31)))), ((int)(((byte)(69)))));
            this.btnThoat.BackgroundImage = global::QuanLyHocSinh.Properties.Resources.Thoat;
            this.btnThoat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThoat.Location = new System.Drawing.Point(668, 382);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(73, 68);
            this.btnThoat.TabIndex = 45;
            this.btnThoat.UseVisualStyleBackColor = false;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(133)))), ((int)(((byte)(156)))));
            this.btnHuy.BackgroundImage = global::QuanLyHocSinh.Properties.Resources.Huy;
            this.btnHuy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHuy.Location = new System.Drawing.Point(589, 382);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(73, 68);
            this.btnHuy.TabIndex = 44;
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.Green;
            this.btnLuu.BackgroundImage = global::QuanLyHocSinh.Properties.Resources.Luu;
            this.btnLuu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLuu.Location = new System.Drawing.Point(352, 382);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(73, 68);
            this.btnLuu.TabIndex = 43;
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // picturebox
            // 
            this.picturebox.BackgroundImage = global::QuanLyHocSinh.Properties.Resources.korganizer_icon;
            this.picturebox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picturebox.ErrorImage = null;
            this.picturebox.Location = new System.Drawing.Point(21, 11);
            this.picturebox.Name = "picturebox";
            this.picturebox.Size = new System.Drawing.Size(53, 50);
            this.picturebox.TabIndex = 40;
            this.picturebox.TabStop = false;
            // 
            // frmChungChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(0)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(760, 467);
            this.Controls.Add(this.btnXemDiem);
            this.Controls.Add(this.btnNhapDiem);
            this.Controls.Add(this.btnTinhDiem);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.dgvBangDiem);
            this.Controls.Add(this.grbNhapLop);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.picturebox);
            this.Controls.Add(this.gbThongTinHocSinh);
            this.Controls.Add(this.lblTieuDe);
            this.Name = "frmChungChi";
            this.Text = "Quản lý chứng chỉ";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDiem)).EndInit();
            this.grbNhapLop.ResumeLayout(false);
            this.grbNhapLop.PerformLayout();
            this.gbThongTinHocSinh.ResumeLayout(false);
            this.gbThongTinHocSinh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnXemDiem;
        private System.Windows.Forms.Button btnNhapDiem;
        private System.Windows.Forms.Button btnTinhDiem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.DataGridView dgvBangDiem;
        private System.Windows.Forms.GroupBox grbNhapLop;
        private System.Windows.Forms.ComboBox combo_nienKhoa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_dotkhaigiang;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.PictureBox picturebox;
        private System.Windows.Forms.Label lbMaHV;
        private System.Windows.Forms.Label lbHoTen;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.GroupBox gbThongTinHocSinh;
        private System.Windows.Forms.Label lblMaHS;
        private System.Windows.Forms.Label lblTieuDe;
    }
}
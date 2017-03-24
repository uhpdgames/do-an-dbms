namespace QuanLyHocSinh
{
    partial class frmBaocao
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaocao));
            this.View_ThongTinHocVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Trung_Tam_Anh_Ngu_A_ZDataSet = new QuanLyHocSinh.Trung_Tam_Anh_Ngu_A_ZDataSet();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.btnTimKiem_2 = new System.Windows.Forms.Button();
            this.txttim = new System.Windows.Forms.TextBox();
            this.combo_Lophoc = new System.Windows.Forms.ComboBox();
            this.cmbGiangVien = new System.Windows.Forms.ComboBox();
            this.combo_KhoaHoc = new System.Windows.Forms.ComboBox();
            this.cb_dotkhaigiang = new System.Windows.Forms.ComboBox();
            this.cmbNienKhoa = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picturebox = new System.Windows.Forms.PictureBox();
            this.rpView = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pane_xem = new System.Windows.Forms.Panel();
            this.View_ThongTinHocVienTableAdapter = new QuanLyHocSinh.Trung_Tam_Anh_Ngu_A_ZDataSetTableAdapters.View_ThongTinHocVienTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.View_ThongTinHocVienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trung_Tam_Anh_Ngu_A_ZDataSet)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox)).BeginInit();
            this.pane_xem.SuspendLayout();
            this.SuspendLayout();
            // 
            // View_ThongTinHocVienBindingSource
            // 
            this.View_ThongTinHocVienBindingSource.DataMember = "View_ThongTinHocVien";
            this.View_ThongTinHocVienBindingSource.DataSource = this.Trung_Tam_Anh_Ngu_A_ZDataSet;
            // 
            // Trung_Tam_Anh_Ngu_A_ZDataSet
            // 
            this.Trung_Tam_Anh_Ngu_A_ZDataSet.DataSetName = "Trung_Tam_Anh_Ngu_A_ZDataSet";
            this.Trung_Tam_Anh_Ngu_A_ZDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("UVN Ba Le", 30F);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(396, 59);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(381, 54);
            this.lblTieuDe.TabIndex = 17;
            this.lblTieuDe.Text = "Báo cáo danh sách học viên";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.btnTimKiem_2);
            this.groupBox.Controls.Add(this.txttim);
            this.groupBox.Controls.Add(this.combo_Lophoc);
            this.groupBox.Controls.Add(this.cmbGiangVien);
            this.groupBox.Controls.Add(this.combo_KhoaHoc);
            this.groupBox.Controls.Add(this.cb_dotkhaigiang);
            this.groupBox.Controls.Add(this.cmbNienKhoa);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.label5);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox.ForeColor = System.Drawing.Color.White;
            this.groupBox.Location = new System.Drawing.Point(306, 116);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(824, 112);
            this.groupBox.TabIndex = 19;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Lọc theo danh sách";
            // 
            // btnTimKiem_2
            // 
            this.btnTimKiem_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnTimKiem_2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTimKiem_2.Location = new System.Drawing.Point(708, 74);
            this.btnTimKiem_2.Name = "btnTimKiem_2";
            this.btnTimKiem_2.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem_2.TabIndex = 10;
            this.btnTimKiem_2.Text = "Tìm kiếm";
            this.btnTimKiem_2.UseVisualStyleBackColor = false;
            this.btnTimKiem_2.Click += new System.EventHandler(this.btnTimKiem_2_Click);
            // 
            // txttim
            // 
            this.txttim.Location = new System.Drawing.Point(581, 74);
            this.txttim.Name = "txttim";
            this.txttim.Size = new System.Drawing.Size(121, 23);
            this.txttim.TabIndex = 9;
            this.txttim.Text = "Nhập tên cần tìm...";
            this.txttim.Click += new System.EventHandler(this.txttim_Click);
            // 
            // combo_Lophoc
            // 
            this.combo_Lophoc.FormattingEnabled = true;
            this.combo_Lophoc.Location = new System.Drawing.Point(581, 31);
            this.combo_Lophoc.Name = "combo_Lophoc";
            this.combo_Lophoc.Size = new System.Drawing.Size(121, 23);
            this.combo_Lophoc.TabIndex = 8;
            this.combo_Lophoc.SelectedIndexChanged += new System.EventHandler(this.combo_Lophoc_SelectedIndexChanged);
            // 
            // cmbGiangVien
            // 
            this.cmbGiangVien.FormattingEnabled = true;
            this.cmbGiangVien.Location = new System.Drawing.Point(378, 74);
            this.cmbGiangVien.Name = "cmbGiangVien";
            this.cmbGiangVien.Size = new System.Drawing.Size(121, 23);
            this.cmbGiangVien.TabIndex = 1;
            this.cmbGiangVien.SelectedIndexChanged += new System.EventHandler(this.cmbGiangVien_SelectedIndexChanged);
            // 
            // combo_KhoaHoc
            // 
            this.combo_KhoaHoc.FormattingEnabled = true;
            this.combo_KhoaHoc.Location = new System.Drawing.Point(378, 27);
            this.combo_KhoaHoc.Name = "combo_KhoaHoc";
            this.combo_KhoaHoc.Size = new System.Drawing.Size(121, 23);
            this.combo_KhoaHoc.TabIndex = 1;
            this.combo_KhoaHoc.SelectedIndexChanged += new System.EventHandler(this.combo_KhoaHoc_SelectedIndexChanged);
            // 
            // cb_dotkhaigiang
            // 
            this.cb_dotkhaigiang.FormattingEnabled = true;
            this.cb_dotkhaigiang.Location = new System.Drawing.Point(139, 74);
            this.cb_dotkhaigiang.Name = "cb_dotkhaigiang";
            this.cb_dotkhaigiang.Size = new System.Drawing.Size(110, 23);
            this.cb_dotkhaigiang.TabIndex = 1;
            this.cb_dotkhaigiang.SelectedIndexChanged += new System.EventHandler(this.cb_dotkhaigiang_SelectedIndexChanged);
            // 
            // cmbNienKhoa
            // 
            this.cmbNienKhoa.FormattingEnabled = true;
            this.cmbNienKhoa.Location = new System.Drawing.Point(139, 31);
            this.cmbNienKhoa.Name = "cmbNienKhoa";
            this.cmbNienKhoa.Size = new System.Drawing.Size(110, 23);
            this.cmbNienKhoa.TabIndex = 1;
            this.cmbNienKhoa.SelectedIndexChanged += new System.EventHandler(this.cmbNienKhoa_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(28, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Đợt khai giảng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(284, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Giảng viên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(505, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Lớp học";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(284, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Khóa học";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(28, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Niên khóa";
            // 
            // picturebox
            // 
            this.picturebox.BackgroundImage = global::QuanLyHocSinh.Properties.Resources.callcenter_girls_flower_icon;
            this.picturebox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picturebox.ErrorImage = null;
            this.picturebox.Location = new System.Drawing.Point(312, 12);
            this.picturebox.Name = "picturebox";
            this.picturebox.Size = new System.Drawing.Size(92, 116);
            this.picturebox.TabIndex = 18;
            this.picturebox.TabStop = false;
            // 
            // rpView
            // 
            this.rpView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpView.DocumentMapWidth = 1;
            reportDataSource1.Name = "DataSet_DS_HocVien";
            reportDataSource1.Value = this.View_ThongTinHocVienBindingSource;
            this.rpView.LocalReport.DataSources.Add(reportDataSource1);
            this.rpView.LocalReport.ReportEmbeddedResource = "QuanLyHocSinh.Report_danh_sach_hoc_vien.rdlc";
            this.rpView.Location = new System.Drawing.Point(0, 0);
            this.rpView.Name = "rpView";
            this.rpView.Size = new System.Drawing.Size(1350, 489);
            this.rpView.TabIndex = 20;
            // 
            // pane_xem
            // 
            this.pane_xem.Controls.Add(this.rpView);
            this.pane_xem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pane_xem.Location = new System.Drawing.Point(0, 240);
            this.pane_xem.Name = "pane_xem";
            this.pane_xem.Size = new System.Drawing.Size(1350, 489);
            this.pane_xem.TabIndex = 20;
            // 
            // View_ThongTinHocVienTableAdapter
            // 
            this.View_ThongTinHocVienTableAdapter.ClearBeforeFill = true;
            // 
            // frmBaocao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(0)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.pane_xem);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.picturebox);
            this.Controls.Add(this.lblTieuDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBaocao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo - thống kê";
            this.Load += new System.EventHandler(this.frmBaocao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.View_ThongTinHocVienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Trung_Tam_Anh_Ngu_A_ZDataSet)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox)).EndInit();
            this.pane_xem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picturebox;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.ComboBox cmbGiangVien;
        private System.Windows.Forms.ComboBox combo_KhoaHoc;
        private System.Windows.Forms.ComboBox cb_dotkhaigiang;
        private System.Windows.Forms.ComboBox cmbNienKhoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer rpView;
        private Trung_Tam_Anh_Ngu_A_ZDataSet Trung_Tam_Anh_Ngu_A_ZDataSet;
        private System.Windows.Forms.BindingSource View_ThongTinHocVienBindingSource;
        private Trung_Tam_Anh_Ngu_A_ZDataSetTableAdapters.View_ThongTinHocVienTableAdapter View_ThongTinHocVienTableAdapter;
        private System.Windows.Forms.Panel pane_xem;
        private System.Windows.Forms.ComboBox combo_Lophoc;
        private System.Windows.Forms.TextBox txttim;
        private System.Windows.Forms.Button btnTimKiem_2;
       // private QuanLyHocSinh.QuanLyHocVien_AZ quanLyHocVien_AZ1;
       // private QuanLyHocSinh.QuanLyHocVien_AZTableAdapters.Hoc_VienTableAdapter hoc_VienTableAdapter1;
    }
}
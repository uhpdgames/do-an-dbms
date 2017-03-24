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
using System.Data.OleDb;

namespace QuanLyHocSinh
{
    public partial class frmLopHoc : Form
    {
        public frmLopHoc()
        {
            InitializeComponent();
        }

        int iDemSoLuongLop; //Số lượng lớp dạy.
        DataSet ds;
        DataView dv;
        SqlDataAdapter daDSLop;
        SqlDataAdapter daKhoahoc;
        SqlDataAdapter daGiangvien;
        SqlDataAdapter daNienKhoa;
        SqlDataAdapter daDot;

        private void frmLopHoc_Load(object sender, EventArgs e)
        {
            #region frmLoad()
            //Chuỗi kết nối 
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            SqlConnection con = new SqlConnection(sChuoiKetNoi);
            con.Open();

            //Chuỗi truy vấn
            string sSelectDSLop = @"Select * From dbo.ThongTinLop";

            //Khởi tạo đối tượng SQLDataAdapter thực hiện truy vấn lấy dữ liệu từ database về
            daDSLop = new SqlDataAdapter(sSelectDSLop, sChuoiKetNoi);
            //Khởi tạo Dataset
            ds = new DataSet("DsQuanLyLop");
            //Đổ dữ liệu vào 1 bảng trong dataset
            daDSLop.Fill(ds, "tblLop");
            dv = new DataView(ds.Tables["tblLop"]);
            //dgvDanhSachLop.DataSource = ds.Tables["tblLop"];
            dgvDanhSachLop.DataSource = dv;
            //Đặt tên cột cho datagridview
            dgvDanhSachLop.Columns["STT_Lop"].HeaderText = "STT";
            dgvDanhSachLop.Columns["MaLop"].HeaderText = "Mã Lớp";
            dgvDanhSachLop.Columns["TenLop"].HeaderText = "Tên Lớp";
            dgvDanhSachLop.Columns["NBT"].HeaderText = "Ngày bắt đầu";
            dgvDanhSachLop.Columns["NKT"].HeaderText = "Ngày kết thúc";
            dgvDanhSachLop.Columns["SS"].HeaderText = "Sỉ số";
            dgvDanhSachLop.Columns["SBD"].HeaderText = "Số buổi dạy";
          
            //Đặt lại độ rộng cho các cột
            dgvDanhSachLop.Columns["MaLop"].Width = 100;
            dgvDanhSachLop.Columns["TenLop"].Width = 100;
            dgvDanhSachLop.Columns["NBT"].Width = 100;
            dgvDanhSachLop.Columns["NKT"].Width = 100;

            //Ẩn các cột không cần thiết hiển thị của Tab. Học Viên
            dgvDanhSachLop.Columns["STT_Lop"].Visible = false;

            //Lấp danh sách giảng viên dạy
            string sSelectGiangVien = @"Select * From dbo.Giang_Vien";
            daGiangvien = new SqlDataAdapter(sSelectGiangVien, sChuoiKetNoi);
            daGiangvien.Fill(ds, "tblGiangVien");
            cmbGiangVien.DataSource = ds.Tables["tblGiangVien"];
            cmbGiangVien.DisplayMember = "TenGV";
            cmbGiangVien.ValueMember = "STT_GV";

            DataGridViewColumn clTenGiangVien = new DataGridViewColumn();
            DataGridViewCell cell_1 = new DataGridViewTextBoxCell();
            clTenGiangVien.CellTemplate = cell_1;
            clTenGiangVien.Name = "TenGV";
            clTenGiangVien.HeaderText = "Giảng viên dạy";
            dgvDanhSachLop.Columns.Add(clTenGiangVien);

            for (int i = 0; i < dgvDanhSachLop.RowCount; i++)
            {
                dgvDanhSachLop.Rows[i].Cells["TenGV"].Value = LayTenGiangVien(dgvDanhSachLop.Rows[i].Cells["STT_GV"].Value.ToString());

            }
            //Ẩn cột
            dgvDanhSachLop.Columns["STT_GV"].Visible = false;
            dgvDanhSachLop.Columns["TenGV"].Width = 150;

            //Khóa học
            string sSelectKhoaHoc = @"Select * From dbo.Khoa_Hoc";
            daKhoahoc = new SqlDataAdapter(sSelectKhoaHoc, sChuoiKetNoi);
            daKhoahoc.Fill(ds, "tblKhoaHoc");
            combo_KhoaHoc.DataSource = ds.Tables["tblKhoaHoc"];
            combo_KhoaHoc.DisplayMember = "TenKhoaHoc";
            combo_KhoaHoc.ValueMember = "STT_KhoaHoc";
            DataGridViewColumn clKhoaHoc = new DataGridViewColumn();
            DataGridViewCell cell_kh = new DataGridViewTextBoxCell();
            clKhoaHoc.CellTemplate = cell_kh;
            clKhoaHoc.Name = "TenKhoaHoc";
            clKhoaHoc.HeaderText = "Khóa học";
            dgvDanhSachLop.Columns.Add(clKhoaHoc);

            for (int i = 0; i < dgvDanhSachLop.RowCount; i++)
            {
                dgvDanhSachLop.Rows[i].Cells["TenKhoaHoc"].Value = LayTenKhoaHoc(dgvDanhSachLop.Rows[i].Cells["STT_KhoaHoc"].Value.ToString());

            }

            //Ẩn cột khóa học 
            dgvDanhSachLop.Columns["STT_KhoaHoc"].Visible = false;
            dgvDanhSachLop.Columns["TenKhoaHoc"].Width = 150;
           
            //Niên khóa
            string sSelectNienKhoa = @"Select * From dbo.Nien_Khoa";
            daNienKhoa = new SqlDataAdapter(sSelectNienKhoa, sChuoiKetNoi);
            daNienKhoa.Fill(ds, "tblNienKhoa");
            cmbniemkhoa.DataSource = ds.Tables["tblNienKhoa"];
            cmbniemkhoa.DisplayMember = "TenNienKhoa";
            cmbniemkhoa.ValueMember = "STT_NienKhoa";
            DataGridViewColumn clNienKhoa = new DataGridViewColumn();
            DataGridViewCell cell_nienkhoa = new DataGridViewTextBoxCell();
            clNienKhoa.CellTemplate = cell_nienkhoa;
            clNienKhoa.Name = "TenNienKhoa";
            clNienKhoa.HeaderText = "Niên khóa";
            dgvDanhSachLop.Columns.Add(clNienKhoa);

            for (int i = 0; i < dgvDanhSachLop.RowCount; i++)
            {
                dgvDanhSachLop.Rows[i].Cells["TenNienKhoa"].Value = LayTenNienKhoa(dgvDanhSachLop.Rows[i].Cells["STT_NienKhoa"].Value.ToString());

            }
            //Ẩn cột 
            dgvDanhSachLop.Columns["STT_NienKhoa"].Visible = false;
            dgvDanhSachLop.Columns["TenNienKhoa"].Width = 150;

            //Đợt khai giảng
            string sSelectKG = @"Select * From dbo.Doi_Khai_Giang";
            daDot = new SqlDataAdapter(sSelectKG, sChuoiKetNoi);
            daDot.Fill(ds, "tblKG");
            cmbdotkhaigiang.DataSource = ds.Tables["tblKG"];
            cmbdotkhaigiang.DisplayMember = "TenDoiHoc";
            cmbdotkhaigiang.ValueMember = "STT_DoiHoc";
            DataGridViewColumn clKG = new DataGridViewColumn();
            DataGridViewCell cell_kh2 = new DataGridViewTextBoxCell();
            clKG.CellTemplate = cell_kh2;
            clKG.Name = "TenDoiHoc";
            clKG.HeaderText = "Đợt khai giảng";
            dgvDanhSachLop.Columns.Add(clKG);

            for (int i = 0; i < dgvDanhSachLop.RowCount; i++)
            {
                dgvDanhSachLop.Rows[i].Cells["TenDoiHoc"].Value = LayTendothoc(dgvDanhSachLop.Rows[i].Cells["STT_DoiHoc"].Value.ToString());

            }
            //Ẩn cột
            dgvDanhSachLop.Columns["STT_DoiHoc"].Visible = false;
            dgvDanhSachLop.Columns["TenDoiHoc"].Width = 150;
    
            //Add thêm lớp vào
            string sThemLop = @"Insert into ThongTinLop(MaLop,TenLop,NBT,NKT,SS,SBD,STT_GV,STT_KhoaHoc,STT_DoiHoc,STT_NienKhoa) values(@MaLop,@TenLop,@NBT,@NKT,@SS,@SBD,@STT_GV,@STT_KhoaHoc,@STT_DoiHoc,@STT_NienKhoa)";
            SqlCommand cmThemLop = new SqlCommand(sThemLop, con);
            cmThemLop.Parameters.Add("@MaLop", SqlDbType.VarChar, 50, "MaLop");
            cmThemLop.Parameters.Add("@TenLop", SqlDbType.NVarChar, 50, "TenLop");
            cmThemLop.Parameters.Add("@NBT", SqlDbType.Date, 10, "NBT");
            cmThemLop.Parameters.Add("@NKT", SqlDbType.Date, 10, "NKT");
            cmThemLop.Parameters.Add("@SS", SqlDbType.Int, 10, "SS");
            cmThemLop.Parameters.Add("@SBD", SqlDbType.Int, 10, "SBD");
            cmThemLop.Parameters.Add("@STT_GV", SqlDbType.Int, 10, "STT_GV");
            cmThemLop.Parameters.Add("@STT_KhoaHoc", SqlDbType.Int, 10, "STT_KhoaHoc");
            cmThemLop.Parameters.Add("@STT_DoiHoc", SqlDbType.Int, 10, "STT_DoiHoc");
            cmThemLop.Parameters.Add("@STT_NienKhoa", SqlDbType.Int, 10, "STT_NienKhoa");

            daDSLop.InsertCommand = cmThemLop;

            //Tạo đối tượng command thực thi câu lệnh truy vấn update lại dử liệu
            string sSuaLop = @"Update ThongTinLop set MaLop=@MaLop,TenLop=@TenLop,NBT=@NBT,NKT=@NKT,SS=@SS,SBD=@SBD,STT_GV=@STT_GV,STT_KhoaHoc=@STT_KhoaHoc,STT_DoiHoc=@STT_DoiHoc,STT_NienKhoa=@STT_NienKhoa where STT_Lop=@STT_Lop";
            SqlCommand cmSuaLop = new SqlCommand(sSuaLop, con);
            cmSuaLop.Parameters.Add("@MaLop", SqlDbType.VarChar, 50, "MaLop");
            cmSuaLop.Parameters.Add("@TenLop", SqlDbType.NVarChar, 50, "TenLop");
            cmSuaLop.Parameters.Add("@NBT", SqlDbType.Date, 10, "NBT");
            cmSuaLop.Parameters.Add("@NKT", SqlDbType.Date, 10, "NKT");
            cmSuaLop.Parameters.Add("@SS", SqlDbType.Int, 10, "SS");
            cmSuaLop.Parameters.Add("@SBD", SqlDbType.Int, 10, "SBD");
            cmSuaLop.Parameters.Add("@STT_GV", SqlDbType.Int, 10, "STT_GV");
            cmSuaLop.Parameters.Add("@STT_KhoaHoc", SqlDbType.Int, 10, "STT_KhoaHoc");
            cmSuaLop.Parameters.Add("@STT_DoiHoc", SqlDbType.Int, 10, "STT_DoiHoc");
            cmSuaLop.Parameters.Add("@STT_NienKhoa", SqlDbType.Int, 10, "STT_NienKhoa");

            //Điều kiện để tìm giá trị để sửa
            cmSuaLop.Parameters.Add("@STT_Lop", SqlDbType.Int, 10, "STT_Lop");

            daDSLop.UpdateCommand = cmSuaLop;

            //Tạo đối tượng command xóa dữ liệu 
            string sXoaLop = @"Delete From ThongTinLop where STT_Lop=@STT_Lop";
            SqlCommand cmXoaLop = new SqlCommand(sXoaLop, con);
            cmXoaLop.Parameters.Add("@STT_Lop", SqlDbType.Int, 50, "STT_Lop");
            daDSLop.DeleteCommand = cmXoaLop;

            #endregion

        }
        //duyệt Tên giảng viên
        public string LayTenGiangVien(string sMaGV)
        {
            //Chuỗi kết nối  
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            //Chuỗi truy vấn
            string sTenGiangVien = @"Select TenGV From Giang_Vien Where STT_GV=" + sMaGV;
            SqlDataAdapter daDSGiangVien = new SqlDataAdapter(sTenGiangVien, sChuoiKetNoi);
            DataTable dt_1 = new DataTable();
            daDSGiangVien.Fill(dt_1);
            if (dt_1.Rows.Count > 0)
            {
                return dt_1.Rows[0][0].ToString();
            }
            return "";
        }
        //duyệt khai giảng
        public string LayTendothoc(string sMak)
        {
            //Chuỗi kết nối  
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            //Chuỗi truy vấn
            string sTenDothoc = @"Select TenDoiHoc From Doi_Khai_Giang Where STT_DoiHoc=" + sMak;
            SqlDataAdapter daDSdothoc = new SqlDataAdapter(sTenDothoc, sChuoiKetNoi);
            DataTable dt_21 = new DataTable();
            daDSdothoc.Fill(dt_21);
            if (dt_21.Rows.Count > 0)
            {
                return dt_21.Rows[0][0].ToString();
            }
            return "";
        }

        //duyệt khóa học
        public string LayTenKhoaHoc(string sMaKhoaHoc)
        {
            //Chuỗi kết nối  
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            //Chuỗi truy vấn
            string sTenKhoaHoc = @"Select TenKhoaHoc From Khoa_Hoc Where STT_KhoaHoc=" + sMaKhoaHoc;
            SqlDataAdapter daTenKhoaHoc = new SqlDataAdapter(sTenKhoaHoc, sChuoiKetNoi);
            DataTable dt2 = new DataTable();
            daTenKhoaHoc.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                return dt2.Rows[0][0].ToString();
            }
            return "";
        }
        //duyệt niên khóa
        public string LayTenNienKhoa(string sMaNK)
        {
            //Chuỗi kết nối  
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            //Chuỗi truy vấn
            string sTenNien = @"Select TenNienKhoa From Nien_Khoa Where STT_NienKhoa=" + sMaNK;
            SqlDataAdapter daDSKhoa = new SqlDataAdapter(sTenNien, sChuoiKetNoi);
            DataTable dt = new DataTable();
            daDSKhoa.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            return "";
        }
        //Code thêm 1 lớp vào cơ sở dử liệu
        private void btnNhapLop_Click(object sender, EventArgs e)
        {
            //Kiểm tra tính hợp lệ đầu vào dữ liệu
            if (txtSoBuoiDay.Text == "" || txtSiSo.Text == "")
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ thông tin!", "Thông báo");
                return;
            }
            //Thêm 1 dòng vào tblLop
            DataRow r = ds.Tables["tblLop"].NewRow();
            //Nhập giá trị vào các trường tương ứng trên Datarow
            r["SBD"] = txtSoBuoiDay.Text;
            r["SS"] = txtSiSo.Text;
            r["NBT"] = dtpNgaybt.Text;
            r["NKT"] = dtpNgaykt.Text;
            //fix
            if ((combo_KhoaHoc.SelectedValue) == null && !(combo_KhoaHoc.SelectedValue is DataRowView))
        
            {
                MessageBox.Show("Bạn chưa chọn khóa học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            r["STT_KhoaHoc"] = combo_KhoaHoc.SelectedValue;
            if ((cmbGiangVien.SelectedValue) == null && !(cmbGiangVien.SelectedValue is DataRowView))
            {
                MessageBox.Show("Bạn chưa chọn giảng viên nhận lớp dạy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            r["STT_GV"] = cmbGiangVien.SelectedValue;
            if ((cmbdotkhaigiang.SelectedValue) == null && !(cmbdotkhaigiang.SelectedValue is DataRowView))
            {
                MessageBox.Show("Bạn chưa chọn đợt học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            r["STT_DoiHoc"] = cmbdotkhaigiang.SelectedValue;
            if ((cmbniemkhoa.SelectedValue) == null && !(cmbniemkhoa.SelectedValue is DataRowView))
            {
                MessageBox.Show("Bạn chưa chọn niên khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            r["STT_NienKhoa"] = cmbniemkhoa.SelectedValue;

            r["TenLop"] = combo_Lophoc.Text;

            r["MaLop"] = this.MaLopCuoi();

            if (iDemSoLuongLop == 0)
            {
                SoluongLop();
            }
            else
            iDemSoLuongLop++;
            r["STT_Lop"] = iDemSoLuongLop;
            //Add vào tblLop
            ds.Tables["tblLop"].Rows.Add(r);
          
            //Thêm tên lớp vào datagridview
            dgvDanhSachLop.Rows[dgvDanhSachLop.RowCount - 1].Cells["TenKhoaHoc"].Value = LayTenKhoaHoc(combo_KhoaHoc.SelectedValue.ToString());
            dgvDanhSachLop.Rows[dgvDanhSachLop.RowCount - 1].Cells["TenGV"].Value = LayTenGiangVien(cmbGiangVien.SelectedValue.ToString());
            dgvDanhSachLop.Rows[dgvDanhSachLop.RowCount - 1].Cells["TenDoiHoc"].Value = LayTendothoc(cmbdotkhaigiang.SelectedValue.ToString());
            dgvDanhSachLop.Rows[dgvDanhSachLop.RowCount - 1].Cells["TenNienKhoa"].Value = LayTenNienKhoa(cmbniemkhoa.SelectedValue.ToString());

        }
        //Code Auto tự tạo mã lớp
        public string MaLopCuoi()
        {
            //Chuỗi kết nối 
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            SqlConnection con = new SqlConnection(sChuoiKetNoi);
            if (con.State == ConnectionState.Closed)
                con.Open();          
            //Chuỗi truy vấn
            string sMaLop2 = @"Select MaLop From ThongTinLop";
            SqlDataAdapter daDSLop2 = new SqlDataAdapter(sMaLop2, sChuoiKetNoi);
            DataTable dt2 = new DataTable();
            daDSLop2.Fill(dt2);          
            con.Close();

            string s = "";
            if (dt2.Rows.Count <= 0)
                s = "Eng001"; //Giá trị đầu tiên.
            else
            {
                int iDongCuoi;
                s = "Eng";// Mặc định
                iDongCuoi = Convert.ToInt32(dt2.Rows[dt2.Rows.Count - 1][0].ToString().Substring(3, 3));
                iDongCuoi = iDongCuoi + 1;
                if (iDongCuoi < 10)
                    s = s + "00";
                else if (iDongCuoi < 100)
                    s = s + "0";
                s = s + iDongCuoi.ToString();
            }

            return s;
        }
        //Code Auto số lượng lớp dạy
        public void SoluongLop()
        {

            //Chuỗi kết nối 
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            //Chuỗi truy vấn
            string sSoLuong = @"Select STT_Lop From ThongTinLop";
            SqlDataAdapter daSoLuong = new SqlDataAdapter(sSoLuong, sChuoiKetNoi);
            DataTable dt = new DataTable();
            daSoLuong.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Lấy chỉ số phần tử dòng cuối cùng 
                int iDongCuoi = dt.Rows.Count - 1;
                iDemSoLuongLop = int.Parse(dt.Rows[iDongCuoi][0].ToString());
            }
        }
        //Code nút Lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daDSLop.Update(ds, "tblLop");
                MessageBox.Show("Lưu thành công !", "Thông báo");
            }
            catch (Exception ex)
            {
                 //MessageBox.Show("Thao tác lỗi...", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                MessageBox.Show("Lưu thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //Code nút Hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ds.Tables["tblLop"].RejectChanges();
        }
        //Code nút thoát
        private void btnThoatRa_Click(object sender, EventArgs e)
        {
            
               this.Close();
        }
        //Code sự kiện hiện thị thông tin học viên sau khi click vào bất kì 1 dòng dử liệu.
        private void dgvDanhSachLop_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvDanhSachLop.SelectedRows[0];
            lb_MaLop.Text = dr.Cells["MaLop"].Value.ToString();
            combo_Lophoc.Text = dr.Cells["TenLop"].Value.ToString();
            dtpNgaybt.Text = dr.Cells["NBT"].Value.ToString();
            dtpNgaykt.Text = dr.Cells["NKT"].Value.ToString();
            combo_KhoaHoc.SelectedValue = dr.Cells["STT_KhoaHoc"].Value.ToString();
            cmbdotkhaigiang.SelectedValue = dr.Cells["STT_DoiHoc"].Value.ToString();
            cmbniemkhoa.SelectedValue = dr.Cells["STT_NienKhoa"].Value.ToString();
            cmbGiangVien.SelectedValue = dr.Cells["STT_GV"].Value.ToString();

            txtSoBuoiDay.Text = dr.Cells["SBD"].Value.ToString();
            txtSiSo.Text = dr.Cells["SS"].Value.ToString();

        }
        //Code nút Sữa
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvDanhSachLop.SelectedRows[0];
                dgvDanhSachLop.BeginEdit(true);
                dr.Cells["TenLop"].Value = combo_Lophoc.Text;
                dr.Cells["NBT"].Value = dtpNgaybt.Text;
                dr.Cells["NKT"].Value = dtpNgaykt.Text;
                dr.Cells["SBD"].Value = txtSoBuoiDay.Text;
                dr.Cells["SS"].Value = txtSiSo.Text;
                dr.Cells["STT_KhoaHoc"].Value = combo_KhoaHoc.SelectedValue;
                dr.Cells["STT_NienKhoa"].Value = cmbniemkhoa.SelectedValue;
                dr.Cells["STT_DoiHoc"].Value = cmbdotkhaigiang.SelectedValue;
                dr.Cells["STT_GV"].Value = cmbGiangVien.SelectedValue;
                dgvDanhSachLop.EndEdit();
                MessageBox.Show("Cập nhật dữ liệu thành công !", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thao tác lỗi...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }
        //Code nút xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvDanhSachLop.SelectedRows[0];
                dgvDanhSachLop.Rows.Remove(dr);
                MessageBox.Show("Xóa thành công !", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

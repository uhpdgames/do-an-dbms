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
    public partial class Diem : Form
    {
        public Diem()
        {
            InitializeComponent();
        }

        DataView dv;
        DataSet ds;    
        DataTable dt;
        private void Diem_Load(object sender, EventArgs e)
        {
            //Hiện thị thông tin mặc định khi người dùng phần mềm chọn chức năng nhập điểm.
            SqlDataAdapter daNhapDiem;
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            SqlConnection con = new SqlConnection(sChuoiKetNoi);
            con.Open();

            //lấy dataset
            ds = new DataSet("DsQuanLyHocVien");
      

            //Hiển thị thông tin học viên lên màn hình.
            string sSelectHocVien = @"Select Hoc_Vien.*,ThongTinLop.STT_DoiHoc From dbo.Hoc_Vien inner join ThongTinLop on Hoc_Vien.STT_Lop=ThongTinLop.STT_Lop";
            daNhapDiem = new SqlDataAdapter(sSelectHocVien, sChuoiKetNoi);
            daNhapDiem.Fill(ds, "tblHoc_Vien");
            dv = new DataView(ds.Tables["tblHoc_Vien"]);
            dgvBangDiem.DataSource = dv;

            //Ẩn các cột không cần thiết hiển thị của Tab. Học Viên
            dgvBangDiem.Columns["STT_HV"].Visible = false;
            dgvBangDiem.Columns["NgaySinh"].Visible = false;
            dgvBangDiem.Columns["DiaChi"].Visible = false;

            //Hiện tên lớp
            DataGridViewColumn clTenLop = new DataGridViewColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            clTenLop.CellTemplate = cell;
            clTenLop.Name = "TenLop";
            clTenLop.HeaderText = "Tên lớp";
            dgvBangDiem.Columns.Add(clTenLop);

            for (int i = 0; i < dgvBangDiem.RowCount; i++)
            {
                dgvBangDiem.Rows[i].Cells["TenLop"].Value = LayTenLopHoc(dgvBangDiem.Rows[i].Cells["STT_Lop"].Value.ToString());

            }

            //Ẩn cột lớp
            dgvBangDiem.Columns["STT_Lop"].Visible = false;
            dgvBangDiem.Columns["TenLop"].Width = 100;

            //Hiện lấy tên khóa
            DataGridViewColumn clKhoaHoc = new DataGridViewColumn();
            DataGridViewCell cell_kh = new DataGridViewTextBoxCell();
            clKhoaHoc.CellTemplate = cell_kh;
            clKhoaHoc.Name = "TenKhoaHoc";
            clKhoaHoc.HeaderText = "Khóa học";
            dgvBangDiem.Columns.Add(clKhoaHoc);

            for (int i = 0; i < dgvBangDiem.RowCount; i++)
            {
                dgvBangDiem.Rows[i].Cells["TenKhoaHoc"].Value = LayTenKhoaHoc(dgvBangDiem.Rows[i].Cells["STT_KhoaHoc"].Value.ToString());

            }

            //Ẩn cột khóa học
            dgvBangDiem.Columns["STT_KhoaHoc"].Visible = false;
            dgvBangDiem.Columns["TenKhoaHoc"].Width = 120;

            //Hiện đợt học
            DataGridViewColumn clKG = new DataGridViewColumn();
            DataGridViewCell cell_kh2 = new DataGridViewTextBoxCell();
            clKG.CellTemplate = cell_kh2;
            clKG.Name = "TenDoiHoc";
            clKG.HeaderText = "Đợt";
            dgvBangDiem.Columns.Add(clKG);

            for (int i = 0; i < dgvBangDiem.RowCount; i++)
            {
                dgvBangDiem.Rows[i].Cells["TenDoiHoc"].Value = LayTendothoc(dgvBangDiem.Rows[i].Cells["STT_DoiHoc"].Value.ToString());

            }
            //Ẩn cột
            dgvBangDiem.Columns["STT_DoiHoc"].Visible = false;
            dgvBangDiem.Columns["TenDoiHoc"].Width = 50;

            //Đặt lại tên
            dgvBangDiem.Columns["MaHV"].HeaderText = "Mã HV";
            dgvBangDiem.Columns["HoTen"].HeaderText = "Họ tên";
            dgvBangDiem.Columns["SDT"].HeaderText = "SĐT";
            dgvBangDiem.Columns["GioiTinh"].HeaderText = "Giới Tính";


            //lấy Khóa học
            LoadcmbKhoaHoc();
            //Lấy niên khóa
            LoadNienKhoa();
            //Lấy đợt học
            LoadcmbDot();

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

        //Duyệt lấy tên lớp
        public string LayTenLopHoc(string sSTT_Lop)
        {
            //Chuỗi kết nối  
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            //Chuỗi truy vấn
            string sTenLop = @"Select TenLop From ThongTinLop Where STT_Lop=" + sSTT_Lop;
            SqlDataAdapter daTenLop = new SqlDataAdapter(sTenLop, sChuoiKetNoi);
            DataTable dt = new DataTable();
            daTenLop.Fill(dt);
            //Đếm các dòng dữ liệu, nếu có dữ liệu trong bảng ThongTinLop trả về giá trị
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            //(dt.Rows.Count < 0) Không có dữ liệu trong bảng trả về ""/NULL;
            return "";
        }

        //Duyệt lấy khóa học
        public string LayTenKhoaHoc(string sSTT_KhoaHoc)
        {
            //Chuỗi kết nối  
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            //Chuỗi truy vấn
            string sTenKhoaHoc = @"Select TenKhoaHoc From Khoa_Hoc Where STT_KhoaHoc=" + sSTT_KhoaHoc;
            SqlDataAdapter daTenKhoaHoc = new SqlDataAdapter(sTenKhoaHoc, sChuoiKetNoi);
            DataTable dt2 = new DataTable();
            daTenKhoaHoc.Fill(dt2);
            //Đếm các dòng dữ liệu, nếu có dữ liệu trong bảng Khoa_Hoc trả về giá trị
            if (dt2.Rows.Count > 0)
            {
                return dt2.Rows[0][0].ToString();
            }
            return "";
        }
        //lấy dử liệu từ bảng Khóa học
        SqlDataAdapter daKhoaHoc;
        private void LoadcmbKhoaHoc()
        {
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            string sSelectKG = @"Select * From dbo.Khoa_Hoc";
            daKhoaHoc = new SqlDataAdapter(sSelectKG, sChuoiKetNoi);
            daKhoaHoc.Fill(ds, "tblKhoaHoc");
            combo_KhoaHoc.DataSource = ds.Tables["tblKhoaHoc"];
            combo_KhoaHoc.DisplayMember = "TenKhoaHoc";
            combo_KhoaHoc.ValueMember = "STT_KhoaHoc"; 
        }
        //lấy dử liệu từ bảng đợi khai giảng
        SqlDataAdapter daDot;
        private void LoadcmbDot()
        {
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            string sSelectKG = @"Select * From dbo.Doi_Khai_Giang";
            daDot = new SqlDataAdapter(sSelectKG, sChuoiKetNoi);
            daDot.Fill(ds, "tblKG");
            cb_dotkhaigiang.DataSource = ds.Tables["tblKG"];
            cb_dotkhaigiang.DisplayMember = "TenDoiHoc";
            cb_dotkhaigiang.ValueMember = "STT_DoiHoc";
        }
        SqlDataAdapter daNienKhoa;
        //lấy dử liệu từ bảng niên khóa
        private void LoadNienKhoa()
        {
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            string sSelectNienKhoa = @"Select * From dbo.Nien_Khoa";
            daNienKhoa = new SqlDataAdapter(sSelectNienKhoa, sChuoiKetNoi);
            daNienKhoa.Fill(ds, "tblNienKhoa");
            combo_nienKhoa.DataSource = ds.Tables["tblNienKhoa"];
            combo_nienKhoa.DisplayMember = "TenNienKhoa";
            combo_nienKhoa.ValueMember = "STT_NienKhoa";
        }
        //Lấy danh sách học viên chưa nhập điểm.
        SqlDataAdapter daNhapDiem2;
        private void LoaddsHVnhapDiem()
        {
            //Chuỗi kết nối 
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            string sSelectLopHocVien = string.Format(@"Select Hoc_Vien.MaHV,Hoc_Vien.HoTen,ThongTinLop.TenLop,Khoa_Hoc.TenKhoaHoc,Doi_Khai_Giang.TenDoiHoc,Nien_Khoa.TenNienKhoa
                From Hoc_Vien,ThongTinLop,Nien_Khoa,Khoa_Hoc,Doi_Khai_Giang 
                where Hoc_Vien.STT_Lop=ThongTinLop.STT_Lop
                and ThongTinLop.STT_KhoaHoc=Khoa_Hoc.STT_KhoaHoc 
                and ThongTinLop.STT_NienKhoa=Nien_Khoa.STT_NienKhoa 
                and ThongTinLop.STT_DoiHoc=Doi_Khai_Giang.STT_DoiHoc
               
                and Nien_Khoa.STT_NienKhoa={0} 
                and ThongTinLop.STT_Lop={1} 
                and Khoa_Hoc.STT_KhoaHoc={2} 
                and Doi_Khai_Giang.STT_DoiHoc ={3}
                and Hoc_Vien.STT_HV NOT IN (select STT_HV from BangDiem)"
                    , combo_nienKhoa.SelectedValue, combo_Lophoc.SelectedValue, combo_KhoaHoc.SelectedValue, cb_dotkhaigiang.SelectedValue);
            //Khởi tạo đối tượng SQLDataAdapter thực hiện truy vấn lấy dữ liệu từ database về
            daNhapDiem2 = new SqlDataAdapter(sSelectLopHocVien, sChuoiKetNoi);
            DataTable dt2 = new DataTable();
            //Đổ dữ liệu vào 1 bảng trong datatable
            daNhapDiem2.Fill(dt2);
            if (dt2.Rows.Count != 0)
            {
                //Nếu có điểm thì gán datasource
                dgvBangDiem.DataSource = dt2;
            }
            else
            {
                //Nếu không có điểm thì không làm gì null
                dgvBangDiem.DataSource = null;
            }
        }
        SqlDataAdapter daHocVien;
       //Truy vấn dử liệu học viên đã có nhập điểm.
        private void LoadDSDiemHV()
        {
            if (combo_KhoaHoc.SelectedValue != null && !(combo_KhoaHoc.SelectedValue is DataRowView)
              && cb_dotkhaigiang.SelectedValue != null && !(cb_dotkhaigiang.SelectedValue is DataRowView)
              && combo_Lophoc.SelectedValue != null && !(combo_Lophoc.SelectedValue is DataRowView)
              && combo_nienKhoa.SelectedValue != null && !(combo_nienKhoa.SelectedValue is DataRowView)
              )
            {
                //Chuỗi kết nối 
                string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
   
                //Chuỗi truy vấn
                string sSelectDiem = string.Format(@"Select Hoc_Vien.MaHV,Hoc_Vien.HoTen,ThongTinLop.TenLop,Khoa_Hoc.TenKhoaHoc,Doi_Khai_Giang.TenDoiHoc,Nien_Khoa.TenNienKhoa,BangDiem.Diem
                From BangDiem,Hoc_Vien,ThongTinLop,Nien_Khoa,Khoa_Hoc,Doi_Khai_Giang 
                where Hoc_Vien.STT_Lop=ThongTinLop.STT_Lop 
                and  Hoc_Vien.STT_HV=BangDiem.STT_HV 
                and ThongTinLop.STT_KhoaHoc=Khoa_Hoc.STT_KhoaHoc 
                and ThongTinLop.STT_NienKhoa=Nien_Khoa.STT_NienKhoa 
                and ThongTinLop.STT_DoiHoc=Doi_Khai_Giang.STT_DoiHoc
           
                and Nien_Khoa.STT_NienKhoa={0} 
                and ThongTinLop.STT_Lop={1} 
                and Khoa_Hoc.STT_KhoaHoc={2} 
                and Doi_Khai_Giang.STT_DoiHoc ={3}"
                    , combo_nienKhoa.SelectedValue, combo_Lophoc.SelectedValue, combo_KhoaHoc.SelectedValue, cb_dotkhaigiang.SelectedValue);
                //Khởi tạo đối tượng SQLDataAdapter thực hiện truy vấn lấy dữ liệu từ database về
                daHocVien = new SqlDataAdapter(sSelectDiem, sChuoiKetNoi);
                DataTable dt = new DataTable();
                //Đổ dữ liệu vào 1 bảng trong datatable
                daHocVien.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    //Nếu có điểm thì gán datasource
                    dgvBangDiem.DataSource = dt;
    
                }
                else
                {
                    dgvBangDiem.DataSource = null;
                }
                //Ẩn cột không cần hiện
                dgvBangDiem.Columns["TenLop"].Visible = false;
                dgvBangDiem.Columns["TenKhoaHoc"].Visible = false;
                dgvBangDiem.Columns["TenDoiHoc"].Visible = false;

            }
        }
        int TaoCot = 0;
        private bool NutKT = true;
        private void btnNhapDiem_Click(object sender, EventArgs e)
        {
            //Gọi hàm để load dgv học viên chưa nhập điểm
            LoaddsHVnhapDiem();
            if (dgvBangDiem.Rows.Count == 0 || dgvBangDiem.DataSource == null)
            {
                MessageBox.Show("Học viên có mã số là" + lbMaHV.Text + "đã được nhập điểm rồi !", "Thông Báo!");
                NutKT = true;
                LoadDSDiemHV();
                return;
            }
            if(TaoCot==0)
            { 
            //Thêm vào nhiều cột điểm vào.
            //Diem
            DataGridViewColumn clDiem = new DataGridViewColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();

            clDiem.CellTemplate = cell;
            clDiem.Name = "Diem";
            dgvBangDiem.Columns.Add(clDiem);
            //Kiểm tra hợp lệ
            NutKT = false;
            //Thêm 1 cột
            TaoCot++;
            }
           
        }
        SqlDataAdapter daThongTinKhoa_Lop;

        private void combo_KhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDSDiemHV();

          
           if (cb_dotkhaigiang.SelectedValue != null && !(cb_dotkhaigiang.SelectedValue is DataRowView)
           &&   (combo_KhoaHoc.SelectedValue != null && !(combo_KhoaHoc.SelectedValue is DataRowView))
               )
            {

                //Lấy thông tin lớp.
                string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
                // string sSelectKhoa = @"Select * From Khoa_Hoc where STT_DoiHoc=" + cb_dotkhaigiang.SelectedValue;
                string sSelectThongTinLop = @"Select * From ThongTinLop  where STT_KhoaHoc=" + combo_KhoaHoc.SelectedValue + " and STT_DoiHoc=" + cb_dotkhaigiang.SelectedValue;
               // string sSelectThongTinLop = @"Select * From ThongTinLop  where STT_DoiHoc=" + cb_dotkhaigiang.SelectedValue;


                daThongTinKhoa_Lop = new SqlDataAdapter(sSelectThongTinLop, sChuoiKetNoi);
                DataTable dt = new DataTable();
                daThongTinKhoa_Lop.Fill(dt);
                combo_Lophoc.DataSource = dt;
                combo_Lophoc.DisplayMember = "TenLop";
                combo_Lophoc.ValueMember = "STT_Lop";
                combo_Lophoc.SelectedItem = null;
            }
      
        }
       
  
        private void combo_nienKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDSDiemHV();
        
        }

        private void combo_Lophoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDSDiemHV();
        }

        private void dgvBangDiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow r = ds.Tables["tblHoc_Vien"].NewRow();
        
                DataGridViewRow dr = dgvBangDiem.SelectedRows[0];

                lbMaHV.Text = dr.Cells["MaHV"].Value.ToString();
                lbHoTen.Text = dr.Cells["HoTen"].Value.ToString();
                lbGioiTinh_.Text = dr.Cells["GioiTinh"].Value.ToString();
                lbSDT.Text = dr.Cells["SDT"].Value.ToString();

            }
            catch { return; }
        }
        SqlDataAdapter daDiem;
        private void btnLuu_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Chức năng này không có !", "Thông báo", MessageBoxButtons.OK);
            #region
            
            //    if (NutKT == false)
            //    {
            //        try
            //         {
            //        string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            //        SqlConnection con = new SqlConnection(sChuoiKetNoi);
            //        con.Open();
            //        for (int i = 0; i < dgvBangDiem.Rows.Count; i++)
            //        {
            //            //biến trung gian
            //            string sSTT_HV = dgvBangDiem.Rows[i].Cells["STT_HV"].Value.ToString();
            //            string sSTT_Lop = dgvBangDiem.Rows[i].Cells["STT_Lop"].Value.ToString();
            //            string sSTT_KhoaHoc = dgvBangDiem.Rows[i].Cells["STT_KhoaHoc"].Value.ToString();
            //            string sSTT_Diem = dgvBangDiem.Rows[i].Cells["Diem"].Value.ToString();

            //            string sThemLuu = string.Format("INSERT INTO BangDiem values ({0},{1},{2},{3})", sSTT_HV, sSTT_Lop, sSTT_KhoaHoc, sSTT_Diem);
            //            SqlCommand cmdThem = new SqlCommand(sThemLuu, con);
            //            //(STT_HV,STT_Lop,STT_KhoaHoc,Diem) 
            //            cmdThem.ExecuteNonQuery();
            //        }
            //        con.Close();
            //        NutKT = true;
            //        MessageBox.Show("Nhập điểm thành công !", "Thông báo");
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("Nhập điểm thất bại !", "Thông báo");
            //            return;
            //        }

            //  }
            //    else
            //    { 
            //        try
            //    {
            //        //Chuỗi kết nối 
            //        string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            //        //Khởi tạo đối tượng connection
            //        SqlConnection con = new SqlConnection(sChuoiKetNoi);
            //        con.Open();
            //        for (int i = 0; i < dgvBangDiem.Rows.Count; i++)
            //        {
            //            //Tạo biến trung gian 
            //            string sSTT_HV = dgvBangDiem.Rows[i].Cells["STT_HV"].Value.ToString();
            //            string sSTT_Lop = dgvBangDiem.Rows[i].Cells["STT_Lop"].Value.ToString();
            //            string sSTT_KhoaHoc = dgvBangDiem.Rows[i].Cells["STT_KhoaHoc"].Value.ToString();
            //            string sSTT_Diem = dgvBangDiem.Rows[i].Cells["Diem"].Value.ToString();

            //            //Chuỗi truy vấn
            //            string sInsert = string.Format("Update BangDiem set Diem={0} where STT_HV={1} and STT_Lop={2}", sSTT_Diem, sSTT_HV, sSTT_Lop);
            //            SqlCommand cm = new SqlCommand(sInsert, con);
            //            cm.ExecuteNonQuery();

            //        }
            //        con.Close();
            //        NutKT = true;
            //        MessageBox.Show("Cập nhật thành công !", "Thông báo");
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Cập nhật thất bại !", "Thông báo");
            //    }
            //}


            #endregion
        }
       


        //Xem thông tin tất cả học viên co điểm
        private void btnXemDiem_Click(object sender, EventArgs e)
        {
            //Tải tất cả thông tin học viên có điểm
            LoadDSDiemHV();
            if (TaoCot != 0)
            {
                dgvBangDiem.Columns.Remove("Diem");

            }
            NutKT = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       }
} 


 

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
    public partial class frmQuanLyHocVien : Form
    {
        public frmQuanLyHocVien()
        {
            InitializeComponent();
        }
        int iDemSoHV; //Đếm số lượng học viên học tại trung tâm.
        DataSet ds;
        DataView dv;
        DataTable dt;
        SqlDataAdapter daHocVien;
        SqlDataAdapter daLopHoc;
        SqlDataAdapter daKhoaHoc;
        private void frmQuanLyHocSinh_Load(object sender, EventArgs e)
        {
            //Mã học viên tự động tạo. Không cho phép người dùng nhập vào giá trị. (false)
            txtMaHV.Enabled = false;

            #region frmLoad(void);
           //Chuỗi kết nối 
           string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
           SqlConnection con = new SqlConnection(sChuoiKetNoi);
           con.Open();
           //Chuỗi truy vấn
           string sSelectHocVien = @"Select * From dbo.Hoc_Vien";
           //Khởi tạo đối tượng SQLDataAdapter thực hiện truy vấn lấy dữ liệu từ database về
           daHocVien = new SqlDataAdapter(sSelectHocVien, sChuoiKetNoi);
           //Khởi tạo Dataset
           ds = new DataSet("DsQuanLyHocVien");
           //Đổ dữ liệu vào 1 bảng trong dataset
            daHocVien.Fill(ds, "tblHocVien");
            dv = new DataView(ds.Tables["tblHocVien"]);
            //dgvDanhSachHocVien.DataSource = ds.Tables["tblHocVien"];
            dgvDanhSachHocVien.DataSource = dv;
           //Đặt tên cột cho datagridview
            dgvDanhSachHocVien.Columns["STT_HV"].HeaderText = "STT";
            dgvDanhSachHocVien.Columns["MaHV"].HeaderText = "Mã học viên";
            dgvDanhSachHocVien.Columns["HoTen"].HeaderText = "Họ tên";
            dgvDanhSachHocVien.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvDanhSachHocVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvDanhSachHocVien.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvDanhSachHocVien.Columns["SDT"].HeaderText = "Số điện thoại";

           //Đặt lại độ rộng cho các cột trên datagridview học sinh

            dgvDanhSachHocVien.Columns["MaHV"].Width = 100;
            dgvDanhSachHocVien.Columns["GioiTinh"].Width = 100;
            dgvDanhSachHocVien.Columns["NgaySinh"].Width = 100;

            //Ẩn các cột không cần thiết hiển thị của Tab. Học Viên
            dgvDanhSachHocVien.Columns["STT_HV"].Visible = false;
  
            //Đổ dữ liệu lên control combobox Lớp
            SqlDataAdapter daLopHoc;
            string sSelectLopHoc = @"Select * From dbo.ThongTinLop";
            daLopHoc = new SqlDataAdapter(sSelectLopHoc, sChuoiKetNoi);
            daLopHoc.Fill(ds, "tblLopHoc");
            cmbLop.DataSource = ds.Tables["tblLopHoc"];
            cmbLop.DisplayMember = "TenLop";
            cmbLop.ValueMember = "STT_Lop";

            //tạo chuỗi truy vấn lấy thông tin cả 2 bảng Học Viên và Thông Tin Lớp.
            DataGridViewColumn clTenLop = new DataGridViewColumn();
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            clTenLop.CellTemplate = cell;
            clTenLop.Name = "TenLop";
            clTenLop.HeaderText = "Tên lớp";
            dgvDanhSachHocVien.Columns.Add(clTenLop);

            for (int i = 0; i < dgvDanhSachHocVien.RowCount; i++)
            {
                dgvDanhSachHocVien.Rows[i].Cells["TenLop"].Value = LayTenLopHoc(dgvDanhSachHocVien.Rows[i].Cells["STT_Lop"].Value.ToString());

            }

            //Ẩn cột lớp
            dgvDanhSachHocVien.Columns["STT_Lop"].Visible = false;
            dgvDanhSachHocVien.Columns["TenLop"].Width = 150;

            //Đổ dữ liệu lên control combobox Khóa học
            SqlDataAdapter daKhoaHoc;
            string sSelectKhoaHoc = @"Select * From dbo.Khoa_Hoc";
            daKhoaHoc = new SqlDataAdapter(sSelectKhoaHoc, sChuoiKetNoi);
            daKhoaHoc.Fill(ds, "tblKhoaHoc");
            cmbKhoaHoc.DataSource = ds.Tables["tblKhoaHoc"];
            cmbKhoaHoc.DisplayMember = "TenKhoaHoc";
            cmbKhoaHoc.ValueMember = "STT_KhoaHoc";
            DataGridViewColumn clKhoaHoc = new DataGridViewColumn();
            DataGridViewCell cell_kh = new DataGridViewTextBoxCell();
            clKhoaHoc.CellTemplate = cell_kh;
            clKhoaHoc.Name = "TenKhoaHoc";
            clKhoaHoc.HeaderText = "Khóa học";
            dgvDanhSachHocVien.Columns.Add(clKhoaHoc);

            for (int i = 0; i < dgvDanhSachHocVien.RowCount; i++)
            {
                dgvDanhSachHocVien.Rows[i].Cells["TenKhoaHoc"].Value = LayTenKhoaHoc(dgvDanhSachHocVien.Rows[i].Cells["STT_KhoaHoc"].Value.ToString());

            }

            //Ẩn cột khóa học
            dgvDanhSachHocVien.Columns["STT_KhoaHoc"].Visible = false;
            dgvDanhSachHocVien.Columns["TenKhoaHoc"].Width = 150;

            //Thêm 1 Học Viên mới vào danh sách hồ sơ quản lý.
            string sThemHV = @"Insert into Hoc_Vien(MaHV,HoTen,GioiTinh,NgaySinh,DiaChi,SDT,STT_Lop,STT_KhoaHoc) values(@MaHV,@HoTen,@GioiTinh,@NgaySinh,@DiaChi,@SDT,@STT_Lop,@STT_KhoaHoc)";
            SqlCommand cmThemHV = new SqlCommand(sThemHV, con);
            //cmThemHV.Parameters.Add("@STT_HV", SqlDbType.Int, 10, "STT_HV");//1 : Auto, nên không cần thêm.
            cmThemHV.Parameters.Add("@MaHV", SqlDbType.VarChar, 10, "MaHV");//2
            cmThemHV.Parameters.Add("@HoTen", SqlDbType.NVarChar, 50, "HoTen");//3
            cmThemHV.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 3, "GioiTinh");//4
            cmThemHV.Parameters.Add("@NgaySinh", SqlDbType.DateTime, 10, "NgaySinh");//5
            cmThemHV.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 100, "DiaChi");//6
            cmThemHV.Parameters.Add("@SDT", SqlDbType.Char, 11, "SDT");//7
            cmThemHV.Parameters.Add("@STT_Lop", SqlDbType.Int, 5, "STT_Lop");//8
            cmThemHV.Parameters.Add("@STT_KhoaHoc", SqlDbType.Int, 5, "STT_KhoaHoc");//9
      
            daHocVien.InsertCommand = cmThemHV;

            //Tạo đối tượng command thực thi câu lệnh truy vấn update lại dử liệu
            string sSuaHV = @"Update Hoc_Vien set MaHV=@MaHV,HoTen=@HoTen,GioiTinh=@GioiTinh,NgaySinh=@NgaySinh,DiaChi=@DiaChi,SDT=@SDT,STT_Lop=@STT_Lop,STT_KhoaHoc=@STT_KhoaHoc where STT_HV=@STT_HV";
            SqlCommand cmSuaHV = new SqlCommand(sSuaHV, con);
            cmSuaHV.Parameters.Add("@MaHV", SqlDbType.VarChar, 10, "MaHV");
            cmSuaHV.Parameters.Add("@HoTen", SqlDbType.NVarChar, 50, "HoTen");
            cmSuaHV.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 3, "GioiTinh");
            cmSuaHV.Parameters.Add("@NgaySinh", SqlDbType.DateTime, 10, "NgaySinh");
            cmSuaHV.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 100, "DiaChi");
            cmSuaHV.Parameters.Add("@SDT", SqlDbType.Char, 11, "SDT");
            cmSuaHV.Parameters.Add("@STT_Lop", SqlDbType.Int, 5, "STT_Lop");
            cmSuaHV.Parameters.Add("@STT_KhoaHoc", SqlDbType.Int, 5, "STT_KhoaHoc");

            //Điều kiện để tìm giá trị để sửa
            cmSuaHV.Parameters.Add("@STT_HV", SqlDbType.Int, 50, "STT_HV");

            daHocVien.UpdateCommand = cmSuaHV;

            //Tạo đối tượng command xóa dữ liệu 
            string sXoaHV = @"Delete From Hoc_Vien where STT_HV=@STT_HV";
            SqlCommand cmXoaHV = new SqlCommand(sXoaHV, con);
            cmXoaHV.Parameters.Add("@STT_HV", SqlDbType.Int, 50, "STT_HV");
            daHocVien.DeleteCommand = cmXoaHV;

            #endregion || frmQuanLy_Load
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
        //Thêm dữ liệu mới 1 học viên || code nút THÊM 
        private void btnThem_Click(object sender, EventArgs e)
        {
        
            #region Code cho nút THÊM
          
            //Kiểm tra tính hợp lệ đầu vào dữ liệu
            if (txtHoTen.Text == "" || txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Thêm 1 dòng vào tblHocVien
            DataRow r = ds.Tables["tblHocVien"].NewRow();
            //Nhập giá trị vào các trường tương ứng trên Datarow
            r["HoTen"] = txtHoTen.Text;
            if (rdbGioiTinhNam.Checked == true)
            {
                r["GioiTinh"] = "Nam";
            }
            else
            {
                r["GioiTinh"] = "Nữ";
            }
            r["NgaySinh"] = dtpNgaySinh.Text;
            r["DiaChi"] = txtDiaChi.Text;
            r["SDT"] = txtsdt.Text;

            //Sửa lỗi nhập lớp học và khóa học
            if //((cmbKhoaHoc.SelectedValue) == null && !(cmbKhoaHoc.SelectedValue is DataRowView) ||
           ((cmbLop.SelectedValue == null) && !(cmbLop.SelectedValue is DataRowView))
            {
                MessageBox.Show("Bạn chưa chọn lớp học !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            r["STT_Lop"] = cmbLop.SelectedValue;

            if ((cmbKhoaHoc.SelectedValue) == null && !(cmbKhoaHoc.SelectedValue is DataRowView))
               // ((cmbLop.SelectedValue == null) && !(cmbLop.SelectedValue is DataRowView)))
            {
                MessageBox.Show("Bạn chưa chọn khóa học !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            r["STT_KhoaHoc"] = cmbKhoaHoc.SelectedValue;

            //Them mới Mã học viên ( chế độ tự động )
            r["MaHV"] = this.MaHVCuoiCungTruocKhiThem();
            //Thêm mới STT học viên, đếm có bao nhiêu học viên trong trung tâm Anh Ngữ AZ
            if (iDemSoHV == 0)
            {
                SoluongHV();
            }
            iDemSoHV++;
            r["STT_HV"] = iDemSoHV;

            //Add vào tblHocVien 
            ds.Tables["tblHocVien"].Rows.Add(r);

            //Thêm tên lớp vào datagridview
            dgvDanhSachHocVien.Rows[dgvDanhSachHocVien.RowCount - 1].Cells["TenLop"].Value = LayTenLopHoc(cmbLop.SelectedValue.ToString());
            dgvDanhSachHocVien.Rows[dgvDanhSachHocVien.RowCount - 1].Cells["TenKhoaHoc"].Value = LayTenKhoaHoc(cmbKhoaHoc.SelectedValue.ToString());
     
            //Sửa lỗi nút Thêm
            // MessageBox.Show("Thêm thành công, ấn Lưu và thoát chương trình để cập nhật!", "Thông báo");
            #endregion 
        }
      
        //Auto MaHV
        public string MaHVCuoiCungTruocKhiThem()
        {

            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            SqlConnection con = new SqlConnection(sChuoiKetNoi);
            if (con.State == ConnectionState.Closed)
                con.Open();
            //Chuỗi truy vấn
            string sMaHVCuoiCung = @"Select MaHV From Hoc_Vien";
            SqlDataAdapter daMaHV = new SqlDataAdapter(sMaHVCuoiCung, sChuoiKetNoi);
            DataTable dt = new DataTable();
            daMaHV.Fill(dt);
            con.Close();

            string s = "";

            if (dt.Rows.Count <= 0)
                s = "AZ0001"; //Mã HV có dạng mẫu AZxxxx
            else
            {
                // Lấy chỉ số phần tử dòng cuối cùng 
                int iDongCuoi;
                s = "AZ";// Mặc định
                iDongCuoi= Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(2,4)); //Lấy 2 giá trị string, 4 giá trị int.
                iDongCuoi = iDongCuoi + 1;
                if(iDongCuoi<10)                
                    s = s + "000";
                else if (iDongCuoi<100)
                    s = s + "00";
                else if(iDongCuoi<1000)
                    s = s + "0";
                s = s + iDongCuoi.ToString();
           
            }
           
          //txtMaHV.Text = s; Tự động hiện thị mã HV trước khi thêm.
           return s; // Trả về giá trị sau khi thêm thành công.        
        }
        //Auto STT_HV
        public void SoluongHV()
        {

            //Chuỗi kết nối 
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            //Chuỗi truy vấn
            string sSoLuong = @"Select STT_HV From Hoc_Vien";
            SqlDataAdapter daSoLuong= new SqlDataAdapter(sSoLuong, sChuoiKetNoi);
            DataTable dt = new DataTable();
            daSoLuong.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Lấy chỉ số phần tử dòng cuối cùng 
                int iDongCuoi = dt.Rows.Count - 1;
                iDemSoHV = int.Parse(dt.Rows[iDongCuoi][0].ToString());
            }
        }
        //Code cho nút LƯU học viên
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daHocVien.Update(ds, "tblHocVien");
                MessageBox.Show("Lưu thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thao tác", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                //MessageBox.Show("Thao tác lỗi...", "Thông báo");
                return;
            }
        }
        //Code cho nút SỬA học viên
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvDanhSachHocVien.SelectedRows[0];
                dgvDanhSachHocVien.BeginEdit(true);
                //Không cho phép sữa MaHV;
                //dr.Cells["STT_HV"].Value = txtMaHV.Text;
                //dr.Cells["MaHV"].Value = txtMaHV.Text; 
                dr.Cells["HoTen"].Value = txtHoTen.Text;
                if (rdbGioiTinhNam.Checked == true)
                {
                    dr.Cells["GioiTinh"].Value = "Nam";
                }
                else
                {
                    dr.Cells["GioiTinh"].Value = "Nữ";
                }
                dr.Cells["NgaySinh"].Value = dtpNgaySinh.Text;
                dr.Cells["DiaChi"].Value = txtDiaChi.Text;
                dr.Cells["SDT"].Value = txtsdt.Text;
                dr.Cells["STT_Lop"].Value = cmbLop.SelectedValue;
                dr.Cells["STT_KhoaHoc"].Value = cmbKhoaHoc.SelectedValue;
                dgvDanhSachHocVien.EndEdit();
                MessageBox.Show("Cập nhật dữ liệu thành công !", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thao tác lỗi...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }
        //Code sự kiện hiện thị thông tin học viên sau khi click vào bất kì 1 dòng dử liệu.
        private void dgvDanhSachHocVien_Click(object sender, EventArgs e)
        {
           
                DataGridViewRow dr = dgvDanhSachHocVien.SelectedRows[0];
                txtMaHV.Text = dr.Cells["MaHV"].Value.ToString();
                txtHoTen.Text = dr.Cells["HoTen"].Value.ToString();
                if (dr.Cells["GioiTinh"].Value.ToString() == "Nam")
                {
                    rdbGioiTinhNam.Checked = true;
                }
                else
                {
                    rdbGioiTinhNu.Checked = false;
                }
                dtpNgaySinh.Text = dr.Cells["NgaySinh"].Value.ToString();
                txtDiaChi.Text = dr.Cells["DiaChi"].Value.ToString();
                txtsdt.Text = dr.Cells["SDT"].Value.ToString();
                cmbLop.SelectedValue = dr.Cells["STT_Lop"].Value.ToString();
                cmbKhoaHoc.SelectedValue = dr.Cells["STT_KhoaHoc"].Value.ToString();
        }
        //Code cho nút XÓA học viên
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvDanhSachHocVien.SelectedRows[0];
                dgvDanhSachHocVien.Rows.Remove(dr);
                MessageBox.Show("Xóa thành công", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Code cho nút HỦY học viên
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ds.Tables["tblHocVien"].RejectChanges();
        }
        //Code cho nút THOÁT frm học viên
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Code cho chức năng tìm kiếm học viên
        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
        }
        //Code cho chức năng click tìm kiếm học viên
        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            dv.RowFilter = string.Format("HoTen like '%{0}%'", txtTimKiem.Text);
            //dv.RowFilter = "HoTen like '%" + txtTimKiem.Text + "%'";
            //Dòng dử liệu hiện thị thêm khi tìm kiếm / code sai khi load đếm stt sai.
            //dgvDanhSachHocVien.Rows[dgvDanhSachHocVien.RowCount - 1].Cells["TenLop"].Value = LayTenLopHoc(cmbLop.SelectedValue.ToString());
            //dgvDanhSachHocVien.Rows[dgvDanhSachHocVien.RowCount - 1].Cells["TenKhoaHoc"].Value = LayTenKhoaHoc(cmbKhoaHoc.SelectedValue.ToString());

        }
        //Chuổi kết nối dử liệu chính.
        SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True");
        //Lấy thông tin học viên // backup , code này không sử dụng.
        private void LoadHV()
        {
           
            if (con.State == ConnectionState.Closed)
                con.Open();
            string sql = "tb_ThongTinHV";
            SqlCommand comd = new SqlCommand(sql, con);
            comd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter daHV = new SqlDataAdapter(comd);

            dt = new DataTable();
            daHV.Fill(dt);
            con.Close();
            dgvDanhSachHocVien.DataSource = dt;

            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnHuy.Enabled = false;
            btnXoa.Enabled = false;
        }
    }
}
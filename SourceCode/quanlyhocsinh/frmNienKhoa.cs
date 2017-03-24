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
    public partial class frmNienKhoa : Form
    {
        public frmNienKhoa()
        {
            InitializeComponent();
        }
        int iDemSoLuong;
        DataSet ds;
        DataView dv;
        SqlDataAdapter daNienKhoa;

        private void frmNienKhoa_Load(object sender, EventArgs e)
        {
            //Mã tự động tạo. Không cho phép người dùng nhập vào giá trị. (false)
            txtMaKhoaHoc.Enabled = false;
            #region frmLoad(void);
            //Chuỗi kết nối 
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            SqlConnection con = new SqlConnection(sChuoiKetNoi);
            con.Open();

            //Chuỗi truy vấn
            string sSelectKhoaHoc = @"Select * From dbo.Nien_Khoa";

            //Khởi tạo đối tượng SQLDataAdapter thực hiện truy vấn lấy dữ liệu từ database về
            daNienKhoa = new SqlDataAdapter(sSelectKhoaHoc, sChuoiKetNoi);
            //Khởi tạo Dataset
            ds = new DataSet("DsQuanLyNienKhoa");
            //Đổ dữ liệu vào 1 bảng trong dataset
            daNienKhoa.Fill(ds, "tblNienKhoa");
            dv = new DataView(ds.Tables["tblNienKhoa"]);
            //dgvDanhSachHocVien.DataSource = ds.Tables["tblHocVien"];
            dgvDanhSachKhoaHoc.DataSource = dv;
            //Đặt tên cột cho datagridview
            dgvDanhSachKhoaHoc.Columns["STT_NienKhoa"].HeaderText = "STT";
            dgvDanhSachKhoaHoc.Columns["MaNienKhoa"].HeaderText = "Mã NK";
            dgvDanhSachKhoaHoc.Columns["TenNienKhoa"].HeaderText = "Tên niên khóa";
            //Đặt lại độ rộng cho các cột trên datagridview
            dgvDanhSachKhoaHoc.Columns["MaNienKhoa"].Width = 70;
            dgvDanhSachKhoaHoc.Columns["TenNienKhoa"].Width = 150;

            //Ẩn các cột không cần thiết
            dgvDanhSachKhoaHoc.Columns["STT_NienKhoa"].Visible = false;

            //Thêm niên khóa mới vào
            string sThemNienKhoa = @"Insert into Nien_Khoa(MaNienKhoa,TenNienKhoa) values(@MaNienKhoa,@TenNienKhoa)";
            SqlCommand cmThemNienKhoa = new SqlCommand(sThemNienKhoa, con);
            cmThemNienKhoa.Parameters.Add("@MaNienKhoa", SqlDbType.VarChar, 50, "MaNienKhoa");
            cmThemNienKhoa.Parameters.Add("@TenNienKhoa", SqlDbType.NVarChar, 50, "TenNienKhoa");
            daNienKhoa.InsertCommand = cmThemNienKhoa;

            //Sữa niên khóa
            string sSuaNienKhoa = @"Update Nien_Khoa set TenNienKhoa=@TenNienKhoa,MaNienKhoa=@MaNienKhoa where STT_NienKhoa=@STT_NienKhoa";
            SqlCommand cmSuaNienKhoa = new SqlCommand(sSuaNienKhoa, con);
            cmSuaNienKhoa.Parameters.Add("@TenNienKhoa", SqlDbType.NVarChar, 50, "TenNienKhoa");
            cmSuaNienKhoa.Parameters.Add("@MaNienKhoa", SqlDbType.VarChar, 50, "MaNienKhoa");


            cmSuaNienKhoa.Parameters.Add("@STT_NienKhoa", SqlDbType.Int, 5, "STT_NienKhoa");

            daNienKhoa.UpdateCommand = cmSuaNienKhoa;
            //Xóa nien khoa
            string sXoaNienKhoa = @"Delete From Nien_Khoa where STT_NienKhoa=@STT_NienKhoa";
            SqlCommand cmXoaNienKhoa = new SqlCommand(sXoaNienKhoa, con);
            cmXoaNienKhoa.Parameters.Add("@STT_NienKhoa", SqlDbType.Int, 5, "STT_NienKhoa");
            daNienKhoa.DeleteCommand = cmXoaNienKhoa;

            #endregion
        }
        //Code nút Thêm

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiểm tra tính hợp lệ đầu vào dữ liệu
            if (txtTenKhoaHoc.Text == "")
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ thông tin!", "Thông báo");
                return;
            }
            //Thêm 1 dòng vào tblHocVien
            DataRow r = ds.Tables["tblNienKhoa"].NewRow();
            //Nhập giá trị vào các trường tương ứng trên Datarow
            r["TenNienKhoa"] = txtTenKhoaHoc.Text;
            if (iDemSoLuong == 0)
            {
                MaKHOA();
            }
            iDemSoLuong++;
            r["STT_NienKhoa"] = iDemSoLuong;
            r["MaNienKhoa"] = this.MaKhoaHoc();
            //Add Database
            ds.Tables["tblNienKhoa"].Rows.Add(r);
        }
        //Auto tạo STT_khóa
        public void MaKHOA()
        {

            //Chuỗi kết nối 
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            //Chuỗi truy vấn
            string sMaCuoik = @"Select STT_NienKhoa From Nien_Khoa";
            SqlDataAdapter daKhoaHoc2 = new SqlDataAdapter(sMaCuoik, sChuoiKetNoi);
            DataTable dt = new DataTable();
            daKhoaHoc2.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Lấy chỉ số phần tử dòng cuối cùng 
                int iDongCuoi = dt.Rows.Count - 1;
                iDemSoLuong = int.Parse(dt.Rows[iDongCuoi][0].ToString());
            }
        }
        //Auto tạo mã khóa
        public string MaKhoaHoc()
        {

            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            SqlConnection con = new SqlConnection(sChuoiKetNoi);
            if (con.State == ConnectionState.Closed)
                con.Open();
            //Chuỗi truy vấn
            string sMaKhoaHocCuoiCung = @"Select MaNienKhoa From Nien_Khoa";
            SqlDataAdapter daMa22 = new SqlDataAdapter(sMaKhoaHocCuoiCung, sChuoiKetNoi);
            DataTable dt = new DataTable();
            daMa22.Fill(dt);
            con.Close();

            string s = "";

            if (dt.Rows.Count <= 0)
                s = "Nam0001"; //Mã có dạng mẫu Namxxxx; là mã đầu tiên
            else
            {
                // Lấy chỉ số phần tử dòng cuối cùng 
                int iDongCuoi;
                s = "Nam";// Mặc định
                iDongCuoi = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(3, 4)); //Lấy 2 giá trị string, 4 giá trị int.
                iDongCuoi = iDongCuoi + 1;
                if (iDongCuoi < 10)
                    s = s + "000";
                else if (iDongCuoi < 100)
                    s = s + "00";
                else if (iDongCuoi < 1000)
                    s = s + "0";
                s = s + iDongCuoi.ToString();

            }
            return s; // Trả về giá trị sau khi thêm thành công.        
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daNienKhoa.Update(ds, "tblNienKhoa");
                MessageBox.Show("Lưu thành công !", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu thất bại !", "Thông báo");
                return;
            }
        }
        //Code nút Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvDanhSachKhoaHoc.SelectedRows[0];
                dgvDanhSachKhoaHoc.BeginEdit(true);
                dr.Cells["TenNienKhoa"].Value = txtTenKhoaHoc.Text;

                dgvDanhSachKhoaHoc.EndEdit();
                MessageBox.Show("Cập nhật dữ liệu thành công !", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thao tác lỗi...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }
        //Code nút hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ds.Tables["tblNienKhoa"].RejectChanges();
        }
        //Code nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvDanhSachKhoaHoc.SelectedRows[0];
                dgvDanhSachKhoaHoc.Rows.Remove(dr);
                MessageBox.Show("Xóa thành công", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại", "Thông báo");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDanhSachKhoaHoc_Click(object sender, EventArgs e)
        {
                    //sự kiện Click hiện thông tin khóa học
  
            DataGridViewRow dr = dgvDanhSachKhoaHoc.SelectedRows[0];
            txtMaKhoaHoc.Text = dr.Cells["MaNienKhoa"].Value.ToString();
            txtTenKhoaHoc.Text = dr.Cells["TenNienKhoa"].Value.ToString();
 
        }
    }
}

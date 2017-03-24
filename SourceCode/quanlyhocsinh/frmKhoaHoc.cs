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
    public partial class frmKhoaHoc : Form
    {
        public frmKhoaHoc()
        {
            InitializeComponent();
        }
        int iDemSoKhoa; //Đếm số lượng khóa học đang có tại trung tâm.
        DataSet ds;
        DataView dv;
        SqlDataAdapter daKhoaHoc;

        private void frmKhoaHoc_Load(object sender, EventArgs e)
        {
            //Mã tự động tạo. Không cho phép người dùng nhập vào giá trị. (false)
            txtMaKhoaHoc.Enabled = false;

            #region frmLoad(void);
            //Chuỗi kết nối 
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            SqlConnection con = new SqlConnection(sChuoiKetNoi);
            con.Open();

            //Chuỗi truy vấn
            string sSelectKhoaHoc = @"Select * From dbo.Khoa_Hoc";

            //Khởi tạo đối tượng SQLDataAdapter thực hiện truy vấn lấy dữ liệu từ database về
            daKhoaHoc = new SqlDataAdapter(sSelectKhoaHoc, sChuoiKetNoi);
            //Khởi tạo Dataset
            ds = new DataSet("DsQuanLyKhoaHoc");
            //Đổ dữ liệu vào 1 bảng trong dataset
            daKhoaHoc.Fill(ds, "tblKhoaHoc");
            dv = new DataView(ds.Tables["tblKhoaHoc"]);
            //dgvDanhSachHocVien.DataSource = ds.Tables["tblHocVien"];
            dgvDanhSachKhoaHoc.DataSource = dv;
            //Đặt tên cột cho datagridview
            dgvDanhSachKhoaHoc.Columns["STT_KhoaHoc"].HeaderText = "STT";
            dgvDanhSachKhoaHoc.Columns["MaKhoaHoc"].HeaderText = "Mã KH";
            dgvDanhSachKhoaHoc.Columns["TenKhoaHoc"].HeaderText = "Tên khóa học";
            //Đặt lại độ rộng cho các cột trên datagridview
            dgvDanhSachKhoaHoc.Columns["MaKhoaHoc"].Width = 70;
            dgvDanhSachKhoaHoc.Columns["TenKhoaHoc"].Width = 150;

            //Ẩn các cột không cần thiết
            dgvDanhSachKhoaHoc.Columns["STT_KhoaHoc"].Visible = false;

            //Thêm Khóa học mới vào
            string sThemKhoaHoc = @"Insert into Khoa_Hoc(MaKhoaHoc,TenKhoaHoc) values(@MaKhoaHoc,@TenKhoaHoc)";
            SqlCommand cmThemKhoaHoc = new SqlCommand(sThemKhoaHoc, con);
            cmThemKhoaHoc.Parameters.Add("@MaKhoaHoc", SqlDbType.VarChar, 50, "MaKhoaHoc");
            cmThemKhoaHoc.Parameters.Add("@TenKhoaHoc", SqlDbType.NVarChar, 50, "TenKhoaHoc");
            daKhoaHoc.InsertCommand = cmThemKhoaHoc;

            //Sữa khóa học
            string sSuaKhoaHoc = @"Update Khoa_Hoc set TenKhoaHoc=@TenKhoaHoc,MaKhoaHoc=@MaKhoaHoc where STT_KhoaHoc=@STT_KhoaHoc";
            SqlCommand cmSuaKhoaHoc = new SqlCommand(sSuaKhoaHoc, con);
            cmSuaKhoaHoc.Parameters.Add("@TenKhoaHoc", SqlDbType.NVarChar, 50, "TenKhoaHoc");
            cmSuaKhoaHoc.Parameters.Add("@MaKhoaHoc", SqlDbType.VarChar, 50, "MaKhoaHoc");


            cmSuaKhoaHoc.Parameters.Add("@STT_KhoaHoc", SqlDbType.Int, 5, "STT_KhoaHoc");

            daKhoaHoc.UpdateCommand = cmSuaKhoaHoc;
            //Xóa khoác học
            string sXoaKhoaHoc = @"Delete From Khoa_Hoc where STT_KhoaHoc=@STT_KhoaHoc";
            SqlCommand cmXoaKhoaHoc = new SqlCommand(sXoaKhoaHoc, con);
            cmXoaKhoaHoc.Parameters.Add("@STT_KhoaHoc", SqlDbType.Int, 5, "STT_KhoaHoc");
            daKhoaHoc.DeleteCommand = cmXoaKhoaHoc;

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
            DataRow r = ds.Tables["tblKhoaHoc"].NewRow();
            //Nhập giá trị vào các trường tương ứng trên Datarow
            r["TenKhoaHoc"] = txtTenKhoaHoc.Text;
            if (iDemSoKhoa == 0)
            {
                MaKHOA();
            }
            iDemSoKhoa++;
            r["STT_KhoaHoc"] = iDemSoKhoa;
            r["MaKhoaHoc"] = this.MaKhoaHoc();
            //Add Database
            ds.Tables["tblKhoaHoc"].Rows.Add(r);

        }
        //Auto tạo STT_khóa
        public void MaKHOA()
        {

            //Chuỗi kết nối 
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            //Chuỗi truy vấn
            string sMaCuoik = @"Select STT_KhoaHoc From Khoa_Hoc";
            SqlDataAdapter daKhoaHoc2 = new SqlDataAdapter(sMaCuoik, sChuoiKetNoi);
            //  SqlDataAdapter daTenKhoaHoc = new SqlDataAdapter(sMaHVCuoiCung, sChuoiKetNoi);
            DataTable dt = new DataTable();
            daKhoaHoc2.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Lấy chỉ số phần tử dòng cuối cùng 
                int iDongCuoi = dt.Rows.Count - 1;
                iDemSoKhoa = int.Parse(dt.Rows[iDongCuoi][0].ToString());
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
            string sMaKhoaHocCuoiCung = @"Select MaKhoaHoc From Khoa_Hoc";
            SqlDataAdapter daMa22 = new SqlDataAdapter(sMaKhoaHocCuoiCung, sChuoiKetNoi);
            DataTable dt = new DataTable();
            daMa22.Fill(dt);
            con.Close();

            string s = "";

            if (dt.Rows.Count <= 0)
                s = "KH0001"; //Mã có dạng mẫu KHxxxx; là mã đầu tiên
            else
            {
                // Lấy chỉ số phần tử dòng cuối cùng 
                int iDongCuoi;
                s = "KH";// Mặc định
                iDongCuoi = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(2, 4)); //Lấy 2 giá trị string, 4 giá trị int.
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
        //Code nút lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daKhoaHoc.Update(ds, "tblKhoaHoc");
                MessageBox.Show("Lưu thành công !", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu thất bại !", "Thông báo");
                return;
            }
        }
        //sự kiện Click hiện thông tin khóa học
        private void dgvDanhSachKhoaHoc_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvDanhSachKhoaHoc.SelectedRows[0];
            txtMaKhoaHoc.Text = dr.Cells["MaKhoaHoc"].Value.ToString();
            txtTenKhoaHoc.Text = dr.Cells["TenKhoaHoc"].Value.ToString();
          
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
        //Code nút hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ds.Tables["tblKhoaHoc"].RejectChanges();
        }
        //Code nút thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
          
              this.Close();
        }
        //Code nut Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvDanhSachKhoaHoc.SelectedRows[0];
                dgvDanhSachKhoaHoc.BeginEdit(true);
                dr.Cells["TenKhoaHoc"].Value = txtTenKhoaHoc.Text;

                dgvDanhSachKhoaHoc.EndEdit();
                MessageBox.Show("Cập nhật dữ liệu thành công !", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thao tác lỗi...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }
    }
}

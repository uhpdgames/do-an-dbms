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
    public partial class frmDotHoc : Form
    {
        public frmDotHoc()
        {
            InitializeComponent();
        }
        int iDemSoKhoa;
        DataSet ds;
        DataView dv;
        SqlDataAdapter daKhoaHoc;

        private void frmDotHoc_Load(object sender, EventArgs e)
        {
            //Mã tự động tạo. Không cho phép người dùng nhập vào giá trị. (false)
            txtMaKhoaHoc.Enabled = false;

            #region frmLoad(void);
            //Chuỗi kết nối 
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            SqlConnection con = new SqlConnection(sChuoiKetNoi);
            con.Open();

            //Chuỗi truy vấn
            string sSelectKhoaHoc = @"Select * From dbo.Doi_Khai_Giang";

            //Khởi tạo đối tượng SQLDataAdapter thực hiện truy vấn lấy dữ liệu từ database về
            daKhoaHoc = new SqlDataAdapter(sSelectKhoaHoc, sChuoiKetNoi);
            //Khởi tạo Dataset
            ds = new DataSet("DsQuanLyDotHoc");
            //Đổ dữ liệu vào 1 bảng trong dataset
            daKhoaHoc.Fill(ds, "tblDoiHoc");
            dv = new DataView(ds.Tables["tblDoiHoc"]);
            //dgvDanhSachHocVien.DataSource = ds.Tables["tblHocVien"];
            dgvDanhSachKhoaHoc.DataSource = dv;
            //Đặt tên cột cho datagridview
            dgvDanhSachKhoaHoc.Columns["STT_DoiHoc"].HeaderText = "STT";
            dgvDanhSachKhoaHoc.Columns["MaDoiHoc"].HeaderText = "Mã DH";
            dgvDanhSachKhoaHoc.Columns["TenDoiHoc"].HeaderText = "Tên đợt học";
            //Đặt lại độ rộng cho các cột trên datagridview
            dgvDanhSachKhoaHoc.Columns["MaDoiHoc"].Width = 70;
            dgvDanhSachKhoaHoc.Columns["TenDoiHoc"].Width = 100;

            //Ẩn các cột không cần thiết
            dgvDanhSachKhoaHoc.Columns["STT_DoiHoc"].Visible = false;

            //Thêm Khóa học mới vào
            string sThemKhoaHoc = @"Insert into Doi_Khai_Giang(MaDoiHoc,TenDoiHoc,STT_NienKhoa) values(@MaDoiHoc,@TenDoiHoc,@STT_NienKhoa)";
            SqlCommand cmThemKhoaHoc = new SqlCommand(sThemKhoaHoc, con);
            cmThemKhoaHoc.Parameters.Add("@MaDoiHoc", SqlDbType.VarChar, 50, "MaDoiHoc");
            cmThemKhoaHoc.Parameters.Add("@TenDoiHoc", SqlDbType.NVarChar, 50, "TenDoiHoc");
            cmThemKhoaHoc.Parameters.Add("@STT_NienKhoa", SqlDbType.Int, 10, "STT_NienKhoa");
            daKhoaHoc.InsertCommand = cmThemKhoaHoc;

            //Sữa khóa học
            string sSuaKhoaHoc = @"Update Doi_Khai_Giang set TenDoiHoc=@TenDoiHoc,MaDoiHoc=@MaDoiHoc,STT_NienKhoa=@STT_NienKhoa where STT_DoiHoc=@STT_DoiHoc";
            SqlCommand cmSuaKhoaHoc = new SqlCommand(sSuaKhoaHoc, con);
            cmSuaKhoaHoc.Parameters.Add("@TenDoiHoc", SqlDbType.NVarChar, 50, "TenDoiHoc");
            cmSuaKhoaHoc.Parameters.Add("@MaDoiHoc", SqlDbType.VarChar, 50, "MaDoiHoc");
            cmSuaKhoaHoc.Parameters.Add("@STT_NienKhoa", SqlDbType.Int, 10, "STT_NienKhoa");

            cmSuaKhoaHoc.Parameters.Add("@STT_DoiHoc", SqlDbType.Int, 5, "STT_DoiHoc");

            daKhoaHoc.UpdateCommand = cmSuaKhoaHoc;
            //Xóa khoác học
            string sXoaKhoaHoc = @"Delete From Doi_Khai_Giang where STT_DoiHoc=@STT_DoiHoc";
            SqlCommand cmXoaKhoaHoc = new SqlCommand(sXoaKhoaHoc, con);
            cmXoaKhoaHoc.Parameters.Add("@STT_DoiHoc", SqlDbType.Int, 5, "STT_DoiHoc");
            daKhoaHoc.DeleteCommand = cmXoaKhoaHoc;

            SqlDataAdapter daNienKhoa;
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
            dgvDanhSachKhoaHoc.Columns.Add(clNienKhoa);

            for (int i = 0; i < dgvDanhSachKhoaHoc.RowCount; i++)
            {
                dgvDanhSachKhoaHoc.Rows[i].Cells["TenNienKhoa"].Value = LayTenNienKhoa(dgvDanhSachKhoaHoc.Rows[i].Cells["STT_NienKhoa"].Value.ToString());

            }
            //Ẩn cột 
            dgvDanhSachKhoaHoc.Columns["STT_NienKhoa"].Visible = false;
            dgvDanhSachKhoaHoc.Columns["TenNienKhoa"].Width = 100;

            #endregion
        }

        //duyệt niên khóa
        public string LayTenNienKhoa(string sMaNK)
        {
            //Chuỗi kết nối  
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            //Chuỗi truy vấn
            string sTenNien = @"Select TenNienKhoa From Nien_Khoa Where STT_NienKhoa=" + sMaNK;
            SqlDataAdapter daDS = new SqlDataAdapter(sTenNien, sChuoiKetNoi);
            DataTable dt3 = new DataTable();
            daDS.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                return dt3.Rows[0][0].ToString();
            }
            return "";
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
            DataRow r = ds.Tables["tblDoiHoc"].NewRow();
            //Nhập giá trị vào các trường tương ứng trên Datarow
            r["TenDoiHoc"] = txtTenKhoaHoc.Text;
            if (iDemSoKhoa == 0)
            {
                MaKHOA();
            }
            iDemSoKhoa++;
            r["STT_DoiHoc"] = iDemSoKhoa;
            r["STT_NienKhoa"] = cmbniemkhoa.SelectedValue;
            r["MaDoiHoc"] = this.MaDoiHoc();
            //Add Database
            ds.Tables["tblDoiHoc"].Rows.Add(r);

            dgvDanhSachKhoaHoc.Rows[dgvDanhSachKhoaHoc.RowCount - 1].Cells["TenNienKhoa"].Value = LayTenNienKhoa(cmbniemkhoa.SelectedValue.ToString());
        }
        //Auto tạo STT_khóa
        public void MaKHOA()
        {

            //Chuỗi kết nối 
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            //Chuỗi truy vấn
            string sMaCuoik = @"Select STT_DoiHoc From Doi_Khai_Giang";
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
        public string MaDoiHoc()
        {

            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            SqlConnection con = new SqlConnection(sChuoiKetNoi);
            if (con.State == ConnectionState.Closed)
                con.Open();
            //Chuỗi truy vấn
            string sMaDoiHocCuoiCung = @"Select MaDoiHoc From Doi_Khai_Giang";
            SqlDataAdapter daMa22 = new SqlDataAdapter(sMaDoiHocCuoiCung, sChuoiKetNoi);
            DataTable dt = new DataTable();
            daMa22.Fill(dt);
            con.Close();

            string s = "";

            if (dt.Rows.Count <= 0)
                s = "Dot001"; //Mã có dạng mẫu KHxxxx; là mã đầu tiên
            else
            {
                // Lấy chỉ số phần tử dòng cuối cùng 
                int iDongCuoi;
                s = "Dot";// Mặc định
                iDongCuoi = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(3, 3)); //Lấy 2 giá trị string, 4 giá trị int.
                iDongCuoi = iDongCuoi + 1;
                if (iDongCuoi < 10)
                    s = s + "00";
                else if (iDongCuoi < 100)
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
                daKhoaHoc.Update(ds, "tblDoiHoc");
                MessageBox.Show("Lưu thành công !", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu thất bại !", "Thông báo");
                return;
            }
        }

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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ds.Tables["tblDoiHoc"].RejectChanges();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //sự kiện Click hiện thông tin
        private void dgvDanhSachKhoaHoc_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvDanhSachKhoaHoc.SelectedRows[0];
            txtMaKhoaHoc.Text = dr.Cells["MaDoiHoc"].Value.ToString();
            txtTenKhoaHoc.Text = dr.Cells["TenDoiHoc"].Value.ToString();
            cmbniemkhoa.SelectedValue = dr.Cells["STT_NienKhoa"].Value.ToString();

        }
    }
}

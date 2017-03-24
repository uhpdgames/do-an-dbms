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
    public partial class frmGiangVien : Form
    {
        public frmGiangVien()
        {
            InitializeComponent();
        }
        int iDemSoGV;//Đếm số lượng giảng viên đang dạy ở trung tâm.
        DataSet ds;
        DataView dv;
        SqlDataAdapter daGiangVien;
        SqlDataAdapter daTenTrinhDo;

        private void frmGiangVien_Load(object sender, EventArgs e)
        {
            //Mã giảng viên tự động tạo. Không cho phép người dùng nhập vào giá trị. (false)
            txtMaGV.Enabled = false;
            #region frmLoad(void);

            //Chuỗi kết nối 
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            SqlConnection con = new SqlConnection(sChuoiKetNoi);
            con.Open();

            //Chuỗi truy vấn
            string sSelectGiangVien = @"Select * From dbo.Giang_Vien";

            //Khởi tạo đối tượng SQLDataAdapter thực hiện truy vấn lấy dữ liệu từ database về
            daGiangVien = new SqlDataAdapter(sSelectGiangVien, sChuoiKetNoi);
            //Khởi tạo Dataset
            ds = new DataSet("DsQuanLyGiangVien");
            //Đổ dữ liệu vào 1 bảng trong dataset
            daGiangVien.Fill(ds, "tblGiangVien");
            dv = new DataView(ds.Tables["tblGiangVien"]);
            //dgvDanhSachGiangVien.DataSource = ds.Tables["tblGiangVien"];
            dgvDanhSachGiangVien.DataSource = dv;
            //Đặt tên cột cho datagridview
            dgvDanhSachGiangVien.Columns["STT_GV"].HeaderText = "STT";
            dgvDanhSachGiangVien.Columns["MaGV"].HeaderText = "Mã giảng viên";
            dgvDanhSachGiangVien.Columns["TenGV"].HeaderText = "Họ tên";
            dgvDanhSachGiangVien.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvDanhSachGiangVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvDanhSachGiangVien.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvDanhSachGiangVien.Columns["SDT"].HeaderText = "Số điện thoại";
            dgvDanhSachGiangVien.Columns["Email"].HeaderText = "Email";
            //Đặt lại độ rộng cho các cột trên datagridview học sinh

            dgvDanhSachGiangVien.Columns["MaGV"].Width = 100;
            dgvDanhSachGiangVien.Columns["Email"].Width = 150;
            dgvDanhSachGiangVien.Columns["GioiTinh"].Width = 100;
            dgvDanhSachGiangVien.Columns["NgaySinh"].Width = 100;

            //Ẩn các cột không cần thiết hiển thị
            dgvDanhSachGiangVien.Columns["STT_GV"].Visible = false;
         
            //Đổ dữ liệu lên control combobox trình độ
            string sSelectTrinhDo = @"Select * From dbo.TrinhDo";
            daTenTrinhDo = new SqlDataAdapter(sSelectTrinhDo, sChuoiKetNoi);
            daTenTrinhDo.Fill(ds, "tblTrinhDo");
            cmbTrinhDo.DataSource = ds.Tables["tblTrinhDo"];
            cmbTrinhDo.DisplayMember = "TrinhDo";
            cmbTrinhDo.ValueMember = "MaTD";

            DataGridViewColumn clTrinhDo = new DataGridViewColumn();
            DataGridViewCell cell_trinhdo = new DataGridViewTextBoxCell();
            clTrinhDo.CellTemplate = cell_trinhdo;
            clTrinhDo.Name = "TrinhDo";
            clTrinhDo.HeaderText = "Trình Độ";
            dgvDanhSachGiangVien.Columns.Add(clTrinhDo);

            for (int i = 0; i < dgvDanhSachGiangVien.RowCount; i++)
            {
                dgvDanhSachGiangVien.Rows[i].Cells["TrinhDo"].Value = LayTrinhDo(dgvDanhSachGiangVien.Rows[i].Cells["MaTD"].Value.ToString());

            }

            //Ẩn cột không cần thiết
            dgvDanhSachGiangVien.Columns["MaTD"].Visible = false;
            dgvDanhSachGiangVien.Columns["TrinhDo"].Width = 100;

            //Thêm Giảng viên mới
            string sThemGV = @"Insert into Giang_Vien(MaGV,TenGV,GioiTinh,NgaySinh,DiaChi,SDT,MaTD,Email) values(@MaGV,@TenGV,@GioiTinh,@NgaySinh,@DiaChi,@SDT,@MaTD,@Email)";
            SqlCommand cmThemGV = new SqlCommand(sThemGV, con);
            cmThemGV.Parameters.Add("@MaGV", SqlDbType.VarChar, 10, "MaGV");
            cmThemGV.Parameters.Add("@TenGV", SqlDbType.NVarChar, 50, "TenGV");
            cmThemGV.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 3, "GioiTinh");
            cmThemGV.Parameters.Add("@NgaySinh", SqlDbType.Date, 10, "NgaySinh");
            cmThemGV.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50, "DiaChi");
            cmThemGV.Parameters.Add("@MaTD", SqlDbType.Int, 5, "MaTD");
            cmThemGV.Parameters.Add("@SDT", SqlDbType.VarChar, 20, "SDT");
            cmThemGV.Parameters.Add("@Email", SqlDbType.VarChar, 50, "Email");

            daGiangVien.InsertCommand = cmThemGV;

            //sửa giảng viên
            //Tạo đối tượng command thực thi câu lệnh truy vấn update
            string sSuaGV = @"Update Giang_Vien set MaGV=@MaGV,TenGV=@HoTen,GioiTinh=@GioiTinh,NgaySinh=@NgaySinh,DiaChi=@DiaChi,SDT=@SDT,MaTD=@MaTD,Email=@Email where STT_GV=@STT_GV";
            SqlCommand cmSuaGV = new SqlCommand(sSuaGV, con);
            cmSuaGV.Parameters.Add("@MaGV", SqlDbType.VarChar, 10, "MaGV");
            cmSuaGV.Parameters.Add("@HoTen", SqlDbType.NVarChar, 50, "TenGV");
            cmSuaGV.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 3, "GioiTinh");
            cmSuaGV.Parameters.Add("@NgaySinh", SqlDbType.DateTime, 10, "NgaySinh");
            cmSuaGV.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 100, "DiaChi");
            cmSuaGV.Parameters.Add("@SDT", SqlDbType.VarChar, 20, "SDT");
            cmSuaGV.Parameters.Add("@Email", SqlDbType.VarChar, 50, "Email");
            cmSuaGV.Parameters.Add("@MaTD", SqlDbType.Int, 5, "MaTD");

            //Điều kiện để tìm giá trị để sửa
            cmSuaGV.Parameters.Add("@STT_GV", SqlDbType.Int, 5, "STT_GV");
  
            daGiangVien.UpdateCommand = cmSuaGV;

            //xóa giảng viên.
            //Tạo đối tượng command xóa dữ liệu 
            string sXoaGV = @"Delete From Giang_Vien where STT_GV=@STT_GV";
            SqlCommand cmXoaGV = new SqlCommand(sXoaGV, con);
            cmXoaGV.Parameters.Add("@STT_GV", SqlDbType.Int, 50, "STT_GV");
            daGiangVien.DeleteCommand = cmXoaGV;

            #endregion
        }
           
        //duyệt lấy danh sách Trình độ giảng viên.
        public string LayTrinhDo(string sMaTD)
        {
            //Chuỗi kết nối  
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            //Chuỗi truy vấn
            string sTenTD = @"Select TrinhDo From TrinhDo Where MaTD=" + sMaTD;
            SqlDataAdapter daTenTrinhDo = new SqlDataAdapter(sTenTD, sChuoiKetNoi);
            DataTable dt = new DataTable();
            daTenTrinhDo.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            return "";
        }
        //Tự động tạo mã giảng viên.
        public string MaGV()
        {

            //Chuỗi kết nối 
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            SqlConnection con = new SqlConnection(sChuoiKetNoi);
            if (con.State == ConnectionState.Closed)
                con.Open();
            //Chuỗi truy vấn
            string sMaGV = @"Select MaGV From Giang_Vien";
            SqlDataAdapter daMaGV = new SqlDataAdapter(sMaGV, sChuoiKetNoi);
            DataTable dt = new DataTable();
            daMaGV.Fill(dt);
            //đóng kết nối sql
            con.Close();

            string sss = "";

            if (dt.Rows.Count <= 0)
                sss = "AV0001"; // Mã Giảng Viên có dạng AVxxxx
            else
            {
                // Lấy chỉ số phần tử dòng cuối cùng 
                int iDongCuoi;
                sss = "AV";// Mặc định
                iDongCuoi = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(2, 4)); //Lấy 2 giá trị string, 4 giá trị int.
                iDongCuoi = iDongCuoi + 1;
                if (iDongCuoi < 10)
                    sss = sss + "000";
                else if (iDongCuoi < 100)
                    sss = sss + "00";
                else if (iDongCuoi < 1000)
                    sss = sss + "0";
                sss = sss + iDongCuoi.ToString();
            }
            return sss;
        }
       //Auto STT_GV
        public void SoluongGV()
        {

            //Chuỗi kết nối 
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            //Chuỗi truy vấn
            string sSoLuong = @"Select STT_GV From Giang_Vien";
            SqlDataAdapter daSoLuong = new SqlDataAdapter(sSoLuong, sChuoiKetNoi);
            DataTable dt = new DataTable();
            daSoLuong.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Lấy chỉ số phần tử dòng cuối cùng 
                int iDongCuoi = dt.Rows.Count - 1;
                iDemSoGV = int.Parse(dt.Rows[iDongCuoi][0].ToString());
            }
        }
        private void btnThem_2_Click(object sender, EventArgs e)
        {
            #region Code cho nút THÊM
            //Kiểm tra tính hợp lệ đầu vào dữ liệu
            if (txtHoTen_2.Text == "" || txtDiaChi_2.Text == "")
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ thông tin !", "Thông báo");
                return;
            }
            //Thêm 1 dòng vào tblGiangVien
            DataRow r = ds.Tables["tblGiangVien"].NewRow();
            //Nhập giá trị vào các trường tương ứng trên Datarow
            r["TenGV"] = txtHoTen_2.Text;
            if (rdbGioiTinhNam_2.Checked == true)
            {
                r["GioiTinh"] = "Nam";
            }
            else
            {
                r["GioiTinh"] = "Nữ";
            }
            r["NgaySinh"] = dtpNgaySinh_2.Text;
            r["DiaChi"] = txtDiaChi_2.Text;
            r["SDT"] = txtsdt_2.Text;
            r["Email"] = txtEmail.Text;
            r["MaTD"] = cmbTrinhDo.SelectedValue;
            if (iDemSoGV == 0)
            {
                SoluongGV();
            }
            iDemSoGV++;
            r["STT_GV"] = iDemSoGV;
            r["MaGV"] = this.MaGV();
            //Add vào tblGiangVien 
            ds.Tables["tblGiangVien"].Rows.Add(r);
            //Thêm tên lớp vào datagridview
            dgvDanhSachGiangVien.Rows[dgvDanhSachGiangVien.RowCount - 1].Cells["TrinhDo"].Value = LayTrinhDo(cmbTrinhDo.SelectedValue.ToString());

            #endregion
        }
        //Code cho nút LƯU
        private void btnLuu_2_Click(object sender, EventArgs e)
        {
            try
            {
                daGiangVien.Update(ds, "tblGiangVien");
                MessageBox.Show("Lưu thành công !", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu thất bại !", "Thông báo");
                return;
            }
        }
        //Code cho nút SỬA
        private void btnSua_2_Click(object sender, EventArgs e)
        {
           
            DataGridViewRow dr = dgvDanhSachGiangVien.SelectedRows[0];
            dgvDanhSachGiangVien.BeginEdit(true);
            dr.Cells["TenGV"].Value = txtHoTen_2.Text;
            if (rdbGioiTinhNam_2.Checked == true)
            {
                dr.Cells["GioiTinh"].Value = "Nam";
            }
            else
            {
                dr.Cells["GioiTinh"].Value = "Nữ";
            }
            dr.Cells["NgaySinh"].Value = dtpNgaySinh_2.Text;
            dr.Cells["DiaChi"].Value = txtDiaChi_2.Text;
            dr.Cells["SDT"].Value = txtsdt_2.Text;
            dr.Cells["MaTD"].Value = cmbTrinhDo.SelectedValue;
            dr.Cells["Email"].Value = txtEmail.Text;
            dgvDanhSachGiangVien.EndEdit();
            MessageBox.Show("Cập nhật dữ liệu thành công !", "Thông báo");
        }
        //Code cho nút XÓA
        private void btnXoa_2_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr2 = dgvDanhSachGiangVien.SelectedRows[0];
                dgvDanhSachGiangVien.Rows.Remove(dr2);
                MessageBox.Show("Xóa thành công", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại", "Thông báo");
            }
        }
        //Code cho nút HỦY
        private void btnHuy_2_Click(object sender, EventArgs e)
        {
            ds.Tables["tblGiangVien"].RejectChanges();

        }
        //Code cho nút THOÁT
        private void btnThoat_2_Click(object sender, EventArgs e)
        {
                this.Close();
        }
        //Code cho nút Tìm kiếm
        private void btnTimKiem_2_Click(object sender, EventArgs e)
        {
            dv.RowFilter = string.Format("TenGV like '%{0}%'", txtTimKiem_2.Text);
        }
        //Code cho chức năng click tìm kiếm
        private void txtTimKiem_2_TextChanged(object sender, EventArgs e)
        {
           txtTimKiem_2.Text = "";
        }
        //Code sự kiện hiện thị thông tin giảng viên sau khi click vào bất kì 1 dòng dử liệu.
        private void dgvDanhSachGiangVien_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvDanhSachGiangVien.SelectedRows[0];
            txtMaGV.Text = dr.Cells["MaGV"].Value.ToString();
            txtHoTen_2.Text = dr.Cells["TenGV"].Value.ToString();
            if (dr.Cells["GioiTinh"].Value.ToString() == "Nam")
            {
                rdbGioiTinhNam_2.Checked = true;
            }
            else
            {
                rdbGioiTinhNu_2.Checked = false;
            }
            dtpNgaySinh_2.Text = dr.Cells["NgaySinh"].Value.ToString();
            txtDiaChi_2.Text = dr.Cells["DiaChi"].Value.ToString();
            cmbTrinhDo.SelectedValue = dr.Cells["MaTD"].Value.ToString();
            txtEmail.Text = dr.Cells["Email"].Value.ToString();
            txtsdt_2.Text = dr.Cells["SDT"].Value.ToString();
        }

        private void txtTimKiem_2_Click(object sender, EventArgs e)
        {
            txtTimKiem_2.Text = "";
        }
    }
}

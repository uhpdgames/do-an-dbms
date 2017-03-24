﻿using System;
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
    public partial class frmQuanLyHocSinh : Form
    {
        public frmQuanLyHocSinh()
        {
            InitializeComponent();
        }
        int iMaHS;
        DataSet ds;
        DataView dv;
        SqlDataAdapter daHocSinh;
        SqlDataAdapter daLopHoc;
        SqlDataAdapter daHocSinh_LopHoc;
        private void frmQuanLyHocSinh_Load(object sender, EventArgs e)
        {

            //Chuỗi kết nối 
            string sChuoiKetNoi = @"Data Source=DANG-PC\SQLEXPRESS;Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            SqlConnection con = new SqlConnection(sChuoiKetNoi);
            con.Open();

            //Chuỗi truy vấn
            string sSelectHocSinh = @"Select * From dbo.Hoc_Vien";

            //Khởi tạo đối tượng SQLDataAdapter thực hiện truy vấn lấy dữ liệu từ database về
            daHocSinh = new SqlDataAdapter(sSelectHocSinh, sChuoiKetNoi);
            //Khởi tạo Dataset
            ds = new DataSet("DsQuanLyHocSinh");
            //Đổ dữ liệu vào 1 bảng trong dataset
            daHocSinh.Fill(ds, "tblHocSinh");
            dv = new DataView(ds.Tables["tblHocSinh"]);
            //dgvDanhSachHocSinh.DataSource = ds.Tables["tblHocSinh"];
            dgvDanhSachHocSinh.DataSource = dv;
            //Đặt tên cột cho datagridview
            dgvDanhSachHocSinh.Columns["MaHV"].HeaderText = "Mã học viên";
            dgvDanhSachHocSinh.Columns["HoTen"].HeaderText = "Họ tên";
            dgvDanhSachHocSinh.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvDanhSachHocSinh.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvDanhSachHocSinh.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvDanhSachHocSinh.Columns["MaLop"].HeaderText = "Lớp học";
            dgvDanhSachHocSinh.Columns["SDT"].HeaderText = "Số điện thoại";
          
            //Đặt lại độ rộng cho các cột trên datagridview học sinh

            dgvDanhSachHocSinh.Columns["MaHV"].Width = 100;
            dgvDanhSachHocSinh.Columns["GioiTinh"].Width = 70;
            dgvDanhSachHocSinh.Columns["NgaySinh"].Width = 100;
            dgvDanhSachHocSinh.Columns["MaLop"].Width = 80;

            //Đổ dữ liệu lên control combobox
            string sSelectLopHoc = @"Select * From dbo.Lop_Hoc";
            daLopHoc = new SqlDataAdapter(sSelectLopHoc, sChuoiKetNoi);
            daLopHoc.Fill(ds, "tblLopHoc");
            cmbLop.DataSource = ds.Tables["tblLopHoc"];
            cmbLop.DisplayMember = "TenLop";
            cmbLop.ValueMember = "MaLop";
            //tạo chuỗi truy vấn lấy thông tin cả 2 bảng 
            string sSelectHS_LopHoc = @"select Hoc_Vien.*,Lop_Hoc.TenLop from dbo.Hoc_Vien,dbo.Lop_Hoc where Hoc_Vien.MaLop=Lop_Hoc.MaLop";
            daHocSinh_LopHoc = new SqlDataAdapter(sSelectHS_LopHoc, sChuoiKetNoi);
            daHocSinh_LopHoc.Fill(ds, "tblHocSinh_LopHoc");
            dgvDanhSachHocSinh.DataSource = ds.Tables["tblHocSinh_LopHoc"];
            ////Ẩn cột lớp học 
            dgvDanhSachHocSinh.Columns["MaLop"].Visible = false;
            dgvDanhSachHocSinh.Columns["TenLop"].HeaderText = "Tên lớp";
            dgvDanhSachHocSinh.Columns["TenLop"].Width = 150;

            //Cách 2 : 
            //tạo chuỗi truy vấn lấy thông tin cả 2 bảng 
            //DataGridViewColumn clTenLop = new DataGridViewColumn();
            //DataGridViewCell cell = new DataGridViewTextBoxCell();
            //clTenLop.CellTemplate = cell;
            //clTenLop.Name = "TenLop";
            //clTenLop.HeaderText = "Tên lớp";
            //dgvDanhSachHocSinh.Columns.Add(clTenLop);

            //for (int i = 0; i < dgvDanhSachHocSinh.RowCount; i++)
            //{
            //    dgvDanhSachHocSinh.Rows[i].Cells["TenLop"].Value = LayTenLopHoc(dgvDanhSachHocSinh.Rows[i].Cells["MaLop"].Value.ToString());

            //}

            //Ẩn cột lớp học 
            //dgvDanhSachHocSinh.Columns["MaLop"].Visible = false;
            //dgvDanhSachHocSinh.Columns["TenLop"].HeaderText = "Tên lớp";
            //dgvDanhSachHocSinh.Columns["TenLop"].Width = 50;

            //Tạo đối tượng kết nối đến Database
            //SqlConnection con = new SqlConnection(sChuoiKetNoi);
            //Tạo đối tượng command thực thi câu lệnh truy vấn insert
            string sThemHS = @"Insert into HocSinh(HoTen,GioiTinh,NgaySinh,DiaChi,MaLop) values(@HoTen,@GioiTinh,@NgaySinh,@DiaChi,@MaLop)";
            SqlCommand cmThemHS = new SqlCommand(sThemHS, con);
            cmThemHS.Parameters.Add("@HoTen", SqlDbType.NVarChar, 50, "HoTen");
            cmThemHS.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 3, "GioiTinh");
            cmThemHS.Parameters.Add("@NgaySinh", SqlDbType.DateTime, 10, "NgaySinh");
            cmThemHS.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 100, "DiaChi");
            cmThemHS.Parameters.Add("@MaLop", SqlDbType.Int, 5, "MaLop");

            daHocSinh.InsertCommand = cmThemHS;

            //Tạo đối tượng command thực thi câu lệnh truy vấn update
            string sSuaHS = @"Update HocSinh set HoTen=@HoTen,GioiTinh=@GioiTinh,NgaySinh=@NgaySinh,DiaChi=@DiaChi,MaLop=@MaLop where MaHS=@MaHS";
            SqlCommand cmSuaHS = new SqlCommand(sSuaHS, con);
            cmSuaHS.Parameters.Add("@HoTen", SqlDbType.NVarChar, 50, "HoTen");
            cmSuaHS.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 3, "GioiTinh");
            cmSuaHS.Parameters.Add("@NgaySinh", SqlDbType.DateTime, 10, "NgaySinh");
            cmSuaHS.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 100, "DiaChi");
            cmSuaHS.Parameters.Add("@MaLop", SqlDbType.Int, 5, "MaLop");

            cmSuaHS.Parameters.Add("@MaHS", SqlDbType.Int, 5, "MaHS");
            daHocSinh.UpdateCommand = cmSuaHS;

            //Tạo đối tượng command xóa dữ liệu 
            string sXoaHS = @"Delete From HocSinh where MaHS=@MaHS";
            SqlCommand cmXoaHS = new SqlCommand(sXoaHS, con);
            cmXoaHS.Parameters.Add("@MaHS", SqlDbType.Int, 5, "MaHS");
            daHocSinh.DeleteCommand = cmXoaHS;


        }
        //Cách 2: duyệt Tên lớp
        public string LayTenLopHoc(string sMaLop)
        { 
             //Chuỗi kết nối 
            //edit:  Data Source=  
            string sChuoiKetNoi = @"DANG-PC\SQLEXPRESS;Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            //Chuỗi truy vấn
            string sTenLop = @"Select TenLop From Lop_Hoc Where MaLop=" + sMaLop;
            SqlDataAdapter daTenLop = new SqlDataAdapter(sTenLop, sChuoiKetNoi);
            DataTable dt = new DataTable();
            daTenLop.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            return "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiểm tra tính hợp lệ đầu vào dữ liệu
            if (txtHoTen.Text == "" || txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ thông tin!", "Thông báo");
                return;
            }
            //Thêm 1 dòng vào tblHocSinh
            DataRow r = ds.Tables["tblHocSinh"].NewRow();
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
            r["MaLop"] = cmbLop.SelectedValue;
            if (iMaHS == 0)
            {
                MaHSCuoiCungTruocKhiThem();
            }
            iMaHS++;
            r["MaHS"] = iMaHS;
            //Add vào tblHocSinh 
            ds.Tables["tblHocSinh"].Rows.Add(r);
            //Thêm tên lớp vào datagridview
            dgvDanhSachHocSinh.Rows[dgvDanhSachHocSinh.RowCount - 1].Cells["TenLop"].Value = LayTenLopHoc(cmbLop.SelectedValue.ToString());

        }
        public void MaHSCuoiCungTruocKhiThem()
        {

            //Chuỗi kết nối 
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=QuanLyHocSinh;Integrated Security=True";
            //Chuỗi truy vấn
            string sMaHSCuoiCung = @"Select MaHS From HocSinh";
            SqlDataAdapter daTenLop = new SqlDataAdapter(sMaHSCuoiCung, sChuoiKetNoi);
            DataTable dt = new DataTable();
            daTenLop.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                // Lấy chỉ số phần tử dòng cuối cùng 
                int iDongCuoi = dt.Rows.Count - 1;
                iMaHS = int.Parse(dt.Rows[iDongCuoi][0].ToString());
            }
           
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daHocSinh.Update(ds, "tblHocSinh");
                MessageBox.Show("Lưu thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvDanhSachHocSinh.SelectedRows[0];
            dgvDanhSachHocSinh.BeginEdit(true);
            dr.Cells["MaHS"].Value = txtMaHS.Text;
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
            dr.Cells["MaLop"].Value = cmbLop.SelectedValue;
            dgvDanhSachHocSinh.EndEdit();
            MessageBox.Show("Cập nhật dữ liệu thành công !", "Thông báo");
        }

        private void dgvDanhSachHocSinh_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgvDanhSachHocSinh.SelectedRows[0];
            txtMaHS.Text = dr.Cells["MaHS"].Value.ToString();
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
            cmbLop.SelectedValue = dr.Cells["MaLop"].Value.ToString();


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvDanhSachHocSinh.SelectedRows[0];
                dgvDanhSachHocSinh.Rows.Remove(dr);
                MessageBox.Show("Xóa thành công", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại", "Thông báo");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ds.Tables["tblHocSinh"].RejectChanges();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn thật sự muốn thoát ?","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
            {
                this.Close();
            }
            return;
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //dv.RowFilter = "HoTen like '%" + txtTimKiem.Text + "%'";
            dv.RowFilter = string.Format("HoTen like '%{0}%'", txtTimKiem.Text);
        }

        private void gbThongTinHocSinh_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        
       
       
    }
}

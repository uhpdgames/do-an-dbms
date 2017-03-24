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
using Microsoft.Reporting.WinForms;

namespace QuanLyHocSinh
{
    public partial class frmBaocao : Form
    {
        public frmBaocao()
        {
            InitializeComponent();
        }
        DataView dv;
        DataSet ds;
        private void frmBaocao_Load(object sender, EventArgs e)
        {
         
            this.View_ThongTinHocVienTableAdapter.Fill(this.Trung_Tam_Anh_Ngu_A_ZDataSet.View_ThongTinHocVien);
        
            //Khai báo
            ds = new DataSet("dsThongKe");

            //Load cmb niên khóa 
            LoadNienKhoa();
            //Lấy đợt học
            LoadcmbDot();
            //lấy Khóa học
            LoadcmbKhoaHoc();
            //lấy giảng viên.
            LoadGiangVien();

            // LoadDSHV();
          //  LoadDSHVReport();
            dv = new DataView(this.Trung_Tam_Anh_Ngu_A_ZDataSet.View_ThongTinHocVien);

            this.View_ThongTinHocVienBindingSource.DataSource = dv;
            this.rpView.RefreshReport();

        }
        //lấy dử liệu từ giảng viên
        SqlDataAdapter daGiangVien;
        private void LoadGiangVien()
        {
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            string sSelectNienKhoa = @"Select * From dbo.Giang_Vien";
            daGiangVien = new SqlDataAdapter(sSelectNienKhoa, sChuoiKetNoi);
            daGiangVien.Fill(ds, "tblGiangVien");
            cmbGiangVien.DataSource = ds.Tables["tblGiangVien"];
            cmbGiangVien.DisplayMember = "TenGV";
            cmbGiangVien.ValueMember = "STT_GV";
        }
        //lấy dử liệu từ bảng niên khóa
        SqlDataAdapter daNienKhoa;
        private void LoadNienKhoa()
        {
            string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
            string sSelectNienKhoa = @"Select * From dbo.Nien_Khoa";
            daNienKhoa = new SqlDataAdapter(sSelectNienKhoa, sChuoiKetNoi);
            daNienKhoa.Fill(ds, "tblNienKhoa");
            cmbNienKhoa.DataSource = ds.Tables["tblNienKhoa"];
            cmbNienKhoa.DisplayMember = "TenNienKhoa";
            cmbNienKhoa.ValueMember = "STT_NienKhoa";
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

        SqlDataAdapter daThongTinKhoa_Lop;
        private void combo_KhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // LoadDSHV();
            LoadDSHVReport();

            if (cb_dotkhaigiang.SelectedValue != null && !(cb_dotkhaigiang.SelectedValue is DataRowView)
            && (combo_KhoaHoc.SelectedValue != null && !(combo_KhoaHoc.SelectedValue is DataRowView))
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
        //Lấy báo cáo
        SqlDataAdapter daHV;
        private void LoadDSHVReport()
        {
            if (combo_KhoaHoc.SelectedValue != null && !(combo_KhoaHoc.SelectedValue is DataRowView)

             && combo_Lophoc.SelectedValue != null && !(combo_Lophoc.SelectedValue is DataRowView)
               )
            {
                //Chuỗi kết nối 
                string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
                //Chuỗi truy vấn
                string sSelecHV = string.Format(@"Select Hoc_Vien.MaHV,Hoc_Vien.HoTen,Hoc_Vien.GioiTinh,Hoc_Vien.NgaySinh,Hoc_Vien.DiaChi,Hoc_Vien.SDT,ThongTinLop.TenLop,Khoa_Hoc.TenKhoaHoc,ThongTinLop.NBT,ThongTinLop.NKT,Giang_Vien.TenGV
                From Hoc_Vien,ThongTinLop,Khoa_Hoc,Giang_Vien
                where Hoc_Vien.STT_Lop=ThongTinLop.STT_Lop 
                and ThongTinLop.STT_KhoaHoc=Khoa_Hoc.STT_KhoaHoc 
                and Giang_Vien.STT_GV=ThongTinLop.STT_Lop
             
                and ThongTinLop.STT_Lop={0} 
                and Khoa_Hoc.STT_KhoaHoc={1}
              
               "
                    , combo_Lophoc.SelectedValue, combo_KhoaHoc.SelectedValue);
                //Khởi tạo đối tượng SQLDataAdapter thực hiện truy vấn lấy dữ liệu từ database về
                daHV = new SqlDataAdapter(sSelecHV, sChuoiKetNoi);
                DataTable dt = new DataTable();
                //Đổ dữ liệu vào 1 bảng trong datatable
                daHV.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    //Nếu có điểm thì gán datasource
                    View_ThongTinHocVienBindingSource.DataSource = dt;
                    this.rpView.RefreshReport();
                }
                else
                {
                    View_ThongTinHocVienBindingSource.DataSource = null;
                    this.rpView.RefreshReport();
                }
            }



        }

        private void combo_Lophoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // LoadDSHV();
            LoadDSHVReport();
        }

        private void cb_dotkhaigiang_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            //Tạo reportparameter
            ReportParameter rpadoihoc = new ReportParameter("parameterDoi_Khai_Giang", cb_dotkhaigiang.Text);
            //Set parameter rpakhaigiang
            rpView.LocalReport.SetParameters(rpadoihoc);
        }

        private void cmbNienKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            //Tạo reportparameter
            ReportParameter rpanienkhoa = new ReportParameter("parameterNien_Khoa", cmbNienKhoa.Text);
            //Set parameter rpakhaigiang
            rpView.LocalReport.SetParameters(rpanienkhoa);
        }

        private void cmbGiangVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load lấy danh sách giảng viên dạy
            LoadDSHVReport_theoGiangVien();
        }
        //Lấy báo cáo theo giảng viên
        SqlDataAdapter daGiangVien_;
        private void LoadDSHVReport_theoGiangVien()
        {
            if (cmbGiangVien.SelectedValue != null && !(cmbGiangVien.SelectedValue is DataRowView)

            // && combo_Lophoc.SelectedValue != null && !(combo_Lophoc.SelectedValue is DataRowView)
               )
            {
                //Chuỗi kết nối 
                string sChuoiKetNoi = @"Data Source=(local);Initial Catalog=Trung_Tam_Anh_Ngu_A_Z;Integrated Security=True";
                //Chuỗi truy vấn
                string sSelecHV = string.Format(@"Select Hoc_Vien.MaHV,Hoc_Vien.HoTen,Hoc_Vien.GioiTinh,Hoc_Vien.NgaySinh,Hoc_Vien.DiaChi,Hoc_Vien.SDT,ThongTinLop.TenLop,Khoa_Hoc.TenKhoaHoc,ThongTinLop.NBT,ThongTinLop.NKT,Giang_Vien.TenGV
                From Hoc_Vien,ThongTinLop,Khoa_Hoc,Giang_Vien
                where Hoc_Vien.STT_Lop=ThongTinLop.STT_Lop 
                and ThongTinLop.STT_KhoaHoc=Khoa_Hoc.STT_KhoaHoc 
                and Giang_Vien.STT_GV=ThongTinLop.STT_Lop
             
                and Giang_Vien.STT_GV={0} 
                
              
               "
                    ,cmbGiangVien.SelectedValue);
                //Khởi tạo đối tượng SQLDataAdapter thực hiện truy vấn lấy dữ liệu từ database về
                daGiangVien_ = new SqlDataAdapter(sSelecHV, sChuoiKetNoi);
                DataTable dt = new DataTable();
                //Đổ dữ liệu vào 1 bảng trong datatable
                daGiangVien_.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    //Nếu có điểm thì gán datasource
                    View_ThongTinHocVienBindingSource.DataSource = dt;
                    this.rpView.RefreshReport();
                }
                else
                {
                    View_ThongTinHocVienBindingSource.DataSource = null;
                    this.rpView.RefreshReport();
                }
            }
        }

     

        private void btnTimKiem_2_Click(object sender, EventArgs e)
        {
            dv.RowFilter = string.Format("HoTen like '%{0}%'", txttim.Text);
            this.rpView.RefreshReport();
        }

        private void txttim_Click(object sender, EventArgs e)
        {
            txttim.Text = "";
        }
    }
}

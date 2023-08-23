using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Net.NetworkInformation;

namespace DAL
{

    public class DatabaseAccess
    {
        public static SqlConnection cnn = new SqlConnection(Properties.Settings.Default.tpsconeect);
       
        public static string CheckLogicDTO(TaiKhoan taikhoan)
        { 
            SqlDataAdapter tkhoan = new SqlDataAdapter("select * from DangNhap where TaiKhoan='" + taikhoan.sTaiKhoan+ "'", cnn);
            DataSet admin = new DataSet();
            tkhoan.Fill(admin);
            
                string s = "";
                foreach (DataRow dr in admin.Tables[0].Rows)
                    s = dr[1].ToString();
                if (taikhoan.sMatKhau != s.Trim())
            {
                return "Tài khoản hoặc mật khẩu không chính xác!";
            }
           
            foreach (DataRow dr in admin.Tables[0].Rows)
                taikhoan.sHoTen = dr[2].ToString();
            return taikhoan.sTaiKhoan;
        }
        public static void loadTaiKhoanDTO(TaiKhoan taikhoan,string username)
        {
            
            SqlDataAdapter tkhoan = new SqlDataAdapter("select * from DangNhap where TaiKhoan='" + username+ "'", cnn);
            DataSet admin = new DataSet();
            tkhoan.Fill(admin);

            foreach (DataRow dr in admin.Tables[0].Rows)
            {
                taikhoan.sTaiKhoan = dr[0].ToString();
                taikhoan.sHoTen=dr[1].ToString();
                taikhoan.sPhanQuyen = dr[3].ToString();
            }

        }
       
        public static void LoadPhongDTO (List<Phong> phong)
        {
         

            SqlDataAdapter sqlphong = new SqlDataAdapter("SELECT p.MaPhong, p.LoaiPhong, p.TinhTrang, p.Note, lp.DonGia FROM Phong p JOIN LoaiPhong lp ON p.LoaiPhong = lp.LoaiPhong", cnn);
            DataSet dsphong = new DataSet();
            sqlphong.Fill(dsphong);
            foreach(DataRow dr in dsphong.Tables[0].Rows)
            {
                Phong newP = new Phong();
                newP.sMaPhong= dr[0].ToString();
                newP.sLoaiPhong = dr[1].ToString();
                newP.iDonGia = int.Parse(dr[4].ToString());
                newP.sTinhTrang = dr[2].ToString();
                newP.sNote = dr[3].ToString();
                phong.Add(newP);
            }
        }
       
        public static void LoadKhachDTO(List<LoaiKhach> lk)
        {
            SqlDataAdapter sqlkhach = new SqlDataAdapter("SELECT * from LoaiKhach", cnn);
            DataSet dskhach = new DataSet();

            sqlkhach.Fill(dskhach);
            foreach (DataRow dr in dskhach.Tables[0].Rows)
            {
                LoaiKhach newLK = new LoaiKhach();
                newLK.Loai= dr[0].ToString();
                newLK.Ten = dr[1].ToString();
                newLK.HeSo = float.Parse(dr[2].ToString());
                lk.Add(newLK);
            }
        }
        static SqlDataAdapter sqlkhach = new SqlDataAdapter("SELECT * from LoaiPhong", cnn);
        static DataSet dskhach = new DataSet();
        public static void LoadPhongDTO(List<LoaiPhong> lk)
        {

          
            sqlkhach.Fill(dskhach);
            foreach (DataRow dr in dskhach.Tables[0].Rows)
            {
                LoaiPhong newLK = new LoaiPhong();
                newLK.Loai = dr[0].ToString();
                newLK.DonGia = dr[1].ToString();
               
                lk.Add(newLK);
            }
        }
        public static void UpdateLoaiPhongDTO()
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(sqlkhach);
            sqlkhach.Update(dskhach);
        }
        static int SLPhieuThue()
        {
          
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM PhieuThue", cnn);
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            int rowCount = (int)command.ExecuteScalar();
            return rowCount;
        }
       static int SLKhachHang()
        {
           
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM KhachHang", cnn);
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            int rowCount = (int)command.ExecuteScalar();
            return rowCount;
        }
        public static void SaveKhachHangDTO(List<KhachHang> kh)
        {
           
            string makh;
            int i = (SLKhachHang() + 1);
            foreach(KhachHang khs in kh)
            {
                makh = "KH" + i.ToString();
                khs.MaKH = makh;
                SqlCommand cmd = new SqlCommand("insert into KhachHang values('"+makh+"','"+khs.TenKH+"','"+khs.LoaiKH+"','"+khs.CMND+"','"+khs.DiaChi+"')", cnn);
                //Goi ExecuteNonQuery de gui command
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
                cmd.ExecuteNonQuery();
                i++;
            }
        }
        public static void SavePhieuThueDTO(PhieuThue pts)
        {
          
            string mapt;
            int i = (SLPhieuThue() + 1);
           
                mapt = "PT" + i.ToString();
                pts.MaPT = mapt;

                SqlCommand cmd = new SqlCommand("insert into PhieuThue values('" + mapt+ "','" + pts.MaPhong + "','" + pts.NgayThue+"','"+pts.MaNV+"')", cnn);
            //Goi ExecuteNonQuery de gui command
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            cmd.ExecuteNonQuery();
            SqlCommand cmd2 = new SqlCommand("Update Phong set TinhTrang='Thue' where MaPhong='"+pts.MaPhong+"'", cnn);
            cmd2.ExecuteNonQuery();

        }
        public static void SaveChiTietPhieuThueDTO(List<CHITIETPHIEUTHUE> ctpt)
        {
            
            foreach (CHITIETPHIEUTHUE ct in ctpt) {
                SqlCommand cmd = new SqlCommand("insert into ChiTietPhieuThue values('" +ct.MaPT+"','"+ ct.MaKH+"')", cnn);
                //Goi ExecuteNonQuery de gui command
                cmd.ExecuteNonQuery();
            }
        }
        public static void LoadPhieuThue(PhieuThue pt,string maphong)
        {
            
            SqlDataAdapter tkhoan = new SqlDataAdapter("SELECT * FROM PhieuThue WHERE MaPhong ='"+maphong+"' ORDER BY NgayThue", cnn);
            DataSet admin = new DataSet();
            tkhoan.Fill(admin);

            DataRow dr = admin.Tables[0].Rows[0];
                pt.MaPT = dr[0].ToString();
                pt.MaPhong = dr[1].ToString();
                pt.NgayThue = dr[2].ToString();
                pt.MaNV = dr[3].ToString();

        }
        public static void LoadChiTietPhieuThueDTO(List<CHITIETPHIEUTHUE> pt,string mapt)
        {
            
            SqlDataAdapter tkhoan = new SqlDataAdapter("SELECT * FROM ChiTietPhieuThue WHERE MaPhieuThue = '" + mapt + "'", cnn);
            DataSet admin = new DataSet();
            tkhoan.Fill(admin);

            foreach (DataRow dr in admin.Tables[0].Rows)
            {
                CHITIETPHIEUTHUE ctpt = new CHITIETPHIEUTHUE();
                ctpt.MaPT = dr[0].ToString();
                ctpt.MaKH = dr[1].ToString();
                pt.Add(ctpt);
            }
        }
        public static void LoadKhachHangDTO(List<KhachHang> kh,List<string> makh)
        {
            
            foreach (string ma in makh)
            {
                SqlDataAdapter tkhoan = new SqlDataAdapter("SELECT * FROM KhachHang WHERE MaKH = '" + ma + "'", cnn);
                DataSet admin = new DataSet();
                tkhoan.Fill(admin);

                foreach (DataRow dr in admin.Tables[0].Rows)
                {
                    KhachHang newkh = new KhachHang();
                    newkh.MaKH = dr[0].ToString();
                    newkh.TenKH = dr[1].ToString();
                    newkh.LoaiKH = dr[2].ToString();
                    newkh.CMND = dr[3].ToString();
                    newkh.DiaChi= dr[4].ToString();
                    kh.Add(newkh);
                }
            }
        }
        static int SLHoaDon()
        {
            
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM HoaDon", cnn);
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            int rowCount = (int)command.ExecuteScalar();
            return rowCount;
        }
        public static void SaveHoaDonDTO(HoaDon pts)
        {
           
            string mapt;
            int i = (SLHoaDon() + 1);

            mapt = "HD" + i.ToString();
            pts.MaHD = mapt;

            SqlCommand cmd = new SqlCommand("insert into HoaDon values('" + pts.KhachHang + "','" + pts.DiaChi + "','" + pts.NgayThanhToan + "','"+pts.TriGia+ "','" +mapt+"','"+pts.MaNV+ "')", cnn);
            //Goi ExecuteNonQuery de gui command
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            cmd.ExecuteNonQuery();
        }
    public static void SaveCTHD(List<ChiTietHD> cthd,List<string> mp)
        {
            
            foreach (ChiTietHD ct in cthd)
            {

                
                    SqlCommand cmd = new SqlCommand("insert into ChiTietHoaDon values('" + ct.MaHD + "','" + ct.MaPhieuThue + "','"+ct.SoNgayThue+"',"+ct.ThanhTien+")", cnn);
                    //Goi ExecuteNonQuery de gui command
                    cmd.ExecuteNonQuery();
            }
            foreach(string m in mp)
            {
                SqlCommand cmd2 = new SqlCommand("Update Phong set TinhTrang='Trong' where MaPhong='" + m + "'", cnn);
                cmd2.ExecuteNonQuery();
            }
        }
        public static void LoadPhongThueDTO(List<Phong> phong)
        {
           
            SqlDataAdapter sqlphong = new SqlDataAdapter("SELECT p.MaPhong, p.LoaiPhong, p.TinhTrang, p.Note, lp.DonGia FROM Phong p JOIN LoaiPhong lp ON p.LoaiPhong = lp.LoaiPhong where p.TinhTrang='Thue'", cnn);
            DataSet dsphong = new DataSet();

            sqlphong.Fill(dsphong);
            foreach (DataRow dr in dsphong.Tables[0].Rows)
            {
                Phong newP = new Phong();
                newP.sMaPhong = dr[0].ToString();
                newP.sLoaiPhong = dr[1].ToString();
                newP.iDonGia = int.Parse(dr[4].ToString());
                newP.sTinhTrang = dr[2].ToString();
                newP.sNote = dr[3].ToString();
                phong.Add(newP);
            }
            
        }

        public static void LoadPhieuThueMPDT(List<string>lpt,string mp,string month)
        {
           
            int currentYear = DateTime.Now.Year;
            SqlDataAdapter tkhoan = new SqlDataAdapter("SELECT MaPhieuThue FROM PhieuThue WHERE MaPhong ='" + mp + "' AND MONTH(NgayThue)='"+month+"' AND YEAR(NgayThue)='"+currentYear.ToString()+"'", cnn);
            DataSet admin = new DataSet();
            tkhoan.Fill(admin);

            foreach(DataRow dr in admin.Tables[0].Rows)
            {
                lpt.Add(dr[0].ToString());
            }

        }
        public static void LoadPhieuThueLpDT(List<string>lpt,string lp,string month)
        {
           
            int currentYear = DateTime.Now.Year;
            SqlDataAdapter tkhoan = new SqlDataAdapter("SELECT p.MaPhieuThue FROM PhieuThue p JOIN Phong ph ON p.MaPhong = ph.MaPhong JOIN LoaiPhong lp ON ph.LoaiPhong = lp.LoaiPhong WHERE lp.LoaiPhong = '"+lp+"' AND MONTH(NgayThue)='"+month+ "' AND YEAR(NgayThue)='" + currentYear.ToString() + "'", cnn);
            DataSet admin = new DataSet();
            tkhoan.Fill(admin);

            foreach (DataRow dr in admin.Tables[0].Rows)
            {
                lpt.Add(dr[0].ToString());
            }
        }
        public static float DoanhThuLoaiPhongBC(List<string> mpt)
        {
           
            float tong = 0;
            foreach (string s in mpt)
            {
                SqlCommand cmd = new SqlCommand("SELECT SUM(CAST(ThanhTien AS FLOAT)) FROM ChiTietHoaDon WHERE MaPhieuThue = '"+s+"'", cnn);
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
                object result = cmd.ExecuteScalar();
                float sum = Convert.IsDBNull(result) ? 0 : Convert.ToSingle(result);
                tong += sum;
            }
            return tong;
        }
        public static int SoNgayThuePhongBC(List<string> mpt)
        {
           
            int tong = 0;
            foreach (string s in mpt)
            {
                SqlCommand cmd = new SqlCommand("SELECT SUM(CAST(SoNgayThue AS INT)) FROM ChiTietHoaDon WHERE MaPhieuThue = '" + s + "'", cnn);
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
                object result = cmd.ExecuteScalar();
                int sum = Convert.IsDBNull(result) ? 0 : Convert.ToInt32(result);
                tong += sum;

            }
            return tong;
        }
        public static void LoadQuyDinhDTO(List<QuyDinh> qd)
        {
            
            SqlDataAdapter sqlkhach = new SqlDataAdapter("SELECT * from QuyDinh", cnn);
            DataSet dskhach = new DataSet();

            sqlkhach.Fill(dskhach);
            foreach (DataRow dr in dskhach.Tables[0].Rows)
            {
                QuyDinh newLK = new QuyDinh();
                newLK.MaQd = dr[0].ToString();
                newLK.TenQD = dr[1].ToString();
                newLK.GiaTri = dr[2].ToString();
                qd.Add(newLK);
            }
        }
        public static void AddLoaiKhachDTO(LoaiKhach lk)
        {
           
            SqlCommand cmd = new SqlCommand("insert into LoaiKhach values('" + lk.Loai + "','" + lk.Ten + "','" + lk.HeSo +"')", cnn);
            //Goi ExecuteNonQuery de gui command
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            cmd.ExecuteNonQuery();
        }
        public static void UpdateLoaiKhachDTO(LoaiKhach lk)
        {
            
            SqlCommand cmd2 = new SqlCommand("Update LoaiKhach set TenLoaiKhach='"+lk.Ten+"',HeSo='"+lk.HeSo+"' where LoaiKhach='" + lk.Loai+ "'", cnn);
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            cmd2.ExecuteNonQuery();
        }
        public static void DeleteLoaiKhachDTO(string MaLK)
        {
            
            SqlCommand cmd2 = new SqlCommand("Delete from LoaiKhach where LoaiKhach='" +MaLK + "'", cnn);
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            cmd2.ExecuteNonQuery();
        }
        public static void AddLoaiPhongDTO(LoaiPhong lk)
        {
           

            SqlCommand cmd = new SqlCommand("insert into LoaiPhong values('" + lk.Loai + "','" + lk.DonGia +"')", cnn);
            //Goi ExecuteNonQuery de gui command
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            cmd.ExecuteNonQuery();
        }
        public static void UpdateLoaiPhongDTO(LoaiPhong lk)
        {
            
            SqlCommand cmd2 = new SqlCommand("Update LoaiPhong set DonGia='" + lk.DonGia +"' where LoaiPhong='" + lk.Loai + "'", cnn);
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            cmd2.ExecuteNonQuery();
        }
        public static void DeleteLoaiPhongDTO(string MaLK)
        {
           
            SqlCommand cmd2 = new SqlCommand("Delete from LoaiPhong where LoaiPhong='" + MaLK + "'", cnn);
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            cmd2.ExecuteNonQuery();
        }
        public static void UpdateQuyDinhDTO(QuyDinh qd)
        {
           
            SqlCommand cmd2 = new SqlCommand("Update QuyDinh set TenQuyDinh='" + qd.TenQD + "',GiaTriQuyDinh='"+qd.GiaTri+"' where MaQuyDinh='" + qd.MaQd + "'", cnn);
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            cmd2.ExecuteNonQuery();
        }
        public static void AddPhongDTO(Phong lk)
        {
           
            SqlCommand cmd = new SqlCommand("insert into Phong values('" + lk.sMaPhong + "','" + lk.sLoaiPhong + "','" + lk.sTinhTrang + "','"+lk.sNote+"')", cnn);
            //Goi ExecuteNonQuery de gui command
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            cmd.ExecuteNonQuery();
        }
        public static void UpdatePhongDTO(Phong lk)
        { 
            SqlCommand cmd2 = new SqlCommand("Update Phong set LoaiPhong='" + lk.sLoaiPhong + "',TinhTrang='" + lk.sTinhTrang + "',Note='"+lk.sNote+"' where MaPhong='" + lk.sMaPhong + "'", cnn);
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            cmd2.ExecuteNonQuery();
        }
        public static void DeletePhongDTO(string MaLK)
        {
            
            SqlCommand cmd2 = new SqlCommand("Delete from Phong where MaPhong='" + MaLK + "'", cnn);
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            cmd2.ExecuteNonQuery();
        }

    } 
}

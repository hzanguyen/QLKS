using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{

    public class DatabaseAccess
    {
        public static string CheckLogicDTO(TaiKhoan taikhoan)
        {
            SqlConnection cnn;
            cnn = new SqlConnection("Data Source=DESKTOP-UIRD8ES\\MAYCHU;Initial Catalog=QLKS;Integrated Security=True");
            SqlDataAdapter tkhoan = new SqlDataAdapter("select TaiKhoan,Password from DangNhap where TaiKhoan='" + taikhoan.sTaiKhoan+ "'", cnn);
            DataSet admin = new DataSet();
            tkhoan.Fill(admin);
            
                string s = "";
                foreach (DataRow dr in admin.Tables[0].Rows)
                    s = dr[1].ToString();
                if (taikhoan.sMatKhau != s.Trim())
            {
                return "Tài khoản hoặc mật khẩu không chính xác!";
            }
            return taikhoan.sTaiKhoan;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class KhachHangAccess:DatabaseAccess
    {
        public void SaveKhachHang(List<KhachHang> kh)
        {
            SaveKhachHangDTO(kh);
        }
        public void LoadKhachHang(List<KhachHang> kh ,List<string> makh)
        {
            LoadKhachHangDTO(kh, makh);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class KhachHangBLL
    {
        KhachHangAccess khac = new KhachHangAccess();
        public void SaveKhachHang(List<KhachHang> kh)
        {

           
            khac.SaveKhachHang(kh);
        }
        public void LoadKhachHang(List<KhachHang> kh, List<string> makh)
        {
            khac.LoadKhachHang(kh, makh);
        }
    }
}

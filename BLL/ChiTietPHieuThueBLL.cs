using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietPHieuThueBLL
    {
        ChiTietPhieuThuAccess ctptac = new ChiTietPhieuThuAccess();
        public void SaceChiTietPhieuThu(List<CHITIETPHIEUTHUE> ctpt)
        {
           
            ctptac.SaveChiTietPhieuThue(ctpt);
        }
        public void loadChiTietPhieuThu(List<CHITIETPHIEUTHUE> pt,string mp)
        {
            ctptac.LoadChiTietPhieuThue(pt,mp);
        }
    }
}

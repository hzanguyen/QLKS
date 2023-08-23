using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class ChiTietPhieuThuAccess:DatabaseAccess
    {
        public void SaveChiTietPhieuThue(List<CHITIETPHIEUTHUE> ctpt)
        {
            SaveChiTietPhieuThueDTO(ctpt);
        }
        public void LoadChiTietPhieuThue(List<CHITIETPHIEUTHUE> pt, string mp)
        {
            LoadChiTietPhieuThueDTO(pt, mp);   
        }
        
    }
}

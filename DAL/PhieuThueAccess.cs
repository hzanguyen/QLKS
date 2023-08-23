using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class PhieuThueAccess:DatabaseAccess
    {
        public void SavePhieuThue(PhieuThue pt)
        {
            SavePhieuThueDTO(pt);
        }
        public void loadPhieuThu(PhieuThue pt,string maphong)
        {
            LoadPhieuThue(pt, maphong);
        }
        public void LoadPhieuThuMP(List<string>mpl,string mp,string month)
        {
            LoadPhieuThueMPDT(mpl, mp, month);
        }
        public void LoadPhieuThueLP(List<string>mpl,string mp,string month)
        {
            LoadPhieuThueLpDT(mpl, mp, month);
        }
    }
}

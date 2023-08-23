using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BLL
{
    public class PhieuThuBLL
    {
        PhieuThueAccess ptac = new PhieuThueAccess();
        public void SavePhieuThue(PhieuThue pt) {
           
            ptac.SavePhieuThue(pt);
        }
        public void LoadPhieuThue(PhieuThue pt, string maphong) { 
        
            ptac.loadPhieuThu(pt, maphong);
        }
         public void LoadPhieuThueMP(List<string>mpt,string mp,string month)
        {
            ptac.LoadPhieuThuMP(mpt, mp, month);
        }  
        public void LoadPhieuThueLp(List<string>mpt,string mp,string month)
        {
            ptac.LoadPhieuThueLP(mpt, mp, month);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class ChiTietHDBLL
    {
        ChiTietHDAccess cthdac = new ChiTietHDAccess();
        public void SaveChiTietHoaDon(List<ChiTietHD>cthd,List<string > mp)
        {
            cthdac.SaveChiTietHD(cthd, mp);
        }
    }
}

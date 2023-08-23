using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class HoaDonBLL
    {
        HoaDonAccess hdac = new HoaDonAccess();
        public void SaveHoaDon(HoaDon hd)
        {
            hdac.SaveHoaDon(hd);
        }
    }
}

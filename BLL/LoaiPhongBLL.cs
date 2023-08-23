using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class LoaiPhongBLL
    {
        LoadPhongAccess lpac = new LoadPhongAccess();
        public void LoadPhong(List<LoaiPhong> lp)
        {
            lpac.LoadPhong(lp);
        }
        public void AddLoadPhong(LoaiPhong lp)
        {
            lpac.AddLoaiPhong(lp);
        }
        public void UpdateLoaiPhong(LoaiPhong lp)
        {
            lpac.UpdateLoaiphong(lp);
        }
        public void DeleteLoaiPhong(string ml)
        {
            lpac.DeleteLoaiPhong(ml);
        }
    }
}

using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoadPhongAccess:DatabaseAccess
    {
        public void LoadPhong(List<LoaiPhong> lp)
        {
            LoadPhongDTO(lp);
        }
        public void AddLoaiPhong(LoaiPhong lp)
        {
            AddLoaiPhongDTO(lp);
        }
        public void UpdateLoaiphong(LoaiPhong lp)
        {
            UpdateLoaiPhongDTO(lp);
        }
        public void DeleteLoaiPhong(string ml)
        {
            DeleteLoaiPhongDTO(ml);
        }
    }
}

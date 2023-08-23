using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class LoaiKhachBLL
    {
        LoaiKhachAcess lkac = new LoaiKhachAcess();

        public void LoadKhach(List<LoaiKhach> lk)
        {
            lkac.LoadKhach(lk);
        }
        public void UpdateLoaiKhach(LoaiKhach lk)
        {
            lkac.UpdateLoaiKhach(lk);
        }
        public void AddLoaiKhach(LoaiKhach lk)
        {
            lkac.AddLoaiKhach(lk);
        }
        public void DeleteLoaiKhach(string ml)
        {
            lkac.DeleteLoaiKhach(ml);
        }
    }
}

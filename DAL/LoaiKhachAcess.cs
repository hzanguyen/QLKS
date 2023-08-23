using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO; 
namespace DAL
{
    public class LoaiKhachAcess:DatabaseAccess
    {
        public void LoadKhach(List<LoaiKhach> lk)
        {
            LoadKhachDTO(lk);
        }
        public void AddLoaiKhach(LoaiKhach lk)
        {
            AddLoaiKhachDTO(lk);
        }
        public void UpdateLoaiKhach(LoaiKhach lk)
        {
            UpdateLoaiKhachDTO(lk);
        }
        public void DeleteLoaiKhach(string ml)
        {
            DeleteLoaiKhachDTO(ml);
        }

    }
}

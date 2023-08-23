using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class PhongAccess : DatabaseAccess
    {
        public void LoadPhong(List<Phong> phong)
        {
            LoadPhongDTO(phong);
        }
        public void LoadPhongThue(List<Phong> phong)
        {
            LoadPhongThueDTO(phong);
        }
        public void AddPhong(Phong phong)
        {
            AddPhongDTO(phong);
        }
        public void UpdatePhong(Phong phong)
        {
            UpdatePhongDTO(phong);
        }
        public void DeletePhong(string mp)
        {
            DeletePhongDTO(mp);
        }
    }
}

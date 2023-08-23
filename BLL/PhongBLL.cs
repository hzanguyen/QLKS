using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class PhongBLL
    {
        PhongAccess pac = new PhongAccess();
        public void LoadPhong(List<Phong> phong)
        {
           
            pac.LoadPhong(phong);
        }
        public void LoadPhongThue(List<Phong> phong)
        {
            pac.LoadPhongThue(phong);
        }
        public void AddPhong(Phong phong)
        {
            pac.AddPhong(phong);
        }
        public void UpdatePhong(Phong phong)
        {
            pac.UpdatePhong(phong);

        }
        public void DeletePhong(string mp)
        {
            pac.DeletePhong(mp);
        }
    }
}

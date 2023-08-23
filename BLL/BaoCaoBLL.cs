using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
namespace BLL
{
    public class BaoCaoBLL
    {
        BaoCaoAccess bsac=new BaoCaoAccess();
        public float DoanhThuLP(List<string> mtp)
        {
            return bsac.DoanhThuLP(mtp);

        }
        public int SoNgayThue(List<string> mtp)
        {
            return bsac.SoNgayThueP(mtp);
        }
    }
}

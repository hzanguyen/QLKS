using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class BaoCaoAccess:DatabaseAccess
    {
        public float DoanhThuLP(List<string> mpt)
        {
            float sum=DoanhThuLoaiPhongBC(mpt);
            return sum;
        }
        public int SoNgayThueP(List<string> mpt)
        {
            int sum=SoNgayThuePhongBC(mpt);
            return sum;
        }
    }
}

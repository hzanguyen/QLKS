using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QuyDinhBLL
    {
        QuyDinhAccess qdac = new QuyDinhAccess();
        public void LoadQuyDinh(List<QuyDinh> qd)
        {
            qdac.LoadQuyDinh(qd);
        }
        public void UpdateQuyDinh(QuyDinh qd)
        {
            qdac.UpdateQuyDinh(qd);
        }
    }
}

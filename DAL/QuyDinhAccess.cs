using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuyDinhAccess:DatabaseAccess
    {
        public void LoadQuyDinh(List<QuyDinh> qd)
        {
            LoadQuyDinhDTO(qd);
        }
        public void UpdateQuyDinh(QuyDinh qd)
        {
            UpdateQuyDinhDTO(qd);
        }
    }
}

﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class ChiTietHDAccess:DatabaseAccess
    {
        public void SaveChiTietHD(List<ChiTietHD> cthd,List<string> mp)
        {
           SaveCTHD(cthd, mp);
        }
    }
}

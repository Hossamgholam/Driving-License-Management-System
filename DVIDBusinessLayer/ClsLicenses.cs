using DVIDDataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVIDBusinessLayer
{
    public class ClsLicenses
    {
        public static bool IsExsit(int PersonID,int LicenseClassId)
        {
            return ClslicensesData.ISExsit(PersonID, LicenseClassId);
        }
    }
}

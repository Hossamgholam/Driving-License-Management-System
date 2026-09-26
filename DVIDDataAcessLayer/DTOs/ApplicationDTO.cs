using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DVIDDataAcessLayer.DTOs
{
    public class ApplicationDTO
    {
        public int ApplicationID { get; set; }
        public int ApplicationPersonID { get; set; }    
        public int ApplicationTypeID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public byte ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }

        public float PaidFees { get;set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVIDDataAcessLayer.DTOs
{
    public class UserDTO
    {
        public int UserID { get; set; } 
        public int PersonID { get; set;  }
        public string UserName { get; set; }    
        public string Password { get; set; }
        public bool IsActive {  get; set; }
    }
}

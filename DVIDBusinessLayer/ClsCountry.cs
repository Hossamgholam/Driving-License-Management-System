using DVIDDataAcessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVIDBusinessLayer
{
    public  class ClsCountry
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public ClsCountry()
        {
            CountryID = 0;
            CountryName=string.Empty;
        }
        private ClsCountry(int CountryID, string CountryName)
        {
            this.CountryID= CountryID;
            this.CountryName= CountryName;
        }

        public static ClsCountry Find(int CountryID)
        {
            string CountryName = "";
            if(ClsCountryDataAccess.FindByID(CountryID,ref CountryName))
            {
                return new ClsCountry(CountryID,CountryName);
            }
            return null;
        }
        public static ClsCountry Find(string CountryName)
        {
            int CountryID = 0;
            if (ClsCountryDataAccess.FindByName(CountryName, ref CountryID))
            {
                return new ClsCountry(CountryID, CountryName);
            }
            return null;
        }
        
        public static DataTable GetAll()
        {
            return ClsCountryDataAccess.GetAllCountries();
        }
    
    }
}

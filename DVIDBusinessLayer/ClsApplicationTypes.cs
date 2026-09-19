using DVIDDataAcessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVIDBusinessLayer
{
    public class ClsApplicationTypes
    {

        public int ApplicationTypesID {  get; private set; }
        public string ApplicationTypesTitle { get; set; }
        public double ApplicationFees {  get;  set; }

        public ClsApplicationTypes(int applicationID,string applicationTypeTitle,double applicationFees) {

            ApplicationTypesID=applicationID;
            ApplicationTypesTitle=applicationTypeTitle;
            ApplicationFees=applicationFees;

        }

        public static ClsApplicationTypes Find(int applicationTypeID)
        {
            //not necessry to use DTOs
            string applicationTypeTitle = "";
            double applicationFees = 0;

            if(ClsApplicationTypesDataAccess.Find(applicationTypeID,ref applicationTypeTitle,ref applicationFees))
            {
                return new ClsApplicationTypes(applicationTypeID,applicationTypeTitle,applicationFees);
            }
            return null;
        }
        public static DataTable GetAll()
        {
            return ClsApplicationTypesDataAccess.GetAll();
        }

        private bool _Update()
        {
            return ClsApplicationTypesDataAccess.Update(this.ApplicationTypesID,this.ApplicationTypesTitle,this.ApplicationFees);
        }
        public bool Save()
        {
            return _Update();
        }

        public static bool IsExsit(int applicationTypeID)
        {
            return ClsApplicationTypesDataAccess.IsExist(applicationTypeID);    
        }

    }
}

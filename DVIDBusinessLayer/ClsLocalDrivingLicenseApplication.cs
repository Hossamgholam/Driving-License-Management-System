using DVIDDataAcessLayer;
using DVIDDataAcessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVIDBusinessLayer
{
    public class ClsLocalDrivingLicenseApplication:ClsApplication
    {
        enum _EnMode
        {
            Add,
            Update,
           
        }


        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public ClsLicenseClasses LicenseClassInfo;
        private _EnMode _Mode;



        public ClsLocalDrivingLicenseApplication()
        {
            
            LocalDrivingLicenseApplicationID = -1;
            LicenseClassID = -1;
            

            _Mode = _EnMode.Add;
        }
        public ClsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID,int LicenseClassID, int ApplicationID
            ,int ApplicationPersonId,DateTime ApplicationDate,int ApplicationTypeId, EnApplicationStatus ApplicationStatus,DateTime LastStatuseDate,float PaidFees,int CreatedByUserId)
            :base(ApplicationID,ApplicationPersonId,ApplicationTypeId,CreatedByUserId,ApplicationDate ,ApplicationStatus,LastStatuseDate,PaidFees)
            
        {
            this. LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LicenseClassID = LicenseClassID;
            LicenseClassInfo=ClsLicenseClasses.Find(LicenseClassID);
            

            _Mode = _EnMode.Update;
        }

       

        private bool _add()
        {
            this.LocalDrivingLicenseApplicationID=ClsLocalDrivingLicenseApplicationData.Add(this.LicenseClassID, this.ApplicationID);
            
            return(this.LocalDrivingLicenseApplicationID > 0);
        }
        private bool _update()
        {
            return ClsLocalDrivingLicenseApplicationData.Update(this.LocalDrivingLicenseApplicationID, this.LicenseClassID, this.ApplicationID);
        }
        public bool Save()
        {
            //we save applicatiion befor save localDrivingLicense
            base.mode=(ClsApplication.EnMode)_Mode;
            if(!base.Save()) return false;
            
            switch(_Mode)
            {
                case _EnMode.Add:
                    if(_add())
                    {
                        _Mode = _EnMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case _EnMode.Update:
                    return _update();
                default:
                    return false;
            }
        }

        public static ClsLocalDrivingLicenseApplication Find(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1;
            int LicenseClassID = -1;

            if(ClsLocalDrivingLicenseApplicationData.Find(LocalDrivingLicenseApplicationID,ref LicenseClassID, ref ApplicationID))
            {
                ClsApplication App = ClsApplication.Find(ApplicationID);

                return new ClsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, LicenseClassID, ApplicationID
                    , App.ApplicationPersonID, App.ApplicationDate, App.ApplicationTypeID, App.ApplicationStatus, App.LastStatusDate, App.PaidFees, App.CreatedByUserID);
            }
            return null;
            
        }
        public static ClsLocalDrivingLicenseApplication FindByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID = -1;
            int LicenseClassID = -1;

            if (ClsLocalDrivingLicenseApplicationData.FindByApplicationID(ApplicationID, ref LocalDrivingLicenseApplicationID, ref LicenseClassID   ))
            {
                ClsApplication App = ClsApplication.Find(ApplicationID);

                return new ClsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, LicenseClassID, ApplicationID
                    , App.ApplicationPersonID, App.ApplicationDate, App.ApplicationTypeID, App.ApplicationStatus, App.LastStatusDate, App.PaidFees, App.CreatedByUserID);
            }
            return null;

        }



        public static DataTable GetAll()
        {
            return ClsLocalDrivingLicenseApplicationData.GetAll();
        }


        public static bool Delete(int localDrivingLicenseApplicationID)
        {
            return ClsLocalDrivingLicenseApplicationData.Delete(localDrivingLicenseApplicationID);
        }



        public static bool IsExists(int localDrivingLicenseApplicationID)
        {
            return ClsLocalDrivingLicenseApplicationData.IsExsit(localDrivingLicenseApplicationID);
        }
        public static bool IsExistsByApplicationID(int applicationID)
        {
            return ClsLocalDrivingLicenseApplicationData.IsExsitByApplicationID(applicationID);
        }
    }
}

using DVIDDataAcessLayer;
using DVIDDataAcessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace DVIDBusinessLayer
{
    public class ClsApplication
    {
    
        private enum _EnMode { Add=0 , update };
        private enum _EnApplicationType
        {
            NewLocalDrivingLicense = 1,
            RenewDrivingLicense = 2,
            ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4,
            ReleaseDetainedDrivingLicense = 5,
            NewInternationalLicense = 6,
            RetakeTest = 7
        }
        public enum _EnApplicationStatus
        {
            New = 1,
            Canceled = 2,
            Completed = 3
        }



        public int ApplicationID { get;private set; }
        public int ApplicationPersonID { get; set; }

        public int ApplicationTypeID { get; set; }
        public ClsApplicationTypes ApplicationTypesInfo;

        public int CreatedByUserID { get; set; }
        public ClsUser UserInfo { get; set; }

        public DateTime ApplicationDate { get; set; }

        //it make enum the make string value and swith value to string 
        //i think i know why it do not use it as it becuse applicationstatus i do not fexsid table such applicationtype
        public _EnApplicationStatus ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }

        private _EnMode _mode;


        public ClsApplication()
        {
            this.ApplicationID=-1;
            this.ApplicationPersonID=-1;
            this.ApplicationTypeID=-1;
            this.CreatedByUserID=-1;
            this.ApplicationDate=DateTime.Now;
            this.ApplicationStatus=_EnApplicationStatus.New;
            this.LastStatusDate=DateTime.Now;
            this.PaidFees=0;

            _mode=_EnMode.Add;
        }
        public ClsApplication(int ApplicationID, int ApplicationPersonID, int ApplicationTypeID, int CreatedByUserID, DateTime ApplicationDate, _EnApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees)
        {
            this.ApplicationID=ApplicationID;

            this.ApplicationPersonID=ApplicationPersonID;
            

            this.ApplicationTypeID=ApplicationTypeID;
            this.ApplicationTypesInfo=ClsApplicationTypes.Find(ApplicationTypeID);

            this.CreatedByUserID=CreatedByUserID;
            this.UserInfo=ClsUser.Find(CreatedByUserID);

            this.ApplicationDate=ApplicationDate;
            this.ApplicationStatus=ApplicationStatus;

            this.LastStatusDate = LastStatusDate;
            this.PaidFees=PaidFees;

            _mode=_EnMode.update;

        }
        
        
        private bool _Add()
        {
            ApplicationDTO applicationDTO =new ApplicationDTO()
            {
                ApplicationPersonID = this.ApplicationPersonID,
                ApplicationTypeID = this.ApplicationTypeID,
                CreatedByUserID = this.CreatedByUserID,
                ApplicationDate = this.ApplicationDate,
                ApplicationStatus=(byte)this.ApplicationStatus,
                LastStatusDate=this.LastStatusDate,
                PaidFees=this.PaidFees,
            };

            this.ApplicationID=ClsApplicationDataAccess.Add(applicationDTO);


            //-1 becuse i initialize it in constractor by -1 
            return (this.ApplicationID!=-1);
        }
        private bool _update()
        {
            ApplicationDTO appDTO = new ApplicationDTO()
            {
                ApplicationID = this.ApplicationID,
                ApplicationPersonID = this.ApplicationPersonID,
                ApplicationTypeID = this.ApplicationTypeID,
                CreatedByUserID = this.CreatedByUserID,
                ApplicationDate = this.ApplicationDate,
                ApplicationStatus=(byte)this.ApplicationStatus,
                LastStatusDate=this.LastStatusDate,
                PaidFees=this.PaidFees,

            };

            return ClsApplicationDataAccess.Update(this.ApplicationID, appDTO);
        }
        public  bool Save()
        {
            switch (_mode)
            {
                case _EnMode.Add:
                    if (_Add())
                    {
                        _mode=_EnMode.update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case _EnMode.update:
                    return _update();

                default:return false;
            }
            
        }

        public static ClsApplication Find(int appicationId)
        {
            ApplicationDTO applicationDTO = null;
            if(ClsApplicationDataAccess.Find(appicationId,ref applicationDTO)!=false)
            {
                return new ClsApplication(applicationDTO.ApplicationID, applicationDTO.ApplicationPersonID, applicationDTO.ApplicationTypeID, applicationDTO.CreatedByUserID, applicationDTO.ApplicationDate,(_EnApplicationStatus) applicationDTO.ApplicationStatus, applicationDTO.LastStatusDate, applicationDTO.PaidFees);
            }
            return null;
        }
        
        public static DataTable GetAll()
        {
            return ClsApplicationDataAccess.GetAll();
        }

        public static bool Delete(int applicationID)
        {
            return ClsApplicationDataAccess.Delete(applicationID);
        }
    }
}

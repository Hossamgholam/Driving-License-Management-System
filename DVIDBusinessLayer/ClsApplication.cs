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
    
        public enum EnMode { Add=0 , update };
        public enum EnApplicationType
        {
            NewLocalDrivingLicense = 1,
            RenewDrivingLicense = 2,
            ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4,
            ReleaseDetainedDrivingLicense = 5,
            NewInternationalLicense = 6,
            RetakeTest = 7
        }
        public enum EnApplicationStatus
        {
            New = 1,
            Canceled = 2,
            Completed = 3
        }



        public int ApplicationID { get; set; }
        public int ApplicationPersonID { get; set; }
        public ClsPerson PersonInfo;

        public int ApplicationTypeID { get; set; }
        public ClsApplicationTypes ApplicationTypesInfo;

        public int CreatedByUserID { get; set; }
        public ClsUser UserInfo { get; set; }

        public DateTime ApplicationDate { get; set; }

        //it make enum the make string value and swith value to string 
        //i think i know why it do not use it as it becuse applicationstatus i do not fexsid table such applicationtype
        public EnApplicationStatus ApplicationStatus { get; set; }
        public string StatusName
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case EnApplicationStatus.New:
                        return "New";
                    case EnApplicationStatus.Canceled:
                        return "Canceled";
                    case EnApplicationStatus.Completed:
                        return "Completed";

                    default:
                        return "UnKonw";
                }
                    
            }
        }

        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }

        public EnMode mode;


        public ClsApplication()
        {
            this.ApplicationID=-1;
            this.ApplicationPersonID=-1;
            this.ApplicationTypeID=-1;
            this.CreatedByUserID=-1;
            this.ApplicationDate=DateTime.Now;
            this.ApplicationStatus=EnApplicationStatus.New;
            this.LastStatusDate=DateTime.Now;
            this.PaidFees=0;

            mode=EnMode.Add;
        }
        public ClsApplication(int ApplicationID, int ApplicationPersonID, int ApplicationTypeID, int CreatedByUserID, DateTime ApplicationDate, EnApplicationStatus ApplicationStatus, DateTime LastStatusDate, float PaidFees)
        {
            this.ApplicationID=ApplicationID;

            this.ApplicationPersonID=ApplicationPersonID;
            this.PersonInfo=ClsPerson.Find(ApplicationPersonID);

            this.ApplicationTypeID=ApplicationTypeID;
            this.ApplicationTypesInfo=ClsApplicationTypes.Find(ApplicationTypeID);

            this.CreatedByUserID=CreatedByUserID;
            this.UserInfo=ClsUser.Find(CreatedByUserID);

            this.ApplicationDate=ApplicationDate;
            this.ApplicationStatus=ApplicationStatus;

            this.LastStatusDate = LastStatusDate;
            this.PaidFees=PaidFees;

            mode=EnMode.update;

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

        //is static
        public static bool UpdateStatus(int applicationID, byte newStatus)
        {
            return ClsApplicationDataAccess.UpdateStatus(applicationID, newStatus);
        }

        //update status for curren object
        public bool New()
        {
            return ClsApplication.UpdateStatus(ApplicationID, 1);
        }
        public bool Canceled()
        {
           return  ClsApplicationDataAccess.UpdateStatus(ApplicationID, 2);
        }
        public bool Completed()
        {
            return ClsApplicationDataAccess.UpdateStatus(ApplicationID, 3);
        }


        public  bool Save()
        {
            switch (mode)
            {
                case EnMode.Add:
                    if (_Add())
                    {
                        mode=EnMode.update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case EnMode.update:
                    return _update();

                default:return false;
            }
            
        }

        public static ClsApplication Find(int appicationId)
        {
            ApplicationDTO applicationDTO = null;
            if(ClsApplicationDataAccess.Find(appicationId,ref applicationDTO)!=false)
            {
                return new ClsApplication(applicationDTO.ApplicationID, applicationDTO.ApplicationPersonID, applicationDTO.ApplicationTypeID, applicationDTO.CreatedByUserID, applicationDTO.ApplicationDate,(EnApplicationStatus) applicationDTO.ApplicationStatus, applicationDTO.LastStatusDate, applicationDTO.PaidFees);
            }
            return null;
        }


        // Get application ID if application is active(not completed or canceled) for a specific person and application type
        public static int GetActiveApplicationID(int applicationPersonID,EnApplicationType applicationType)
        {
            return ClsApplicationDataAccess.GetActiveApplicationID(applicationPersonID,(int)applicationType);
        }
        public int GetActiveApplicationID(EnApplicationType applicationType)
        {
            return GetActiveApplicationID(ApplicationPersonID, applicationType);
        }


        //GetActiveApplicationIDforLicense
        public static int GetActiveApplicationIDFroLicense(int ApplicationPersonID, EnApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return ClsApplicationDataAccess.GetActiveApplicationIDforLicense(ApplicationPersonID,(int) ApplicationTypeID, LicenseClassID);
        }
        public int GetActiveApplicationIDFroLicense( EnApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return GetActiveApplicationIDFroLicense(this.ApplicationPersonID, ApplicationTypeID, LicenseClassID);
        }

        public static DataTable GetAll()
        {
            return ClsApplicationDataAccess.GetAll();
        }

        public static bool Delete(int applicationID)
        {
            return ClsApplicationDataAccess.Delete(applicationID);
        }



        public static bool IsExsit(int applicationID)
        {
            return ClsApplication.IsExsit(applicationID);
        }


        // Check if a person has an active(not completed or canceled) application of a specific type
        public static bool DoesPersonHaveActiveApplication(int applicationPersonID, EnApplicationType ApplicationTypeID)
        {
            return ClsApplicationDataAccess.DoesPersonHaveActiveApplication(applicationPersonID,(int) ApplicationTypeID);

        }
        public bool DoesPersonHaveActiveApplication(EnApplicationType ApplicationTypeID)
        {
            return DoesPersonHaveActiveApplication(this.ApplicationPersonID, ApplicationTypeID);
        }
    }
}

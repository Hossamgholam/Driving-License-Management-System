using DVIDDataAcessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace DVIDBusinessLayer
{
    public class ClsLicenseClasses
    {
        private enum _EnMode
        {
            Add,
            Update,
        }


        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }
        private _EnMode Mode { get; set; }

        public ClsLicenseClasses()
        {
            LicenseClassID = -1;
            ClassName = string.Empty;
            ClassDescription = string.Empty;
            MinimumAllowedAge = 0;
            DefaultValidityLength = 0;
            ClassFees = 0.0f;
            Mode = _EnMode.Add;
        }

        public ClsLicenseClasses(int LicenseClassID, string ClassName, string ClassDescription, byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
            Mode = _EnMode.Update;
        }


        private bool _add()
        {
            this.LicenseClassID = ClsLicenseClassesData.Add(this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
            return (this.LicenseClassID > 0);
        }
        private bool _update()
        {
            return ClsLicenseClassesData.Update(this.LicenseClassID, this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case _EnMode.Add:
                    if (_add())
                    {
                        Mode = _EnMode.Update;
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

        public static ClsLicenseClasses Find(int LicenseClassID)
        {
            string ClassName = string.Empty;
            string ClassDescription = string.Empty;
            byte MinimumAllowedAge = 0;
            byte DefaultValidityLength = 0;
            float ClassFees = 0.0f;

            if (ClsLicenseClassesData.Find(LicenseClassID, ref ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
            {
                return new ClsLicenseClasses(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            else
            {
                return null;
            }
        }
        public static ClsLicenseClasses Find(string ClassName)
        {
            int LicenseClassID = -1;
            string ClassDescription = string.Empty;
            byte MinimumAllowedAge = 0;
            byte DefaultValidityLength = 0;
            float ClassFees = 0.0f;

            if (ClsLicenseClassesData.Find(ClassName, ref LicenseClassID, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))
            {
                return new ClsLicenseClasses(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            }
            else
            {
                return null;
            }
        }


        public static DataTable GetAll()
        {
            return ClsLicenseClassesData.GetAll();
        }

        public static bool Delete(int LicenseClassID)
        {
            return ClsLicenseClassesData.Delete(LicenseClassID);
        }

        public static bool IsExists(int LicenseClassID)
        {
            return ClsLicenseClassesData.IsExists(LicenseClassID);
        }

    }
}

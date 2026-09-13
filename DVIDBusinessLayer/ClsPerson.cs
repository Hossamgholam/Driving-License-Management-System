using DVIDDataAcessLayer;
using DVIDDataAcessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVIDBusinessLayer
{
    public class ClsPerson
    {
        private enum EnMode { add, update };
        private EnMode _mode;

        public int PersonID { get;set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public byte Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NationalityCountryID { get; set; }
        public ClsCountry Country;

        // the value is Null  so wh
        private string _ImagePathe;
        public string ImagePath
        {
            get { return _ImagePathe; }
            //if (we make _ImagePathe =ImagePath)   { the value that return form dataAcessLayer is "" becom null
            set { _ImagePathe=value; }
        }



        public ClsPerson()
        {
            PersonID = 0;
            NationalNo =string.Empty;
            FirstName=string.Empty;
            SecondName=string.Empty;
            ThirdName=string.Empty;
            LastName=string.Empty;
            DateOfBirth=DateTime.MinValue;
            Gender =byte.MinValue;
            Address= string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            NationalityCountryID = int.MinValue;
            ImagePath = string.Empty;

            _mode=EnMode.add;
        }

        //for update delete  becuse we make search first by find
        //and find return class with update mode (return constructo with paramter)
        private ClsPerson(int personID, string nationalNo, string firstName, string secondName, string thirdName, string lastName, DateTime dateOfBirth, byte gender, string address, string email, string phone, int nationalityCountryID, string imagePath)
        {
            this.PersonID=personID;
            this.NationalNo=nationalNo;
            this.FirstName=firstName;
            this.SecondName=secondName;
            this.ThirdName=thirdName;
            this.LastName=lastName;
            this.DateOfBirth=dateOfBirth;
            this.Gender=gender;
            this.Address=address;
            this.Email=email;
            this.Phone=phone;
            this.NationalityCountryID=nationalityCountryID;
            //imagePath return from dataAccess = ""
            //when he get to assing it to this.imagePath
            //he found in set properity  _imagePath =imagePath so go in recurciv imagePath call get 
            //and return _imagePath=Null
            this.ImagePath=imagePath;
            this.Country = ClsCountry.Find(nationalityCountryID);
            this._mode=EnMode.update;
        }
       
        
        public static ClsPerson Find(int personID)
        {
            PersonDTO personDTO = null;
            if (ClsPersonDataAccess.FindByID(personID, ref personDTO))
            {
                return new ClsPerson(personDTO.PersonID, personDTO.NationalNo, personDTO.FirstName, personDTO.SecondName, personDTO.ThirdName, personDTO.LastName,
                    personDTO.DateOfBirth, personDTO.Gender, personDTO.Address, personDTO.Email, personDTO.Phone,
                    personDTO.NationalityCountryID, personDTO.ImagePath);
            }
            else
            {
                return null;
            }
        }
        public static ClsPerson Find(string nationalNo)
        {
           
            PersonDTO personDTO = null;
            if (ClsPersonDataAccess.FindByNationalNo(nationalNo, ref personDTO))
            {
                return new ClsPerson(personDTO.PersonID, personDTO.NationalNo, personDTO.FirstName, personDTO.SecondName, personDTO.ThirdName, personDTO.LastName,
                    personDTO.DateOfBirth, personDTO.Gender, personDTO.Address, personDTO.Email, personDTO.Phone,
                    personDTO.NationalityCountryID, personDTO.ImagePath);
            }
            else
            {
                return null;
            }
        }
       
        
        private bool _AddNewCountry()
        {
            //full dto with all data from this class
            
            PersonDTO personDTO = new PersonDTO
            {
                NationalNo = this.NationalNo,
                FirstName = this.FirstName,
                SecondName = this.SecondName,
                ThirdName = this.ThirdName,
                LastName = this.LastName,
                DateOfBirth = this.DateOfBirth,
                Gender = this.Gender,
                Address = this.Address,
                Email = this.Email,
                Phone = this.Phone,
                NationalityCountryID = this.NationalityCountryID,
                ImagePath = this.ImagePath
            };

            //function to add new country and return the new id to this class or -1 if failed
            this.PersonID=ClsPersonDataAccess.Add(personDTO);

            return (this.PersonID !=-1);

        }
        private bool _UpdateCountry()
        {
            //full dto with all data from this class
            PersonDTO personDTO = new PersonDTO
            {
                PersonID = this.PersonID,
                NationalNo = this.NationalNo,
                FirstName = this.FirstName,
                SecondName = this.SecondName,
                ThirdName = this.ThirdName,
                LastName = this.LastName,
                DateOfBirth = this.DateOfBirth,
                Gender = this.Gender,
                Address = this.Address,
                Email = this.Email,
                Phone = this.Phone,
                NationalityCountryID = this.NationalityCountryID,
                ImagePath = this.ImagePath
            };

            //function to update country and return true if success
            return ClsPersonDataAccess.Update(personDTO);
        }
        public bool save()
        {
            switch (_mode)
            {
                case EnMode.add:
                    if (_AddNewCountry())
                    {
                        _mode=EnMode.update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case EnMode.update:
                    return _UpdateCountry();

                default:
                    return false;

            }
        }

        public static bool DeletePerson(int PerosnID)
        {
            return ClsPersonDataAccess.Delete(PerosnID);
        }
        
        public static DataTable GetAllPerson()
        {
            return ClsPersonDataAccess.GetAll();
        }

        public static bool isExsit(int personID)
        {
            return ClsPersonDataAccess.ISExsitByID(personID);
        }
        public static bool isExsit(string NationalNo){
            return ClsPersonDataAccess.ISExsitNatiionalNo(NationalNo);
        }
        public static bool isExsit(string NationalNo, int personID)
        {
            return ClsPersonDataAccess.ISExsitNatiionalNo(NationalNo, personID);
        }


    }
}

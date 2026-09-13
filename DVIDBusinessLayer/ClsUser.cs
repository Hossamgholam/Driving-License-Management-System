using DVIDDataAcessLayer;
using DVIDDataAcessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVIDBusinessLayer
{
    public class ClsUser
    {
        enum EnMode { Add=0,Update=1};


        //how use this class not need to put value for (UserID or Person)
        public int UserID { get;private set; }
        public int PersonID {  get; set; }
        public ClsPerson Person { get;private set; }
        public string UserName { get; set; }
        public string Password { get; set; }    
        public bool IsActive {  get; set; }

        private EnMode _Mode;



        public ClsUser()
        {
            UserID=-1;
            PersonID=-1;
            Person=null;
            UserName="";
            Password="";
            IsActive = false;

            _Mode=EnMode.Add;

        }

        public ClsUser(int userID,int personID,string userName,string password,bool isActive)
        {
            this.UserID = userID;
            this.PersonID=personID;
            this.Person=ClsPerson.Find(personID);
            this.UserName = userName;
            this.Password = password;
            this.IsActive= isActive;

            _Mode = EnMode.Update;

        }

        //Create
        private bool _AddUser()
        {
            UserDTO userDTO = new UserDTO(){
                UserID=this.UserID,
                PersonID=this.PersonID,
                UserName=this.UserName,
                Password=this.Password,
                IsActive=this.IsActive,
            };

            // if UserID is still -1 as it in Non-Paramter constrctor that mean he do not add
            this.UserID=ClsUserDataAccess.Add(userDTO);

            return (this.UserID!=-1);

        }
        //update
        private bool _UpdateUser()
        {
            UserDTO userDTO = new UserDTO()
            {
                UserID=this.UserID,
                PersonID = this.PersonID,
                UserName = this.UserName,
                Password = this.Password,
                IsActive=this.IsActive
            };
            return (ClsUserDataAccess.Update(userDTO));
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case EnMode.Add:
                    if (_AddUser())
                    {
                        _Mode=EnMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                   
                case EnMode.Update:
                    if (_UpdateUser())
                    {
                        return true;    
                    }
                    return false;
                default:
                    return false;
                   
               
            }
        }


        //Retrive 
        public static ClsUser Find(int userID)
        {
            UserDTO user = null;
            if(ClsUserDataAccess.FindByID(userID,ref user))
            {
                return new ClsUser(user.UserID,user.PersonID,user.UserName,user.Password,user.IsActive);
            }
            return null;
        }
        public static ClsUser FindByPersonID(int PersonID)
        {
            UserDTO user = null;
            if (ClsUserDataAccess.FindByPersonID(PersonID, ref user))
            {
                return new ClsUser(user.UserID, user.PersonID, user.UserName, user.Password, user.IsActive);
            }
            return null;

        }
        public static ClsUser FindByUserNamePassword(string UserName, string Passwrod)
        {
            UserDTO user = null;
            if (ClsUserDataAccess.FindByUserNamePassword(UserName,Passwrod,ref user))
            {
                return new ClsUser(user.UserID, user.PersonID, user.UserName, user.Password, user.IsActive);
            }
            return null;

        }
        public static ClsUser FindByUserName(string userName)
        {
            UserDTO user = null;
            if (ClsUserDataAccess.FindByUserName(userName, ref user))
            {
                return new ClsUser(user.UserID, user.PersonID, user.UserName, user.Password, user.IsActive);
            }
            return null;
        }
        public static DataTable GetAll()
        {
            return ClsUserDataAccess.GetAll();
        }


        public static bool Delete(int userID)
        {
            return ClsUserDataAccess.Delete(userID);
        }


        public static bool IsExist(int userID)
        {
            return ClsUserDataAccess.IsExist(userID);
        }
        public static bool IsExistByPersonID(int personID)
        {
            return ClsUserDataAccess.IsExistByPersonID(personID);
        }
        public static bool IsExist(string userName)
        {
            return ClsUserDataAccess.IsExist(userName);
        }
        public static bool IsExist(string userName, int userID)
        {
            return ClsUserDataAccess.IsExist(userName, userID);
        }


   
        public static bool ChangePassword(int userID, string newPassword)
        {
            return ClsUserDataAccess.ChangePassword(userID, newPassword);
        }
    }
}

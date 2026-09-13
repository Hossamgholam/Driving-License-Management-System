using DVIDBusinessLayer;
using DVIDDataAcessLayer;
using DVIDDataAcessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Person
            #region DataAccessLayer Test
            #region addperson
            // PersonDTO person = new PersonDTO
            // {
            //     NationalNo = "123456789",
            //     FirstName = "John",
            //     SecondName = "Doe",
            //     ThirdName = "Middle",
            //     LastName = "Smith",
            //     DateOfBirth = new DateTime(1990, 1, 1),
            //     Gender = 1,
            //     Address = "123 Main",
            //     Phone = "555-1234",
            //     Email = "john.doe@example.com",
            //     NationalityCountryID = 2,
            //     ImagePath=""

            // };
            //int personId = ClsPersonDataAccess.Add(person);
            // Console.WriteLine("Person added with ID: " + personId);
            #endregion

            #region findbyID
            //PersonDTO personDTO =null;
            //ClsPersonDataAccess.FindByID(1, ref personDTO);
            //Console.WriteLine("++++++++++++++++++++++++++++++");
            //Console.WriteLine("person info");
            //Console.WriteLine("++++++++++++++++++++++++++++++");
            //Console.WriteLine("person id:"+personDTO.PersonID);
            //Console.WriteLine("person name:"+personDTO.FirstName+" "+personDTO.LastName);
            #endregion

            #region update delete 

            //PersonDTO personDTO = null;
            //ClsPersonDataAccess.FindByID(1034, ref personDTO);


            //personDTO.FirstName = "hossam";
            //personDTO.LastName  = "gholam";
            //personDTO.Email= "hossamgholam1234@gmail.com";

            //if (ClsPersonDataAccess.Update(personDTO))
            //{
            //    Console.WriteLine("update sucess:");
            //}
            //else
            //{
            //    Console.WriteLine("not sucess update:");
            //}

            //if (ClsPersonDataAccess.Delete(1034))
            //{
            //    Console.WriteLine("delete success:");
            //}
            //else
            //{
            //    Console.WriteLine("delete not success");
            //}



            #endregion

            #region get all person
            //DataTable tablePerson = ClsPersonDataAccess.GetAll();

            //foreach (DataRow row in tablePerson.Rows)
            //{
            //    Console.WriteLine($"my name is {row["FirstName"]} {row["LastName"]}");

            //}

            //if (ClsPersonDataAccess.ISExsitByID(1))
            //{
            //    Console.WriteLine("person is exsit:ID foun");
            //}
            //else
            //{
            //    Console.WriteLine("person not exist by id");
            //}

            //if (ClsPersonDataAccess.ISExsitNatiionalNo("N1"))
            //{
            //    Console.WriteLine("person is exsit:ID  foun");
            //}
            //else
            //{
            //    Console.WriteLine("person not exist by id");
            //}
            #endregion
            #endregion

            #region BusinessLayer Test
            #region Find Person By ID
            //ClsPerson person = ClsPerson.Find("N1");
            //Console.WriteLine("===============================");
            //Console.WriteLine("person info");
            //Console.WriteLine("===============================");
            //Console.WriteLine("person id:" + person.PersonID);
            //Console.WriteLine("person name:" + person.FirstName + " " + person.LastName);
            //Console.WriteLine("person national no:" + person.NationalNo);
            #endregion



            #region add update person
            //ClsPerson person1 = new ClsPerson
            //{
            //    NationalNo = "N1",
            //    FirstName = "John",
            //    SecondName = "Doe",
            //    ThirdName = "Middle",
            //    LastName = "Smith",
            //    DateOfBirth = new DateTime(1990, 1, 1),
            //    Gender = 1,
            //    Address = "123 Main",
            //    Phone = "555-1234",
            //    Email = "john.doe@example.com",
            //    NationalityCountryID = 2,
            //    ImagePath = ""


            //};
            //if (person1.save())
            //{
            //    Console.WriteLine("Person saved successfully.");
            //} else {
            //    Console.WriteLine("Failed to save person.");
            //}




            //ClsPerson person = ClsPerson.Find(1035);
            //if (person != null) {
            //    person.NationalNo="N11";
            //    person.FirstName="hossam";
            //    person.LastName="gholam";
            //    person.Email="hossamgholam1234@gmail.com";
            //    if (person.save())
            //    {
            //        Console.WriteLine("Person updated successfully.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Failed to update person.");
            //    }

            //}
            //else
            //{
            //    Console.WriteLine("Person not found.");
            //}

            //if (ClsPerson.DeletePerson(1036))
            //{
            //    Console.WriteLine("person is delete");
            //}
            //else
            //{
            //    Console.WriteLine("person not delete");
            //}

            #endregion


            //if (ClsPersonDataAccess.ISExsitNatiionalNo("N1", 1)){
            //    Console.WriteLine("is exist");
            //}
            //else
            //{
            //    Console.WriteLine("not exsit");
            //}
            #endregion
            #endregion

            #region User
            #region DatAccessLayer
            #region Add
            //UserDTO userDTO = new UserDTO()
            //{
            //    PersonID=2056,
            //    UserName="Ali22",
            //    Password="22",
            //    IsActive=true,

            //};
            //int UserID = ClsUserDataAccess.Add(userDTO);
            //Console.WriteLine(UserID);

            #endregion

            #region Find
            //UserDTO userDTO = new UserDTO();
            ////if (ClsUserDataAccess.FindByID(0, ref userDTO))
            ////{
            ////    Console.WriteLine("user Exsit:");
            ////}
            ////else
            ////{
            ////    Console.WriteLine("User not Exsit");
            ////}

            ////if (ClsUserDataAccess.FindByPersonID(2055, ref userDTO))
            ////{
            ////    Console.WriteLine("user Exsit:");
            ////}
            ////else
            ////{
            ////    Console.WriteLine("User not Exsit");
            ////}

            //if (ClsUserDataAccess.FindByUserNamePassword("Hosam123", "Hossam@2004", ref userDTO))
            //{
            //    Console.WriteLine("user Exsit:");
            //}
            //else
            //{
            //    Console.WriteLine("User not Exsit");
            //}

            //if (ClsUserDataAccess.FindByUserName("Hosam123",ref userDTO))
            //{
            //    Console.WriteLine("user Exsit:");
            //}
            //else
            //{
            //    Console.WriteLine("User not Exsit");
            //}

            //DataTable dt = new DataTable();
            //dt=ClsUserDataAccess.GetAll();
            //if (dt!=null)
            //{
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        Console.WriteLine(dr["UserName"]+" " +dr["FullName"]);
            //    }
            //}
            //else { Console.WriteLine("No Date"); }
            #endregion

            #region Update

            //UserDTO userDTO = new UserDTO();
            //ClsUserDataAccess.FindByID(20, ref userDTO);

            //userDTO.UserName="Hosam123";
            //userDTO.Password="Hossam@2004";
            //userDTO.IsActive=false;

            //if (ClsUserDataAccess.Update(userDTO))
            //{
            //    Console.WriteLine("Yes");
            //}
            //else
            //{
            //    Console.WriteLine("no");
            //}

            #endregion

            #region Delete 
            //add user
            //UserDTO userDTO = new UserDTO()
            //{
            //    PersonID=2056,
            //    UserName="Ali22",
            //    Password="22",
            //    IsActive=true,

            //};
            //int UserID = ClsUserDataAccess.Add(userDTO);
            //Console.WriteLine(UserID);

            ////check if it exsit
            //if (ClsUserDataAccess.IsExsit(UserID))
            //{
            //    Console.WriteLine("is exsit");
            //    if (ClsUserDataAccess.Delete(UserID))
            //    {
            //        Console.WriteLine("Yes");
            //    }
            //    else
            //    {
            //        Console.WriteLine("no");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Not Exsit:");
            //}

            #endregion

            #region isExsit
            //if (ClsUserDataAccess.IsExistByPersonID(2054))
            //{
            //    Console.WriteLine("yes exsit");
            //}
            //else
            //{
            //    Console.WriteLine("not exsit");
            //}

            //if (ClsUserDataAccess.IsExist("Hosam123", 20))
            //{
            //    Console.WriteLine("you make update for this username so it is note exsit");
            //}
            //else
            //{
            //    Console.WriteLine("you add new username so this nuser name exsit");
            //}
            #endregion

            #region IsPersonidRelate
            //if (ClsUserDataAccess.IsPerosnIDRelatedToUser(105))
            //{
            //    Console.WriteLine("yes");
            //}
            //else
            //{
            //    Console.WriteLine("no");
            //}

            //if (ClsUserDataAccess.ChangePassword(17, "Omar12"))
            //{
            //    Console.WriteLine("Password change");
            //}
            //else { Console.WriteLine("no"); }
            #endregion
            #endregion

            #region BussinessLayer

            #region Add update
            //ClsUser user = new ClsUser();
            //user.PersonID=2058;
            //user.UserName="Ahmed1";
            //user.Password="Ahmed@2004";
            //user.IsActive = true;

            //if( user.Save())
            //{
            //    Console.WriteLine("Yes save:");
            //}
            //else { Console.WriteLine("no save"); }

            ////update

            //user.UserName="Ahmed123";
            //user.IsActive=false;

            //if (user.Save())
            //{
            //    Console.WriteLine("yser update");
            //}
            //else { Console.WriteLine("not save"); }
            #endregion

            #region Find
            //DataTable dt =ClsUser.GetAll();
            //if (dt!=null)
            //{
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        Console.WriteLine(dr["UserName"]+" " +dr["FullName"]);
            //    }
            //}
            //else { Console.WriteLine("No Date"); }

            //Console.WriteLine("=========================");
            //if (ClsUser.Find(0)!=null)
            //{
            //    Console.WriteLine("user Exsit:");
            //}
            //else
            //{
            //    Console.WriteLine("User not Exsit");
            //}

            //if (ClsUser.FindByPersonID(2055)!=null)
            //{
            //    Console.WriteLine("user Exsit:");
            //}
            //else
            //{
            //    Console.WriteLine("User not Exsit");
            //}

            //if (ClsUser.FindByUserNamePassword("Hossam123", "Hossam@2004")!=null)
            //{
            //    Console.WriteLine("user Exsit:");
            //}
            //else
            //{
            //    Console.WriteLine("User not Exsit");
            //}

            //if (ClsUser.FindByUserName("Hosam123")!=null)
            //{
            //    Console.WriteLine("user Exsit:");
            //}
            //else
            //{
            //    Console.WriteLine("User not Exsit");


            //}
            #endregion

            #region
            if (ClsUser.IsExistByPersonID(2054))
            {
                Console.WriteLine("yes exsit");
            }
            else
            {
                Console.WriteLine("not exsit");
            }

            if (ClsUser.IsExist("Hosam123", 20))
            {
                Console.WriteLine("you make update for this username so it is note exsit");
            }
            else
            {
                Console.WriteLine("you add new username so this nuser name exsit");
            }
            #endregion


            #endregion
            #endregion
        }

    }
}
    




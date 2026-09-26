using DVIDBusinessLayer;
using DVIDDataAcessLayer;
using DVIDDataAcessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVlD;
using DVlD.Global_Class;
using static DVIDBusinessLayer.ClsApplication;

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
            //if (ClsUser.IsExistByPersonID(2054))
            //{
            //    Console.WriteLine("yes exsit");
            //}
            //else
            //{
            //    Console.WriteLine("not exsit");
            //}

            //if (ClsUser.IsExist("Hosam123", 20))
            //{
            //    Console.WriteLine("you make update for this username so it is note exsit");
            //}
            //else
            //{
            //    Console.WriteLine("you add new username so this nuser name exsit");
            //}
            #endregion


            #endregion
            #endregion

            #region login
            // //ClsGlobalUser.RememberMe("Hossam", "hossam@1234");

            // string username = "", password = "";

            //if( ClsGlobalUser.GetStoredCreditional(ref username, ref password))
            // {
            //     Console.WriteLine($"my name is {username}, my passowrod {password}");
            // }
            // else
            // {
            //     Console.WriteLine("no creditional");
            // }
            #endregion

            #region Application type
            //DataTable dt = ClsApplicationTypes.GetAll();

            //foreach (DataRow dr in dt.Rows)
            //{
            //    Console.WriteLine($"{dr["ID"]}\t {dr["Title"]}\t {dr["Fees"]}");
            //}

            /////
            //ClsApplicationTypes applicationTypes = ClsApplicationTypes.Find(1);

            //if (ClsApplicationTypes.IsExsit(1))
            //{
            //    Console.WriteLine($"{applicationTypes.ApplicationTypesID}\t {applicationTypes.ApplicationTypesTitle}\t {applicationTypes.ApplicationFees}");
            //}
            //else
            //{
            //    Console.WriteLine("Not Exsit");
            //}

            ////update 
            //applicationTypes.ApplicationTypesTitle="New Local Driving License Service";
            //applicationTypes.ApplicationFees=15.00;

            //if (applicationTypes.Save())
            //{
            //    Console.WriteLine("Save successful");
            //}
            //else
            //{
            //    Console.WriteLine("Note successful");
            //}
            #endregion

            #region Test Type
            #region data Access
            #region Add
            //string title = "Blood Test";
            //string description = "A test to check blood sugar levels";
            //float fees = 50.0f;

            //int testID = ClsTestTypesDataAccess.Add(title, description, fees);
            //if(testID != -1)
            //{
            //    Console.WriteLine($"Test type added with ID: {testID}");
            //}
            //else
            //{
            //    Console.WriteLine("Failed to add test type.");
            //}
            #endregion

            #region Find
            //int id = 1;
            //string title = "";
            //string description = "";
            //float fees = 0.0f;

            //if (ClsTestTypesDataAccess.Find(id, ref title, ref description, ref fees))
            //{
            //    Console.WriteLine($"Test type found: ID={id}, Title={title}, Description={description}, Fees={fees}");
            //}
            //else
            //{
            //    Console.WriteLine("Test type not found.");
            //}
            #endregion

            #region getAll
            //DataTable testTypesTable = ClsTestTypesDataAccess.GetAll();
            //foreach (DataRow row in testTypesTable.Rows)
            //{
            //    Console.WriteLine($"ID: {row["TestTypeID"]}, Title: {row["TestTypeTitle"]}, Description: {row["TestTypeDescription"]}, Fees: {row["TestTypeFees"]}");
            //}

            #endregion

            #region is Exsit update
            //int testTypeID = 7;
            //if(ClsTestTypesDataAccess.IsExsit(testTypeID))
            //{
            //    Console.WriteLine($"Test type with ID {testTypeID} exists.");

            //    // Update the test type
            //    string newTitle = "Updated Test Title";
            //    string newDescription = "Updated Test Description";
            //    float newFees = 75.0f;

            //    if(ClsTestTypesDataAccess.Update(testTypeID, newTitle, newDescription, newFees))
            //    {
            //        Console.WriteLine("Test type updated successfully.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Failed to update test type.");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine($"Test type with ID {testTypeID} does not exist.");
            //}
            #endregion
            #endregion

            #region Business Layer
            //ClsTestTypes testType = ClsTestTypes.Find(1);
            //if(testType != null)
            //{
            //    Console.WriteLine($"Test type found: ID={testType.ID}, Title={testType.Title}, Description={testType.Description}, Fees={testType.Fees}");
            //}
            //else
            //{
            //    Console.WriteLine("Test type not found.");
            //}

            //DataTable allTestTypes = ClsTestTypes.GetAll();
            //foreach (DataRow row in allTestTypes.Rows)
            //{
            //    Console.WriteLine($"ID: {row["TestTypeID"]}, Title: {row["TestTypeTitle"]}, Description: {row["TestTypeDescription"]}, Fees: {row["TestTypeFees"]}");
            //}

            //string newTitle = "New Test Type";
            //string newDescription = "Description for new test type";
            //float newFees = 100.0f;
            //ClsTestTypes newTestType = new ClsTestTypes
            //{
            //    Title = newTitle,
            //    Description = newDescription,
            //    Fees = newFees
            //};
            //if(newTestType.Save())
            //{
            //    Console.WriteLine("New test type added successfully.");
            //}
            //else
            //{
            //    Console.WriteLine("Failed to add new test type.");
            //}

            //if(ClsTestTypes.IsExsit(7))
            //{
            //    ClsTestTypes existingTestType = ClsTestTypes.Find(7);
            //    existingTestType.Title = "Updated Test Type Title";
            //    existingTestType.Description = "Updated Description";
            //    existingTestType.Fees = 150.0f;
            //    if(existingTestType.Save())
            //    {
            //        Console.WriteLine("Test type updated successfully.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Failed to update test type.");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine($"Test type with ID {newTestType.ID} does not exist.");
            //}
            #endregion
            #endregion

            #region application
            #region DataAccess
            //ApplicationDTO application = new ApplicationDTO
            //{
            //    ApplicationPersonID = 2056,
            //    ApplicationTypeID = 1,
            //    CreatedByUserID = 1,
            //    ApplicationDate = DateTime.Now,
            //    ApplicationStatus = 1,
            //    LastStatusDate = DateTime.Now,
            //    PaidFees = 100.0f

            //};
            //if (ClsApplicationDataAccess.Add(application) != -1)
            //{
            //    Console.WriteLine("Application added successfully.");
            //}
            //else
            //{
            //    Console.WriteLine("Failed to add application.");
            //}



            //ApplicationDTO application = new ApplicationDTO();  
            //if(ClsApplicationDataAccess.Find(11, ref application))
            //{
            //    Console.WriteLine($"Application found: ID={application.ApplicationID}, PersonID={application.ApplicationPersonID}, TypeID={application.ApplicationTypeID}, CreatedByUserID={application.CreatedByUserID}, Date={application.ApplicationDate}, Status={application.ApplicationStatus}, LastStatusDate={application.LastStatusDate}, PaidFees={application.PaidFees}");
            //}
            //else
            //{
            //    Console.WriteLine("Application not found.");
            //}



            //DataTable applicationsTable = ClsApplicationDataAccess.GetAll();
            //if(applicationsTable != null)
            //{
            //   for(int i = 0; i < 4; i++)
            //    {
            //        DataRow row = applicationsTable.Rows[i];
            //        Console.WriteLine($"Application ID: {row["ApplicationID"]}, Person ID: {row["ApplicantPersonID"]}, Type ID: {row["ApplicationTypeID"]}, Created By User ID: {row["CreatedByUserID"]}, Date: {row["ApplicationDate"]}, Status: {row["ApplicationStatus"]}, Last Status Date: {row["LastStatusDate"]}, Paid Fees: {row["PaidFees"]}");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No applications found.");
            //}




            //ApplicationDTO applicationToUpdate = new ApplicationDTO();
            //ClsApplicationDataAccess.Find(135, ref applicationToUpdate);
            //applicationToUpdate.ApplicationStatus = 2; // Update the status
            //applicationToUpdate.LastStatusDate = DateTime.Now; // Update the last status date
            //applicationToUpdate.PaidFees = 150.0f; // Update the paid fees

            //if(ClsApplicationDataAccess.Update(135, applicationToUpdate))
            //{
            //    Console.WriteLine("Application updated successfully.");
            //}
            //else
            //{
            //    Console.WriteLine("Failed to update application.");
            //}


            //if (ClsApplicationDataAccess.Delete(136))
            //{
            //    Console.WriteLine("Application deleted successfully.");
            //}
            //else
            //{
            //    Console.WriteLine("Failed to delete application.");
            //}
            #endregion
            #region BusinessLayer
            //ClsApplication application = new ClsApplication();
            //application.ApplicationPersonID = 2056;
            //application.ApplicationTypeID = 1;
            //application.CreatedByUserID = 1;
            //application.ApplicationDate = DateTime.Now;
            //application.ApplicationStatus = _EnApplicationStatus.New;
            //application.LastStatusDate = DateTime.Now;
            //application.PaidFees = 100.0f;
            
            //if(application.Save())
            //{
            //    Console.WriteLine("Application saved successfully.");
            //}
            //else
            //{
            //    Console.WriteLine("Failed to save application.");
            //}

            //ClsApplication existingApplication = ClsApplication.Find(137);
            //if(existingApplication != null)
            //{
            //    existingApplication.ApplicationStatus = _EnApplicationStatus.Canceled;
            //    existingApplication.LastStatusDate = DateTime.Now;
            //    existingApplication.PaidFees = 15.0f;
            //    if (existingApplication.Save())
            //    {
            //        Console.WriteLine("Application updated successfully.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Failed to update application.");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Application not found.");
            //}



            //if(ClsApplicationDataAccess.IsExsit(137))
            //{
            //    Console.WriteLine("Application exists.");
            //    if(ClsApplicationDataAccess.Delete(137))
            //    {
            //        Console.WriteLine("Application deleted successfully.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Failed to delete application.");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Application does not exist.");
            //}

            //ClsApplication applicationToFind = ClsApplication.Find(138);
            //if(applicationToFind != null)
            //{
            //    Console.WriteLine("application found:");
            //    if(ClsApplicationDataAccess.UpdateStatus(138, (byte)_EnApplicationStatus.Completed))
            //    {
            //        Console.WriteLine("Application status updated successfully.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Failed to update application status.");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Application not found.");
            //}


            if(ClsApplicationDataAccess.DoesPersonHaveActiveApplication(2056, 1))
            {
                int applicationID = ClsApplicationDataAccess.FindActiveApplication(2056,2 );
                Console.WriteLine("Person has an active application of the specified type.");
                Console.WriteLine("Application ID: " + applicationID);
            }
            else
            {
                Console.WriteLine("Application does not exist.");
            }

            #endregion
            #endregion
        }

    }
}
    




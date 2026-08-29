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


            if (ClsPersonDataAccess.ISExsitNatiionalNo("N1", 1)){
                Console.WriteLine("is exist");
            }
            else
            {
                Console.WriteLine("not exsit");
            }
            #endregion
        }
    }


}

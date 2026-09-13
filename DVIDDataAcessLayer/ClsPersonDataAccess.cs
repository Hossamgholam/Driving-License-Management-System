using DVIDDataAcessLayer.DTOs;
using DVIDDataAcessLayer.HelperMethod;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVIDDataAcessLayer
{
 
    public class ClsPersonDataAccess
    {
        //R(find  get)  C(add)  U(update)  D(delete)  (CRUD
        public static bool FindByID(int PersonID, ref PersonDTO person)
        {
            bool found = false;
            SqlConnection connection=new SqlConnection(ClsDataAccessSetting.ConnectionString);

            string query = "select* from Person where PersonID = @PersonID;";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read()) {
                    found = true;
                    person=Maping.MapingPerson(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                found=false;
            }
            finally
            {
                connection.Close();
            }

                return found;
        
        }
        public static bool FindByNationalNo(string NationalNo, ref PersonDTO person)
        {
            bool found = false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.ConnectionString);

            string query = "select* from Person where NationalNo = @NationalNo;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    found = true;
                    person = Maping.MapingPerson(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                found = false;
            }
            finally
            {
                connection.Close();
            }
            return found;
        }
        
        /// <summary>
        /// Get all persons from the database.
        /// return CountryID not important because it will be replaced by CountryName in the query
        /// </summary>
        /// <returns>A DataTable containing all persons</returns>
        public static DataTable GetAll()
        {
            DataTable TableOfPerson=new DataTable();
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "select PersonID,NationalNo,FirstName,SecondName,ThirdName,LastName," +
                "DateOfBirth,Gender=" +
                "case " +
                "when Gender=0 then 'male'" +
                "when Gender=1 then 'female'" +
                "end," +
                "Address,Phone,Email,Countries.CountryName,ImagePath" +
                " from Person  join Countries on Person.NationalityCountryID=Countries.CountryID";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader=command.ExecuteReader();
                if (reader.Read())
                {

                TableOfPerson.Load(reader);
                }

            } catch (Exception ex)
            {
                TableOfPerson= null;
            }
            finally { connection.Close(); }
            return TableOfPerson;
        }
        public static int Add(PersonDTO person)
        {
            
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.ConnectionString);

            string query= "insert into Person(NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath)" +
                "values (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gender, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath);" +
            "select SCOPE_IDENTITY() as PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", person.NationalNo);
            command.Parameters.AddWithValue("@FirstName", person.FirstName);
            command.Parameters.AddWithValue("@SecondName", person.SecondName);

            command.Parameters.AddWithValue("@ThirdName",string.IsNullOrWhiteSpace(person.ThirdName) ? (object)DBNull.Value :person.ThirdName);

            command.Parameters.AddWithValue("@LastName", person.LastName);
            command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
            command.Parameters.AddWithValue("@Gender", person.Gender);
            command.Parameters.AddWithValue("@Address", person.Address);
            command.Parameters.AddWithValue("@Phone", person.Phone);

            command.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(person.Email) ? (object)DBNull.Value : person.Email);
            
            command.Parameters.AddWithValue("@NationalityCountryID", person.NationalityCountryID) ;
            
            command.Parameters.AddWithValue("@ImagePath", string.IsNullOrWhiteSpace(person.ImagePath)?(object)DBNull.Value:person.ImagePath);



            try
            {
                connection.Open();
                object result=command.ExecuteScalar();
                if (result!=null&& int.TryParse(result.ToString(), out int YourID))
                {
                    person.PersonID= YourID;
                }
            }
            catch (Exception ex)
            {
               person.PersonID = -1;
                // Log the exception or handle it as needed

            }
            finally
            {
                connection.Close();
            }
                return person.PersonID;
        }
        public static bool Update (PersonDTO person)
        {
            int rowAffect = 0;

            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "update Person set NationalNo=@NationalNo, FirstName = @FirstName, SecondName = @SecondName, ThirdName = @ThirdName, LastName = @LastName," +
                "DateOfBirth = @DateOfBirth, Gender = @Gender, Address = @Address, Phone = @Phone, Email = @Email," +
                "NationalityCountryID = @NationalityCountryID, ImagePath = @ImagePath where PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", person.PersonID);
            command.Parameters.AddWithValue("@NationalNo", person.NationalNo);
            command.Parameters.AddWithValue("@FirstName", person.FirstName);
            command.Parameters.AddWithValue("@SecondName", person.SecondName);

            command.Parameters.AddWithValue("@ThirdName", string.IsNullOrWhiteSpace(person.ThirdName) ? (object)DBNull.Value : person.ThirdName);

            command.Parameters.AddWithValue("@LastName", person.LastName);
            command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
            command.Parameters.AddWithValue("@Gender", person.Gender);
            command.Parameters.AddWithValue("@Address", person.Address);
            command.Parameters.AddWithValue("@Phone", person.Phone);

            command.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(person.Email) ? (object)DBNull.Value : person.Email);

            command.Parameters.AddWithValue("@NationalityCountryID", person.NationalityCountryID);

            command.Parameters.AddWithValue("@ImagePath", string.IsNullOrWhiteSpace(person.ImagePath) ? (object)DBNull.Value : person.ImagePath);

            try
            {
                connection.Open();
                rowAffect=command.ExecuteNonQuery();


            }
            catch(Exception ex) 
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (rowAffect>0);
        }
        public static bool Delete(int PersonID)
        {
            int RowAffect = 0;
            SqlConnection connection =new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "delete Person where PersonID=@PersonID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                RowAffect = command.ExecuteNonQuery();  

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
                return (RowAffect>0);
        }

        public static bool ISExsitByID(int PersonID)
        {
            bool isExsit = false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "select 1 from Person Where PersonID=@PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isExsit = reader.Read();
                reader.Close();


            }
            catch (Exception ex)
            {
                return isExsit;
            }
            finally
            {
                connection.Close();

            }
            return isExsit ;
        }

        public static bool ISExsitNatiionalNo(string NationalNo)
        {
            bool isExsit = false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "select 1 from Person Where NationalNo=@NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isExsit = reader.Read();

                reader.Close() ;


            }
            catch (Exception ex)
            {
                return isExsit;
            }
            finally
            {
                connection.Close();

            }
            return isExsit;
        }

        public static bool ISExsitNatiionalNo(string NationalNo, int personId)
        {
            bool isExsit = false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            
            string query = "select 1 from Person Where NationalNo=@NationalNo and PersonID<>@personId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@personId", personId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isExsit = reader.Read();
                reader.Close();


            }
            catch (Exception ex)
            {
                return isExsit;
            }
            finally
            {
                connection.Close();

            }
            return isExsit;
        }
    }
}

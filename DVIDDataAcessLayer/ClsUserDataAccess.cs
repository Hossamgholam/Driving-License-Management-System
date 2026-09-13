using DVIDDataAcessLayer.DTOs;
using DVIDDataAcessLayer.HelperMethod;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DVIDDataAcessLayer
{
    public class ClsUserDataAccess
    {
        //Create
        public static int Add(UserDTO user)
        {
            //open connection
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.ConnectionString);

            //make Query
            string Query = "insert into Users(PersonID,UserName,Password,IsActive) values(@PersonID,@UserName,@Password,@IsActive);" +
                "select SCOPE_IDENTITY() as UserID ;";

            //Make Car that carry connection and Query
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", user.PersonID);
            command.Parameters.AddWithValue("@UserName", user.UserName);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@IsActive", user.IsActive);

            try
            {
                connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int UserID))
                {
                    user.UserID= UserID;
                }


            }
            catch (Exception ex)
            {
                user.UserID=-1;
            }
            finally
            {
                connection.Close();
            }

            return user.UserID;
        }

        //Retrive(Find GetAll)
        public static bool FindByID(int userID, ref UserDTO user)
        {
            bool Found = false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.ConnectionString);

            string query = "select* from Users where UserID=@UserID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserID", userID);


            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Found = true;
                    user=Maping.MapingUser(reader);
                }
                else
                {
                    Found = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Found=false;
            }
            finally { connection.Close(); }

            return Found;

        }
        public static bool FindByPersonID(int PersonID, ref UserDTO user)
        {
            bool Found = false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.ConnectionString);

            string query = "select* from Users where PersonID=@PersonID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Found = true;
                    user=Maping.MapingUser(reader);
                }
                else
                {
                    Found = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Found=false;
            }
            finally { connection.Close(); }

            return Found;

        }
        public static bool FindByUserNamePassword(string UserName, string Passwrod, ref UserDTO user)
        {
            bool Found = false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.ConnectionString);

            string query = "select* from Users where (UserName=@UserName and Password=@Password)";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Passwrod);


            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Found = true;
                    user=Maping.MapingUser(reader);
                }
                else
                {
                    Found = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Found=false;
            }
            finally { connection.Close(); }

            return Found;

        }
        public static bool FindByUserName(string userName, ref UserDTO user)
        {
            bool Found = false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.ConnectionString);

            string query = "select* from Users where UserName=@UserName ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@UserName", userName);



            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Found = true;
                    user=Maping.MapingUser(reader);
                }
                else
                {
                    Found = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Found=false;
            }
            finally { connection.Close(); }

            return Found;
        }
        public static DataTable GetAll()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.ConnectionString);

            string query = "select U.UserID,P.PersonID, p.FirstName+' '+p.SecondName+' '+ISNULL( P.ThirdName,'')+' '+p.LastName as FullName,U.UserName,U.IsActive " +
                "from Users U " +
                "join Person P " +
                "on U.PersonID=p.PersonID";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                dt=null;
            }
            finally { connection.Close(); }
            return dt;
        }

        //Update
        public static bool Update(UserDTO user)
        {
            int RowAffect = 0;

            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "update Users set UserName=@UserName ,Password=@Password,IsActive=@IsActive" +
                " where UserID=@UserID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", user.UserName);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@IsActive", user.IsActive);

            command.Parameters.AddWithValue("@UserID", user.UserID);

            try
            {
                connection.Open();
                RowAffect=command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally { connection.Close(); }

            return (RowAffect>0);

        }

        //Delete
        public static bool Delete(int userID)
        {
            int RowAffect = 0;
            SqlConnection conn = new SqlConnection(ClsDataAccessSetting.ConnectionString);

            string Query = "Delete Users where UserID=@UserID;";

            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@UserID", userID);

            try
            {
                conn.Open();
                RowAffect = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally { conn.Close(); }


            return (RowAffect>0);
        }

        //IsExsit
        public static bool IsExist(int userID)
        {
            bool IsExsit = false;
            SqlConnection con = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "select 1 from Users where UserID=@UserID";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@UserID", userID);
            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsExsit= reader.Read();
                reader.Close();

            }
            catch (Exception ex)
            {
                return false;
            }
            finally { con.Close(); }


            return IsExsit;
        }
        public static bool IsExistByPersonID(int personID)
        {
            bool IsExsit = false;

            SqlConnection con = new SqlConnection(ClsDataAccessSetting.ConnectionString);

            string query = "select 1 from Users where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@PersonID", personID);


            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsExsit= reader.Read();
                reader.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally { con.Close(); }


            return IsExsit;
        }
        public static bool IsExist(string userName)
        {
            bool IsExsit = false;

            SqlConnection con = new SqlConnection(ClsDataAccessSetting.ConnectionString);

            string query = "select 1 from Users where UserName=@UserName";

            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@UserName", userName);


            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsExsit= reader.Read();
                reader.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally { con.Close(); }


            return IsExsit;
        }
        public static bool IsExist(string userName, int userID)
        {
            bool IsExsit = false;

            SqlConnection con = new SqlConnection(ClsDataAccessSetting.ConnectionString);

            string query = "select 1 from Users where UserName=@UserName and UserID<>@UserID;";

            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@UserName", userName);
            command.Parameters.AddWithValue("@UserID", userID);


            try
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsExsit= reader.Read();
                reader.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally { con.Close(); }


            return IsExsit;
        }

     

        public static bool ChangePassword(int userID, string newPassword)
        {
            int RowAffect = 0;

            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "update Users set Password=@Password" +
                " where UserID=@UserID;";
            SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@Password",newPassword);
            
            command.Parameters.AddWithValue("@UserID", userID);

            try
            {
                connection.Open();
                RowAffect=command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally { connection.Close(); }

            return (RowAffect>0);
        }
    }
}

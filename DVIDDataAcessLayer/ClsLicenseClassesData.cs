using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVIDDataAcessLayer
{
    public static class ClsLicenseClassesData
    {
        public static int Add(string ClassName, string ClassDescription, byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            int LicenseClassID = -1; // Initialize with a default value indicating failure

            SqlConnection conn = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string sql = "INSERT INTO LicenseClasses (ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees) " +
                         "VALUES (@ClassName, @ClassDescription, @MinimumAllowedAge, @DefaultValidityLength, @ClassFees); " +
                         "SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ClassName", ClassName);
            cmd.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            cmd.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            cmd.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            cmd.Parameters.AddWithValue("@ClassFees", ClassFees);

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                if(result!= null && int.TryParse(result.ToString(),out int ReturndLicenseClassID))
                {
                    LicenseClassID = ReturndLicenseClassID; 
                }
               

            }
            catch (Exception ex)
            {
                //// Handle exception (e.g., log it)
                //throw new Exception("Error adding license class: " + ex.Message);

                return -1; // Return -1 to indicate an error occurred
            }
            finally
            {
                conn.Close();
            }
            return LicenseClassID; // Return the newly generated LicenseClassID or -1 if an error occurred
        }

        public static bool Find(int LicenseClassID,ref string ClassName,ref string ClassDescription,ref byte MinimumAllowedAge,ref byte DefaultValidityLength ,ref float ClassFees)
        {
            bool Found = false;

            SqlConnection conn=new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "select * from LicenseClasses where LicenseClassID=@LicenseClassID";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;

                    ClassName=(string)reader["ClassName"];
                    ClassDescription=(string)reader["ClassDescription"];
                    MinimumAllowedAge=(byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength=(byte)reader["DefaultValidityLength"];
                    ClassFees=Convert.ToSingle(reader["ClassFees"]);
                }

            }
            catch (Exception ex)
            {
                //throw new Exception("Erro in Trying to find LicenseClass "+ex.Message);
                return false;
            }

            return Found;
        }
        public static bool Find(string ClassName,ref int LicenseClassID, ref string ClassDescription, ref byte MinimumAllowedAge, ref byte DefaultValidityLength, ref float ClassFees)
        {
            bool Found = false;

            SqlConnection conn = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "select * from LicenseClasses where ClassName=@ClassName";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;

                    LicenseClassID=(int)reader["LicenseClassID"];
                    ClassDescription=(string)reader["ClassDescription"];
                    MinimumAllowedAge=(byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength=(byte)reader["DefaultValidityLength"];
                    ClassFees=Convert.ToSingle(reader["ClassFees"]);
                }

            }
            catch (Exception ex)
            {
                //throw new Exception("Erro in Trying to find LicenseClass "+ex.Message);
                return false;
            }

            return Found;
        }

        public static DataTable GetAll()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "select * from LicenseClasses";
            SqlCommand command = new SqlCommand(query, conn);
            
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                //throw new Exception("Error retrieving license classes: " + ex.Message);
                return null; // Return null to indicate an error occurred
            }
            return dt;
        }

        public static bool Update(int LicenseClassID, string ClassName, string ClassDescription, byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            int rowsAffected = 0;
            SqlConnection conn = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string sql = @"UPDATE LicenseClasses SET ClassName=@ClassName, ClassDescription=@ClassDescription,
                           MinimumAllowedAge=@MinimumAllowedAge, DefaultValidityLength=@DefaultValidityLength, 
                           ClassFees=@ClassFees WHERE LicenseClassID=@LicenseClassID";
           
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            cmd.Parameters.AddWithValue("@ClassName", ClassName);
            cmd.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            cmd.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            cmd.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            cmd.Parameters.AddWithValue("@ClassFees", ClassFees);
            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                //throw new Exception("Error updating license class: " + ex.Message);
                return false; // Return false to indicate an error occurred
            }
            finally
            {
                conn.Close();
            }
            return rowsAffected > 0; // Return true if at least one row was updated, otherwise false
        }   

        public static bool Delete(int LicenseClassID)
        {
            int rowsAffected = 0;

            SqlConnection conn = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string sql = "DELETE FROM LicenseClasses WHERE LicenseClassID=@LicenseClassID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                //throw new Exception("Error deleting license class: " + ex.Message);
                return false; // Return false to indicate an error occurred
            }
            finally
            {
                conn.Close();
            }
            return rowsAffected > 0; // Return true if at least one row was deleted, otherwise false
        }

        public static bool IsExists(int LicenseClassID)
        {
            bool exists = false;
            SqlConnection conn = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "SELECT 1 FROM LicenseClasses WHERE LicenseClassID=@LicenseClassID";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                exists = reader.HasRows;
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                //throw new Exception("Error checking existence of license class: " + ex.Message);
                return false; // Return false to indicate an error occurred
            }
            finally
            {
                conn.Close();
            }
            return exists;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVIDDataAcessLayer
{
    public static class ClsApplicationTypesDataAccess
    {

        public static bool Find(int applicationTypeID,ref string applicationTypeTitle,ref double applicationFees)
        {
            bool Found=false;

            SqlConnection conn = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "select * from ApplicationTypes where ApplicationTypeID=@ApplicationTypeID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Found = true;
                    applicationTypeTitle=(string)reader["ApplicationTypeTitle"];
                    applicationFees=Convert.ToDouble( reader["ApplicationFees"]);

                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally { conn.Close(); }
            return Found;
        }
        public static DataTable GetAll()
        {
            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "select ApplicationTypeID as ID,ApplicationTypeTitle as Title,ApplicationFees as Fees from ApplicationTypes";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                    
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                return null;
            }
            finally { conn.Close(); }
            return dataTable;
        }
        public static bool Update(int applicationTypeID, string applicationTypeTitle, double applicationFees)
        {
            int RowAffect = 0;

            SqlConnection conn = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "update ApplicationTypes set ApplicationTypeTitle=@ApplicationTypeTitle , ApplicationFees=@ApplicationFees where ApplicationTypeID=@ApplicationTypeID";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", applicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationFees", applicationFees);
            command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);

            try
            {
                conn.Open();
                RowAffect = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                return false;
            } finally { conn.Close(); }

            return (RowAffect>0);

        }

        public static bool IsExist(int applicationID)
        {
            bool IsExsit = false;
            SqlConnection con = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "select 1 from ApplicationTypes where ApplicationTypeID=@ApplicationTypeID";
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@ApplicationTypeID", applicationID);
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
    }
}

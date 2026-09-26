using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DVIDDataAcessLayer
{
    public static class ClsTestTypesDataAccess
    {
        public static int Add(string Title,string Description,float Fees)
        {
            int TestID = -1;

            SqlConnection conn = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string Query = "insert into TestTypes (TestTypeTitle,TestTypeDescription,TestTypeFees) Values(@TestTypeTitle,@TestTypeDescription,@TestTypeFees);" +
                "select SCOPE_IDENTITY() ";


            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@TestTypeTitle", Title);
            cmd.Parameters.AddWithValue("@TestTypeDescription", Description);
            cmd.Parameters.AddWithValue("@TestTypeFees", Fees);


            try
            {
                conn.Open();
                object result= cmd.ExecuteScalar();

                if(result!= null && int.TryParse(result.ToString(), out int insertID))
                {
                    TestID=insertID; 
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally { conn.Close(); }

            return TestID;
        }

        public static bool Find(int ID, ref string Title, ref string Description, ref float Fees)
        {
            bool Found = false;

            SqlConnection conn = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "select*from TestTypes where TestTypeID=@TestTypeID;";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TestTypeID", ID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Found= true;
                    ID=(int)reader["TestTypeID"];
                    Title=(string)reader["TestTypeTitle"];
                    Description=(string)reader["TestTypeDescription"];
                    Fees=Convert.ToSingle(reader["TestTypeFees"]);
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
            DataTable dataTable = new DataTable()   ;

            SqlConnection conn = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "select * from TestTypes";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    dataTable.Load(reader);
                }
                reader.Close();

            }
            catch(Exception ex)
            {
                return null;
            }
            finally { conn.Close(); }

            return dataTable;

        }

        public static bool Update(int ID,string newTitle,string newDescription,float Fees)
        {
            int rowAffected = 0;
            SqlConnection conn = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "update TestTypes set TestTypeTitle=@TestTypeTitle,TestTypeDescription=@TestTypeDescription,TestTypeFees=@TestTypeFees where TestTypeID=@TestTypeID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TestTypeID", ID);
            cmd.Parameters.AddWithValue("@TestTypeTitle", newTitle);
            cmd.Parameters.AddWithValue("@TestTypeDescription", newDescription);
            cmd.Parameters.AddWithValue("@TestTypeFees", Fees);

            try
            {
                conn.Open();
                rowAffected = cmd.ExecuteNonQuery();

                
            }
            catch (Exception ex)
            {
                return false;
            }
            finally { conn.Close(); }

            return (rowAffected > 0);
        }

       public static bool IsExsit(int ID)
        {
            bool Found = false;
            SqlConnection conn = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "select 1 from TestTypes where TestTypeID=@TestTypeID;";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TestTypeID", ID);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Found = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally { conn.Close(); }
            return Found;
        }
    }
}

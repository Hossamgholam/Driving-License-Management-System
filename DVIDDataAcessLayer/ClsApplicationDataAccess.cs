using DVIDDataAcessLayer.DTOs;
using DVIDDataAcessLayer.HelperMethod;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVIDDataAcessLayer
{
    public static class ClsApplicationDataAccess
    {
        //CRUD Operations for Application Data Access Layer
        // Create
        public static int Add(ApplicationDTO application)
        {
            SqlConnection conn=new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "insert into Applications(ApplicantPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID)" +
                "values(@ApplicantPersonID,@ApplicationDate,@ApplicationTypeID,@ApplicationStatus,@LastStatusDate,@PaidFees,@CreatedByUserID);" +
                "select SCOPE_IDENTITY()";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ApplicantPersonID", application.ApplicationPersonID);
            cmd.Parameters.AddWithValue("@ApplicationDate", application.ApplicationDate);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", application.ApplicationTypeID);
            cmd.Parameters.AddWithValue("@ApplicationStatus", application.ApplicationStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", application.LastStatusDate);
            cmd.Parameters.AddWithValue("@PaidFees", application.PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", application.CreatedByUserID);

            try
            {
                conn.Open();

                object result= cmd.ExecuteScalar();
                if (result != null&&int.TryParse(result.ToString(), out int ReturnID))
                {
                    application.ApplicationID = ReturnID;
                }
            }
            catch ( Exception ex)
            {
                return application.ApplicationID=-1;
            }finally { conn.Close(); }
            



            return application.ApplicationID;

        }


        // Read(findByID   GetAll)
        public static bool Find(int applicationID,ref ApplicationDTO application)
        {
            bool Found=false;

            SqlConnection conn = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "select * from Applications where ApplicationID=@ApplicationID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Found = true;
                    application=Maping.MapingApplication(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally {  conn.Close(); }






            return Found;
        }
        public static int FindActiveApplication(int applicationiPersonID, int applicationTypeID)
        {
            int ActiveApplication = -1;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "select ApplicationID from Applications where ApplicantPersonID=@ApplicantPersonID and ApplicationTypeID=@ApplicationTypeID and ApplicationStatus=1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", applicationiPersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);


            try
            {
                connection.Open();
                object result= command.ExecuteScalar();
                if(result!=null&&int.TryParse(result.ToString(),out int returnedID))
                {
                    ActiveApplication = returnedID;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally { connection.Close(); }
            return ActiveApplication;
        }
        public static DataTable GetAll()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ClsDataAccessSetting.ConnectionString   );
            string query = "select* from Applications";
            SqlCommand command = new SqlCommand(query, conn);
            try
            {
                conn.Open();

                SqlDataReader reader=command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                return null;
            }finally{ conn.Close(); }   


            return dt;
        }

        //Update
        public static bool Update(int applicationID,ApplicationDTO application)
        {
            int RowAffect = 0;
            SqlConnection conn=new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "update Applications set ApplicantPersonID=ApplicantPersonID,ApplicationDate=@ApplicationDate," +
                "ApplicationTypeID=@ApplicationTypeID,ApplicationStatus=@ApplicationStatus," +
                "LastStatusDate=@LastStatusDate,PaidFees=@PaidFess,CreatedByUserID=@CreatedByUserID " +
                "where ApplicationID=@ApplicationID";

            SqlCommand cmd=new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ApplicantPersonID", application.ApplicationPersonID);
            cmd.Parameters.AddWithValue("@ApplicationDate", application.ApplicationDate);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", application.ApplicationTypeID);
            cmd.Parameters.AddWithValue("@ApplicationStatus", application.ApplicationStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", application.LastStatusDate);
            cmd.Parameters.AddWithValue("@PaidFess", application.PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", application.CreatedByUserID);
            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);

            try
            {
                conn.Open();
                RowAffect= cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                return false;
            }finally { conn.Close(); }



            return (RowAffect>0);
        }
        public static bool UpdateStatus(int applicationID,byte newStatus)
        {
            int RowAffect = 0;
            SqlConnection con=new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = @"
                            update Applications set 
                            ApplicationStatus=@ApplicationStatus,
                            LastStatusDate=@LastStatusDate 
                            where ApplicationID=@ApplicationID
                           ";
            SqlCommand cmd=new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ApplicationStatus", newStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);
            try
            {
                con.Open();
                RowAffect=cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally {  con.Close(); }

            return (RowAffect> 0);


        }

        //Delete
        public static bool Delete(int applicationID)
        {
            int RowAffect = 0;
            SqlConnection conn=new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "delete Applications where ApplicationID=@applicationID;";
            SqlCommand cmd=new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@applicationID",applicationID);

            try
            {
                conn.Open();
                RowAffect = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }finally{ conn.Close(); }   

            return (RowAffect>0);
        }

        public static bool IsExsit(int applicationID)
        {
            bool Found=false;
            SqlConnection con=new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = @"select 1 from Applications where ApplicationID=@ApplicationID;";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);

            try
            {
                con.Open();
                SqlDataReader reader=cmd.ExecuteReader();
                Found=reader.HasRows;
                reader.Close();

            }catch(Exception ex)
            {
                return false;
            }
            finally{ con.Close(); }

            return Found;
        }
        public static bool DoesPersonHaveActiveApplication(int applicationPersonID, int applicationTypeID)
        {
            return (FindActiveApplication(applicationPersonID, applicationTypeID)!=-1);
        }
    }
}

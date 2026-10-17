using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVIDDataAcessLayer
{
    //we do not use DTos 
    public static class ClsLocalDrivingLicenseApplicationData
    {
        public static int Add(int licenceClass,int applicationID)
        {
            int LocalLicenseID = -1;


            SqlConnection conn =  new SqlConnection(ClsDataAccessSetting.ConnectionString);

            string query = @"insert into LocalDrivingLicenseApplications(LicenseClassID,ApplicationID)values(@LicenseClassID,@ApplicationID);
                             select SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LicenseClassID", licenceClass);
            cmd.Parameters.AddWithValue("@ApplicationID", applicationID);



            try
            {
                conn.Open();
                object result=cmd.ExecuteScalar();
                if (result != null&&int.TryParse(result.ToString(), out int ReturndID))
                {
                    LocalLicenseID = ReturndID;
                }
                
            }
            catch (Exception ex)
            {
                return -1;
            }finally { conn.Close(); }

            return LocalLicenseID;
        }

        public static bool Find(int localDrivingLicenseApplicationID, ref int licenceClass,ref int applicationID)
        {
            bool Found = false;

            SqlConnection conn=new SqlConnection(ClsDataAccessSetting.ConnectionString);

            string query = "select * from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);

            try
            {
                conn.Open();
                SqlDataReader reader=command.ExecuteReader();
                if (reader.Read())
                {
                    Found= true;

                    licenceClass=(int)reader["LicenseClassID"];
                    applicationID=(int)reader["ApplicationID"];
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                return false;
            }
            finally { conn.Close(); }







            return Found;
        }
        public static bool FindByApplicationID(int applicationID,ref int localDrivingLicenseApplicationID, ref int licenceClass)
        {
            bool Found = false;

            SqlConnection conn = new SqlConnection(ClsDataAccessSetting.ConnectionString);

            string query = "select * from LocalDrivingLicenseApplications where ApplicationID=@ApplicationID";

            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Found= true;

                    localDrivingLicenseApplicationID=(int)reader["LocalDrivingLicenseApplicationID"];
                    licenceClass=(int)reader["LicenseClassID"];
                }
                reader.Close();

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
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "select * from LocalDrivingLicenseApplications_View";
            SqlCommand command = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                return null;
            }
            finally { conn.Close(); }
            return dt;
        }

        public static bool Update(int localDrivingLicenseApplicationID,int NewLicenceClass,int NewapplicationID)
        {
            int AffectRow = 0;
            SqlConnection con = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = @"update LocalDrivingLicenseApplications 
                             set ApplicationID=@NewApplicationID ,LicenseClassID=@NewLicenseClassID 
                             where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@NewLicenseClassID", NewLicenceClass);
            cmd.Parameters.AddWithValue("@NewApplicationID", NewapplicationID);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);

            try
            {
                con.Open();
                AffectRow=cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }finally { con.Close(); }




            return (AffectRow>0);
        }
     
        public static bool Delete(int localDrivingLicenseApplicationID)
        {
            int AffectRow = 0;
            SqlConnection con = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = @"delete from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID;";

            SqlCommand cmd = new SqlCommand(query, con);
            
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);

            try
            {
                con.Open();
                AffectRow=cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally { con.Close(); }




            return (AffectRow>0);
        }

        public static bool IsExsit(int localDrivingLicenseApplicationID)
        {
            bool Found=false;

            SqlConnection conn = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "select 1 from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);

            try
            {
                conn.Open();
                SqlDataReader reader=command.ExecuteReader();   
                Found = reader.Read();

                reader.Close();
            }catch(Exception ex)
            {
                return false;

            }finally { conn.Close(); }
           return Found;
        }
        public static bool IsExsitByApplicationID(int applicationID)
        {
            bool Found = false;

            SqlConnection conn = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "select 1 from LocalDrivingLicenseApplications where ApplicationID=@ApplicationID";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                Found = reader.Read();

                reader.Close();
            }
            catch (Exception ex)
            {
                return false;

            }
            finally { conn.Close(); }
            return Found;
        }


        //DoesPassTestType(localid,tyste type)
        //DoesAttendTesttype()
        //TotalTrialsPerTest()
        //IsThereAnActiveScheduleddTest()
    }
}

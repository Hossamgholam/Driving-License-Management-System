using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVIDDataAcessLayer
{
    public class ClslicensesData
    {
        public static bool ISExsit(int PersonID,int LicenseClassID)
        {
            bool Found = false;

            SqlConnection conn = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string Query = @"select 1 from Licenses 
                             inner join Applications
                             on Licenses.ApplicationID=Applications.ApplicationID
                             Where Applications.ApplicantPersonID=@PersonID and Licenses.LicenseClass=@LicenseClassID and Licenses.IsActive=1";
           
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Found=reader.HasRows;
                reader.Close();

            }
            catch (Exception ex)
            {
                return false;
            }finally { conn.Close(); }


            return Found;
        }
    }
}

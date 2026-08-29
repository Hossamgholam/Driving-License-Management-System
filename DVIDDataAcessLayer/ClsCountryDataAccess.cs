using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVIDDataAcessLayer
{
    public class ClsCountryDataAccess
    {
        public static bool FindByID(int countryID, ref string countryName)
        {
            bool found = false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.ConnectionString);

            string query = "SELECT CountryName FROM Countries WHERE CountryID = @CountryID;";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CountryID", countryID);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    found = true;
                    countryName = reader["CountryName"].ToString();
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
        public static bool FindByName(string countryName, ref int countryID)
        {
            bool found = false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "SELECT CountryID FROM Countries WHERE CountryName = @CountryName;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CountryName", countryName);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    found = true;
                    countryID = (int)reader["CountryID"];
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
        public static DataTable GetAllCountries()
        {
            DataTable TableOFCountries = new DataTable();

            SqlConnection connection = new SqlConnection(ClsDataAccessSetting.ConnectionString);
            string query = "Select* from Countries";

            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TableOFCountries.Load(reader);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            return TableOFCountries;
        }
    
    }
}

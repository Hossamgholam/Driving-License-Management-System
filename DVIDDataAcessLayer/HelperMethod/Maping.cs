using DVIDDataAcessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVIDDataAcessLayer.HelperMethod
{
    internal class Maping
    {

        //maping person data from database to PersonDTO object
        public static PersonDTO MapingPerson (SqlDataReader reader)
        {
            return new PersonDTO()
            {
                PersonID =(int)reader["PersonID"],
                NationalNo=(string)reader["NationalNo"],
                FirstName=(string)reader["FirstName"],
                SecondName=(string)reader["SecondName"],

                ThirdName=reader.IsDBNull(reader.GetOrdinal("ThirdName")) ? "" : (string)reader["ThirdName"],
                LastName=(string)reader["LastName"],
                DateOfBirth=(DateTime)reader["DateOfBirth"],
                Gender=(byte)reader["Gender"],
                Address=(string)reader["Address"],
                Phone=(string)reader["Phone"],
                Email=reader.IsDBNull(reader.GetOrdinal("Email")) ? "" : (string)reader["Email"],
                NationalityCountryID=(int)reader["NationalityCountryID"],
                ImagePath=reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? "" : (string)reader["ImagePath"]
            };
        }
        public static UserDTO MapingUser(SqlDataReader reader)
        {
            return new UserDTO()
            {
                UserID=(int)reader["UserID"],
                PersonID=(int)reader["PersonID"],
                UserName=(string)reader["UserName"],
                Password=(string)reader["Password"],
                IsActive=(bool)reader["IsActive"],
            };
        }
    }
}

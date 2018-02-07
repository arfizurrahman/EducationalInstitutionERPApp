using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EducationalInstitutionERPApp.Models;

namespace EducationalInstitutionERPApp.Gateway
{
    public class LoginGateway : Gateway
    {
        public bool IsEmailExists(Admin admin)
        {
          Query = "SELECT Email FROM Admin WHERE Email = @email";

            Command = new SqlCommand(Query, Connection);
            
            Command.Parameters.Clear();
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = admin.Email;
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRow = false;
            if (Reader.HasRows)
            {
                hasRow = true;
            }
            Reader.Close();
            Connection.Close();
            return hasRow;
        }

        public bool IsPasswordCorrect(Admin admin)
        {
            Query = "SELECT Email FROM Admin WHERE Password = @password";

            Command = new SqlCommand(Query, Connection);
            
            Command.Parameters.Clear();
            Command.Parameters.Add("password", SqlDbType.VarChar);
            Command.Parameters["password"].Value = admin.Password;
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRow = false;
            if (Reader.HasRows)
            {
                hasRow = true;
            }
            Reader.Close();
            Connection.Close();
            return hasRow;
        }
    }
    
}
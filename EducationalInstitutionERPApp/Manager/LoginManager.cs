using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EducationalInstitutionERPApp.Gateway;
using EducationalInstitutionERPApp.Models;

namespace EducationalInstitutionERPApp.Manager
{
    public class LoginManager
    {
        LoginGateway aLoginGateway = new LoginGateway();

        public string Login(Admin admin)
        {
            if (aLoginGateway.IsEmailExists(admin))
            {
                if (aLoginGateway.IsPasswordCorrect(admin))
                {
                    return "ok";
                }
                return "Incorrect Password!!";
            }
            else
            {
                return "Incorrect Email or Password!!";
            }
        }
    }
}
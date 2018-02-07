using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EducationalInstitutionERPApp.Startup))]
namespace EducationalInstitutionERPApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

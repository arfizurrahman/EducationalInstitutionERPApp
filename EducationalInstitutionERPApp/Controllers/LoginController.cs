using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EducationalInstitutionERPApp.Manager;
using EducationalInstitutionERPApp.Models;

namespace EducationalInstitutionERPApp.Controllers
{
    public class LoginController : Controller
    {
        LoginManager aLoginManager = new LoginManager();
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            ViewBag.Message = aLoginManager.Login(admin);
            if (ViewBag.Message == "ok")
            {
                
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
	}
}
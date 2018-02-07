using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EducationalInstitutionERPApp.Models.LibraryModels;

namespace EducationalInstitutionERPApp.Controllers
{
    public class LibraryController : Controller
    {
        //
        // GET: /Library/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveNewBook()
        {
            return View();
        }
        public ActionResult SaveNewBook(Book book)
        {
            return View();
        }
    }
}
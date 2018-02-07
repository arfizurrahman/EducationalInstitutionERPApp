using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EducationalInstitutionERPApp.Manager;
using EducationalInstitutionERPApp.Models.HRAndPayrollModels;
using EducationalInstitutionERPApp.Models.StudentModels;

namespace EducationalInstitutionERPApp.Controllers
{
    public class HomeController : Controller
    {
        HRAndPayrollManager aPayrollManager = new HRAndPayrollManager();
        StudentManager aStudentManager = new StudentManager();
        public ActionResult Index()
        {
            List<Employee> teachers = aPayrollManager.GetAllTeachers();
            int tNumber = teachers.Count;
            ViewBag.Teachers = tNumber;
            List<Employee> employees = aPayrollManager.GetAllStaffs();
            int employeeNumber = employees.Count;
            ViewBag.Staffs = employeeNumber;
            List<Student> students = aStudentManager.GetAllStudentsForIndex();
            int sNo = students.Count;
            ViewBag.Students = sNo;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
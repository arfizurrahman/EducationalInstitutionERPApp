using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EducationalInstitutionERPApp.Manager;
using EducationalInstitutionERPApp.Models.AcademicModels;
using EducationalInstitutionERPApp.Models.HRAndPayrollModels;
using EducationalInstitutionERPApp.Models.StudentModels;

namespace EducationalInstitutionERPApp.Controllers
{
    public class StudentController : Controller
    {
        AcademicManager anAcademicManager = new AcademicManager();
        HRAndPayrollManager aPayrollManager = new HRAndPayrollManager();
        StudentManager aStudentManager = new StudentManager();
        //
        // GET: /Student/
        public ActionResult Index()
        {
            return View();
        }

        //Register Student
        //-------------------

        public ActionResult RegisterStudent()
        {
            ViewBag.Departments = GetDepartmentsForDropdownList();
            ViewBag.Genders = GetGendersForDropdownList();
            return View();
        }
        [HttpPost]
        public ActionResult RegisterStudent(Student student)
        {
            ViewBag.Departments = GetDepartmentsForDropdownList();
            ViewBag.Genders = GetGendersForDropdownList();

            DateTime myDateTime = new DateTime();
            myDateTime = DateTime.ParseExact(student.DateOfBirth, "dd-MM-yyyy", null);
            String date = myDateTime.ToString("yyyy-MM-dd");
            student.DateOfBirth = date;

            DateTime myDateTime2 = new DateTime();
            myDateTime2 = DateTime.ParseExact(student.RegistrationDate, "dd-MM-yyyy", null);
            String date2 = myDateTime2.ToString("yyyy-MM-dd");
            student.RegistrationDate = date2;
            ViewBag.Message = aStudentManager.RegisterStudent(student);
            return View();
        }

        private List<SelectListItem> GetDepartmentsForDropdownList()
        {

            var departments = anAcademicManager.GetAllDepartment();
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem(){Value="", Text="---Select---"}
            };
            foreach (Department dept in departments)
            {
                SelectListItem item = new SelectListItem() { Value = dept.Id.ToString(), Text = dept.DepartmentName };
                items.Add(item);
            }
            return items;
        }

        private List<SelectListItem> GetGendersForDropdownList()
        {
            var genders = aPayrollManager.GetAllGenders();

            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "", Text = "--Select--"}
            };

            foreach (Gender gender in genders)
            {
                SelectListItem item = new SelectListItem() { Value = gender.Id.ToString(), Text = gender.GenderName };
                items.Add(item);
            }

            return items;
        }

                       //ManageStudent
        /////////////////---------------/////////////


        public ActionResult ManageStudent()
        {
            return View();
        }


                     //CourseEnrollment
              ////-------------------------------///
        public ActionResult EnrollInACourse()
        {
            ViewBag.Departments = GetDepartmentsForDropdownList();
            return View();
        }
        [HttpPost]
        public ActionResult EnrollInACourse(CourseEnrollmentVm aCourseEnrollmentVm)
        {
            ViewBag.Departments = GetDepartmentsForDropdownList();
            DateTime myDateTime = new DateTime();
            myDateTime = DateTime.ParseExact(aCourseEnrollmentVm.Date, "dd-MM-yyyy", null);
            String date = myDateTime.ToString("yyyy-MM-dd");
            aCourseEnrollmentVm.Date = date;
            ViewBag.Message = aStudentManager.SaveEnrollMent(aCourseEnrollmentVm);
            return View();
        }
        public JsonResult GetCourseEnrollmentInfoByDepartmentId(int id)
        {
            List<Student> students = aStudentManager.GetStudentByDepartmentId(id);
            var courseInfo = anAcademicManager.GetCourseByDepartmentId(id);
            CourseEnrollmentVm aCourseEnrollmentVm = new CourseEnrollmentVm();
            aCourseEnrollmentVm.Students = students;
            aCourseEnrollmentVm.Courses = courseInfo;
            
            return Json(aCourseEnrollmentVm);
        }

        public JsonResult GetStudentInfoById(int id)
        {
            var studentInfo = aStudentManager.GetStudentInfoById(id);
            return Json(studentInfo);
        }
        
        
	}
}
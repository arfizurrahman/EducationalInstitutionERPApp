using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EducationalInstitutionERPApp.Manager;
using EducationalInstitutionERPApp.Models.AcademicModels;
using EducationalInstitutionERPApp.Models.HRAndPayrollModels;

namespace EducationalInstitutionERPApp.Controllers
{
    public class AcademicController : Controller
    {
        AcademicManager anAcademicManager = new AcademicManager();
        
        //
        // GET: /Academic/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveDepartment()
        {
            ViewBag.Departments = anAcademicManager.GetAllDepartment();
            return View();
        }
        [HttpPost]
        public ActionResult SaveDepartment(Department aDepartment)
        {
            ViewBag.Departments = anAcademicManager.GetAllDepartment();
            ViewBag.Message = anAcademicManager.SaveDepartment(aDepartment);
            return View();
        }
        public ActionResult SaveCourse()
        {
            ViewBag.Departments = GetDepartmentsForDropdownList();
            ViewBag.Semesters = GetSemetersForDropdownList();
            ViewBag.Courses = anAcademicManager.GetAllCourse();
            return View();
        }
        [HttpPost]
        public ActionResult SaveCourse(Course aCourse)
        {
            ViewBag.Departments = GetDepartmentsForDropdownList();
            ViewBag.Semesters = GetSemetersForDropdownList();
            ViewBag.Courses = anAcademicManager.GetAllCourse();
            ViewBag.Message = anAcademicManager.SaveCourse(aCourse);
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

        private List<SelectListItem> GetSemetersForDropdownList()
        {

            var semesters = anAcademicManager.GetAllSemester();
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem(){Value="", Text="---Select---"}
            };
            foreach (Semester semester in semesters)
            {
                SelectListItem item = new SelectListItem() { Value = semester.Id.ToString(), Text = semester.SemesterName };
                items.Add(item);
            }
            return items;
        }

        public ActionResult AssignCourseToTeacher()
        {
            ViewBag.Departments = GetDepartmentsForDropdownList();
            
            return View();
        }
        [HttpPost]
        public ActionResult AssignCourseToTeacher(CourseAssignmentVm courseAssignment)
        {
            ViewBag.Departments = GetDepartmentsForDropdownList();
            ViewBag.Message = anAcademicManager.SaveCourseAssignment(courseAssignment);
            return View();
        }

        
        public JsonResult GetTeacherCourseByDepartmentId(int id)
        {
            List<Employee> teacherInfo = anAcademicManager.GetTeacherByDepartmentId(id);
            var courseInfo = anAcademicManager.GetCourseByDepartmentId(id);
            CourseAssignmentVm assignmentVm = new CourseAssignmentVm();
            assignmentVm.Courses = courseInfo;
            assignmentVm.Employees = teacherInfo;
            return Json(assignmentVm);
        }

        //CreditTaken
        public JsonResult GetTeacherInfoById(int id)
        {
            var teacherInfo = anAcademicManager.GetTeacherInfoById(id);
            return Json(teacherInfo);
        }
        public JsonResult GetCourseInfoById(int id)
        {
            var courseInfo = anAcademicManager.GetCourseInfoById(id);
            return Json(courseInfo);
        }


                        //Course statistics
                        ///////////////////
        public ActionResult ManageAssignedCourses()
        {
            ViewBag.Departments = GetDepartmentsForDropdownList();
            return View();
        }

        [HttpPost]
        public ActionResult ManageAssignedCourses(CourseAssignmentVm courseAssignment)
        {
            ViewBag.Departments = GetDepartmentsForDropdownList();
            int id = courseAssignment.DepartmentId;
            ViewBag.Courses = anAcademicManager.GetAllCourses(id);
            return View();
        }
        public JsonResult DeleteCourseByAssignedCourseId(int id)
        {

            anAcademicManager.DeleteAassignedCourse(id);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetCoursesByDepartmentId(int id)
        //{
            

            
        //    return Json(courses);
        //}
        
	}
}
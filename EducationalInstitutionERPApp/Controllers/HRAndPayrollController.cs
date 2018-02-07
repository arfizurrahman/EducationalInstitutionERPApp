using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using EducationalInstitutionERPApp.Manager;
using EducationalInstitutionERPApp.Models.AcademicModels;
using EducationalInstitutionERPApp.Models.HRAndPayrollModels;

namespace EducationalInstitutionERPApp.Controllers
{
    public class HRAndPayrollController : Controller
    {
        HRAndPayrollManager aPayrollManager = new HRAndPayrollManager();
        TimeTableManager aTimeTableManager = new TimeTableManager();
        AcademicManager academicManager = new AcademicManager();
        //
        // GET: /HRAndPayroll/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddEmployeeType()
        {
            ViewBag.EmployeeTypes = aPayrollManager.GetAllEmpTypes();
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployeeType(EmployeeType employeeType)
        {
            ViewBag.Message = aPayrollManager.AddEmployeeType(employeeType);
            ViewBag.EmployeeTypes = aPayrollManager.GetAllEmpTypes();
            return View();
        }
        [HttpGet]
        public PartialViewResult EditType(int typeid)
        {
            EmployeeType type = new EmployeeType();

            type = aPayrollManager.GetEmpType(typeid);


            return PartialView(type);
        }

        
        public JsonResult EditType(EmployeeType employeeType)
        {
            ViewBag.Message = aPayrollManager.UpdateType(employeeType);

            //EmployeeType type = new EmployeeType();

            //type = aPayrollManager.GetTypeForShow(employeeType);
            return Json(ViewBag.Message);
        }

        public ActionResult AddDesignation()
        {
            ViewBag.Designations = aPayrollManager.GetAllDesignation();
            return View();
        }
        [HttpPost]
        public ActionResult AddDesignation(Designation designation)
        {
            ViewBag.Message = aPayrollManager.AddDesignation(designation);
            ViewBag.Designations = aPayrollManager.GetAllDesignation();
            return View();
        }
        //public JsonResult DeleteType(int id)
        //{

        //    //aPayrollManager.DeleteType(id);

        //    return Json(true, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult AddEmployee()
        {
            ViewBag.Departments = GetDepartmentsForDropdownList();
            ViewBag.Categories = GetCategoriesForDropdownList();
            ViewBag.Genders = GetGendersForDropdownList();
            ViewBag.Designations = GetDesignationsForDropdownList();

            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            ViewBag.Departments = GetDepartmentsForDropdownList();
            ViewBag.Categories = GetCategoriesForDropdownList();
            ViewBag.Genders = GetGendersForDropdownList();
            ViewBag.Designations = GetDesignationsForDropdownList();

            var binaryReader = new BinaryReader(employee.EmployeeImage.InputStream);
            employee.EmpImage = binaryReader.ReadBytes(employee.EmployeeImage.ContentLength);
            DateTime myDateTime = new DateTime();
            myDateTime = DateTime.ParseExact(employee.DateOfBirth, "dd-MM-yyyy", null);
            String date = myDateTime.ToString("yyyy-MM-dd");
            employee.DateOfBirth = date;
            ViewBag.Message = aPayrollManager.AddEmployee(employee);
            return View();
        }

        private List<SelectListItem> GetDepartmentsForDropdownList()
        {
            var departments = academicManager.GetAllDepartment();

            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "", Text = "--Select--"}
            };

            foreach (Department department in departments)
            {
                SelectListItem item = new SelectListItem() { Value = department.Id.ToString(), Text = department.DepartmentName };
                items.Add(item);
            }

            return items;
        }
        private List<SelectListItem> GetCategoriesForDropdownList()
        {
            var categories = aPayrollManager.GetAllEmpTypes();

            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "", Text = "--Select--"}
            };

            foreach (EmployeeType employeeType in categories)
            {
                SelectListItem item = new SelectListItem() { Value = employeeType.Id.ToString(), Text = employeeType.EmpType };
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
        private List<SelectListItem> GetDesignationsForDropdownList()
        {
            var designations = aPayrollManager.GetAllDesignation();

            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "", Text = "--Select--"}
            };

            foreach (Designation designation in designations)
            {
                SelectListItem item = new SelectListItem() { Value = designation.Id.ToString(), Text = designation.DesignationName };
                items.Add(item);
            }

            return items;
        }

        public ActionResult EmployeeList()
        {
            ViewBag.Employees = aPayrollManager.GetAllEmployees();
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeList(Employee employee)
        {
            ViewBag.Employees = aPayrollManager.GetAllEmployees();
            return View();
        }

        public ActionResult EmployeeProfile()
        {
            ViewBag.Departments = GetDepartmentsForDropdownList();
            ViewBag.Categories = GetCategoriesForDropdownList();
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeProfile(Employee employee)
        {
            Employee anEmployee = aPayrollManager.GetEmployeeInfo(employee);
            if (anEmployee != null)
            {
                ViewBag.Employee = anEmployee;
            }
            else
            {
                ViewBag.Message = "No Employee Found";
            }
            ViewBag.Departments = GetDepartmentsForDropdownList();
            ViewBag.Categories = GetCategoriesForDropdownList();
            return View();
        }
	}
}
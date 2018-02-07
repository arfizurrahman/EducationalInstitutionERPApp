using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EducationalInstitutionERPApp.Manager;
using EducationalInstitutionERPApp.Models.AcademicModels;
using EducationalInstitutionERPApp.Models.TimeTableModels;
using EducationalInstitutionERPApp.Models.TransportModels;
using Rotativa;

namespace EducationalInstitutionERPApp.Controllers
{
    public class TimeTableController : Controller
    {
        TimeTableManager aTimeTableManager = new TimeTableManager();
        AcademicManager anAcademicManager = new AcademicManager();
        //
        // GET: /TimeTable/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddClassRoom()
        {
            ViewBag.Categories = GetCategoriesForDropdownList();
            ViewBag.Buildings = GetBuildingsForDropdownList();
            ViewBag.Building = aTimeTableManager.GetAllBuilding();
            //ViewBag.ClassRooms = aTimeTableManager.GetAllClassRoom();
            return View();
        }
        [HttpPost]
        public ActionResult AddClassRoom(ClassRoom aClassRoom)
        {
            ViewBag.Categories = GetCategoriesForDropdownList();
            ViewBag.Buildings = GetBuildingsForDropdownList();
            ViewBag.Building = aTimeTableManager.GetAllBuilding();
            ViewBag.Message = aTimeTableManager.AddClassRoom(aClassRoom);
            return View();
        }


        private List<SelectListItem> GetCategoriesForDropdownList()
        {

            var categories = aTimeTableManager.GetAllCategory();
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem(){Value="", Text="---Select---"}
            };
            foreach (RoomCategory category in categories)
            {
                SelectListItem item = new SelectListItem() { Value = category.Id.ToString(), Text = category.CategoryName };
                items.Add(item);
            }
            return items;
        }

        private List<SelectListItem> GetBuildingsForDropdownList()
        {

            var buildings = aTimeTableManager.GetAllBuilding();
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem(){Value="", Text="---Select---"}
            };
            foreach (Building building in buildings)
            {
                SelectListItem item = new SelectListItem() { Value = building.Id.ToString(), Text = building.BuildingName };
                items.Add(item);
            }
            return items;
        }

        public JsonResult GetAllRoomsByBuildingId(int id)
        {
            var rooms = aTimeTableManager.GetAllRooms(id);

            //foreach (ClassRoom room in rooms)
            //{

            //    room.TeacherName = anTeacherManager.GetAssaigned(course.Id).ToString();
            //}


            return Json(rooms);
        }

        public ActionResult CreateTimeTable()
        {
            //ViewBag.rooms = a.GetAllRooms();
            ViewBag.Buildings = aTimeTableManager.GetAllBuilding();
            ViewBag.Departments = anAcademicManager.GetAllDepartment();
            return View();
        }
        [HttpPost]
        public ActionResult CreateTimeTable(TimeTableVM aTimeTable)
        {
            
            ViewBag.Buildings = aTimeTableManager.GetAllBuilding();
            ViewBag.Departments = anAcademicManager.GetAllDepartment();
            ViewBag.Message = aTimeTableManager.Create(aTimeTable);
            return View();
        }
        public JsonResult GetCourseByDepartmentId(TimeTableVM timeTable)
        {
            var courses = aTimeTableManager.GetAllCourses(timeTable);
            return Json(courses);
        }
        public JsonResult GetRoomByBuildingId(TimeTableVM timeTable)
        {
            var rooms = aTimeTableManager.GetAllRoom(timeTable);
            return Json(rooms);
        }


        public ActionResult ViewTimeTable()
        {
            ViewBag.Departments = anAcademicManager.GetAllDepartment();
            ViewBag.Semesters = anAcademicManager.GetAllSemester();
            return View();
        }
        [HttpPost]
        public ActionResult ViewTimeTable(TimeTableVM aTimeTableVm)
        {
            
            ViewBag.Semesters = anAcademicManager.GetAllSemester();
            ViewBag.Departments = anAcademicManager.GetAllDepartment();
            ViewBag.TimeTables = aTimeTableManager.GetSchedule(aTimeTableVm);
            return View();
        }
        public ActionResult DownloadTimeTable()
        {

            ViewBag.Semesters = anAcademicManager.GetAllSemester();
            ViewBag.Departments = anAcademicManager.GetAllDepartment();
            return View();
        }
        [HttpPost]
        public ActionResult DownloadTimeTable(TimeTableVM timeTable)
        {
            ViewBag.Semesters = anAcademicManager.GetAllSemester();
            ViewBag.Departments = anAcademicManager.GetAllDepartment();
            TempData["deptId"] = timeTable.DepartmentId;
            int semId = timeTable.SemesterId;
            TempData["semesterId"] = semId;
            return RedirectToAction("GenerateTimeTablePdf", "TimeTable");

            return View();
        }
        public ActionResult GenerateTimeTablePdf()
        {
            int deptId = (int)TempData["deptId"];
            int semId = (int) TempData["semesterId"];
            List<TimeTableVM> days = aTimeTableManager.GetDays();
            List<Semester> semesters = (List<Semester>)anAcademicManager.GetAllSemester();
            List<TimeTableVM> timeTables = new List<TimeTableVM>();
            List<DepartmentScheduleVm> departmentSchedules = new List<DepartmentScheduleVm>();

            foreach (Semester semester in semesters)
            {
                foreach (TimeTableVM day in days)
                {
                    string Day = day.Day;
                    TimeTableVM aTimeTableVm = new TimeTableVM();

                    aTimeTableVm.Schedules = aTimeTableManager.GetAllSchedule(deptId, semester, Day);
                    aTimeTableVm.Day = Day;
                    aTimeTableVm.Semester = semester.SemesterName;
                    timeTables.Add(aTimeTableVm);
                }

                DepartmentScheduleVm aDepartmentScheduleVm = new DepartmentScheduleVm();
                aDepartmentScheduleVm.Semester = semester.SemesterName;
                aDepartmentScheduleVm.DeptTimeTables = timeTables;
                departmentSchedules.Add(aDepartmentScheduleVm);

            }
            
           
            ViewBag.Days = days;
            ViewBag.TimeTables = timeTables;
            ViewBag.DepartmentShceduls = departmentSchedules;
            ViewBag.Semesters = semesters;
           
            return new ViewAsPdf("GenerateTimeTablePdf", "TimeTable")
            {
                FileName = "Class Schedule.pdf"
            };
            

        }


	}
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EducationalInstitutionERPApp.Manager;
using EducationalInstitutionERPApp.Models.TransportModels;
using Rotativa;

namespace EducationalInstitutionERPApp.Controllers
{
    public class TransportController : Controller
    {
        TransportManager aTransportManager = new TransportManager();
        //
        // GET: /Transport/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddVehicle()
        {
            
            ViewBag.VehicleTypes = GetVehicleTypeForDropDownList();
            ViewBag.Drivers = GetDriverForDropDownList();
            ViewBag.Vehicles = aTransportManager.GetAllVehicles();
            return View();
        }
        [HttpPost]
        public ActionResult AddVehicle(Vehicle vehicle)
        {
            ViewBag.VehicleTypes = GetVehicleTypeForDropDownList();
            ViewBag.Drivers = GetDriverForDropDownList();
            
            ViewBag.Message = aTransportManager.AddVehilce(vehicle);
            ViewBag.Vehicles = aTransportManager.GetAllVehicles();
            return View();
        }
        private List<SelectListItem> GetDriverForDropDownList()
        {
            var drivers = aTransportManager.GetAllDrivers();

            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "", Text = "--Select--"}
            };

            foreach (Driver driver in drivers)
            {
                SelectListItem item = new SelectListItem() { Value = driver.Id.ToString(), Text = driver.Name };
                items.Add(item);
            }

            return items;
        }
        private List<SelectListItem> GetVehicleTypeForDropDownList()
        {
            var vehicleTypes = aTransportManager.GetAllVehicleTypes();

            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem{Value = "", Text = "--Select--"},
                
            };

            foreach (Vehicle vehicle in vehicleTypes)
            {
                SelectListItem item = new SelectListItem() { Value = vehicle.VehicleTypeId.ToString(), Text = vehicle.VehicleType };
                items.Add(item);
            }

            return items;
        }
        //public JsonResult EditVehicleById(int vid)
        //{
        //    if (vid.Equals(null))
        //    {
        //             RedirectToAction("EditVehicle", new { id = vid });     
        //    }


        //    return Json(true);

        //}
        public ActionResult EditVehicle(int id)
        {
            ViewBag.VehicleTypes = GetVehicleTypeForDropDownList();
            ViewBag.Drivers = GetDriverForDropDownList();
            ViewBag.Vehicle = aTransportManager.GetVehicleType(id);

            return View();

        }
        [HttpPost]
        public ActionResult EditVehicle(Vehicle vehicle)
        {
            ViewBag.VehicleTypes = GetVehicleTypeForDropDownList();
            ViewBag.Drivers = GetDriverForDropDownList();
            ViewBag.Message = aTransportManager.UpdateVehicle(vehicle);
            return View();

        }

        
        public JsonResult DeleteVehicle(int id)
        {
            aTransportManager.DeleteVehicle(id);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowVehicleInfo()
        {
            return View();
        }
       
        public ActionResult AddDriver()
        {
            
            ViewBag.Drivers = aTransportManager.GetAllDrivers();
            return View();
        }
        [HttpPost]
        public ActionResult AddDriver(Driver driver)
        {
            if (driver.DriverImage != null)
            {
            var binaryReader = new BinaryReader(driver.DriverImage.InputStream);
            driver.DImage = binaryReader.ReadBytes(driver.DriverImage.ContentLength);


                //driver.DImage = new byte[DriverImage.ContentLength];
                //DriverImage.InputStream.Read(driver.DImage, 0, DriverImage.ContentLength);
            }
            
            
            
            
            ViewBag.Message = aTransportManager.AddDriver(driver);
            ViewBag.Drivers = aTransportManager.GetAllDrivers();
            return View();
        }
        public JsonResult DeleteDriverByDriverId(int id)
        {
            
            aTransportManager.DeleteDriver(id);

            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditDriver()
        {
            return View();
        }

        //public ActionResult DeleteDriver(int id)
        //{
        //    int value = aTransportManager.DeleteDriver(id);
        //    return View(value);
        //}
        //[HttpPost]
        //public ActionResult DeleteDriver()
        //{
            
        //    return View();
        //}
        public ActionResult ShowDriverInfo()
        {
            return View();
        }
        public ActionResult AddRoute()
        {
            ViewBag.Routes = aTransportManager.GetAllRoutes();
            return View();
        }

        [HttpPost]
        public ActionResult AddRoute(RouteVM route)
        {
            ViewBag.Routes = aTransportManager.GetAllRoutes();
            ViewBag.Message = aTransportManager.AddRoute(route);
            return View();

        }
        public ActionResult EditRoute()
        {
            return View();
        }

        public ActionResult DeleteRoute()
        {
            return View();
        }

        public ActionResult ShowRouteInfo()
        {
            return View();
        }
        public ActionResult AddDestination()
        {
            ViewBag.Destinations = aTransportManager.GetAllDestinations();
            ViewBag.PickupAndDrops = GetPickupDropPlaceForDropdownList();
            ViewBag.FeeTypes = GetFeeTypesForDropdownList();
            ViewBag.Routes = GetRoutesForDropdownList();
            return View();
        }

        [HttpPost]
        public ActionResult AddDestination(Destination destination)
        {
            ViewBag.Destinations = aTransportManager.GetAllDestinations();
            ViewBag.Routes = GetRoutesForDropdownList();
            ViewBag.FeeTypes = GetFeeTypesForDropdownList();
            ViewBag.PickupAndDrops = GetPickupDropPlaceForDropdownList();
            ViewBag.Message = aTransportManager.AddDestination(destination);
            return View();
        }

        private List<SelectListItem> GetPickupDropPlaceForDropdownList()
        {
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "", Text = "---Select---"},
                new SelectListItem() {Value = "1", Text = "Chawkbazar"},
                new SelectListItem() {Value = "2", Text = "Bahaddarhat"},
                new SelectListItem() {Value = "3", Text = "AK khan"},
                new SelectListItem() {Value = "4", Text = "GEC"},
                new SelectListItem() {Value = "5", Text = "2No Gate"},
                new SelectListItem() {Value = "6", Text = "WASA"},
                new SelectListItem() {Value = "7", Text = "Lalkhan Bazar"},
                new SelectListItem() {Value = "8", Text = "Kotuallay"},
                new SelectListItem() {Value = "9", Text = "Agrabad"},
                new SelectListItem() {Value = "10", Text = "Vatiyari"},
                new SelectListItem() {Value = "11", Text = "Katghor"},
                new SelectListItem() {Value = "12", Text = "Dewanhat"},
                new SelectListItem() {Value = "13", Text = "Boropul"}
            };
            return items;
        }

        private List<SelectListItem> GetRoutesForDropdownList()
        {
            var routes = aTransportManager.GetRoutesForDropdownList();

            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "", Text = "--Select--"}
            };

            foreach (Destination destination in routes)
            {
                SelectListItem item = new SelectListItem() { Value = destination.RouteId.ToString(), Text = destination.RouteCode };
                items.Add(item);
            }

            return items;
        }

        private List<SelectListItem> GetFeeTypesForDropdownList()
        {
            var feeTypes = aTransportManager.GetAllFeeTypes();

            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "", Text = "--Select--"}
            };

            foreach (Destination destination in feeTypes)
            {
                SelectListItem item = new SelectListItem() { Value = destination.FeeTypeId.ToString(), Text = destination.FeeType };
                items.Add(item);
            }

            return items;
        }
        public ActionResult EditDestination()
        {
            return View();
        }

        public ActionResult DeleteDestination()
        {
            return View();
        }

        public ActionResult ShowDestinationInfo()
        {
            return View();
        }
        public ActionResult UserDestinationAllocation()
        {
            return View();
        }

        public ActionResult AssignVehicle()
        {
            ViewBag.AssignedVehicles = aTransportManager.GetAllAssignedVehicles();
            ViewBag.Routes = GetRoutesForDropdownList();
            ViewBag.Users = GetUserTypeForDropdownList();
            ViewBag.VehicleTypes = GetVehicleTypeForDropDownList();
            return View();
        }
        [HttpPost]
        public ActionResult AssignVehicle(AssignVehicleVM assignVehicle)
        {
            
            ViewBag.Routes = GetRoutesForDropdownList();
            ViewBag.Message = aTransportManager.Assign(assignVehicle);
            ViewBag.Users = GetUserTypeForDropdownList();
            ViewBag.VehicleTypes = GetVehicleTypeForDropDownList();
            ViewBag.AssignedVehicles = aTransportManager.GetAllAssignedVehicles();
            return View();
        }
        public JsonResult GetVehicleById(int id)
        {
            var vehicles = aTransportManager.GetVehicleById(id);
            return Json(vehicles);
        }
        public JsonResult DeleteAssigned(int id)
        {
            aTransportManager.DeleteAssigned(id);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        private List<SelectListItem> GetUserTypeForDropdownList()
        {
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "", Text = "---Select---"},
                new SelectListItem() {Value = "1", Text = "Faculty"},
                new SelectListItem() {Value = "2", Text = "Student"}
            };
            return items;
        }

        public ActionResult BusSchedule()
        {
            return RedirectToAction("GeneratePdf", "Transport");

            return View();
        }
        public ActionResult GeneratePdf(AssignVehicleVM assignVehicle)
        {
            ViewBag.Schedule = aTransportManager.GetSchedule();
            ViewBag.Schedule2 = aTransportManager.GetSchedule2();
            return new ViewAsPdf("GeneratePdf", "Transport")
            {
                FileName = "Bus Schedule.pdf"
            };
            

        }
       
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EducationalInstitutionERPApp.Gateway;
using EducationalInstitutionERPApp.Models.TransportModels;

namespace EducationalInstitutionERPApp.Manager
{
    public class TransportManager
    {
        TransportGateway aTransportGateway = new TransportGateway();
        public string AddDriver(Driver driver)
        {
            if (aTransportGateway.IsLicenseNoExists(driver))
            {
                return "License No aleady exists!";
            }
            else
            {
                int rowAffected = aTransportGateway.AddDriver(driver);
                if (rowAffected > 0)
                {
                    return "Driver added successfully!";
                }
                else
                {
                    return "Failed to add driver!";
                }
            }
        }

        public List<Driver> GetAllDrivers()
        {
            return aTransportGateway.GetAllDrivers();
        }

        public List<Vehicle> GetAllVehicleTypes()
        {
            return aTransportGateway.GetAllVehicleTypes();
        }

        public string AddVehilce(Vehicle vehicle)
        {

            if (aTransportGateway.IsDriverAvailable(vehicle))
            {
               
                return "Driver not available";
            }
            else
            {
                
            if (aTransportGateway.IsVehicleNoExists(vehicle))
            {
                return "Vehicle No already exists!!";   
             }
              
                else
                {
                    int rowAffected = aTransportGateway.AddVehicle(vehicle);
                    if (rowAffected > 0)
                    {
                        return "Vehicle added suucessfully!!";
                    }
                    else
                    {
                        return "Failed to add vehicle!!";
                    }
                }
            }
        }

        public List<Vehicle> GetAllVehicles()
        {
            return aTransportGateway.GetAllVehicles();
        }

        public string AddRoute(RouteVM route)
        {
            if (aTransportGateway.IsRouteCodeExists(route))
            {
                return "Route already added!!";
            }
            else
            {
                if (aTransportGateway.IsRouteAdded(route))
                {
                    return "Route already added!!";
                }
                int rowAffected = aTransportGateway.AddRoute(route);
                if (rowAffected > 0)
                {
                    return "Route added successfully!";
                }
                else
                {
                    return "Failed to add row";
                }
            }
        }

        public List<RouteVM> GetAllRoutes()
        {
            return aTransportGateway.GetAllRoutes();
        }

        public IEnumerable<Destination> GetAllFeeTypes()
        {
            return aTransportGateway.GetAllFeeTypes();
        }

        public string AddDestination(Destination destination)
        {
            if (aTransportGateway.IsDestinationAdded(destination))
            {
                return "Destination already added!!";
            }
            else
            {
                int rowAffected = aTransportGateway.AddDestination(destination);
                return "Destination & Fees added suucessfully!!";
            }
        }

        public IEnumerable<Destination> GetRoutesForDropdownList()
        {
            return aTransportGateway.GetRoutesForDropdownList();
        }

        public List<Destination> GetAllDestinations()
        {
            return aTransportGateway.GetAllDestinations();
        }

        public List<Vehicle> GetVehicleById(int id)
        {
            return aTransportGateway.GetVehicleById(id);
        }

        public string Assign(AssignVehicleVM assignVehicle)
        {
        //    string fromH = assignVehicle.StartTime;
        //    string fromHSub = fromH.Substring(0, 2);
        //    string fromM = assignVehicle.StartTime;
        //    string fromMSub = fromM.Substring(3, 2);
        //    int fromMin = Convert.ToInt32(fromHSub) * 60 + Convert.ToInt32(fromMSub);
        //    if (aTransportGateway.IsVehicleExist(assignVehicle))
        //    {
                
        //    } 
        //    else
        //    {
        //        return "Vehicle assigned suucessfully!!";
        //    }
            int rowAffected = aTransportGateway.Assign(assignVehicle);
            if (rowAffected > 0)
            {
                return "Vehicle assigned suucessfully!!";
            }
            else
            {
                return "Failed To Assign Vehicle!!";
            }
        }

        public List<AssignVehicleVM> GetAllAssignedVehicles()
        {
            return aTransportGateway.GetAllAssignedVehicles();
        }

        public List<AssignVehicleVM> GetSchedule()
        {
            return aTransportGateway.GetSchedule();
        }

        public List<AssignVehicleVM> GetSchedule2()
        {
            return aTransportGateway.GetSchedule2();
        }

        public void DeleteDriver(int id)
        {
            if (aTransportGateway.DriverAssignedToVehicle(id))
            {
                Vehicle vehicle = aTransportGateway.GetVehicleId(id);
                if (aTransportGateway.IsVehicleAssigned(vehicle.Id))
                {

                    aTransportGateway.DeleteDriversAssignedVehicle(vehicle.Id);
                }
                //else
                //{
                //    if (aTransportGateway.DriverAssignedToVehicle(id))
                //    {
                        aTransportGateway.DeleteDriversVehicle(id);
                //    }

                //}
            }
           

            aTransportGateway.DeleteDriver(id);
           
        }

        public void DeleteVehicle(int id)
        {
            if (aTransportGateway.IsVehicleAssigned(id))
            {
                aTransportGateway.DeleteDriversAssignedVehicle(id);
            }
            aTransportGateway.DeleteVehicle(id);
        }

        public void DeleteAssigned(int id)
        {
            aTransportGateway.DeleteAssigned(id);
        }

        public Vehicle GetVehicleType(int id)
        {
            return aTransportGateway.GetVehicleType(id);
        }

        public object UpdateVehicle(Vehicle vehicle)
        {

            Vehicle aVehicle = aTransportGateway.GetVehicleIdByNo(vehicle);
            vehicle.Id = aVehicle.Id;
            if (aTransportGateway.IsDriverAvailableForUpdate(vehicle))
            {
               
                return "Driver not available";
            }
            else
            {
                
            if (aTransportGateway.IsVehicleNoExistsForUpdate(vehicle))
            {
                return "Vehicle No already exists!!";   
             }
              
                else
            {
               
                    int rowAffected = aTransportGateway.UpdateVehicle(vehicle);
                    if (rowAffected > 0)
                    {
                        return "Vehicle updated suucessfully!!";
                    }
                    else
                    {
                        return "Failed to add vehicle!!";
                    }
                }
            }
        }
    }
}
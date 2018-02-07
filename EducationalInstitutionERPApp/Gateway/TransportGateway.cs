using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using EducationalInstitutionERPApp.Models.TransportModels;

namespace EducationalInstitutionERPApp.Gateway
{
    public class TransportGateway : Gateway
    {
       

        public bool IsLicenseNoExists(Driver driver)
        {
            Query = "SELECT LicenseNO FROM Driver WHERE LicenseNo = @licenseNo";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("licenseNo", SqlDbType.VarChar);
            Command.Parameters["licenseNo"].Value = driver.LicenseNo;
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRow = false;
            if (Reader.HasRows)
            {
                hasRow = true;
            }
            Reader.Close();
            Connection.Close();
            return hasRow;
        }

        public int AddDriver(Driver driver)
        {
            Query =
               "INSERT INTO Driver(Name,ContactNo,Address,LicenseNo,DriverImage) VALUES(@name, @contactNo, @address, @licenseNo, @driverImage)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = driver.Name;

            Command.Parameters.Add("contactNo", SqlDbType.VarChar);
            Command.Parameters["contactNo"].Value = driver.ContactNo;        

            Command.Parameters.Add("address", SqlDbType.VarChar);
            Command.Parameters["address"].Value = driver.Address;

            Command.Parameters.Add("licenseNo", SqlDbType.VarChar);
            Command.Parameters["licenseNo"].Value = driver.LicenseNo;

            Command.Parameters.Add("driverImage", SqlDbType.VarBinary);
            Command.Parameters["driverImage"].Value = driver.DImage;
            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<Driver> GetAllDrivers()
        {
             Query = "SELECT * FROM Driver";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Driver> drivers = new List<Driver>();

            while (Reader.Read())
            {
                
                      
                   
                Driver driver = new Driver()
                {
                    Id = (int)Reader["Id"], 
                    Name = Reader["Name"].ToString(),
                    ContactNo = Reader["ContactNo"].ToString(),
                    Address = Reader["Address"].ToString(),
                    LicenseNo = Reader["LicenseNo"].ToString(),
                    DImage = Encoding.ASCII.GetBytes(Reader["DriverImage"].ToString()),
                     //DriverImage = (HttpPostedFileBase)new MemoryPostedFile(a)

                };
                
                drivers.Add(driver);
            }
            Reader.Close();
            Connection.Close();
            return drivers;
        }
        //public class MemoryPostedFile : HttpPostedFileBase
        //{
        //    private readonly byte[] fileBytes;

        //    public MemoryPostedFile(byte[] fileBytes, string fileName = null)
        //    {
        //        this.fileBytes = fileBytes;
        //        this.FileName = fileName;
        //        this.InputStream = new MemoryStream(fileBytes);
        //    }

        //    public override int ContentLength => fileBytes.Length;

        //    public override string FileName { get;  }

        //    public override Stream InputStream { get; }
        //}

        public List<Vehicle> GetAllVehicleTypes()
        {
            Query = "SELECT * FROM VehicleType";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Vehicle> vehicles = new List<Vehicle>();

            while (Reader.Read())
            {

                Vehicle vehicle = new Vehicle()
                {
                    VehicleTypeId = (int)Reader["Id"],
                    VehicleType = Reader["Type"].ToString()
                    

                };
                vehicles.Add(vehicle);
            }
            Reader.Close();
            Connection.Close();
            return vehicles;
        }

        public bool IsVehicleNoExists(Vehicle vehicle)
        {
            Query = "SELECT VehicleNo FROM Vehicle WHERE VehicleNo = @vehicleNo";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("vehicleNo", SqlDbType.VarChar);
            Command.Parameters["vehicleNo"].Value = vehicle.VehicleNo;
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRow = false;
            if (Reader.HasRows)
            {
                hasRow = true;
            }
            Reader.Close();
            Connection.Close();
            return hasRow;
        }

        public int AddVehicle(Vehicle vehicle)
        {
            Query =
                "INSERT INTO Vehicle(VehicleNo,NoOfSeats,VehicleTypeId,DriverId) VALUES(@vehicleNo, @noOfSeats, @vehicleTypeId, @driverId)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("vehicleNo", SqlDbType.VarChar);
            Command.Parameters["vehicleNo"].Value = vehicle.VehicleNo;

            Command.Parameters.Add("noOfSeats", SqlDbType.VarChar);
            Command.Parameters["noOfSeats"].Value = vehicle.NoOfSeats;

            Command.Parameters.Add("vehicleTypeId", SqlDbType.VarChar);
            Command.Parameters["vehicleTypeId"].Value = vehicle.VehicleTypeId;

            Command.Parameters.Add("driverId", SqlDbType.VarChar);
            Command.Parameters["driverId"].Value = vehicle.DriverId;


            
            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected; 
        }


        public List<Vehicle> GetAllVehicles()
        {
            Query = "select v.Id,v.VehicleNo, v.NoOfSeats, vt.Type as VehicleType, d.Name as DriverName FROM Vehicle v" +
                    " JOIN Driver d ON v.DriverId = d.Id " +
                    "JOIN VehicleType vt ON vt.Id = v.VehicleTypeId"; 

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Vehicle> vehicles = new List<Vehicle>();

            while (Reader.Read())
            {

                Vehicle vehicle = new Vehicle()
                {
                    Id = (int)Reader["Id"],
                    VehicleNo = Reader["VehicleNo"].ToString(),
                    VehicleType = Reader["VehicleType"].ToString(),
                    NoOfSeats = (int)Reader["NoOfSeats"],
                    DriverName = Reader["DriverName"].ToString()


                };
                vehicles.Add(vehicle);
            }
            Reader.Close();
            Connection.Close();
            return vehicles;
        }

        public bool IsRouteCodeExists(RouteVM route)
        {
            Query = "SELECT Code FROM Route WHERE Code = @code";

           Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("code", SqlDbType.VarChar);
            Command.Parameters["code"].Value = route.RouteCode;
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRow = false;
            if (Reader.HasRows)
            {
                hasRow = true;
            }
            Reader.Close();
            Connection.Close();
            return hasRow;
        }

        public int AddRoute(RouteVM route)
        {
            Query =
               "INSERT INTO Route(Code,StartPlace,EndPlace) VALUES(@code, @startPlace, @endPlace)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("code", SqlDbType.VarChar);
            Command.Parameters["code"].Value = route.RouteCode;

            Command.Parameters.Add("startPlace", SqlDbType.VarChar);
            Command.Parameters["startPlace"].Value = route.StartPlace;

            Command.Parameters.Add("endPlace", SqlDbType.VarChar);
            Command.Parameters["endPlace"].Value = route.EndPlace;

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsRouteAdded(RouteVM route)
        {
            Query = "SELECT StartPlace,EndPlace From Route WHERE StartPlace = @startPlace AND EndPlace = @endPlace";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("startPlace", SqlDbType.VarChar);
            Command.Parameters["startPlace"].Value = route.StartPlace;

            Command.Parameters.Add("endPlace", SqlDbType.VarChar);
            Command.Parameters["endPlace"].Value = route.EndPlace;
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRow = false;
            if (Reader.HasRows)
            {
                hasRow = true;
            }
            Reader.Close();
            Connection.Close();
            return hasRow;
        }

        public List<RouteVM> GetAllRoutes()
        {
            Query = "SELECT * FROM Route";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<RouteVM> routes = new List<RouteVM>();

            while (Reader.Read())
            {

                RouteVM route = new RouteVM()
                {
                    RouteCode = Reader["Code"].ToString(),
                    StartPlace = Reader["StartPlace"].ToString(),
                    EndPlace = Reader["EndPlace"].ToString()


                };
                routes.Add(route);
            }
            Reader.Close();
            Connection.Close();
            return routes;
        }

        public IEnumerable<Destination> GetAllFeeTypes()
        {
            Query = "SELECT * FROM FeeType";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Destination> destinations = new List<Destination>();

            while (Reader.Read())
            {

                Destination destination = new Destination()
                {
                    FeeTypeId = (int)Reader["Id"],
                    FeeType = Reader["Type"].ToString()


                };
                destinations.Add(destination);
            }
            Reader.Close();
            Connection.Close();
            return destinations;
        }

        public bool IsDestinationAdded(Destination destination)
        {
            Query = "SELECT * From DestinationAndFees WHERE PickupAndDrop = @pickupAndDrop";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("pickupAndDrop", SqlDbType.VarChar);
            Command.Parameters["pickupAndDrop"].Value = destination.PickUpAndDrop;

            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRow = false;
            if (Reader.HasRows)
            {
                hasRow = true;
            }
            Reader.Close();
            Connection.Close();
            return hasRow;
        }

        public int AddDestination(Destination destination)
        {
            Query =
               "INSERT INTO DestinationAndFees(RouteId,PickupAndDrop,FeeAmount,FeeTypeId) VALUES(@routeId, @pickupAndDrop, @feeAmount,@feeTypeId)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("routeId", SqlDbType.Int);
            Command.Parameters["routeId"].Value = destination.RouteId;

            Command.Parameters.Add("pickupAndDrop", SqlDbType.VarChar);
            Command.Parameters["pickupAndDrop"].Value = destination.PickUpAndDrop;

            Command.Parameters.Add("feeAmount", SqlDbType.VarChar);
            Command.Parameters["feeAmount"].Value = destination.FeeAmount;

            Command.Parameters.Add("feeTypeId", SqlDbType.VarChar);
            Command.Parameters["feeTypeId"].Value = destination.FeeTypeId;

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public IEnumerable<Destination> GetRoutesForDropdownList()
        {
            Query = "SELECT * FROM Route";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Destination> destinations = new List<Destination>();

            while (Reader.Read())
            {

                Destination destination = new Destination()
                {
                    RouteId = (int)Reader["Id"],
                    RouteCode = Reader["Code"].ToString()


                };
                destinations.Add(destination);
            }
            Reader.Close();
            Connection.Close();
            return destinations;
        }

        public List<Destination> GetAllDestinations()
        {
            Query = "Select r.Code,d.PickupAndDrop, d.FeeAmount, f.Type FROM DestinationAndFees d " +
                    "JOIN Route r ON r.Id = d.RouteId " +
                    "JOIN FeeType f ON d.FeeTypeId = f.Id";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Destination> destinations = new List<Destination>();

            while (Reader.Read())
            {

                Destination destination = new Destination()
                {
                    
                    RouteCode = Reader["Code"].ToString(),
                    PickUpAndDrop = Reader["PickupAndDrop"].ToString(),
                    FeeAmount = (int)Reader["FeeAmount"],
                    FeeType = Reader["Type"].ToString()


                };
                destinations.Add(destination);
            }
            Reader.Close();
            Connection.Close();
            return destinations;
        }

        public List<Vehicle> GetVehicleById(int id)
        {
            Query = "SELECT * FROM Vehicle WHERE VehicleTypeId = @id";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = id;
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Vehicle> vehicles = new List<Vehicle>();

            while (Reader.Read())
            {

                Vehicle vehicle = new Vehicle()
                {
                    Id = (int)Reader["Id"],
                    VehicleNo = Reader["VehicleNo"].ToString()


                };
                vehicles.Add(vehicle);
            }
            Reader.Close();
            Connection.Close();
            return vehicles;   
        }

        public bool IsVehicleExist(AssignVehicleVM assignVehicle)
        {
            Query = "SELECT * From AssignVehicle WHERE VehicleId = @vehicleId";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("vehicleId", SqlDbType.VarChar);
            Command.Parameters["vehicleId"].Value = assignVehicle.VehicleId;

            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRow = false;
            if (Reader.HasRows)
            {
                hasRow = true;
            }
            Reader.Close();
            Connection.Close();
            return hasRow;
        }

        public int Assign(AssignVehicleVM assignVehicle)
        {
            Query =
               "INSERT INTO AssignVehicle(VehicleTypeId,VehicleId,RouteId,StartTime,UserType) VALUES(@vehicleTypeId, @vehicleId, @routeId,@startTime, @userType)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("vehicleTypeId", SqlDbType.Int);
            Command.Parameters["vehicleTypeId"].Value = assignVehicle.VehicleTypeId;

            Command.Parameters.Add("vehicleId", SqlDbType.Int);
            Command.Parameters["vehicleId"].Value = assignVehicle.VehicleId;

            Command.Parameters.Add("routeId", SqlDbType.Int);
            Command.Parameters["routeId"].Value = assignVehicle.RouteId;

            Command.Parameters.Add("startTime", SqlDbType.VarChar);
            Command.Parameters["startTime"].Value = assignVehicle.StartTime;

            Command.Parameters.Add("userType", SqlDbType.VarChar);
            Command.Parameters["userType"].Value = assignVehicle.UserType;

            

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<AssignVehicleVM> GetAllAssignedVehicles()
        {
            Query =
                "select a.Id,a.StartTime,r.StartPlace,r.EndPlace,a.UserType, v.VehicleNo from AssignVehicle a " +
                "JOIN Route r ON r.Id= a.RouteId JOIN Vehicle v ON v.Id = a.VehicleId"; 
            Command = new SqlCommand(Query, Connection);
           
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<AssignVehicleVM> assignedVehicles = new List<AssignVehicleVM>();

            while (Reader.Read())
            {

                AssignVehicleVM assignVehicle = new AssignVehicleVM()
                {
                    Id = (int)Reader["Id"],
                    StartTime = Reader["StartTime"].ToString(),
                    VehicleNo = Reader["VehicleNo"].ToString(),
                    StartPlace = Reader["StartPlace"].ToString(),
                    UserType = Reader["UserType"].ToString(),
                    EndPlace = Reader["EndPlace"].ToString()


                };
                assignedVehicles.Add(assignVehicle);
            }
            Reader.Close();
            Connection.Close();
            return assignedVehicles;   
        }

        public List<AssignVehicleVM> GetSchedule()
        {
            Query =
                "select a.StartTime,r.StartPlace,r.EndPlace,a.UserType, v.VehicleNo from AssignVehicle a " +
                "JOIN Route r ON r.Id= a.RouteId JOIN Vehicle v ON v.Id = a.VehicleId WHERE StartPlace = 'Campus'";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<AssignVehicleVM> assignedVehicles = new List<AssignVehicleVM>();

            while (Reader.Read())
            {

                AssignVehicleVM assignVehicle = new AssignVehicleVM()
                {
                    StartTime = Reader["StartTime"].ToString(),
                    VehicleNo = Reader["VehicleNo"].ToString(),
                    StartPlace = Reader["StartPlace"].ToString(),
                    UserType = Reader["UserType"].ToString(),
                    EndPlace = Reader["EndPlace"].ToString()


                };
                assignedVehicles.Add(assignVehicle);
            }
            Reader.Close();
            Connection.Close();
            return assignedVehicles;   
        }

        public List<AssignVehicleVM> GetSchedule2()
        {
            Query =
                "select a.StartTime,r.StartPlace,r.EndPlace,a.UserType, v.VehicleNo from AssignVehicle a " +
                "JOIN Route r ON r.Id= a.RouteId JOIN Vehicle v ON v.Id = a.VehicleId WHERE EndPlace = 'Campus'";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<AssignVehicleVM> assignedVehicles = new List<AssignVehicleVM>();

            while (Reader.Read())
            {

                AssignVehicleVM assignVehicle = new AssignVehicleVM()
                {
                    StartTime = Reader["StartTime"].ToString(),
                    VehicleNo = Reader["VehicleNo"].ToString(),
                    StartPlace = Reader["StartPlace"].ToString(),
                    UserType = Reader["UserType"].ToString(),
                    EndPlace = Reader["EndPlace"].ToString()


                };
                assignedVehicles.Add(assignVehicle);
            }
            Reader.Close();
            Connection.Close();
            return assignedVehicles;
        }

        public int DeleteDriver(int id)
        {
            Query =
                "Delete from Driver Where Id = @id";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = id;

            



            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;

        }

        public void DeleteVehicle(int id)
        {
            Query =
                "Delete from Vehicle Where Id = @id";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = id;





            Connection.Open();

            Command.ExecuteNonQuery();
            Connection.Close();
            
        }

        public void DeleteAssigned(int id)
        {
            Query =
                "Delete from AssignVehicle Where Id = @id";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = id;





            Connection.Open();

            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public void DeleteDriversVehicle(int id)
        {
            Query =
                "Delete from Vehicle Where DriverId = @id";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = id;





            Connection.Open();

            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public void DeleteDriversAssignedVehicle(int id)
        {
            Query =
                "Delete from AssignVehicle Where VehicleId = @id";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = id;





            Connection.Open();

            Command.ExecuteNonQuery();
            Connection.Close();
        }

        public Vehicle GetVehicleId(int id)
        {
            Query = "SELECT Id FROM Vehicle WHERE DriverId = @id";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = id;
            Reader = Command.ExecuteReader();
            Vehicle vehicle = null;

            if (Reader.Read())
            {

                vehicle = new Vehicle()
                {
                    Id = (int)Reader["Id"],
                  


                };
                
            }
            Reader.Close();
            Connection.Close();
            return vehicle;
        }

        public bool IsVehicleAssigned(int id)
        {
            Query = "SELECT * FROM AssignVehicle WHERE VehicleId = @id";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = id;
            Reader = Command.ExecuteReader();
          
            bool hasRows = false;

            if (Reader.Read())
            {

                hasRows = true;

            }
            Reader.Close();
            Connection.Close();
            return hasRows;
        }

        public bool DriverAssignedToVehicle(int id)
        {
            Query = "SELECT * FROM Vehicle WHERE DriverId = @id";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = id;
            Reader = Command.ExecuteReader();

            bool hasRows = false;

            if (Reader.Read())
            {

                hasRows = true;

            }
            Reader.Close();
            Connection.Close();
            return hasRows;
        }

        public bool IsDriverAvailable(Vehicle vehicle)
        {
            Query = "SELECT * FROM Vehicle WHERE DriverId = @id";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = vehicle.DriverId;
            Reader = Command.ExecuteReader();

            bool hasRows = false;

            if (Reader.Read())
            {

                hasRows = true;

            }
            Reader.Close();
            Connection.Close();
            return hasRows;
        }

        public Vehicle GetVehicleType(int id)
        {

            Query = "select * from Vehicle v JOIN VehicleType vt ON vt.Id = v.VehicleTypeId Join Driver d ON d.Id = v.DriverId WHERE v.Id = @id";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = id;
            Reader = Command.ExecuteReader();
            Vehicle vehicle = null;

            if (Reader.Read())
            {

                vehicle = new Vehicle()
                {
                    Id = (int)Reader["Id"],
                    VehicleNo = Reader["VehicleNo"].ToString(),
                    NoOfSeats = (int)Reader["NoOfSeats"],
                    VehicleTypeId = (int)Reader["VehicleTypeId"],
                    VehicleType = Reader["Type"].ToString(),
                    DriverId = (int)Reader["DriverId"],
                    DriverName = Reader["Name"].ToString()


                };

            }
            Reader.Close();
            Connection.Close();
            return vehicle;
        }

        public bool IsDriverAvailableForUpdate(Vehicle vehicle)
        {
            Query = "SELECT * FROM Vehicle WHERE DriverId = @id And Id <> @vid";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = vehicle.DriverId;
            Command.Parameters.Add("vid", SqlDbType.Int);
            Command.Parameters["vid"].Value = vehicle.Id;
            Reader = Command.ExecuteReader();

            bool hasRows = false;

            if (Reader.Read())
            {

                hasRows = true;

            }
            Reader.Close();
            Connection.Close();
            return hasRows;
        }

        public bool IsVehicleNoExistsForUpdate(Vehicle vehicle)
        {
            Query = "SELECT * FROM Vehicle WHERE VehicleNo = @vehicleNo And Id <> @id";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("vehicleNo", SqlDbType.VarChar);
            Command.Parameters["vehicleNo"].Value = vehicle.VehicleNo;
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = vehicle.Id;
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRow = false;
            if (Reader.HasRows)
            {
                hasRow = true;
            }
            Reader.Close();
            Connection.Close();
            return hasRow;
        }

        public int UpdateVehicle(Vehicle vehicle)
        {
            Query =
                 "Update Vehicle SET VehicleNo = @vehicleNo,NoOfSeats = @noOfSeats,VehicleTypeId = @vehicleTypeId,DriverId = @driverId WHERE Id = @id ";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("vehicleNo", SqlDbType.VarChar);
            Command.Parameters["vehicleNo"].Value = vehicle.VehicleNo;

            Command.Parameters.Add("noOfSeats", SqlDbType.Int);
            Command.Parameters["noOfSeats"].Value = vehicle.NoOfSeats;

            Command.Parameters.Add("vehicleTypeId", SqlDbType.Int);
            Command.Parameters["vehicleTypeId"].Value = vehicle.VehicleTypeId;

            Command.Parameters.Add("driverId", SqlDbType.Int);
            Command.Parameters["driverId"].Value = vehicle.DriverId;
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = vehicle.Id;



            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected; 
        }

        public Vehicle GetVehicleIdByNo(Vehicle vehicle)
        {
            Query = "SELECT * FROM Vehicle WHERE VehicleNo= @vehicleNo ";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("vehicleNo", SqlDbType.VarChar);
            Command.Parameters["vehicleNo"].Value = vehicle.VehicleNo;
            Reader = Command.ExecuteReader();
            Vehicle aVehicle = null;

            if (Reader.Read())
            {

                aVehicle = new Vehicle()
                {
                    Id = (int)Reader["Id"],
                    


                };
               
            }
            Reader.Close();
            Connection.Close();
            return aVehicle;
        }
    }
}
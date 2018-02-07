using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using EducationalInstitutionERPApp.Models.HRAndPayrollModels;

namespace EducationalInstitutionERPApp.Gateway
{
    public class HRAndPayrollGateway : Gateway
    {
        public bool IsTypeExists(EmployeeType employeeType)
        {
            Query = "SELECT * From EmployeeType WHERE Type = @type";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("type", SqlDbType.VarChar);
            Command.Parameters["type"].Value = employeeType.EmpType;

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

        public int Save(EmployeeType employeeType)
        {
            Query =
               "INSERT INTO EmployeeType VALUES(@type)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            

            Command.Parameters.Add("type", SqlDbType.VarChar);
            Command.Parameters["type"].Value = employeeType.EmpType;

            
            

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        

        }

        public List<EmployeeType> GetAllEmpTypes()
        {
            Query =
               "SELECT * FROM EmployeeType";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<EmployeeType> types = new List<EmployeeType>();

            while (Reader.Read())
            {

                EmployeeType type = new EmployeeType()
                {
                    Id = (int)Reader["Id"],
                    EmpType = Reader["Type"].ToString(),
                  


                };
                types.Add(type);
            }
            Reader.Close();
            Connection.Close();
            return types;   
        }

        public EmployeeType GetEmpType(int empId)
        {
            Query =
               "SELECT * FROM EmployeeType WHERE Id = @id";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();


            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = empId;
            Connection.Open();
            Reader = Command.ExecuteReader();
            EmployeeType type = null;

            if (Reader.Read())
            {
                 type = new EmployeeType()
                {
                    Id = (int)Reader["Id"],
                    EmpType = Reader["Type"].ToString(),
                };              
            }
            Reader.Close();
            Connection.Close();
            return type;   
        }

        public int UpdateType(EmployeeType employeeType)
        {
            Query =
               "Update EmployeeType SET Type = '"+employeeType.EmpType+"' WHERE Id = @id";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = employeeType.Id;
            




            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        
        }

        public EmployeeType GetTypeForShow(EmployeeType employeeType)
        {
            Query =
               "SELECT * FROM EmployeeType WHERE Id = @id";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();


            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = employeeType.Id;
            Connection.Open();
            Reader = Command.ExecuteReader();
            EmployeeType type = null;

            if (Reader.Read())
            {
                type = new EmployeeType()
                {
                    Id = (int)Reader["Id"],
                    EmpType = Reader["Type"].ToString(),
                };
            }
            Reader.Close();
            Connection.Close();
            return type;   
        }

        public bool IsDesignationExists(Designation designation)
        {
            Query = "SELECT * From Designation WHERE Designation = @des";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("des", SqlDbType.VarChar);
            Command.Parameters["des"].Value = designation.DesignationName;

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

        public int AddDesignation(Designation designation)
        {
            Query =
               "INSERT INTO Designation VALUES(@des)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();


            Command.Parameters.Add("des", SqlDbType.VarChar);
            Command.Parameters["des"].Value = designation.DesignationName;




            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<Designation> GetAllDesignation()
        {
            Query =
               "SELECT * FROM Designation";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Designation> designations = new List<Designation>();

            while (Reader.Read())
            {

                Designation designation = new Designation()
                {
                    Id = (int)Reader["Id"],
                    DesignationName = Reader["Designation"].ToString(),



                };
                designations.Add(designation);
            }
            Reader.Close();
            Connection.Close();
            return designations;   
        }

        public List<Gender> GetAllGenders()
        {
            Query =
               "SELECT * FROM Gender";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Gender> genders = new List<Gender>();

            while (Reader.Read())
            {
                Gender gender = new Gender()
                {
                    Id = (int)Reader["Id"],
                    GenderName = Reader["Gender"].ToString(),
                };
                genders.Add(gender);
            }
            Reader.Close();
            Connection.Close();
            return genders;  
        }

        public bool IsEmailExists(Employee employee)
        {
            Query = "SELECT * From Employee WHERE Email = @email";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = employee.Email;

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

        public int AddEmployee(Employee employee)
        {
            Query =
               "INSERT INTO Employee VALUES(@name,@genderId,@dob,@contactNo,@email,@address,@joinDate,@deptId,@catId,@desId,@img)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();


            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = employee.Name;
            Command.Parameters.Add("genderId", SqlDbType.Int);
            Command.Parameters["genderId"].Value = employee.GenderId;
            Command.Parameters.Add("dob", SqlDbType.Date);
            Command.Parameters["dob"].Value = employee.DateOfBirth;
            Command.Parameters.Add("contactNo", SqlDbType.VarChar);
            Command.Parameters["contactNo"].Value = employee.ContactNo;
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = employee.Email;
            Command.Parameters.Add("address", SqlDbType.VarChar);
            Command.Parameters["address"].Value = employee.Address;
            Command.Parameters.Add("joinDate", SqlDbType.Date);
            Command.Parameters["joinDate"].Value = employee.JoiningDate;
            Command.Parameters.Add("deptId", SqlDbType.Int);
            Command.Parameters["deptId"].Value = employee.DepartmentId;
            Command.Parameters.Add("catId", SqlDbType.Int);
            Command.Parameters["catId"].Value = employee.CategoryId;
            Command.Parameters.Add("desId", SqlDbType.Int);
            Command.Parameters["desId"].Value = employee.DesignationId;
            Command.Parameters.Add("img", SqlDbType.VarBinary);
            Command.Parameters["img"].Value = employee.EmpImage;

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
        public List<Employee> GetAllEmployees()
        {
            Query = "Select e.Id,e.Name,e.ContactNo,e.Email,g.Gender,e.JoiningDate,d.Name as Department,et.Type as Category FROM Employee e " +
                    "JOIN Gender g ON e.GenderId = g.Id  JOIN Department d ON d.Id = e.DepartmentId " +
                    "JOIN EmployeeType et On et.Id = e.CategoryId";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Employee> employees = new List<Employee>();

            while (Reader.Read())
            {
                string date = Reader["JoiningDate"].ToString();
                string joiningDate = date.Substring(0, 9);

                Employee employee = new Employee()
                {


                    Id = (int)Reader["Id"],
                    Name = Reader["Name"].ToString(),
                    ContactNo = Reader["ContactNo"].ToString(),
                    Email = Reader["Email"].ToString(),
                    Gender = Reader["Gender"].ToString(),
                    JoiningDate = joiningDate,
                    Department = Reader["Department"].ToString(),
                    Category = Reader["Category"].ToString(),
                };
                employees.Add(employee);
            }
            Reader.Close();
            Connection.Close();
            return employees;

        }

        public List<Employee> GetAllTeachers()
        {
            Query = "Select e.Id,e.Name,e.ContactNo,e.Email,g.Gender,e.JoiningDate,d.Name as Department,et.Type as Category FROM Employee e " +
                    "JOIN Gender g ON e.GenderId = g.Id  JOIN Department d ON d.Id = e.DepartmentId " +
                    "JOIN EmployeeType et On et.Id = e.CategoryId WHERE CategoryId = 1";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Employee> employees = new List<Employee>();

            while (Reader.Read())
            {
                string date = Reader["JoiningDate"].ToString();
                string joiningDate = date.Substring(0, 9);
                
                Employee employee = new Employee()
                {
                     

                    Id = (int)Reader["Id"],
                    Name = Reader["Name"].ToString(),
                    ContactNo = Reader["ContactNo"].ToString(),
                    Email = Reader["Email"].ToString(),
                    Gender = Reader["Gender"].ToString(),
                    JoiningDate = joiningDate,
                    Department = Reader["Department"].ToString(),
                    Category = Reader["Category"].ToString(),
                };
                employees.Add(employee);
            }
            Reader.Close();
            Connection.Close();
            return employees;  

        }

        public Employee GetEmployeeInfo(Employee employee)
        {
            Query = "Select e.Id,e.Name,e.ContactNo,e.DateOfBirth,e.Image,e.Address,e.Email,g.Gender,e.JoiningDate,d.Name as Department,et.Type as Category FROM Employee e " +
                    "JOIN Gender g ON e.GenderId = g.Id  JOIN Department d ON d.Id = e.DepartmentId " +
                    "JOIN EmployeeType et On et.Id = e.CategoryId WHERE e.DepartmentId = @deptId and e.CategoryId = @catId and e.Email = @email";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();


            Command.Parameters.Add("deptId", SqlDbType.Int);
            Command.Parameters["deptId"].Value = employee.DepartmentId;
            Command.Parameters.Add("catId", SqlDbType.Int);
            Command.Parameters["catId"].Value = employee.CategoryId;
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = employee.Email;
            Connection.Open();
            Reader = Command.ExecuteReader();
            Employee anEmployee = null;

            if (Reader.Read())
            {
                string date = Reader["JoiningDate"].ToString();
                string joiningDate = date.Substring(0, 9);

                anEmployee = new Employee()
                {


                    Id = (int) Reader["Id"],
                    Name = Reader["Name"].ToString(),
                    ContactNo = Reader["ContactNo"].ToString(),
                    Email = Reader["Email"].ToString(),
                    DateOfBirth = Reader["DateOfBirth"].ToString(),
                    Gender = Reader["Gender"].ToString(),
                    Address = Reader["Address"].ToString(),
                    EmpImage = (byte[]) Reader["Image"],
                    JoiningDate = joiningDate,
                    Department = Reader["Department"].ToString(),
                    Category = Reader["Category"].ToString(),
                };

            }
            
            Reader.Close();
            Connection.Close();
            return anEmployee;
        }

        public List<Employee> GetAllStaffs()
        {
            Query = "Select e.Id,e.Name,e.ContactNo,e.Email,g.Gender,e.JoiningDate,d.Name as Department,et.Type as Category FROM Employee e " +
                     "JOIN Gender g ON e.GenderId = g.Id  JOIN Department d ON d.Id = e.DepartmentId " +
                     "JOIN EmployeeType et On et.Id = e.CategoryId WHERE CategoryId = 2";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Employee> employees = new List<Employee>();

            while (Reader.Read())
            {
                string date = Reader["JoiningDate"].ToString();
                string joiningDate = date.Substring(0, 9);

                Employee employee = new Employee()
                {


                    Id = (int)Reader["Id"],
                    Name = Reader["Name"].ToString(),
                    ContactNo = Reader["ContactNo"].ToString(),
                    Email = Reader["Email"].ToString(),
                    Gender = Reader["Gender"].ToString(),
                    JoiningDate = joiningDate,
                    Department = Reader["Department"].ToString(),
                    Category = Reader["Category"].ToString(),
                };
                employees.Add(employee);
            }
            Reader.Close();
            Connection.Close();
            return employees;  
        }
    }
}
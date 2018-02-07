using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using EducationalInstitutionERPApp.Gateway;
using EducationalInstitutionERPApp.Models.AcademicModels;
using EducationalInstitutionERPApp.Models.HRAndPayrollModels;

namespace EducationalInstitutionERPApp.Manager
{
    public class HRAndPayrollManager
    {
        HRAndPayrollGateway aPayrollGateway = new HRAndPayrollGateway();

        public string AddEmployeeType(EmployeeType employeeType)
        {
            if (aPayrollGateway.IsTypeExists(employeeType))
            {
                return "Type exists";
            }
            else
            {
                int rowAffected = aPayrollGateway.Save(employeeType);
                if (rowAffected > 0)
                {
                    return "Type added suucessfully!!";
                }
                return "Saving failed!!";
            }
        }

        public List<EmployeeType> GetAllEmpTypes()
        {
            return aPayrollGateway.GetAllEmpTypes();
        }

        public EmployeeType GetEmpType(int empId)
        {
            return aPayrollGateway.GetEmpType(empId);
        }

        public string UpdateType(EmployeeType employeeType)
        {
            int rowAffected = aPayrollGateway.UpdateType(employeeType);
            if (rowAffected > 0)
            {
                return "Updated Successfully";
            }
            return "Could no update";
            
        }

        public EmployeeType GetTypeForShow(EmployeeType employeeType)
        {
            return aPayrollGateway.GetTypeForShow(employeeType);
        }

        public string AddDesignation(Designation designation)
        {
            if (aPayrollGateway.IsDesignationExists(designation))
            {
                return "Designations exists";
            }
            else
            {
                int rowAffected = aPayrollGateway.AddDesignation(designation);
                if (rowAffected > 0)
                {
                    return "Designation added suucessfully!!";
                }
                return "Failed to add Designation";
            }
        }

        public List<Designation> GetAllDesignation()
        {
            return aPayrollGateway.GetAllDesignation();
        }


        public List<Gender> GetAllGenders()
        {
            return aPayrollGateway.GetAllGenders();
        }

        public string AddEmployee(Employee employee)
        {
            if (aPayrollGateway.IsEmailExists(employee))
            {
                return "Employee exists";
            }
            else
            {
                int rowAffected = aPayrollGateway.AddEmployee(employee);
                if (rowAffected > 0)
                {
                    return "Employee added suucessfully!!";
                }
                return "Saving failed!!";
            }
        }
        public List<Employee> GetAllEmployees()
        {
            return aPayrollGateway.GetAllEmployees();
        }
        public List<Employee> GetAllTeachers()
        {
            return aPayrollGateway.GetAllTeachers();
        }

        public Employee GetEmployeeInfo(Employee employee)
        {
            return aPayrollGateway.GetEmployeeInfo(employee);
        }

        //public void DeleteType(int id)
        //{
            
        //}
        public List<Employee> GetAllStaffs()
        {
            return aPayrollGateway.GetAllStaffs();
        }
    }
}
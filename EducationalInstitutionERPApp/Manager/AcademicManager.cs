using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EducationalInstitutionERPApp.Gateway;
using EducationalInstitutionERPApp.Models.AcademicModels;
using EducationalInstitutionERPApp.Models.HRAndPayrollModels;

namespace EducationalInstitutionERPApp.Manager
{
    public class AcademicManager
    {
       AcademicGateway anAcademicGateway = new AcademicGateway();


       public string SaveDepartment(Department aDepartment)
        {
            if (anAcademicGateway.IsDepartmentExists(aDepartment))
            {
                return "Department already exists..";
            }
            else
            {

                int rowAffected = anAcademicGateway.SaveDepartment(aDepartment);
                    if (rowAffected > 0)
                    {
                        return "Department saved successfully!";
                    }
                    return "Failed to save Department";
                
            }
        }

       public List<Department> GetAllDepartment()
       {
           return anAcademicGateway.GetAllDepartment();
       }

        
        public IEnumerable<Semester> GetAllSemester()
        {
            return anAcademicGateway.GetAllSemester();
        }

        public string SaveCourse(Course aCourse)
        {
            if (anAcademicGateway.IsCourseExist(aCourse))
            {
                return "Course already exists";
            }
            else
            {
                int isRowAffected = anAcademicGateway.SaveCourse(aCourse);
                if (isRowAffected > 0)
                {
                    return "Course saved successfully";
                }
                else
                {
                    return "Saving failed..";

                }
            }
        }

        public List<Course> GetAllCourse()
        {
            return anAcademicGateway.GetAllCourse();
        }

        //public List<Employee> GetAllTeacher()
        //{
        //    return anAcademicGateway.GetAllTeacher();
        //}

        public List<Employee> GetTeacherByDepartmentId(int id)
        {
            return anAcademicGateway.GetTeacherByDepartmentId(id);
        }

        public List<Course> GetCourseByDepartmentId(int id)
        {
            return anAcademicGateway.GetCourseByDepartmentId(id);
        }

        public CourseAssignmentVm GetTeacherInfoById(int id)
        {
            return anAcademicGateway.GetTeacherInfoById(id);
        }

        public Course GetCourseInfoById(int id)
        {
            return anAcademicGateway.GetCourseInfoById(id);
        }

        public string SaveCourseAssignment(CourseAssignmentVm courseAssignment)
        {
            if (anAcademicGateway.IsCourseAssigned(courseAssignment))
            {
                return "Course alrerady assigned!";
            }
            int rowAffected = anAcademicGateway.SaveCourseAssignment(courseAssignment);
            if (rowAffected > 0)
            {
                return "Course assigned successfully";
            }
            return "Saving failed!";
        }

        public List<CourseAssignmentVm> GetAllCourses(int id)
        {
            return anAcademicGateway.GetAllCourses(id);
        }

        public void DeleteAassignedCourse(int id)
        {
            anAcademicGateway.DeleteAassignedCourse(id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EducationalInstitutionERPApp.Gateway;
using EducationalInstitutionERPApp.Models.StudentModels;

namespace EducationalInstitutionERPApp.Manager
{
    public class StudentManager
    {
        StudentGateway aStudentGateway = new StudentGateway();

        public string RegisterStudent(Student student)
        {
            if (aStudentGateway.IsEmailExists(student))
            {
                return "Enail already exists...";
            }
            else
            {
                string deptcode = aStudentGateway.GetDepartment(student);
                string firstLetter = deptcode.Substring(0, 1);
                int lastRowId = aStudentGateway.GetLastRowId();
                Student aStudent = aStudentGateway.GetRegNo(lastRowId);
                if (aStudent.RegNo == "")
                {
                    long regNo = 100000;
                    student.RegNo = firstLetter + regNo;

                }
                else
                {
                    long regNo = Convert.ToInt64(aStudent.RegNo.Substring(1, 6));
                    regNo = regNo + 1;
                    student.RegNo = firstLetter + regNo;
                }
                int rowAffected = aStudentGateway.RegisterStudent(student);
                if (rowAffected > 0)
                {

                    return "Registration suucessfull!!";
                }
                else
                {
                    return "Registration failed";
                }
            }
        }

        public List<Student> GetStudentByDepartmentId(int id)
        {
            return aStudentGateway.GetStudentByDepartmentId(id);
        }

        public Student GetStudentInfoById(int id)
        {
            return aStudentGateway.GetStudentInfoById(id);
        }

        public string SaveEnrollMent(CourseEnrollmentVm aCourseEnrollmentVm)
        {
            if (aStudentGateway.IsCourseEnrolled(aCourseEnrollmentVm))
            {
                return "Course already enrolled";
            }
            int rowAffected = aStudentGateway.SaveEnrollMent(aCourseEnrollmentVm);
            if (rowAffected > 0)
            {
                return "Course enrolled suucessfully!!";
            }
            else
            {
                return "Enrollment failed";
            }
        }

        public List<Student> GetAllStudentsForIndex()
        {
            return aStudentGateway.GetAllStudentsForIndex();
        }
    }
}
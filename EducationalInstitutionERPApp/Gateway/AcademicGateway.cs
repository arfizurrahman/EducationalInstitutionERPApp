using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EducationalInstitutionERPApp.Models.AcademicModels;
using EducationalInstitutionERPApp.Models.HRAndPayrollModels;

namespace EducationalInstitutionERPApp.Gateway
{
    public class AcademicGateway : Gateway
    {
        CourseAssignmentVm teacher = new CourseAssignmentVm();
        public bool IsDepartmentExists(Department department)
        {
            Query = "SELECT * FROM Department Where Code = @code or Name = @name ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("code", SqlDbType.VarChar);
            Command.Parameters["code"].Value = department.DepartmentCode;
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = department.DepartmentName;
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

        public int SaveDepartment(Department department)
        {
            Query = "INSERT INTO Department VALUES(@code, @name)";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("code", SqlDbType.VarChar);
            Command.Parameters["code"].Value = department.DepartmentCode;
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = department.DepartmentName;
            int isRowEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return isRowEffected;
        }

        public List<Department> GetAllDepartment()
        {
            Query = "SELECT * FROM DEPARTMENT";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Department> departments = new List<Department>();

            while (Reader.Read())
            {

                Department department = new Department()
                {
                    Id = (int)Reader["Id"],
                    DepartmentCode = Reader["Code"].ToString(),
                    DepartmentName = Reader["Name"].ToString()

                };
                departments.Add(department);
            }
            Reader.Close();
            Connection.Close();
            return departments;
        }

        public IEnumerable<Semester> GetAllSemester()
        {
            Query = "SELECT * FROM SEMESTER";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Semester> semesters = new List<Semester>();
            while (Reader.Read())
            {
                Semester semester = new Semester()
                {
                    Id = (int)Reader["Id"],
                    SemesterName = Reader["Name"].ToString()
                };
                semesters.Add(semester);
            }
            Reader.Close();
            Connection.Close();
            return semesters;
        }

        public bool IsCourseExist(Course course)
        {
            Query = "SELECT * FROM Course Where Code = @code or Name = @name ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("code", SqlDbType.VarChar);
            Command.Parameters["code"].Value = course.Code;
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = course.CourseName;
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

        public int SaveCourse(Course course)
        {
            Query = "INSERT INTO Course VALUES(@code, @name,@credit,@description,@dId,@sId)";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("code", SqlDbType.VarChar);
            Command.Parameters["code"].Value = course.Code;
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = course.CourseName;
            Command.Parameters.Add("credit", SqlDbType.Decimal);
            Command.Parameters["credit"].Value = course.Credit;
            Command.Parameters.Add("description", SqlDbType.VarChar);
            Command.Parameters["description"].Value = course.Description;
            Command.Parameters.Add("dId", SqlDbType.Int);
            Command.Parameters["dId"].Value = course.DepartmentId;
            Command.Parameters.Add("sId", SqlDbType.Int);
            Command.Parameters["sId"].Value = course.SemesterId;
            int isRowEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return isRowEffected;
        }

        public List<Course> GetAllCourse()
        {
            Query = "select c.Id,c.Code, c.Name, c.Credit, d.Name as Department,s.Name as Semester FROM Course c " +
                    "JOIN Department d ON d.Id = c.DepartmentId" +
                    " JOIN Semester s ON s.Id = c.SemesterId";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (Reader.Read())
            {
                Course course = new Course();
                course.Id = (int)Reader["Id"];
                course.Code = Reader["Code"].ToString();
                course.CourseName = Reader["Name"].ToString();
                course.Credit = Convert.ToDouble(Reader["Credit"].ToString());
                course.Department = Reader["Department"].ToString();
                course.Semester = Reader["Semester"].ToString();
                courses.Add(course);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

        //public List<Employee> GetAllTeacher()
        //{
        //    Query = "Select e.Id,e.Name from Employee e Join EmployeeType et ON et.Id = e.CategoryId WHERE e.DepartmentId = @ And et.Type = 'Teaching'";
        //    Command = new SqlCommand(Query, Connection);
        //    Connection.Open();
        //    Reader = Command.ExecuteReader();
        //    List<Employee> employees = new List<Employee>();
        //    while (Reader.Read())
        //    {
        //        Employee employee = new Employee();
        //        employee.Id = (int)Reader["Id"];
        //        employee.Name = Reader["Name"].ToString();
                
        //        employees.Add(employee);
        //    }
        //    Reader.Close();
        //    Connection.Close();
        //    return employees;
        //}

        public List<Employee> GetTeacherByDepartmentId(int id)
        {
            Query = "Select e.Id,e.Name from Employee e Join EmployeeType et ON et.Id = e.CategoryId WHERE e.DepartmentId = @deptId And et.Type = 'Teaching'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("deptId", SqlDbType.Int);
            Command.Parameters["deptId"].Value = id;
            Reader = Command.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (Reader.Read())
            {
                Employee employee = new Employee();
                employee.Id = (int)Reader["Id"];
                employee.Name = Reader["Name"].ToString();

                employees.Add(employee);
            }
            Reader.Close();
            Connection.Close();
            return employees;
        }

        public List<Course> GetCourseByDepartmentId(int id)
        {
            Query = "select Id,Code,Name,Credit FROM Course WHERE DepartmentId = @deptId";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("deptId", SqlDbType.Int);
            Command.Parameters["deptId"].Value = id;
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (Reader.Read())
            {
                Course course = new Course();
                course.Id = (int)Reader["Id"];
                course.Code = Reader["Code"].ToString();
                course.CourseName = Reader["Name"].ToString();
                course.Credit = Convert.ToDouble(Reader["Credit"].ToString());
                
                courses.Add(course);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }
        public CourseAssignmentVm GetTeacherInfoById(int id)
        {
            Query = "SELECT SUM(c.Credit) CreditTaken FROM AssignCourse ac JOIN Course c ON c.Id = ac.CourseId JOIN Employee e on e.Id = ac.TeacherId WHERE ac.TeacherId = @tId";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("tId", SqlDbType.Int);
            Command.Parameters["tId"].Value = id;
            Reader = Command.ExecuteReader();
            CourseAssignmentVm teacher = null;

            if (Reader.Read())
            {
                string credit = null;
                teacher = new CourseAssignmentVm();
                credit = Reader["CreditTaken"].ToString();
                if (credit == "")
                {
                    teacher.Message = "0";
                }
                else
                {
                    teacher.CreditTaken = Convert.ToDouble(credit);
                }
                


            }
            Reader.Close();
            Connection.Close();
            return teacher;
        }

        public Course GetCourseInfoById(int id)
        {
            Query = "SELECT * FROM Course Where Id = @id";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = id;
            Reader = Command.ExecuteReader();
            Course course = null;

            while (Reader.Read())
            {
                course = new Course()
                {
                    CourseName = Reader["Name"].ToString(),
                    Credit = Convert.ToDouble(Reader["Credit"].ToString())
                };
            }
            Reader.Close();
            Connection.Close();
            return course;
        }

        public int SaveCourseAssignment(CourseAssignmentVm courseAssignment)
        {
            Query = "INSERT INTO AssignCourse VALUES(@teacherId, @courseId,@departmentId)";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("teacherId", SqlDbType.Int);
            Command.Parameters["teacherId"].Value = courseAssignment.TeacherId;
            Command.Parameters.Add("courseId", SqlDbType.Int);
            Command.Parameters["courseId"].Value = courseAssignment.CourseId;
            Command.Parameters.Add("departmentId", SqlDbType.Int);
            Command.Parameters["departmentId"].Value = courseAssignment.DepartmentId;
            int isRowEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return isRowEffected;
        }

        public bool IsCourseAssigned(CourseAssignmentVm courseAssignment)
        {
            Query = "SELECT * FROM AssignCourse Where TeacherId = @teacherId And CourseId = @courseId ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("teacherId", SqlDbType.Int);
            Command.Parameters["teacherId"].Value = courseAssignment.TeacherId;
            Command.Parameters.Add("courseId", SqlDbType.Int);
            Command.Parameters["courseId"].Value = courseAssignment.CourseId;
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

        public List<CourseAssignmentVm> GetAllCourses(int id)
        {
            Query = "select ac.Id,c.Code, c.Name CourseName, s.Name SemesterName ,e.Name Teacher from AssignCourse ac join Course c on c.Id = ac.CourseId join Semester s On s.Id = c.SemesterId JOin Department d on d.Id = c.DepartmentId JOIN Employee e On e.Id = ac.TeacherId WHERE d.Id = @dId";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Command.Parameters.Clear();
            Command.Parameters.Add("dId", SqlDbType.Int);
            Command.Parameters["dId"].Value = id;
            Reader = Command.ExecuteReader();
            List<CourseAssignmentVm> courses = new List<CourseAssignmentVm>();
            while (Reader.Read())
            {
                CourseAssignmentVm course = new CourseAssignmentVm()
                {
                    Id = (int)Reader["Id"], 
                    CourseName = Reader["CourseName"].ToString(),
                    CourseCode = Reader["Code"].ToString(),
                    SemesterName = Reader["SemesterName"].ToString(),
                    TeacherName = Reader["Teacher"].ToString(),
                };
                courses.Add(course);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

        public void DeleteAassignedCourse(int id)
        {
            Query =
                "Delete from AssignCourse Where Id = @id";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = id;





            Connection.Open();

            Command.ExecuteNonQuery();
            Connection.Close();
            
        }
    }
}
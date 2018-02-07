using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EducationalInstitutionERPApp.Models.StudentModels;

namespace EducationalInstitutionERPApp.Gateway
{
    public class StudentGateway : Gateway
    {
        public bool IsEmailExists(Student student)
        {
            Query = "SELECT Email FROM Student WHERE Email = @email";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = student.Email;
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

        public Student GetRegNo(int id)
        {
            Query = "SELECT RegNo FROM Student WHERE  Id = @id";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("Id", SqlDbType.Int);
            Command.Parameters["Id"].Value = id;
            Connection.Open();
            Reader = Command.ExecuteReader();
            Student aStudent = null;
            if (Reader.Read())
            {
                aStudent = new Student();
                aStudent.RegNo = Reader["RegNo"].ToString();
                

            }
            Reader.Close();
            Connection.Close();
            return aStudent;
        }

        public string GetDepartment(Student student)
        {
            Query = "SELECT Code FROM Department WHERE Id = @departmentId";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("departmentId", SqlDbType.Int);
            Command.Parameters["departmentId"].Value = student.DepartmentId;
            Connection.Open();
            Reader = Command.ExecuteReader();
            string dept = "";
            Student aStudent = null;
            while (Reader.Read())
            {
                aStudent = new Student();
                aStudent.Department = Reader["Code"].ToString();
                dept = aStudent.Department;
            }
            Reader.Close();
            Connection.Close();
            return dept;
        }

        public int RegisterStudent(Student student)
        {
            Query =
                 "INSERT INTO Student(Name,Email,ContactNo,DateOfBirth,GenderId,Date,Address,DepartmentId,RegNo) VALUES(@name, @email, @contactNo, @dateOfBirth,@genderId,@date, @address, @departmentId,@regNo)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = student.Name;

            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = student.Email;

            Command.Parameters.Add("contactNo", SqlDbType.VarChar);
            Command.Parameters["contactNo"].Value = student.ContactNo;

            Command.Parameters.Add("dateOfBirth", SqlDbType.Date);
            Command.Parameters["dateOfBirth"].Value = student.DateOfBirth;

            Command.Parameters.Add("genderId", SqlDbType.Int);
            Command.Parameters["genderId"].Value = student.GenderId;

            Command.Parameters.Add("date", SqlDbType.Date);
            Command.Parameters["date"].Value = student.RegistrationDate;

            Command.Parameters.Add("address", SqlDbType.VarChar);
            Command.Parameters["address"].Value = student.Address;

            Command.Parameters.Add("departmentId", SqlDbType.Int);
            Command.Parameters["departmentId"].Value = student.DepartmentId;

            Command.Parameters.Add("regNo", SqlDbType.VarChar);
            Command.Parameters["regNo"].Value = student.RegNo;
            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public int Update(Student student)
        {
            Query = "UPDATE Student SET RegNo = @regNo WHERE Email = @email";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("regNo", SqlDbType.VarChar);
            Command.Parameters["regNo"].Value = student.RegNo;

            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = student.Email;

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public int GetLastRowId()
        {
            Query = "SELECT MAX(Id) Id FROM Student";
            Command = new SqlCommand(Query, Connection);
           
            Connection.Open();
            Reader = Command.ExecuteReader();
            int id = 0;
            Student aStudent = null;
            while (Reader.Read())
            {
                aStudent = new Student();
                aStudent.Id = (int)Reader["Id"];
                id = aStudent.Id;
            }
            Reader.Close();
            Connection.Close();
            return id;
        }

        public List<Student> GetStudentByDepartmentId(int id)
        {
            Query = "SELECT Id,RegNo FROM Student WHERE DepartmentId = @departmentId";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("departmentId", SqlDbType.Int);
            Command.Parameters["departmentId"].Value = id;
            Connection.Open();
            Reader = Command.ExecuteReader();
          
            List<Student> students = new List<Student>();
            while (Reader.Read())
            {
                Student aStudent = new Student();
                aStudent.Id = (int) Reader["Id"];
                aStudent.RegNo = Reader["RegNo"].ToString();

                students.Add(aStudent);

            }
            Reader.Close();
            Connection.Close();
            return students ;
        }

        public Student GetStudentInfoById(int id)
        {
            Query = "SELECT Name,Email FROM Student WHERE Id = @sId";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("sId", SqlDbType.Int);
            Command.Parameters["sId"].Value = id;
            Reader = Command.ExecuteReader();
            Student student = null;

            if (Reader.Read())
            {
                student = new Student();
                student.Name = Reader["Name"].ToString();
                student.Email = Reader["Email"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return student;
        }

        public int SaveEnrollMent(CourseEnrollmentVm aCourseEnrollmentVm)
        {
            Query =
                 "INSERT INTO CourseEnrollment(StudentId,CourseId,DepartmentId,Date) VALUES(@sId, @cId, @dId, @date)";

            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.Add("dId", SqlDbType.Int);
            Command.Parameters["dId"].Value = aCourseEnrollmentVm.DepartmentId;

            Command.Parameters.Add("sId", SqlDbType.Int);
            Command.Parameters["sId"].Value = aCourseEnrollmentVm.StudentId;

            Command.Parameters.Add("cId", SqlDbType.Int);
            Command.Parameters["cId"].Value = aCourseEnrollmentVm.CourseId;

            Command.Parameters.Add("date", SqlDbType.Date);
            Command.Parameters["date"].Value = aCourseEnrollmentVm.Date;

            
            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsCourseEnrolled(CourseEnrollmentVm aCourseEnrollmentVm)
        {
            Query = "SELECT * FROM CourseEnrollment WHERE CourseId = @cId And StudentId = @sId";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("cId", SqlDbType.Int);
            Command.Parameters["cId"].Value = aCourseEnrollmentVm.CourseId;

            Command.Parameters.Add("sId", SqlDbType.Int);
            Command.Parameters["sId"].Value = aCourseEnrollmentVm.StudentId;
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

        public List<Student> GetAllStudentsForIndex()
        {
            Query = "SELECT Id FROM Student";
            Command = new SqlCommand(Query, Connection);
           
            Connection.Open();
            Reader = Command.ExecuteReader();
            string dept = "";
            List<Student> students = new List<Student>();
            while (Reader.Read())
            {
                Student aStudent = new Student();
                aStudent.Id = (int) Reader["Id"];

                students.Add(aStudent);
            }
            Reader.Close();
            Connection.Close();
            return students;
        }
    }
}
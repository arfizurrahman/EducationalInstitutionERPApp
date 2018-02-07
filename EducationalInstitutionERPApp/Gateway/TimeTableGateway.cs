using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EducationalInstitutionERPApp.Models.AcademicModels;
using EducationalInstitutionERPApp.Models.TimeTableModels;

namespace EducationalInstitutionERPApp.Gateway
{
    public class TimeTableGateway : Gateway
    {
        public IEnumerable<RoomCategory> GetAllCategory()
        {
            Query = "SELECT * FROM RoomCategory";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<RoomCategory> categories = new List<RoomCategory>();
            while (Reader.Read())
            {
                RoomCategory category = new RoomCategory()
                {
                    Id = (int)Reader["Id"],
                    CategoryName = Reader["Category"].ToString()
                };
                categories.Add(category);
            }
            Reader.Close();
            Connection.Close();
            return categories;
        }
        public IEnumerable<Building> GetAllBuilding()
        {
            Query = "SELECT * FROM Building";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Building> buildings = new List<Building>();
            while (Reader.Read())
            {
                Building building = new Building()
                {
                    Id = (int)Reader["Id"],
                    BuildingName = Reader["BuildingName"].ToString()
                };
                buildings.Add(building);
            }
            Reader.Close();
            Connection.Close();
            return buildings;
        }

        public bool IsRoomNoExists(ClassRoom aClassRoom)
        {
            Query = "SELECT * FROM Room Where RoomNo = @roomNo";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("roomNo", SqlDbType.VarChar);
            Command.Parameters["roomNo"].Value = aClassRoom.RoomNo;
            
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

        public int AddClassRoom(ClassRoom aClassRoom)
        {
            Query = "INSERT INTO Room VALUES(@roomNo, @catId, @builId)";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("roomNo", SqlDbType.VarChar);
            Command.Parameters["roomNo"].Value = aClassRoom.RoomNo;
            Command.Parameters.Add("catId", SqlDbType.VarChar);
            Command.Parameters["catId"].Value = aClassRoom.CategoryId;
            Command.Parameters.Add("builId", SqlDbType.VarChar);
            Command.Parameters["builId"].Value = aClassRoom.BuildingId;
            int isRowEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return isRowEffected;
        }

        public List<ClassRoom> GetAllRooms(int id)
        {
            Query = "SELECT r.RoomNo, rc.Category,b.BuildingName FROM Room r " +
                    "JOIN RoomCategory rc ON rc.Id = r.CategoryId JOIN Building b ON b.Id = r.BuildingId WHERE b.Id = @buildingId";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("buildingId", SqlDbType.Int);
            Command.Parameters["buildingId"].Value = id;
            Reader = Command.ExecuteReader();
            List<ClassRoom> rooms = new List<ClassRoom>();
            while (Reader.Read())
            {
                ClassRoom room = new ClassRoom()
                {
                    
                    RoomNo = Reader["RoomNo"].ToString(),
                    Category = Reader["Category"].ToString(),
                    Building = Reader["BuildingName"].ToString()
                    
                };
                rooms.Add(room);
            }
            Reader.Close();
            Connection.Close();
            return rooms;
        }

        public List<Course> GetAllCourses(TimeTableVM timeTable)
        {
            Query = "SELECT * FROM Course Where DepartmentId = @id";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = timeTable.DepartmentId;
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (Reader.Read())
            {
                Course course = new Course()
                {
                    Id = (int)Reader["Id"],
                    CourseName = Reader["Name"].ToString()
                };

                courses.Add(course);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

        public List<ClassRoom> GetAllRoom(TimeTableVM timeTable)
        {
            Query = "SELECT * FROM Room Where BuildingId = @id";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = timeTable.BuildingId;
            Reader = Command.ExecuteReader();
            List<ClassRoom> classRooms = new List<ClassRoom>();
            while (Reader.Read())
            {
                ClassRoom room = new ClassRoom()
                {
                    Id = (int)Reader["Id"],
                    RoomNo = Reader["RoomNo"].ToString()
                };

                classRooms.Add(room);
            }
            Reader.Close();
            Connection.Close();
            return classRooms;
        }

        public List<TimeTableVM> IsScheduleExists(TimeTableVM aTimeTable)
        {
            Query = "SELECT * FROM TimeTable WHERE RoomId = @roomId AND Day = @day AND Allocate =@allocate ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("roomId", SqlDbType.Int);
            Command.Parameters["roomId"].Value = aTimeTable.RoomId;

            Command.Parameters.Add("day", SqlDbType.VarChar);
            Command.Parameters["day"].Value = aTimeTable.Day;

            Command.Parameters.Add("allocate", SqlDbType.Bit);
            Command.Parameters["allocate"].Value = 1;
            Reader = Command.ExecuteReader();
            List<TimeTableVM> timeTableVms = new List<TimeTableVM>();

            if (Reader.Read())
            {
                TimeTableVM timeTable = new TimeTableVM()
                {
                    FromTime = Reader["FromTime"].ToString(),
                    ToTime = Reader["ToTime"].ToString(),
                    Allocate = Reader["Allocate"].ToString()


                };
                timeTableVms.Add(timeTable);
            }
            Reader.Close();
            Connection.Close();
            return timeTableVms;
        }

        public int Create(TimeTableVM aTimeTable)
        {
            Query = "INSERT INTO TimeTable VALUES (@deptId, @courseId,@buildingId, @roomId, @from, @to, @allocate, @day)";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            string fromH = aTimeTable.FromTime;
            string fromHSub = fromH.Substring(0, 2);
            string fromM = aTimeTable.FromTime;
            string fromMSub = fromM.Substring(3, 2);
            int fromMin = Convert.ToInt32(fromHSub) * 60 + Convert.ToInt32(fromMSub);
            string toH = aTimeTable.ToTime;
            string toHSub = toH.Substring(0, 2);
            string toM = aTimeTable.ToTime;
            string toMSub = toM.Substring(3, 2);
            int toMin = Convert.ToInt32(toHSub) * 60 + Convert.ToInt32(toMSub);
            Command.Parameters.Add("deptId", SqlDbType.Int);
            Command.Parameters["deptId"].Value = aTimeTable.DepartmentId;
            Command.Parameters.Add("courseId", SqlDbType.Int);
            Command.Parameters["courseId"].Value = aTimeTable.CourseId;

            Command.Parameters.Add("buildingId", SqlDbType.Int);
            Command.Parameters["buildingId"].Value = aTimeTable.BuildingId;
            Command.Parameters.Add("roomId", SqlDbType.Int);
            Command.Parameters["roomId"].Value = aTimeTable.RoomId;

            Command.Parameters.Add("from", SqlDbType.Int);
            Command.Parameters["from"].Value = fromMin;

            Command.Parameters.Add("to", SqlDbType.Int);
            Command.Parameters["to"].Value = toMin;

            Command.Parameters.Add("allocate", SqlDbType.Bit);
            Command.Parameters["allocate"].Value = 1;

            Command.Parameters.Add("day", SqlDbType.VarChar);
            Command.Parameters["day"].Value = aTimeTable.Day;

            int isRowEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return isRowEffected;
        }

        public List<TimeTableVM> GetSchedule(TimeTableVM aTimeTableVm)
        {
            Query = "SELECT c.Name CourseName, c.Code CourseCode,r.RoomNo , b.BuildingName, tt.FromTime, tt.ToTime" +
                    " FROM TimeTable tt join Room r on r.Id = tt.RoomId " +
                    "JOIN Building b on b.Id = tt.BuildingId " +
                    "join course c on c.Id = tt.CourseId " +
                    "where tt.DepartmentId = @deptId and c.SemesterId = @semId and Day = @day ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("deptId", SqlDbType.Int);
            Command.Parameters["deptId"].Value = aTimeTableVm.DepartmentId;
            Command.Parameters.Add("semId", SqlDbType.Int);
            Command.Parameters["semId"].Value = aTimeTableVm.SemesterId;
            Command.Parameters.Add("day", SqlDbType.VarChar);
            Command.Parameters["day"].Value = aTimeTableVm.Day;
            Reader = Command.ExecuteReader();
            List<TimeTableVM> timeTables = new List<TimeTableVM>();
            while (Reader.Read())
            {
                string sFrom = null;
                string sTo = null;
                int fHr;
                int tHr;
                int from = Convert.ToInt32(Reader["FromTime"]);
                if (from > 719)
                {
                    sFrom = "PM";
                }
                else
                {
                    sFrom = "AM";
                }
                int to = Convert.ToInt32(Reader["ToTime"]);
                if (to > 719)
                {
                    sTo = "PM";
                }
                else
                {
                    sTo = "AM";
                }
                string FromMin = Convert.ToString(from % 60);
                if (FromMin.Length == 1)
                {
                    FromMin = FromMin + "0";
                }
                int FromHr = from / 60;
                if (FromHr > 12)
                {
                    fHr = FromHr - 12;
                }
                else
                {
                    fHr = FromHr;
                }
                string ToMin = Convert.ToString(to % 60);
                if (ToMin.Length == 1)
                {
                    ToMin = ToMin + "0";
                }

                int ToHr = to / 60;
                if (ToHr > 12)
                {
                    tHr = ToHr - 12;
                }
                else
                {
                    tHr = ToHr;
                }

                string fTime = fHr + ":" + FromMin + " " + sFrom;
                string tTime = tHr + ":" + ToMin + " " + sTo;
                
                TimeTableVM timeTable = new TimeTableVM()
                {
                    //Id = (int)Reader["Id"],
                    RoomNo = Reader["RoomNo"].ToString(),
                    CourseName = Reader["CourseName"].ToString(),
                    CourseCode = Reader["CourseCode"].ToString(),

                    BuildingName = Reader["BuildingName"].ToString(),
                    
                    Time = fTime +"-"+ tTime
                };

                timeTables.Add(timeTable);
            }
            Reader.Close();
            Connection.Close();
            return timeTables;
        }

        public List<TimeTableVM> GetDays()
        {
            Query = "SELECT Day FROM Day ";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
           
            Reader = Command.ExecuteReader();
            List<TimeTableVM> timeTableVms = new List<TimeTableVM>();

            while (Reader.Read())
            {
                TimeTableVM timeTable = new TimeTableVM()
                {
                    Day = Reader["Day"].ToString()


                };
                timeTableVms.Add(timeTable);
            }
            Reader.Close();
            Connection.Close();
            return timeTableVms;
        }

        public List<Schedule> GetAllSchedule(int deptId, Semester semester, string day)
        {
            Query = "SELECT c.Name CourseName, c.Code CourseCode,r.RoomNo , b.BuildingName, tt.FromTime, tt.ToTime" +
                   " FROM TimeTable tt join Room r on r.Id = tt.RoomId " +
                   "JOIN Building b on b.Id = tt.BuildingId " +
                   "join course c on c.Id = tt.CourseId " +
                   "where tt.DepartmentId = @deptId and c.SemesterId = @semId and Day = @day ";
            
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.Add("deptId", SqlDbType.Int);
            Command.Parameters["deptId"].Value = deptId;
            Command.Parameters.Add("semId", SqlDbType.Int);
            Command.Parameters["semId"].Value = semester.Id;
            Command.Parameters.Add("day", SqlDbType.VarChar);
            Command.Parameters["day"].Value = day;
            Reader = Command.ExecuteReader();
            List<Schedule> schedules = new List<Schedule>();
            while (Reader.Read())
            {
                string sFrom = null;
                string sTo = null;
                int fHr;
                int tHr;
                int from = Convert.ToInt32(Reader["FromTime"]);
                if (from > 719)
                {
                    sFrom = "PM";
                }
                else
                {
                    sFrom = "AM";
                }
                int to = Convert.ToInt32(Reader["ToTime"]);
                if (to > 719)
                {
                    sTo = "PM";
                }
                else
                {
                    sTo = "AM";
                }
                string FromMin = Convert.ToString(from % 60);
                if (FromMin.Length == 1)
                {
                    FromMin = FromMin + "0";
                }
                int FromHr = from / 60;
                if (FromHr > 12)
                {
                    fHr = FromHr - 12;
                }
                else
                {
                    fHr = FromHr;
                }
                string ToMin = Convert.ToString(to % 60);
                if (ToMin.Length == 1)
                {
                    ToMin = ToMin + "0";
                }

                int ToHr = to / 60;
                if (ToHr > 12)
                {
                    tHr = ToHr - 12;
                }
                else
                {
                    tHr = ToHr;
                }

                string fTime = fHr + ":" + FromMin + " " + sFrom;
                string tTime = tHr + ":" + ToMin + " " + sTo;

                Schedule timeTable = new Schedule()
                {
                    //Id = (int)Reader["Id"],
                    RoomNo = Reader["RoomNo"].ToString(),
                    CourseName = Reader["CourseName"].ToString(),
                    CourseCode = Reader["CourseCode"].ToString(),

                    BuildingName = Reader["BuildingName"].ToString(),

                    Time = fTime + "-" + tTime
                };

                schedules.Add(timeTable);
            }
            Reader.Close();
            Connection.Close();
            return schedules;
        }


        //public List<ClassRoom> GetAllClassRoom()
        //{
            
        //}
    }
}
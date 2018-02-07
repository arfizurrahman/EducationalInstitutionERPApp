using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EducationalInstitutionERPApp.Gateway;
using EducationalInstitutionERPApp.Models.AcademicModels;
using EducationalInstitutionERPApp.Models.TimeTableModels;

namespace EducationalInstitutionERPApp.Manager
{
    public class TimeTableManager
    {
        TimeTableGateway aTimeTableGateway = new TimeTableGateway();

        public IEnumerable<RoomCategory> GetAllCategory()
        {
            return aTimeTableGateway.GetAllCategory();
        }
        public IEnumerable<Building> GetAllBuilding()
        {
            return aTimeTableGateway.GetAllBuilding();
        }

        public string AddClassRoom(ClassRoom aClassRoom)
        {
            if (aTimeTableGateway.IsRoomNoExists(aClassRoom))
            {
                return "Room already exists..";
            }
            else
            {
                int rowAffected = aTimeTableGateway.AddClassRoom(aClassRoom);
                if (rowAffected > 0)
                {
                    return "Classroom added successfully!";
                }
                else
                {
                    return "Saving failed";
                }
            }
        }

        public List<ClassRoom> GetAllRooms(int id)
        {
            return aTimeTableGateway.GetAllRooms(id);
        }

        public List<Course> GetAllCourses(TimeTableVM timeTable)
        {
            return aTimeTableGateway.GetAllCourses(timeTable);
        }

        public List<ClassRoom> GetAllRoom(TimeTableVM timeTable)
        {
            return aTimeTableGateway.GetAllRoom(timeTable);
        }

        public string Create(TimeTableVM aTimeTable)
        {
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

            List<TimeTableVM> classrooms = aTimeTableGateway.IsScheduleExists(aTimeTable);
            if (classrooms.Count > 0)
            {
                foreach (TimeTableVM allocate in classrooms)
                {

                    int from = Convert.ToInt32(allocate.FromTime);
                    int to = Convert.ToInt32(allocate.ToTime);
                    string allocation = allocate.Allocate;
                    if (fromMin >= from && fromMin < to)
                    {
                        return "Schedule allready allocated";
                    }
                    else if (toMin > from && toMin <= to)
                    {
                        return "Schedule allready allocated";
                    }
                    else if (fromMin <= from && toMin >= to)
                    {

                        return "Schedule allready allocated";
                    }
                    else
                    {
                        //Save(allocateClassroom);
                        int isRowAffected = aTimeTableGateway.Create(aTimeTable);
                        if (isRowAffected > 0)
                        {
                            return "TimeTable created successfully!";
                        }
                        else
                        {
                            return "Failed to create timetable..";

                        }
                    }

                }
                return "TimeTable created successfully!";

            }
            else
            {
                int isRowAffected = aTimeTableGateway.Create(aTimeTable);
                if (isRowAffected > 0)
                {
                    return "TimeTable created successfully!";
                }
                else
                {
                    return "Failed to create timetable..";

                }
            }
        }

        public List<TimeTableVM> GetSchedule(TimeTableVM aTimeTableVm)
        {
            return aTimeTableGateway.GetSchedule(aTimeTableVm);
        }

        public List<TimeTableVM> GetDays()
        {
            return aTimeTableGateway.GetDays();
        }

        public List<Schedule> GetAllSchedule(int deptId, Semester semester,string day)
        {
            return aTimeTableGateway.GetAllSchedule(deptId, semester, day);
        }

        //public List<ClassRoom> GetAllClassRoom()
        //{
        //    return aTimeTableGateway.GetAllClassRoom();
        //}
    }
}
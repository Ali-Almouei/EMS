using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EMS_DataAccses_Layer;

namespace EMS_Business_Layer
{
    public class clsInterviewAppointmnets
    {
        public int AppointmentID {  get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsLocked {  get; set; } 
        public string Notes {  get; set; }
        public int PersonID {  get; set; }
        public int DepartmentID { get; set; }   
        public int JobLeveleID { get; set; }
        public int CreatedByUserID { get; set; }
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;

        public clsPeople PersonInfo;
        public clsUsers UserInfo;
        public clsDepartments DepartmentInfo;
        public clsJobLevels JobLevelInfo;
        public clsInterviewAppointmnets() 
        {
            this.AppointmentID = -1;
            this.CreatedDate = DateTime.Now;
            this.AppointmentDate = DateTime.Now;
            this.Notes = "";
            this.PersonID = -1;
            this.DepartmentID = -1;
            this.JobLeveleID = -1;
            this.IsLocked = false;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }

        private clsInterviewAppointmnets(int appointmentID, DateTime createdDate, DateTime appointmentDate, bool islocked,string notes, int personID, int departmentID, int jobLeveleID, int createdByUserID)
        {
           AppointmentID = appointmentID;
            CreatedDate = createdDate;
            AppointmentDate = appointmentDate;
            Notes = notes;
            PersonID = personID;
            IsLocked = islocked;
            DepartmentID = departmentID;
            JobLeveleID = jobLeveleID;
            CreatedByUserID = createdByUserID;
            PersonInfo=clsPeople.GetPersonByID(personID);
            UserInfo=clsUsers.FindUserByID(createdByUserID);
            DepartmentInfo=clsDepartments.FindDepartment(departmentID);
            JobLevelInfo=clsJobLevels.FindlevelByID(jobLeveleID);
            Mode = enMode.Update;
        }
        private bool _AddNew()
        {
            this.AppointmentID = clsInterviewAppointmentsData.AddNewAppointment(this.AppointmentDate, this.IsLocked, this.Notes, this.PersonID, this.DepartmentID, this.JobLeveleID, this.CreatedByUserID);
            return this.AppointmentID != -1;
        }
        private bool _Update()
        {
            return clsInterviewAppointmentsData.UpdateAppointment(this.AppointmentID,this.CreatedDate,this.AppointmentDate,this.IsLocked,this.Notes,this.PersonID,this.DepartmentID,this.JobLeveleID,this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _Update();

            }

            return false;
        }

        public static DataTable GetAllApopintments(DateTime Date)
        {
            return clsInterviewAppointmentsData.GetAllApointments(Date);
        }
        public static bool DeleteAppointment(int AppointmentID)
        {
            return clsInterviewAppointmentsData.DeleteAppointment(AppointmentID);
        }
        public static clsInterviewAppointmnets FindAppointment(int AppointmentID)
        {
           
            DateTime CreatedDate =DateTime.Now,AppointmentDate= DateTime.Now;
            bool IsLocked = false;
            string Notes = "";
            int PersonID=-1,DepartmentID=-1,JobLeveleID=-1,CreatedByUserID=-1;
            if(clsInterviewAppointmentsData.FindAppointmentByID(AppointmentID,ref AppointmentDate,ref  CreatedDate,ref Notes,
              ref IsLocked,ref PersonID,ref DepartmentID,ref JobLeveleID,ref CreatedByUserID))
                return new clsInterviewAppointmnets(AppointmentID,CreatedDate,AppointmentDate,IsLocked, Notes,  PersonID, DepartmentID,JobLeveleID,CreatedByUserID);
            else 
                return null;


        }

        public static bool IsPersonHasActiveAppointment(int PersonID)
        {
            return clsInterviewAppointmentsData.IsPersonHasActiveAppointment((int)PersonID);
        }


        public static DataTable GetAllApointmentsPerPersonID(int PersonID)
        {
            return clsInterviewAppointmentsData.GetAllApointmentsPerPersonID(PersonID);
        }
    }
}

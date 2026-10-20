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
    public class clsInterviews
    {


        public int IntreviewID { get; set; }
        public bool Result {  get; set; }   
        public string Notes {  get; set; }
        public int AppointmentID {  get; set; }
        public int CreatedBytUserID {  get; set; }
        public clsInterviewAppointmnets AppointmentInfo;
        public clsUsers UserInfo;

        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;

        public clsInterviews()
        {
            this.IntreviewID = -1;
            this.Result = false;
            this.Notes = "";
            this.AppointmentID = -1;
            this.CreatedBytUserID = -1;
            Mode = enMode.AddNew;
        }
        private clsInterviews(int intreviewID, bool result, string notes, int appointmentID, int createdBytUserID)
        {
            IntreviewID = intreviewID;
            Result = result;
            Notes = notes;
            AppointmentID = appointmentID;
            CreatedBytUserID = createdBytUserID;
            AppointmentInfo = clsInterviewAppointmnets.FindAppointment(appointmentID);
            UserInfo =clsUsers.FindUserByID(createdBytUserID) ;
            Mode = enMode.Update;
        }
        private bool _Update()
        {
            return clsInterviewData.Updateinterview(this.AppointmentID, this.Result, this.Notes, this.CreatedBytUserID);
        }
        private bool _AddNew()
        {
            this.AppointmentID=clsInterviewData.AddNewinterview(this.Result,this.Notes,this.AppointmentID,this.CreatedBytUserID);   
            return this.AppointmentID != -1;
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
        public static DataTable GetAllInterviews()
        {
            return clsInterviewData.GetAllIntervies();
        }

        public static bool Deleteinterview(int InterviewID)
        {
            return clsInterviewData.DeleteInterview(InterviewID);
        }

        public static bool IsPersonPassInterview(int PersonID)
        {
            return clsInterviewData.IsPersonPassInterview(PersonID);
        }
        public static clsInterviews FindInterview(int InterviewID)
        {
            bool Resul = false;
            string Notes = "";
            int AppointmnetID = -1, CreatedByUserID = -1;
            if(clsInterviewData.FindInterview(InterviewID,ref Resul,ref Notes,ref AppointmnetID,ref CreatedByUserID))
            {
                return new clsInterviews(InterviewID,Resul,Notes,AppointmnetID,CreatedByUserID);
            }
            else
            {
                return null;
            }


        }










    }
}

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
    public class clsAttendance
    {
        public int AttendanceID {  get; set; }
        public DateTime AttendanceDate { get; set; }
        public TimeSpan CheackIn {  get; set; }
        public TimeSpan? CheakOut { get; set; }
        public byte Status { get; set; }
        public int EmployeeID {  get; set; }
        public int CreatedByUserID {  get; set; }

        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;
         public clsEmployees EmployeeInfo { get; set; }
        public clsUsers CreatedByUserInfo { get; set; }
        private bool _Update()
        {
            return clsAttendanceData.UpdateAttendance(this.AttendanceID,this.AttendanceDate,this.CheackIn,this.CheakOut,this.Status,this.EmployeeID
                ,this.CreatedByUserID);
        }
        private bool _AddNew()
        {
            this.AttendanceID = clsAttendanceData.AddNewAttendance(this.CheackIn,this.CheakOut,this.Status,this.EmployeeID,this.CreatedByUserID);
            return this.AttendanceID != -1;
        }

        private clsAttendance(int AttendanceID, DateTime AttendanceDate,TimeSpan CheackIn,TimeSpan? CheackOut,
            int EmployeeID,int CreatedByUserID)
        {
            this.AttendanceID = AttendanceID;
            this.AttendanceDate = AttendanceDate;
            this.CheackIn = CheackIn;
            this.CheakOut = CheackOut;
            this.EmployeeID = EmployeeID;
            this.CreatedByUserID = CreatedByUserID;
            EmployeeInfo=clsEmployees.FindEmployee(EmployeeID);
            CreatedByUserInfo = clsUsers.FindUserByID(CreatedByUserID);
            Mode=enMode.Update;
        }


        public clsAttendance()
        {
            this.AttendanceID = -1;
            this.AttendanceDate = DateTime.Now;
            this.CheackIn = TimeSpan.Zero;
            this.CheakOut = null;
            this.EmployeeID = -1 ;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
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

        public static bool IsEmployeerHasAttendanceForToday(int EmployeeID,DateTime AttendanceDate)
        {
            return clsAttendanceData.IsEmployeerHasAttendanceForToday (EmployeeID, AttendanceDate);
        }

        public static clsAttendance FindAttendance(int AttendanceID, DateTime AttendanceDate)
        {
            int EmployeeID = -1, CreatedByUserID = -1;
            TimeSpan CheackIn = TimeSpan.Zero; TimeSpan? ChaeckOut = null;
            if (clsAttendanceData.FindAttendance(AttendanceID, AttendanceDate, ref CheackIn, ref ChaeckOut, ref EmployeeID, ref CreatedByUserID))
            {
                return new clsAttendance(AttendanceID, AttendanceDate, CheackIn, ChaeckOut, EmployeeID, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }




        public static async Task<DataTable> GetAllAttendance(DateTime AttendanceDate)
        {
            return await clsAttendanceData.GetAllAttendance(AttendanceDate);
        }

        public static bool DeleteAttendance(int AttendanceID)
        {
            return clsAttendanceData.DeleteAttendance(AttendanceID);
        }


    }
}

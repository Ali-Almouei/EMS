using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS_DataAccses_Layer;

namespace EMS_Business_Layer
{
    public class clsAdjustments
    {

        public int AdjustmentID {get;set;}
        public DateTime AdjustmentDate { get;set;}
        public byte Type {  get;set;}
        public decimal Amount {  get;set;}
        public string Notes {  get;set;}
        public int EmployeeID {  get;set;}
        public int CreatedByUserID { get;set;}
        public int? ReferncerAttendanceID {  get; set; }

        public clsEmployees EmployeeInfo;

        public clsUsers UserInfo;

        private bool _AddNew()
        {
            this.AdjustmentID=clsAdjustmentsData.AddNewAdjustmnet(this.Type,this.Amount,this.Notes,this.EmployeeID,this.CreatedByUserID);
            return this.AdjustmentID != -1;
        }
        private bool _Update()
        {
            return clsAdjustmentsData.UpdateAdjustment(this.AdjustmentID, this.AdjustmentDate, this.Type, this.Amount, this.Notes, this.EmployeeID, this.CreatedByUserID);
        }
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;

        public clsAdjustments()
        {
            this.AdjustmentID = -1;
            this. AdjustmentDate = DateTime.Now;
            this.Type = 255;
            this.Amount = 0;
            this. CreatedByUserID = -1;
            this.EmployeeID = -1;
            this.ReferncerAttendanceID = null;
            Mode = enMode.AddNew;
        }

        private clsAdjustments(int adjustmentID, DateTime adjustmentDate, byte type, decimal amount, string notes, int employeeID, int createdByUserID, int? referncerAttendanceID)
        {
            AdjustmentID = adjustmentID;
            AdjustmentDate = adjustmentDate;
            Type = type;
            Amount = amount;
            Notes = notes;
            EmployeeID = employeeID;
            CreatedByUserID = createdByUserID;
            ReferncerAttendanceID = referncerAttendanceID;
            EmployeeInfo = clsEmployees.FindEmployee(employeeID);
            UserInfo=clsUsers.FindUserByID(CreatedByUserID);
            Mode = enMode.Update;
        }

        public static async Task<DataTable> GetAllAdjustments(DateTime AdjustmentDate)
        {
            return await clsAdjustmentsData.GetAllAdjustments(AdjustmentDate);
        }
        public static async Task<DataTable> GetAllAdjustmentsForEmployeer(int EmployeeID,DateTime AdjustmentDate)
        {
            return await clsAdjustmentsData.GetAllAdjustmentsForEmployeer(EmployeeID,AdjustmentDate);
        }
        public static clsAdjustments FindAdjustment(int AdjustmentID)
        {
            int EmployeeID = -1, CreatedByUserID = -1;
            string notes = "";decimal amount = 0; byte type = 255;
            int? REff = null; DateTime AdjustmentDate=DateTime.Now;

            if(clsAdjustmentsData.FindAdjustmentByID(AdjustmentID,ref AdjustmentDate,ref type,ref amount,ref notes,ref EmployeeID,ref CreatedByUserID,ref REff))
            {
                return new clsAdjustments(AdjustmentID, AdjustmentDate, type, amount, notes, EmployeeID, CreatedByUserID, REff);
            }
            else
                return null;



        }
        public static bool DeleteAdjustment(int AdjustmentID)
        {
            return clsAdjustmentsData.DeleteAtjustment(AdjustmentID);
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

        public static int GetEmployeeAdjustmentCountForMonth(int EmployeeID, int Month)
        {
            return clsAdjustmentsData.GetEmployeeAdjustmentCountForMonth(EmployeeID, Month);
        }

        public static bool IsEmployeeHasFiveAdjustmentForMonth(int EmployeeID, int Month)
        {
            return clsAdjustmentsData.GetEmployeeAdjustmentCountForMonth(EmployeeID,Month)>=5;
        }


    }
}

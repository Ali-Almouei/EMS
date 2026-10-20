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
    public class clsSalarylog
    {
        public int LogID {  get; set; } 
        public DateTime LogDate { get; set; }
        public decimal BaseSalary {  get; set; }
        public decimal TotalBonus {  get; set; }
        public decimal TotalPentalty {  get; set; }
        public decimal NetSalary {  get; set; } 
        public int EmployeeID { get; set; }
        public int CraetedByUserID {  get; set; }
        public clsEmployees EmployeeInfo;
        public clsUsers UserInfo;
        enum enMode { AddNew=0,Update=1 }   
        enMode Mode = enMode.AddNew;

        public clsSalarylog()
        {
            this.LogID = -1;
            this.LogDate=DateTime.Now;
            this.BaseSalary = 0;
            this.TotalBonus = 0;
            this.TotalPentalty = 0;
            this.NetSalary = 0;
            this.EmployeeID = -1;
            this.CraetedByUserID = -1;
            Mode = enMode.AddNew;




        }

        private clsSalarylog(int LogID,DateTime LogDate,decimal BaseSalary,decimal TotalBonus,decimal TotalPentalty,int EmployeeID,int CreatedByUserID)
        {
            this.LogID=LogID;
            this.LogDate=LogDate;
            this.BaseSalary=BaseSalary;
            this.TotalBonus=TotalBonus;
            this.TotalPentalty=TotalPentalty;
            this.NetSalary=NetSalary;
            this.EmployeeID=EmployeeID;
            this.CraetedByUserID=CreatedByUserID;
            EmployeeInfo=clsEmployees.FindEmployee(EmployeeID);
            UserInfo=clsUsers.FindUserByID(CreatedByUserID);
            Mode=enMode.Update;

        }


        private bool _AddNew()
        {
            this.LogID=clsSalaryLogData.AddNewSalaryLog(this.EmployeeID,this.CraetedByUserID);
            return this.LogID != -1;
        }


        public static clsSalarylog GetSalaryLog(int LogID)
        {
            int EmployeeID = -1, CreatedByUserID = -1;
            decimal Basesalary=0, TotalBonus=0, TotalPentalty=0,NetSalary=0;
            DateTime LogDate = DateTime.Now;
            if(clsSalaryLogData.FindSalaryLog(LogID ,ref LogDate,ref Basesalary,ref TotalBonus,ref TotalPentalty,ref NetSalary,ref EmployeeID,ref CreatedByUserID))
                return new clsSalarylog(LogID,LogDate,Basesalary,TotalBonus,TotalPentalty,EmployeeID,CreatedByUserID);  
                else
                return null;

        }
        public static  async Task<DataTable> GetAllSalaryLog(DateTime Date)
        {
            return await clsSalaryLogData.GetAllSalaryLog(Date);
        }
        public static bool DeleteLog(int SalaryLogID)
        {
            return clsSalaryLogData.DeleteSalaryLog(SalaryLogID);
            
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

                    return true;

            }

            return false;
        }


        public static bool IsEmployeeHasSalaryThisMonth(int EmployeeID, DateTime Date)
        {
            return clsSalaryLogData.IsEmployeeHasSalaryThisMonth(EmployeeID, Date);
        }

        public static decimal GetBaseSalaryForEmployeer(int EmployeeID)
        {
            return clsSalaryLogData.GetEmployeeABaseSalary(EmployeeID);
        }
        public static decimal GetTotalPenaltyForEmployeer(int  EmployerID,DateTime Date)
        {
            return clsSalaryLogData.GetEmployeeTotalPenalty(EmployerID,Date);
        }
        public static decimal GetTotalBonusForEmployee(int EmployeeID,DateTime Date)
        {
            return clsSalaryLogData.GetEmployeeTotalBonus(EmployeeID, Date);
        }
        public static decimal GetNetSalaryForEmployeer(int EmployeeID,DateTime Date)
        {
            return GetBaseSalaryForEmployeer(EmployeeID)+ (GetTotalBonusForEmployee(EmployeeID, Date) - GetTotalPenaltyForEmployeer(EmployeeID, Date));
        }










    }
}

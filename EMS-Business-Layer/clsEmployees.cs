using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using EMS_DataAccses_Layer;

namespace EMS_Business_Layer
{
    public class clsEmployees
    {
        public int EmployeeID { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public int DepartmentID { get; set; }
        public int LevelID { get; set; }
        public int StatusID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public clsPeople PersonInfo;
        public clsUsers CreatedUserInfo;
        public clsDepartments DepartmentInfo;
        public clsJobLevels JobLevels;
        public clsStatus EmployerStatus;
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;



        public clsEmployees()
        {
            this.EmployeeID = -1;
            this.HireDate = DateTime.Now;
            this.ExpiredDate = null;
            this.DepartmentID = -1;
            this.LevelID = -1;
            this.StatusID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }
        private clsEmployees(int EmployeeID, DateTime HireDate, DateTime? ExpiredDate, int DepartmentID, int LevelID, int Status,
            int PersonID, int CreatedByUserID)
        {
            this.EmployeeID = EmployeeID;
            this.HireDate = HireDate;
            this.ExpiredDate = ExpiredDate;
            this.DepartmentID = DepartmentID;
            this.LevelID = LevelID;
            this.StatusID = Status;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            PersonInfo=clsPeople.GetPersonByID(PersonID);
            DepartmentInfo = clsDepartments.FindDepartment(DepartmentID);
            JobLevels=clsJobLevels.FindlevelByID(LevelID);
            CreatedUserInfo = clsUsers.FindUserByID(CreatedByUserID);
            EmployerStatus=clsStatus.FindStatusbyID(StatusID);
            Mode = enMode.Update;
        }


        private bool _Update()
        {
            return clsEmployeesData.UpdateEmployee(this.EmployeeID, this.HireDate, this.ExpiredDate, this.DepartmentID, this.LevelID, this.PersonID, this.CreatedByUserID, this.StatusID);
        }
        private bool _AddNew()
        {
          this.EmployeeID= clsEmployeesData.AddNewEmployee(this.HireDate, this.DepartmentID, this.LevelID, this.PersonID, this.CreatedByUserID, this.StatusID) ;
            return this.EmployeeID != -1;
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
        public static async Task<DataTable> GetAllEmplooyees()
        {
            return await clsEmployeesData.GetAllEmployees();
        }
        public static bool DeleteEmployee(int EmployeeID)
        {
            return clsEmployeesData.DeleteEmployee(EmployeeID);
        }
        public static clsEmployees FindEmployee(int EmployeeID)
        {
            int DepartmentID = -1, LevelID = -1, PersonID = -1, StatusID=-1, CreatedByUserID = -1;
            //-1 refer to null
            DateTime HireDate = DateTime.Now; DateTime? ExpiredDate = null;
            if (clsEmployeesData.FindEmployeeByID(EmployeeID, ref HireDate, ref ExpiredDate, ref DepartmentID, ref LevelID, ref StatusID, ref PersonID, ref CreatedByUserID))
            {
                return new clsEmployees(EmployeeID, HireDate, ExpiredDate, DepartmentID, LevelID, StatusID, PersonID, CreatedByUserID);
            }else
            {
                return null;
            }

        }

        public static bool IsEmployeeExistByPersonID(int PersonID)
        {
            return clsEmployeesData.IsEmployeeExistByPersonID((int)PersonID);
        }
        public static bool ExpireEmployeer(int EmployeeID)
        {
            return clsEmployeesData.ExpireEmployeer((int)EmployeeID);
        }

        public static bool HireEmployeer(DateTime HireDate, int DepartmentID, int LevelID, int Status,
            int PersonID, int CreatedByUserID)
        {

            clsEmployees employees = new clsEmployees();
            employees.HireDate = HireDate;
            employees.ExpiredDate = null;
            employees.DepartmentID = DepartmentID;
            employees.LevelID = LevelID;
            employees.StatusID = Status;
            employees.PersonID = PersonID;
            employees.CreatedByUserID = CreatedByUserID;
            return employees.Save();
        }

    }
}

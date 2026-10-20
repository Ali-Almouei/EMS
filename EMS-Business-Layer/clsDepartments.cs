using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS_DataAccses_Layer;

namespace EMS_Business_Layer
{
    public class clsDepartments
    {
        public int DepartmentID {  get; set; }
        public string DepartmentName {  get; set; }
        public decimal Multipiler {  get; set; }
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        private clsDepartments(int DepartmentID,string DepartmentName,decimal Multipiler)
        {
            this.DepartmentID = DepartmentID;   
            this.DepartmentName = DepartmentName;
                this.Multipiler = Multipiler;
            Mode = enMode.Update;
        }
        public clsDepartments()
        {
            this.DepartmentID = -1;
            this.DepartmentName = "";
            this.Multipiler = -1;
            Mode = enMode.AddNew;
        }
        private bool _AddNew() => false;
      
        private bool _Update()
        {
            return clsDepartmentsData.UpdateDepartmentInfo(this.DepartmentID, this.DepartmentName, this.Multipiler);
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
        public static DataTable GetAllDepartmets()
        {
            return clsDepartmentsData.GetAllDepartments();
        }
        public static clsDepartments FindDepartment(int DepartmentID)
        {
            string DepartmentName = "";
            decimal Multipiler = 0;
            if(clsDepartmentsData.FindDepartmentByID(DepartmentID,ref DepartmentName,ref Multipiler))

            return new clsDepartments(DepartmentID,DepartmentName,Multipiler);
            else
                return null;    
        }

    }
}

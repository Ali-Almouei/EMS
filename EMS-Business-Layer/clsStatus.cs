using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using EMS_DataAccses_Layer;

namespace EMS_Business_Layer
{
    public  class clsStatus
    {
        public int StatusID {  get; set; }
        public string StatusName { get; set; }
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;

       public  clsStatus()
        {
            this.StatusID = -1;
            this.StatusName = "";
            Mode=enMode.AddNew ;
        }
        private clsStatus(int statusID, string statusName)
        {
            StatusID = statusID;
            StatusName = statusName;
            Mode = enMode.Update;
        }
        public static DataTable GetAllStatus()
        {
            return clsStatusData.GetAllStatus();
        }

        public static clsStatus FindStatusbyID(int statusID)
        {
            string StatusName = "";
            if(clsStatusData.FindStatusByID(statusID,ref StatusName))
            {
                return new clsStatus(statusID,StatusName);
            }
            else
            {
                return null;
            }


        }
    }
}

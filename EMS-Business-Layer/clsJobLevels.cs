using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EMS_DataAccses_Layer;

namespace EMS_Business_Layer
{
    public class clsJobLevels
    {
        public int JobLevelID {  get; set; }
        public string LevelName { get; set; }
        public decimal BaseSalary {  get; set; }    
        enum enMode { AddNew=0,Update=1}
        enMode Mode=enMode.AddNew;

        public clsJobLevels()
        {
            this.JobLevelID = -1;
            this.LevelName = "";
            this.BaseSalary = 0;
            Mode = enMode.AddNew;
        }


        private clsJobLevels(int jobLevelID,string LevelName,decimal baseSalary)
        {
            this.JobLevelID = jobLevelID;   
            this.LevelName = LevelName;
            this.BaseSalary = baseSalary;
            Mode = enMode.Update;
        }









        public static DataTable GetAllLevels()
        {
            return clsJobLevelsDatacs.GetAllJobLevels();
        }

        public static clsJobLevels FindlevelByID(int levelID)
        {
            string LevelName = "";
            decimal BaseSalary = 0;
         if(clsJobLevelsDatacs.FindLevelByID(levelID,ref LevelName,ref BaseSalary))
                return new clsJobLevels(levelID,LevelName,BaseSalary);
         else
                return null;



        }
    }
}

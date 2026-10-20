using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DataAccses_Layer
{
    public  class clsJobLevelsDatacs
    {
        public static DataTable GetAllJobLevels()
        {
            DataTable dt = new DataTable();
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_GetAllJobLevels", Connection))
                {
                    Command.CommandType=CommandType.StoredProcedure;

                    try
                    {
                       Connection.Open();
                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            if(reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }


                    }
                    catch (Exception ex)
                    {
                        clsSettingConnection.LogError(ex.Message);
                    }

                }

            }

            return dt;
        }


        public static bool FindLevelByID(int JobLevelID, ref string LevelName, ref decimal BaseSalary)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_FindLevelByID", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@JobLevelID", JobLevelID);
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound = true;
                                LevelName = (string)Reader["LevelName"];
                                BaseSalary = (decimal)Reader["BaseSalary"];
                            }
                            else
                            {
                                IsFound = false;
                            }





                        }



                    }
                    catch (Exception ex)
                    {
                        clsSettingConnection.LogError(ex.Message);
                    }





                }











            }







            return IsFound;
        }









    }
}

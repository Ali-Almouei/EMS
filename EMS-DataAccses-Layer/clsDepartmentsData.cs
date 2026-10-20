using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DataAccses_Layer
{
    public class clsDepartmentsData
    {
        public static DataTable GetAllDepartments()
        {
            DataTable dt = new DataTable();
            using(SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using(SqlCommand Command= new SqlCommand("sp_GetAllDepartment",Connection))
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

        public static bool UpdateDepartmentInfo(int DepartmentID,string DepartmentName,decimal Multipiler)
        {
            int RowAffected = 0;
            using(SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_UpdateDepartmentInfo", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                    Command.Parameters.AddWithValue("@DepartmentName", DepartmentName);
                    Command.Parameters.AddWithValue("@Multipiler", Multipiler);
                    try
                    {
                        Connection.Open();
                        RowAffected = Command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        clsSettingConnection.LogError(ex.Message);
                    }




                }




            }












            return RowAffected > 0;
        }

        public static bool FindDepartmentByID(int DepartmentID,ref string DepartmentName,ref decimal Multipiler)
        {
            bool IsFound=false;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_FindDepartmentByID", Connection))
                {
                    Command.CommandType= CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@DepartmentID",DepartmentID);
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound = true;
                                DepartmentName = (string)Reader["DepartmentName"];
                                Multipiler = (decimal)Reader["Multipiler"];
                            }
                            else { 
                            IsFound = false;}







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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DataAccses_Layer
{
    public class clsStatusData
    {
        public static DataTable GetAllStatus()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_GetAllStatus", connection))
                {

                    Command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.HasRows)
                            {
                                dt.Load(Reader);
                            }


                        }





                    }
                    catch (Exception ex)
                    {
                        clsSettingConnection.LogError(ex.Message);
                    }
                }




                return dt;
            }



        }

        public static bool FindStatusByID(int StatusID,ref string StatusName)
        {
            bool IsFound=false;

            using (SqlConnection connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using(SqlCommand Command = new SqlCommand("sp_FindStatusByID",connection))
                {
                    Command.CommandType=CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@StatusID", StatusID);

                    try
                    {

                        connection.Open() ;
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound = true;
                                StatusName = (string)Reader["StatusName"];
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DataAccses_Layer
{
    public class clsAttendanceData
    {
        //sp_UpdateAttendance
        //sp_AddNewAttendance
        //sp_IsEmployeerHasAttendanceForToday
        //sp_FindAttendance
        public static async Task<DataTable> GetAllAttendance(DateTime Attendance)
        {
            DataTable dt = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetAllAttendance", Connection))
                {
                    command.Parameters.AddWithValue("@AttendanceDate", Attendance.Date);
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        await Connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
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

        public static int AddNewAttendance(TimeSpan CheackIn, TimeSpan? CheackOut, byte Status, int EmployeeID, int CreatedByUserID)
        {
            int InsertedID = -1;

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_AddNewAttendance", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@CheakIn", CheackIn);
                    if (CheackOut != null)
                        Command.Parameters.AddWithValue("@CheakOut", CheackOut);
                    else
                        Command.Parameters.AddWithValue("@CheakOut", DBNull.Value);

                    Command.Parameters.AddWithValue("@Status", Status);
                    Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    SqlParameter outputIdParam = new SqlParameter("@InsertedID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    Command.Parameters.Add(outputIdParam);

                    try
                    {
                        Connection.Open();
                        Command.ExecuteNonQuery();
                        InsertedID = (int)outputIdParam.Value;



                    }
                    catch (Exception ex)
                    {
                        clsSettingConnection.LogError(ex.Message);
                    }

                }

            }

            return InsertedID;
        }
        public static bool UpdateAttendance(int AttendanceID, DateTime AttendanceDate, TimeSpan CheackIn, TimeSpan? CheackOut, byte Status, int EmployeeID, int CreatedByUserID)
        {
            int RowAffected = 0;

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_UpdateAttendance", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;

                    Command.Parameters.AddWithValue("@AttendanceID", AttendanceID);
                    Command.Parameters.AddWithValue("@AttendanceDate", AttendanceDate.Date);

                    Command.Parameters.AddWithValue("@CheackIn", CheackIn);

                    if (CheackOut != null)
                        Command.Parameters.AddWithValue("@CheackOut", CheackOut);
                    else
                        Command.Parameters.AddWithValue("@CheackOut", DBNull.Value);
                    Command.Parameters.AddWithValue("@Status", Status);
                    Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    

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

        public static bool FindAttendance(int AttendanceID, DateTime AttendanceDate, ref TimeSpan CheackIn, ref TimeSpan? CheackOut, ref int EmployeeID, ref int CreatedByUserID)
        {
            bool IsFound = false;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                {
                    using (SqlCommand Command = new SqlCommand("sp_FindAttendance", Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;
                        Command.Parameters.AddWithValue("@AttendanceID", AttendanceID);
                        Command.Parameters.AddWithValue("@AttendanceDate", AttendanceDate.Date);
                        try
                        {
                            Connection.Open();

                            using (SqlDataReader Reader = Command.ExecuteReader())
                            {
                                if (Reader.Read())
                                {
                                    IsFound = true;
                                    CheackIn = (TimeSpan)Reader["CheackIn"];
                                    if (Reader["CheackOut"] != DBNull.Value)
                                        CheackOut = (TimeSpan)Reader["CheackOut"];
                                    else
                                        CheackOut = null;
                                    EmployeeID = (int)Reader["EmployeeID"];
                                    CreatedByUserID = (int)Reader["CreatedByUserID"];
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
        public static bool DeleteAttendance(int AttendanceID)
        {
            int RowAffected = 0;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_DeleteAttendance", Connection))
                {
                    Command.CommandType= CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@AttendanceID",AttendanceID);
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




                return RowAffected > 0;
            }
        }
        public static bool IsEmployeerHasAttendanceForToday(int EmployeeID, DateTime AttendanceDate)
        {
            bool IsFound = false;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using(SqlCommand Command = new SqlCommand("sp_IsEmployeerHasAttendanceForToday",Connection))
                {
                    Command.CommandType= CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@EmployeeID",EmployeeID);
                    Command.Parameters.AddWithValue("@AttendanceDate",AttendanceDate.Date);
                    try
                    {
                       Connection.Open();
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            IsFound=Reader.HasRows;
                        }






                    }
                    catch (Exception ex)
                    {
                        clsSettingConnection.LogError(ex.Message);
                    }
                }









                return IsFound;




            }
        }
    }
}
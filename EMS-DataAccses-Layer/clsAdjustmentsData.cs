using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EMS_DataAccses_Layer
{
    public class clsAdjustmentsData
    {

        public static async Task<DataTable> GetAllAdjustments(DateTime AdjustmentDate)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_GetAllAdjustmentsForMonth", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@Date", AdjustmentDate);
                    try
                    {
                        await Connection.OpenAsync();
                        using (SqlDataReader Reader = await Command.ExecuteReaderAsync())
                        {
                            if (Reader.HasRows)
                            {
                                dataTable.Load(Reader);
                            }


                        }


                    }
                    catch (Exception ex)
                    {
                        clsSettingConnection.LogError(ex.Message);
                    }

                }







                return dataTable;
            }
        }
        public static async Task<DataTable> GetAllAdjustmentsForEmployeer(int EmployeeID, DateTime AdjustmentDate)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_GetAllAdjustmentsForEmployeee", Connection))
                {
                    Command.CommandType=CommandType.StoredProcedure;    
                    Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    Command.Parameters.AddWithValue("@Date", AdjustmentDate);
                    try
                    {
                        await Connection.OpenAsync();
                        using (SqlDataReader Reader = await Command.ExecuteReaderAsync())
                        {
                            if (Reader.HasRows)
                            {
                                dataTable.Load(Reader);
                            }


                        }


                    }
                    catch (Exception ex)
                    {
                        clsSettingConnection.LogError(ex.Message);
                    }

                }







                return dataTable;
            }






        }

        public static int AddNewAdjustmnet(byte Type, decimal Amount, string Notes, int EmployeeID, int CreatedByUserID)
        {
            int InsertedID = -1;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_AddNewAdjustment", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@Type", Type);
                    Command.Parameters.AddWithValue("@Amount", Amount);
                    if (Notes != null || Notes != "")
                        Command.Parameters.AddWithValue("@Notes", Notes);
                    else
                        Command.Parameters.AddWithValue("@Notes", DBNull.Value);

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

        public static bool UpdateAdjustment(int AdjustmentID, DateTime AdjustmentDate, byte Type, decimal Amount, string Notes, int EmployeeID, int CreatedByUserID)
        {
            int RowAffected = 0;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_UpdateAdjustment", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@AdjustmentID", AdjustmentID);
                    Command.Parameters.AddWithValue("@AdjustmentDate", AdjustmentDate);
                    Command.Parameters.AddWithValue("@Type", Type);
                    Command.Parameters.AddWithValue("@Amount", Amount);
                    if (Notes != null || Notes != "")
                        Command.Parameters.AddWithValue("@Notes", Notes);
                    else
                        Command.Parameters.AddWithValue("@Notes", DBNull.Value);

                    Command.Parameters.AddWithValue("@EmplyeeID", EmployeeID);
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

        public static bool DeleteAtjustment(int AdjustmentID)
        {
            int RowAffected = 0;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_DeleteAdjustment", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("AdjustmentID", AdjustmentID);
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

        public static bool FindAdjustmentByID(int AdjustmentID, ref DateTime AdjustmentDate, ref byte Type, ref decimal Amount, ref string Notes,
            ref int EmployeeID, ref int CreatedByUserID, ref int? ReferncerAttendanceID)
        {
            bool IsFound = false;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_FindAdjustment", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@AdjustmentID", AdjustmentID);
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound = true;
                                AdjustmentDate = (DateTime)Reader["AdjustmentDate"];
                                Type = (byte)Reader["Type"];
                                Amount = (decimal)Reader["Amount"];
                                if (Reader["Notes"] != DBNull.Value)
                                    Notes = (string)Reader["Notes"];
                                else
                                    Notes = "";

                                EmployeeID = (int)Reader["EmployeeID"];
                                CreatedByUserID = (int)Reader["CreatedByUserID"];
                                if (Reader["ReferncerAttendanceID"] != DBNull.Value)
                                    ReferncerAttendanceID = (int)Reader["ReferncerAttendanceID"];
                                else
                                    ReferncerAttendanceID = null;
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


                return IsFound;
            }

        }




        public static int GetEmployeeAdjustmentCountForMonth(int EmployeeID, int Month)
        {
            int count = 0;

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("select dbo.GetEmployeeAdjustmentCountForMonth(@EmployeeID,@Month)", Connection))
                {

                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue("@Month",Month);
                    Command.Parameters.AddWithValue("@EmployeeID",EmployeeID);

                    try
                    {
                        Connection.Open();
                        object Result = Command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int  h))
                        {
                            count = h;
                        }




                    }
                    catch (Exception ex)
                    {
                        clsSettingConnection.LogError(ex.Message);
                    }






                }


                return count;
            }




        }
    }
}
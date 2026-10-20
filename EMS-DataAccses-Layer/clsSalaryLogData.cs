using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DataAccses_Layer
{
    public class clsSalaryLogData
    {
        public static async Task<DataTable> GetAllSalaryLog(DateTime Date)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAllSalaryLog", Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Date", Date);

                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {

                            if (reader.HasRows)
                            {
                                dataTable.Load(reader);
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

        public static bool FindSalaryLog(int SalaryLog, ref DateTime LogDate, ref decimal BaseSalary, ref decimal TotalBonus, ref decimal TotalPenalty, ref decimal NetSalary, ref int EmployeeID, ref int CreatedByUserID)
        {
            bool IsFound = false;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_FindSalary", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@LogID", SalaryLog);
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {

                            if (Reader.Read())
                            {
                                IsFound = true;

                                LogDate = (DateTime)Reader["Date"];
                                BaseSalary = (decimal)Reader["BaseSalary"];
                                TotalBonus = (decimal)Reader["TotalBonus"];
                                TotalPenalty = (decimal)Reader["TotalPenalty"];
                                NetSalary = (decimal)Reader["NetSalary"];
                                EmployeeID = (int)Reader["EmployeeID"];
                                CreatedByUserID = (int)Reader["CreatedbyUserID"];

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

        public static int AddNewSalaryLog(int EmployeeID, int @CreatedByUserID)
        {
            int InsertedID = -1;

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_AddNewSalaryLog", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;

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

        public static bool DeleteSalaryLog(int SalaryLog)
        {
            int RowAffected = 0;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_DeleteSalary", Connection))
                {

                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@LogID", SalaryLog);
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

        public static bool IsEmployeeHasSalaryThisMonth(int EmployeeID, DateTime SalaryDate)
        {
            bool IsFound = false;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_IsEmployeeGetHisSalary", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    Command.Parameters.AddWithValue("@Date", SalaryDate);
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            IsFound = Reader.HasRows;

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

        public static decimal GetEmployeeABaseSalary(int EmployeeID)
        {
            decimal Salary = 0;

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("select dbo.GetBaseSalaryForEmployeer(@EmployeeID)", Connection))
                {

                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);

                    try
                    {
                        Connection.Open();
                        object Result = Command.ExecuteScalar();

                        if (Result != null && decimal.TryParse(Result.ToString(), out decimal h))
                        {
                            Salary = h;
                        }




                    }
                    catch (Exception ex)
                    {
                        clsSettingConnection.LogError(ex.Message);
                    }


                }


                return Salary;
            }


        }


        public static decimal GetEmployeeTotalBonus (int EmployeeID,DateTime Date)
        {
            decimal Salary = 0;

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("select dbo.GetAllBonus(@EmployeeID,@Date)", Connection))
                {

                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    Command.Parameters.AddWithValue("@Date", Date);

                    try
                    {
                        Connection.Open();
                        object Result = Command.ExecuteScalar();

                        if (Result != null && decimal.TryParse(Result.ToString(), out decimal h))
                        {
                            Salary = h;
                        }




                    }
                    catch (Exception ex)
                    {
                        clsSettingConnection.LogError(ex.Message);
                    }


                }


                return Salary;
            }


        }

        public static decimal GetEmployeeTotalPenalty(int EmployeeID,DateTime Date)
        {
            decimal Salary = 0;

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("select dbo.GetAllPenalty(@EmployeeID,@Date)", Connection))
                {

                    Command.CommandType = CommandType.Text;
                    Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    Command.Parameters.AddWithValue("@Date",Date);
                    try
                    {
                        Connection.Open();
                        object Result = Command.ExecuteScalar();

                        if (Result != null && decimal.TryParse(Result.ToString(), out decimal h))
                        {
                            Salary = h;
                        }




                    }
                    catch (Exception ex)
                    {
                        clsSettingConnection.LogError(ex.Message);
                    }




                }


                return Salary;
            }


        }
















    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Runtime.InteropServices;
namespace EMS_DataAccses_Layer
{
    public class clsEmployeesData
    {
        public static async Task<DataTable> GetAllEmployees()
        {
            DataTable dt = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_GetAllEmployees", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;


                    try
                    {
                        await Connection.OpenAsync();
                        using (SqlDataReader Reader = await Command.ExecuteReaderAsync())
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
            }





            return dt;
        }
        public static bool UpdateEmployee(int EmployeeID, DateTime HireDate, DateTime? ExpiredDate, int DepartmentID, int LevelID, int PersonID, int CreatedByUserID, int StatusID)
        {
            int RowAffected = 0;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_UpdateEmployee", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;

                    Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                    if (ExpiredDate != null)
                        Command.Parameters.AddWithValue("@ExpiredDate", ExpiredDate);
                    else
                        Command.Parameters.AddWithValue("@ExpiredDate",System.DBNull.Value);

                    Command.Parameters.AddWithValue("@PersonID", PersonID);
                    Command.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                    Command.Parameters.AddWithValue("@LevelID", LevelID);
                    Command.Parameters.AddWithValue("@StatusID", StatusID);
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

        public static int AddNewEmployee(DateTime HireDate, int DepartmentID, int LevelID, int PersonID, int CreatedByUserID, int StatusID)
        {
            int InsertedID = -1;

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_AddNewEmployee", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@HireDate", HireDate);
                    Command.Parameters.AddWithValue("@PersonID", PersonID);
                    Command.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                    Command.Parameters.AddWithValue("@LevelID", LevelID);
                    Command.Parameters.AddWithValue("@StatusID", StatusID);
                    Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    SqlParameter outputIdParam = new SqlParameter("@EmployeeID", SqlDbType.Int)
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


                return InsertedID;

            }











        }

        public static bool DeleteEmployee(int EmployeeID)
        {
            int RowAffected = 0;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_DeleteEmployee", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
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

        public static bool IsEmployeeExistByPersonID(int PersonID)
        {
            bool IsFound = false;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_IsEmployeeExistByPerson", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@PersonID", PersonID);
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



                return IsFound;
            }








        }
        public static bool FindEmployeeByID(int EmployeeID, ref DateTime HireDate, ref DateTime? ExpiredDate,ref int DepartmentID,
            ref int LevelID,ref int StatusID,ref int PersonID,ref int CreatedByUserID)
        {
            bool IsFound = false;

            using(SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using(SqlCommand Command = new SqlCommand("sp_FindEmployeeByID",Connection))
                {
                    Command.CommandType= CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@EmployeeID",EmployeeID);

                    try
                    {
                        Connection.Open();
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound = true;
                                HireDate=(DateTime)Reader["HireDate"];
                                if (Reader["ExpiredDate"] != DBNull.Value)
                                {
                                    ExpiredDate = (DateTime)Reader["ExpiredDate"];
                                }
                                else
                                {
                                    ExpiredDate = null;
                                }
                                DepartmentID = (int)Reader["DepartmentID"];
                                LevelID = (int)Reader["LevelID"];
                                PersonID = (int)Reader["PersonID"];
                                CreatedByUserID = (int)Reader["CreatedByUserID"];
                                StatusID = (int)Reader["StatusID"];




                            }else
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


        public static bool ExpireEmployeer(int EmployeeID)
        {
            int RowAffected = 0;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_ExpireEmployee", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@EmployeeID",EmployeeID);

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

    }
}
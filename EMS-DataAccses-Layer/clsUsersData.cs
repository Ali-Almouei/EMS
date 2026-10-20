using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DataAccses_Layer
{
    public class clsUsersData
    {
        public static async Task<DataTable> GetAllUsers()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_GetAllUsers", connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        await connection.OpenAsync();
                        using (SqlDataReader Reader = await Command.ExecuteReaderAsync())
                        {

                            if (Reader.HasRows)
                            {
                                dataTable.Load(Reader);
                            }


                        }
                    }
                    catch(  Exception ex)
                    {
                        clsSettingConnection.LogError(ex.Message);
                    }
                }

            }

            return dataTable;
        }

        public static DataTable GetAllUsersPagination(int PageNumber, int RowsPerPage)
        {
            DataTable dt = new DataTable();
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_GetAllUsersPagination ", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@PageNumber", PageNumber);
                    Command.Parameters.AddWithValue("@RowsPerPage", RowsPerPage);
                    try
                    {
                        Connection.Open();
                        SqlDataReader Reader = Command.ExecuteReader();
                        if (Reader.HasRows)
                            dt.Load(Reader);

                    }
                    catch (Exception ex)
                    {
                        clsSettingConnection.LogError(ex.Message);
                    }

                }



                return dt;
            }


















        }

        public static bool DaleteUser(int UserID)
        {
            int RowsAffected = 0;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_DeleteUser", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@UserID", UserID);
                    try
                    {
                        Connection.Open();
                        RowsAffected = Command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        clsSettingConnection.LogError(ex.Message);
                    }


                }
            }




            return RowsAffected > 0;
        }

        public static bool UpdateUser(int UserID, string UserName, string Password, int Permissions, bool IsActive, bool IsAdmin, int PersonID)
        {
            int RowAffected = 0;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_UpdateUser", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@UserID", UserID);
                    Command.Parameters.AddWithValue("@UserName", UserName);
                    Command.Parameters.AddWithValue("@Password", Password);
                    Command.Parameters.AddWithValue("@IsActive", IsActive);
                    Command.Parameters.AddWithValue("@Permissions", Permissions);
                    Command.Parameters.AddWithValue("@IsAdmin", IsAdmin);
                    Command.Parameters.AddWithValue("@PersonID", PersonID);
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

        public static int AddNewUser(string UserName, string Password, int Permissions, bool IsActive, bool IsAdmin, int PersonID)
        {
            int InsertedID = -1;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_AddNewUser", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@UserName", UserName);
                    Command.Parameters.AddWithValue("@Password", Password);
                    Command.Parameters.AddWithValue("@IsActive", IsActive);
                    Command.Parameters.AddWithValue("@Permissions", Permissions);
                    Command.Parameters.AddWithValue("@IsAdmin", IsAdmin);
                    Command.Parameters.AddWithValue("@PersonID", PersonID);
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



                return InsertedID;
            }

        }

        public static bool ChangePassword(int UserID, string Password)
        {
            int RowAffected = 0;

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_ChangePasswordForUser", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@UserID", UserID);
                    Command.Parameters.AddWithValue("@Password", Password);

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

        public static bool FindUserByID(int UserID, ref string UserName, ref string Password, ref bool IsActive, ref int Permissions, ref bool IsAdmin, ref int PersonID)
        {
            bool IsFound = false;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using(SqlCommand Command = new SqlCommand("sp_GetUserByID",Connection))
                {

                    Command.CommandType= CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@UserID", UserID);

                    try
                    {
                        Connection.Open();
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound = true;
                                UserName = (string)Reader["UserName"];
                                Password = (string)Reader["Password"];
                                IsActive = (bool)Reader["IsActive"];
                                Permissions = (int)Reader["Permissions"];
                                IsAdmin = (bool)Reader["IsAdmin"];
                                PersonID = (int)Reader["PersonID"];
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
        public static bool FindUserByPersonID(ref int UserID, ref string UserName, ref string Password, ref bool IsActive, ref int Permissions, ref bool IsAdmin,  int PersonID)
        {
            bool IsFound = false;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_GetUserByPersonID", Connection))
                {

                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        Connection.Open();
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound = true;
                                UserID = (int)Reader["UserID"];

                                UserName = (string)Reader["UserName"];
                                Password = (string)Reader["Password"];
                                IsActive = (bool)Reader["IsActive"];
                                Permissions = (int)Reader["Permissions"];
                                IsAdmin = (bool)Reader["IsAdmin"];
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
        public static bool FindUserByUserNameAndPassword(ref int UserID,  string UserName,  string Password, ref bool IsActive, ref int Permissions, ref bool IsAdmin, ref int PersonID)
        {
            bool IsFound = false;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_GetUserByUserNameAndPassword", Connection))
                {

                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@UserName", UserName);
                    Command.Parameters.AddWithValue("@Password", Password);

                    try
                    {
                        Connection.Open();
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound = true;
                                UserID = (int)Reader["UserID"];
                                IsActive = (bool)Reader["IsActive"];
                                Permissions = (int)Reader["Permissions"];
                                IsAdmin = (bool)Reader["IsAdmin"];
                                PersonID = (int)Reader["PersonID"];

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


        public static bool IsUserExist(int UserID)
        {
            bool isFound = false;

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            using (SqlCommand Command = new SqlCommand("sp_IsUserExist", Connection))
            {
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        isFound = Reader.HasRows;
                    }
                }
                catch (Exception ex)
                {
                    clsSettingConnection.LogError(ex.Message);
                }
            }

            return isFound;
        }

        public static bool IsUserExistByPersonID(int PersonID)
        {
            bool isFound = false;

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            using (SqlCommand Command = new SqlCommand("sp_IsUserExistByPersonID", Connection))
            {
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        isFound = Reader.HasRows;
                    }
                }
                catch (Exception ex)
                {
                    clsSettingConnection.LogError(ex.Message);
                }
            }

            return isFound;
        }
        public static bool IsUserExistByUserName(string UserName)
        {
            bool isFound = false;

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            using (SqlCommand Command = new SqlCommand("sp_IsUserExist", Connection))
            {
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@UserName", UserName);

                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        isFound = Reader.HasRows;
                    }
                }
                catch (Exception ex)
                {
                    clsSettingConnection.LogError(ex.Message);
                }
            }

            return isFound;
        }


    }
}

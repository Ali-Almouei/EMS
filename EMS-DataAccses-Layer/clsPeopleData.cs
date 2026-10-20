using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace EMS_DataAccses_Layer
{
    public class clsPeopleData
    {
        public static bool FindPersonByID(int PersonID, ref string FirstName, ref string MidName, ref string LastName, ref string NationalNO, ref DateTime DateOfBirth, ref string Phone, ref string Email, ref string Address, ref byte Gender, ref string ImagePath, ref int NationalID)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            using (SqlCommand Command = new SqlCommand("sp_FindPersonByID", Connection))
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
                            FirstName = (string)Reader["FirstName"];
                            MidName = Reader["MidName"] != DBNull.Value ? (string)Reader["MidName"] : null;
                            LastName = (string)Reader["LastName"];
                            Phone = (string)Reader["Phone"];
                            Email = (string)Reader["Email"];
                            Address = Reader["Address"] != DBNull.Value ? (string)Reader["Address"] : null;
                            DateOfBirth = (DateTime)Reader["DateOfBirth"];
                            NationalNO = (string)Reader["National_NO"];
                            Gender = (byte)Reader["Gender"];
                            ImagePath = Reader["ImagePath"] != DBNull.Value ? (string)Reader["ImagePath"] : "";
                            NationalID = (int)Reader["NationalID"];
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
        public static bool FindPersonByNationalNO(ref int PersonID, ref string FirstName, ref string MidName, ref string LastName, string NationalNO, ref DateTime DateOfBirth, ref string Phone, ref string Email, ref string Address, ref byte Gender, ref string ImagePath, ref int NationalID)
        {
            bool IsFound = false;

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            using (SqlCommand Command = new SqlCommand("sp_FindPersonByNationalNO", Connection))
            {
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@NationalNO", NationalNO);

                try
                {
                    Connection.Open();
                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.Read())
                        {
                            IsFound = true;
                            PersonID = (int)Reader["PersonID"];
                            FirstName = (string)Reader["FirstName"];
                            MidName = Reader["MidName"] != DBNull.Value ? (string)Reader["MidName"] : null;
                            LastName = (string)Reader["LastName"];
                            Phone = (string)Reader["Phone"];
                            Email = (string)Reader["Email"];
                            Address = Reader["Address"] != DBNull.Value ? (string)Reader["Address"] : null;
                            DateOfBirth = (DateTime)Reader["DateOfBirth"];
                            Gender = (byte)Reader["Gender"];
                            ImagePath = Reader["ImagePath"] != DBNull.Value ? (string)Reader["ImagePath"] : "";
                            NationalID = (int)Reader["NationalID"];
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
        public static bool UpdatePerson(int PersonID, string FirstName, string MidName, string LastName, string NationalNO, DateTime DateOfBirth, string Phone, string Email, string Address, byte Gender, string ImagePath, int NationalID)
        {
            int RowAffected = 0;

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            using (SqlCommand Command = new SqlCommand("sp_UpdatePerson", Connection))
            {
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@PersonID", PersonID);
                Command.Parameters.AddWithValue("@FirstName", FirstName);
                Command.Parameters.AddWithValue("@MidName", MidName);
                Command.Parameters.AddWithValue("@LastName", LastName);
                Command.Parameters.AddWithValue("@NationalNO", NationalNO);
                Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                Command.Parameters.AddWithValue("@Phone", Phone);
                Command.Parameters.AddWithValue("@Email", Email);
                Command.Parameters.AddWithValue("@Address", Address);
                Command.Parameters.AddWithValue("@Gender", Gender);
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
                Command.Parameters.AddWithValue("@NationalID", NationalID);

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

        public static int AddNewPerson(string FirstName, string MidName, string LastName, string NationalNO, DateTime DateOfBirth, string Phone, string Email, string Address, byte Gender, string ImagePath, int NationalID)
        {
            int InsertedID = -1;

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            using (SqlCommand Command = new SqlCommand("sp_AddNewPerson", Connection))
            {
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@FirstName", FirstName);
                Command.Parameters.AddWithValue("@MidName", MidName);
                Command.Parameters.AddWithValue("@LastName", LastName);
                Command.Parameters.AddWithValue("@NationalNO", NationalNO);
                Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                Command.Parameters.AddWithValue("@Phone", Phone);
                Command.Parameters.AddWithValue("@Email", Email);
                Command.Parameters.AddWithValue("@Address", Address);
                Command.Parameters.AddWithValue("@Gender", Gender);
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
                Command.Parameters.AddWithValue("@NationalID", NationalID);

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

        public static bool DeletePerson(int PersonID)
        {
            int RowAffected = 0;

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            using (SqlCommand Command = new SqlCommand("sp_DeletePerson", Connection))
            {
                Command.CommandType = CommandType.StoredProcedure;
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

            return RowAffected > 0;
        }

        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            using (SqlCommand Command = new SqlCommand("sp_IsPersonExist", Connection))
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
        public static async Task<DataTable> GatAllPeople()
        {
            DataTable dt = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_GetAllPersons", Connection))
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
        public static DataTable GetAllPeoplePagination(int PageNumber,int RowsPerPage)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command=new SqlCommand("sp_GetAllPeoplePagination",Connection))
                {
                    Command.CommandType= CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@PageNumber", PageNumber);
                    Command.Parameters.AddWithValue("@RowsPerPage", RowsPerPage);
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader Reader = Command.ExecuteReader())
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







            }






                return dataTable;
        }








    }
}

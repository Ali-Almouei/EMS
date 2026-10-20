using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Security.Policy;

namespace EMS_DataAccses_Layer
{
    public class clsInterviewAppointmentsData
    {
        public static DataTable GetAllApointments(DateTime InterviewDate)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_GetAllInterviewAppointments", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@InterviewDate", InterviewDate);
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = Command.ExecuteReader())
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
        public static DataTable GetAllApointmentsPerPersonID(int PersonID)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_GetAllAppointmetsForPerson", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@PersonID", PersonID);
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader reader = Command.ExecuteReader())
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


        public static int AddNewAppointment(DateTime AppointmentDate, bool IsLocked, string Notes, int PersonID, int DepartmentID, int JobLevelID, int CreatedByUserID)
        {
            int InsertedID = -1;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_AddNewInterviewAppointment", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    Command.Parameters.AddWithValue("@IsLocked", IsLocked);
                    if (Notes != null || Notes != "")
                        Command.Parameters.AddWithValue("@Notes", Notes);
                    else
                        Command.Parameters.AddWithValue("@Notes", DBNull.Value);

                    Command.Parameters.AddWithValue("@PersonID", PersonID);
                    Command.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                    Command.Parameters.AddWithValue("@JobLevelID", JobLevelID);
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
        public static bool UpdateAppointment(int AppointmentID, DateTime CreatedDate, DateTime AppointmentDate, bool IsLocked, string Notes, int PersonID, int DepartmentID, int JobLevelID, int CreatedByUserID)
        {
            int RowAffected = 0;

            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_UpdateInterviewAppointment", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@AppointmentID", AppointmentID);
                    Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
                    Command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                    Command.Parameters.AddWithValue("@IsLocked", IsLocked);
                    if (Notes != null || Notes != "")
                        Command.Parameters.AddWithValue("@Notes", Notes);
                    else
                        Command.Parameters.AddWithValue("@Notes", DBNull.Value);

                    Command.Parameters.AddWithValue("@PersonID", PersonID);
                    Command.Parameters.AddWithValue("@DepartmentID", DepartmentID);
                    Command.Parameters.AddWithValue("@JobLevelID", JobLevelID);
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

                    return RowAffected > 0;
                }







            }
        }

        public static bool DeleteAppointment(int AppointmentID)
        {
            int RowAffected = 0;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_DeleteAppointment", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@AppointmentID", AppointmentID);
                    try
                    {
                        Connection.Open();
                        RowAffected=Command.ExecuteNonQuery();  
                    }
                    catch (Exception ex)
                    {
                        clsSettingConnection.LogError(ex.Message);
                    }
                }



                return RowAffected > 0;
            }


        }

        public static bool FindAppointmentByID(int AppointmentID,ref DateTime AppointmentDate,ref DateTime CreatedDate,ref string Notes,ref bool IsLocked,
            ref int PersonID,ref int DepartmentID,ref int JobLevelID,ref int CreatedbyUserID)
        {
            bool IsFound=false;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using(SqlCommand Command = new SqlCommand("sp_FindAppointment",Connection))
                {
                    Command.CommandType= CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@AppointmentID", AppointmentID);
                    try
                    {
                        Connection.Open();
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                IsFound=true;

                                CreatedDate = (DateTime)Reader["CreatedDate"];
                                AppointmentDate = (DateTime)Reader["AppoinntmentDate"];
                                IsLocked = (bool)Reader["IsLoked"];
                                Notes = (string)Reader["Notes"];
                                PersonID = (int)Reader["PersonID"];
                                DepartmentID = (int)Reader["DepartmentID"];
                                JobLevelID = (int)Reader["JobLevelID"];
                                CreatedbyUserID = (int)Reader["CreatedByUserID"];


                            }
                            else
                            {
                                IsFound=false;
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

        public static bool IsPersonHasActiveAppointment(int PersonID)
        {
            bool IsFound=false;
            using (SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString))
            {
                using (SqlCommand Command = new SqlCommand("sp_IsPersonHasActiveInterviewAppointment", Connection))
                {
                    Command.CommandType=CommandType.StoredProcedure;
                    Command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        Connection.Open();
                        using(SqlDataReader Reader= Command.ExecuteReader())
                        {
                            IsFound=Reader.HasRows;
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
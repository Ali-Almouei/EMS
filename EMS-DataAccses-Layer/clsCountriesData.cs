using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
namespace EMS_DataAccses_Layer
{
    public class clsCountriesData
    {
        public static async Task<DataTable> GetAllCountries()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString);
            SqlCommand Command = new SqlCommand("sp_GetAllCountries", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            try { 
            
               await  Connection.OpenAsync();
                SqlDataReader reader = Command.ExecuteReader();
                dt.Load(reader);
                reader.Close();



            }
            catch (Exception ex)
            {
                clsSettingConnection.LogError(ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return dt;

        }
        public static bool FindCountryByID(int CountryID,ref string CountryName)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection( clsSettingConnection.ConnectionString);
            SqlCommand Command = new SqlCommand("sp_FindCountryByID", Connection);
            Command.CommandType= CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@CountryID",CountryID);

            try
            {
                Connection.Open();
                SqlDataReader Reader=Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    CountryName = (string)Reader["CountryName"];
                    Reader.Close();
                }
                else
                {
                    IsFound = false;
                }
            }
            catch (Exception ex)
            {
                clsSettingConnection.LogError(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return IsFound;

        }
        public static bool FindCountryByName(ref int CountryID,  string CountryName)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsSettingConnection.ConnectionString);
            SqlCommand Command = new SqlCommand("sp_GetCountryByName", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    CountryID = (int)Reader["CountryID"];
                    Reader.Close();
                }
                else
                {
                    IsFound = false;
                }
            }
            catch (Exception ex)
            {
                clsSettingConnection.LogError(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return IsFound;

        }


    }
}

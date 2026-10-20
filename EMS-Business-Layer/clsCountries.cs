using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EMS_DataAccses_Layer;

namespace EMS_Business_Layer
{
    public class clsCountries
    {

        public int CountryID {  get; set; }
        public string CountryName { get; set; }
        public clsCountries() 
        {
            this.CountryID = -1;
            this.CountryName = null;
        
        }
        private clsCountries(int CountryID , string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }
        public static async Task <DataTable> GetAllCountries()
        {
            return await clsCountriesData.GetAllCountries();
        }

        public static clsCountries FindCountryByID(int CountryID)
        {
            string countryName = "";
            if(clsCountriesData.FindCountryByID(CountryID,ref countryName))
                 return new clsCountries(CountryID,countryName);
            else return null;
            
        }
        public static clsCountries FindCountryByName(string CountryName)
        {
            int CountryID = -1;
            if (clsCountriesData.FindCountryByName(ref CountryID,CountryName))
                return new clsCountries(CountryID, CountryName);
            else return null;

        }
    }
}

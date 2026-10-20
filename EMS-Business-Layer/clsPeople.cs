using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS_DataAccses_Layer;

namespace EMS_Business_Layer
{
    public class clsPeople
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + MidName + " " + LastName; }

        }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NationalID { get; set; }
        public string NationalNO { get; set; }
        public byte Gendor { get; set; }
        private string _ImagePath;

        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }
        public clsCountries CountryInfo;


        private clsPeople(int PersonID, string FirstName, string MidName, string LastName, string Phone, string Email, string Address,
          byte Gendor, DateTime DateOfBirth, string ImagePath, string NationalNO, int CountryID)
        {

            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.MidName = MidName;
            this.LastName = LastName;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.ImagePath = ImagePath;
            this.NationalID = CountryID;
            this.NationalNO = NationalNO;
            this.Gendor = Gendor;
            this.CountryInfo = clsCountries.FindCountryByID(CountryID);
            Mode = enMode.Update;



        }
        public clsPeople()
        {
            this.PersonID = -1;
            this.FirstName = "";
            this.MidName = "";
            this.LastName = "";
            this.Phone = "";
            this.Email = "";
            this.NationalNO = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.ImagePath = "";
            this.NationalID = -1;
            Mode = enMode.AddNew;
        }

        private bool _Update()
        {
            return clsPeopleData.UpdatePerson(this.PersonID, this.FirstName, this.MidName, this.LastName, this.NationalNO, this.DateOfBirth, this.Phone, this.Email, this.Address, this.Gendor, this.ImagePath, this.NationalID);
        }
        private bool _AddNew()
        {
            this.PersonID= clsPeopleData.AddNewPerson(this.FirstName, this.MidName, this.LastName, this.NationalNO, this.DateOfBirth, this.Phone, this.Email, this.Address, this.Gendor, this.ImagePath, this.NationalID);
            return this.PersonID!= - 1;

        }
        public static clsPeople GetPersonByID(int PersonID)
        {
            string FirstName="", MidName="", LastName = "", Phone = "",  Email = "", Address = "", ImagePath = "", NationalNO = "";
            int NationalID = -1;
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            if (clsPeopleData.FindPersonByID(PersonID, ref FirstName, ref MidName, ref LastName, ref NationalNO, ref DateOfBirth,
                ref Phone, ref Email, ref Address, ref Gendor, ref ImagePath ,ref NationalID))
                return new clsPeople(PersonID, FirstName, MidName, LastName, Phone, Email, Address,Gendor,DateOfBirth, ImagePath, NationalNO, NationalID);
            else
                return null;

        }
        public static clsPeople GetPersonByNationalNO(string NationalNO)
        {
            string FirstName = "", MidName = "", LastName = "", Phone = "", Email = "", Address = "", ImagePath = "";
            int NationalID = -1,PersonID=-1;
            DateTime DateOfBirth = DateTime.Now;
            byte Gendor = 0;
            if (clsPeopleData.FindPersonByNationalNO(ref PersonID, ref FirstName, ref MidName, ref LastName,  NationalNO, ref DateOfBirth,
                ref Phone, ref Email, ref Address, ref Gendor, ref ImagePath, ref NationalID))
                return new clsPeople(PersonID, FirstName, MidName, LastName, Phone, Email, Address, Gendor, DateOfBirth, ImagePath, NationalNO, NationalID);
            else
                return null;

        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _Update();

            }

            return false;
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPeopleData.DeletePerson(PersonID);
        }
        public static bool IsPersonExist(int PersonID)
        {
            return clsPeopleData.IsPersonExist(PersonID);
        }

        public static async Task<DataTable> GetAllPeople()
        {
            return await clsPeopleData.GatAllPeople();
        }
        public static DataTable GetAllPeoplePagination(int PageNumber,int RowsPerPage)
        {
            return clsPeopleData.GetAllPeoplePagination(PageNumber, RowsPerPage);
        }
    }
}

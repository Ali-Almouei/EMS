using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EMS_DataAccses_Layer;

namespace EMS_Business_Layer
{
    public class clsUsers
    {

        public int UserID {  get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public int Permissions {  get; set; }
        public int PersonID {  get; set; }
        clsPeople Person;

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public clsUsers()
        {
            this.UserID =-1;
            this.UserName ="";
            this.Password ="";
            this.IsActive =false;
            this.IsAdmin =false;
            this.Permissions =0;
            this.PersonID =-1;
            Mode = enMode.AddNew;
        }

        private clsUsers(int UserID, string UserName, string Password,bool IsActive,int Permissions,bool IsAdmin,int PersonID)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive =IsActive;
            this.IsAdmin = IsAdmin;
            this.Permissions =Permissions;
            this.PersonID = PersonID;
            Person=clsPeople.GetPersonByID(PersonID);
            Mode = enMode.Update;
        }

        private bool _AddNew()
        {
            this.UserID= clsUsersData.AddNewUser(this.UserName,this.Password,this.Permissions,this.IsActive,this.IsAdmin,this.PersonID);
            return this.UserID != -1;
        }
        private bool _Update()
        {
            return clsUsersData.UpdateUser(this.UserID, this.UserName, this.Password, this.Permissions, this.IsActive, this.IsAdmin, this.PersonID);
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

        public static clsUsers FindUserByID(int UserID)
        {
            int PersonID=-1 , Permissions=-1 ;
            bool IsActive=false ,IsAdmin=false;
            string UserName="", Password="";

            if(clsUsersData.FindUserByID(UserID,ref UserName,ref Password,ref IsActive, ref Permissions,ref  IsAdmin,ref PersonID))
           return new clsUsers(UserID,UserName,Password,IsActive,Permissions,IsAdmin,PersonID);
            else return null;

        }

        public static clsUsers FindUserByPersonID(int PersonID)
        {
            int UserID = -1, Permissions = -1;
            bool IsActive = false, IsAdmin = false;
            string UserName = "", Password = "";

            if (clsUsersData.FindUserByPersonID(ref UserID, ref UserName, ref Password, ref IsActive, ref Permissions, ref IsAdmin,  PersonID))
                return new clsUsers(UserID, UserName, Password, IsActive, Permissions, IsAdmin, PersonID);
            else return null;

        }
        public static clsUsers FindUserByUserNameAndPassword(string UserName,string Password)
        {
            int PersonID = -1, Permissions = -1,UserID=-1;
            bool IsActive = false, IsAdmin = false;

            if (clsUsersData.FindUserByUserNameAndPassword(ref UserID,  UserName,  Password, ref IsActive, ref Permissions, ref IsAdmin, ref PersonID))
                return new clsUsers(UserID, UserName, Password, IsActive, Permissions, IsAdmin, PersonID);
            else return null;

        }
        public static bool DeleteUser(int UserID)
        {
            return clsUsersData.DaleteUser(UserID);
        }
        public static async Task<DataTable> GetAllUsers()
        {
            return await clsUsersData.GetAllUsers();
        }
        public static DataTable GatAllUsersPagination(int PageNumber,int RowsPerPage)
        {
            return clsUsersData.GetAllUsersPagination(PageNumber, RowsPerPage);
        }
        public bool ChangePassword(int UserID, string Password)
        {
            return clsUsersData.ChangePassword(UserID, Password);
        }

        public static bool IsUserExist(int UserID)
        {
            return clsUsersData.IsUserExist(UserID);
        }
        public static bool IsUserExistByPersonID(int PersonID)
        {
            return clsUsersData.IsUserExistByPersonID(+PersonID);
        }
        public static bool IsUserExistByUserName(string UserName)
        {
            return clsUsersData.IsUserExistByUserName(UserName);
        }
    }
}

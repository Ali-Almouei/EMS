using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS_Business_Layer;
using Microsoft.Win32;

namespace EMS_Presentation_Layer.Classes
{
    internal class clsGlobal
    {
        public static clsUsers CurrentUser;

        public static bool RememberUsernameAndPassword(string UserName, string Password)
        {
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\EMS";
            try
            {
                Registry.SetValue(KeyPath, "UserName", UserName, RegistryValueKind.String);
                Registry.SetValue(KeyPath, "Password", Password, RegistryValueKind.String);
                return true;
            }
            catch (Exception ex)
            {
                clsUtils.LogError(ex.Message);
                return false;
            }



        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\EMS";
            string Val1 = Registry.GetValue(KeyPath, "UserName", null) as string;
            string Val2 = Registry.GetValue(KeyPath, "Password", null) as string;

            try
            {
                if (Val1 != null && Val2 != null)
                {
                    Username = Val1;
                    Password = Val2;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                clsUtils.LogError(ex.Message);
                return false;
            }

        }
    }
}

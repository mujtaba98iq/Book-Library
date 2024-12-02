using DL.SimpleLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersBusinessLayer;

namespace Simple_Library.GlobalClasses
{
    static public class clsGlobal
    {

        public static clsUser CurrentUser;

        public static bool RememberUsernameAndLibraryCardNumber(string Username, string Password)
        {
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD2";
            string ValueNameForUserName = "UserName";
            string ValueDataForUserName = Username;

            string ValueNameForPassword = "Password";
            string ValueDataForPassword = Password;

            try
            {
                Registry.SetValue(KeyPath, ValueNameForUserName, ValueDataForUserName, RegistryValueKind.String);
                Registry.SetValue(KeyPath, ValueNameForPassword, ValueDataForPassword, RegistryValueKind.String);

                return true;
            }
            catch (Exception ex)
            {
                clsErrorHandling.HandleError(ex.ToString());
                return false;
            }

        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found.
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD2";
            string ValueNameForUserName = "UserName";
            string ValueNameForPassword = "Password";

            try
            {
                string UserNameVlaue = Registry.GetValue(KeyPath, ValueNameForUserName, null) as string;
                string PasswordVlaue = Registry.GetValue(KeyPath, ValueNameForPassword, null) as string;

                if (UserNameVlaue != null && PasswordVlaue != null)
                {
                    Username = UserNameVlaue;
                    Password = PasswordVlaue;
                    return true;
                }
                else
                {
                    return false;

                }

            }
            catch (Exception ex)
            {

                clsErrorHandling.HandleError(ex.ToString());
                return false;
            }
            return false;
        }

        public static void ShortWait()
        {
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(5);
            }
        }
        public static void LongWait()
        {
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(5);
            }
        }
        public static string CumputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] beyteHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(beyteHash).Replace("_", "").ToLower();
            }

        }
    }
}

using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using DB_Simple_LibraryDataAccessLayer;
using PeopleBusinessLayer;
namespace UsersBusinessLayer
{

public class clsUser
{
public enum enMode { AddNew = 0, Update = 1 };
public enMode Mode = enMode.AddNew;
public int UserID {get; set;}
public int PersonID {get; set;}
public string UserName {get; set;}
public string LibraryCardNumber { get; set;}
public bool IsActive {get; set;}
public bool IsAdmin {get; set;}
public DateTime DateTime {get; set;}
public clsPerson PersonInfo {get; set;}
public int CreatedByUserID {get; set;}
        public bool IsLibraryCardNumberMatch(string LibraryCardNumber)
        {

            string CurrentLibraryCardNumber = this.LibraryCardNumber;
            LibraryCardNumber = CumputeHash(LibraryCardNumber);
            return CurrentLibraryCardNumber == LibraryCardNumber;
        }


        public clsUser()
{
this.UserID = default;
this.PersonID = default;
this.UserName = default;
this.LibraryCardNumber = default;
this.IsActive = default;
this.IsAdmin = default;
this.DateTime = default;
this.PersonInfo = default;
this.CreatedByUserID = default;


Mode = enMode.AddNew;

}

private clsUser( int UserID,  int PersonID,  string UserName,  string LibraryCardNumber,  bool IsActive,bool IsAdmin , DateTime DateTime, int CreatedByUserID)
{
this.UserID = UserID;
this.PersonID = PersonID;
this.UserName = UserName;
this.LibraryCardNumber = LibraryCardNumber;
this.IsActive = IsActive;
 this.IsAdmin = IsAdmin;
 this.DateTime = DateTime;
 this.PersonInfo = clsPerson.Find(PersonID);
this.CreatedByUserID = CreatedByUserID;


Mode = enMode.Update;

}

private bool _AddNewUser()
{
            //call DataAccess Layer 
            this.LibraryCardNumber = CumputeHash(this.LibraryCardNumber);

            this.UserID = clsUsersDataAccess.AddNewUser(this.PersonID, this.UserName, this.LibraryCardNumber, this.IsActive,this.IsAdmin, this.DateTime,this.CreatedByUserID);

return (this.UserID != -1);

}

private bool _UpdateUser()
{
//call DataAccess Layer 
this.LibraryCardNumber=CumputeHash(this.LibraryCardNumber); 
return clsUsersDataAccess.UpdateUser(this.UserID, this.PersonID, this.UserName, this.LibraryCardNumber, this.IsActive, this.IsAdmin,this.DateTime,this.CreatedByUserID);

}

public static clsUser Find(int UserID)
{
int PersonID = default;
string UserName = default;
string LibraryCardNumber = default;
bool IsActive = default;
bool IsAdmin = default;
DateTime DateTime = default;
int CreatedByUserID = default;


if(clsUsersDataAccess.GetUserInfoByID(UserID, ref PersonID, ref UserName, ref LibraryCardNumber, ref IsActive,ref IsAdmin,ref DateTime,ref CreatedByUserID))
return new clsUser( UserID,  PersonID,  UserName,  LibraryCardNumber,  IsActive,IsAdmin, DateTime, CreatedByUserID);
else
return null;

}

        public static clsUser FindByUsernameAndLibraryCardNumber(string UserName, string LibraryCardNumber)
        {
            int PersonID = default;
            int UserID = default;
            bool IsActive = default;
            bool IsAdmin = default;
            DateTime DateTime = default;
            int CreatedByUserID = default;

            LibraryCardNumber = CumputeHash(LibraryCardNumber);


            if (clsUsersDataAccess.GetUserInfoByIDUserNameAndLibraryCardNumber(ref UserID, ref PersonID, UserName, LibraryCardNumber, ref IsActive,ref IsAdmin,ref DateTime, ref CreatedByUserID))
                return new clsUser(UserID, PersonID, UserName, LibraryCardNumber, IsActive, IsAdmin, DateTime, CreatedByUserID);
            else
                return null;

        }
        public static string CumputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] beyteHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(beyteHash).Replace("_", "").ToLower();
            }

        }
        public bool Save()
        {
            

            switch  (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();

            }




            return false;
        }

public static DataTable GetAllUsers(){return clsUsersDataAccess.GetAllUsers();}
public static DataTable GetNewUsers(){return clsUsersDataAccess.GetNewUsers();}

public static bool DeleteUser(int UserID){return  clsUsersDataAccess.DeleteUser(UserID);}

public static bool isUserExist(int UserID){return clsUsersDataAccess.IsUserExist(UserID);}
public static bool isUserAdmin(int UserID){return clsUsersDataAccess.IsUserAdmin(UserID);}
public static bool isUserExist(string UserName) {return clsUsersDataAccess.IsUserExistByUserName(UserName);}


}

}
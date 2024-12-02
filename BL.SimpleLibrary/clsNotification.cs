using System;
using System.Data;
using DB_Simple_LibraryDataAccessLayer;
namespace NotificaitonsBusinessLayer
{

public class clsNotification
{
public enum enMode { AddNew = 0, Update = 1 };
public enMode Mode = enMode.AddNew;
public int NotificationID {get; set;}
public int UserID {get; set;}
public string Description {get; set;}


public clsNotification()
{
this.NotificationID = default;
this.UserID = default;
this.Description = default;


Mode = enMode.AddNew;

}

private clsNotification( int NotificationID,  int UserID,  string Description)
{
this.NotificationID = NotificationID;
this.UserID = UserID;
this.Description = Description;


Mode = enMode.Update;

}

private bool _AddNewNotification()
{
//call DataAccess Layer 

this.NotificationID = clsNotificaitonsDataAccess.AddNewNotification(this.UserID, this.Description);

return (this.NotificationID != -1);

}

private bool _UpdateNotification()
{
//call DataAccess Layer 

return clsNotificaitonsDataAccess.UpdateNotification(this.NotificationID, this.UserID, this.Description);

}

public static clsNotification Find(int NotificationID)
{
int UserID = default;
string Description = default;


if(clsNotificaitonsDataAccess.GetNotificationInfoByID(NotificationID, ref UserID, ref Description))
return new clsNotification( NotificationID,  UserID,  Description);
else
return null;

}

        public bool Save()
        {
            

            switch  (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewNotification())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateNotification();

            }




            return false;
        }

public static DataTable GetAllNotificaitons(){return clsNotificaitonsDataAccess.GetAllNotificaitons();}
public static DataTable GetAllNotificaitonsForUser(int UserID){return clsNotificaitonsDataAccess.GetAllNotificaitonsForUser(UserID);}

public static bool DeleteNotification(int NotificationID){return  clsNotificaitonsDataAccess.DeleteNotification(NotificationID);}
public static bool DeleteAllNotificationsForUserID(int UserID){return  clsNotificaitonsDataAccess.DeleteAllNotificationsForUserID(UserID);}

public static bool isNotificationExist(int NotificationID){return clsNotificaitonsDataAccess.IsNotificationExist(NotificationID);}


}

}
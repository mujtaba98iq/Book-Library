using System;
using System.Data;
using BooksBusinessLayer;
using DB_Simple_LibraryDataAccessLayer;
namespace ReservationsBusinessLayer
{

public class clsReservation
{
public enum enMode { AddNew = 0, Update = 1 };
public enMode Mode = enMode.AddNew;
public int ReservationID {get; set;}
public int UserID {get; set;}
public int BookID {get; set;}
public DateTime ReservationDate {get; set;}
     public   clsBook BookInfo { get; set;}


public clsReservation()
{
this.ReservationID = default;
this.UserID = default;
this.BookID = default;
this.ReservationDate = default;
            this.BookInfo = default;


Mode = enMode.AddNew;

}

private clsReservation( int ReservationID,  int UserID,  int BookID,  DateTime ReservationDate,  int CreatedByUserID)
{
this.ReservationID = ReservationID;
this.UserID = UserID;
this.BookID = BookID;
this.ReservationDate = ReservationDate;
            this.BookInfo = clsBook.Find(BookID);

Mode = enMode.Update;

}

private bool _AddNewReservation()
{
//call DataAccess Layer 

this.ReservationID = clsReservationsDataAccess.AddNewReservation(this.UserID, this.BookID, this.ReservationDate);

return (this.ReservationID != -1);

}

private bool _UpdateReservation()
{
//call DataAccess Layer 

return clsReservationsDataAccess.UpdateReservation(this.ReservationID, this.UserID, this.BookID, this.ReservationDate);

}

public static clsReservation Find(int ReservationID)
{
int UserID = default;
int BookID = default;
DateTime ReservationDate = default;
int CreatedByUserID = default;


if(clsReservationsDataAccess.GetReservationInfoByID(ReservationID, ref UserID, ref BookID, ref ReservationDate, ref CreatedByUserID))
return new clsReservation( ReservationID,  UserID,  BookID,  ReservationDate,  CreatedByUserID);
else
return null;

}

public static clsReservation FindByUserIDAndBookID(int UserID,int BookID)
{
int ReservationID = default;
DateTime ReservationDate = default;
int CreatedByUserID = default;


if(clsReservationsDataAccess.GetReservationInfoByUserIDAndBookID(ref ReservationID,  UserID, BookID, ref ReservationDate, ref CreatedByUserID))
return new clsReservation( ReservationID,  UserID,  BookID,  ReservationDate,  CreatedByUserID);
else
return null;

}

        public bool Save()
        {
            

            switch  (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewReservation())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateReservation();

            }




            return false;
        }

public static DataTable GetAllReservations(){return clsReservationsDataAccess.GetAllReservations();}

public static bool DeleteReservation(int ReservationID){return  clsReservationsDataAccess.DeleteReservation(ReservationID);}

public static bool isReservationExist(int ReservationID){return clsReservationsDataAccess.IsReservationExist(ReservationID);}
public static bool isUserReserveThisBook(int UserID,int BookID){return clsReservationsDataAccess.isUserReserveThisBook(UserID,BookID);}


}

}
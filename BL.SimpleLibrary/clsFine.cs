using System;
using System.Data;
using DB_Simple_LibraryDataAccessLayer;
namespace FinesBusinessLayer
{

public class clsFine
{
public enum enMode { AddNew = 0, Update = 1 };
public enMode Mode = enMode.AddNew;
public int FineID {get; set;}
public int UserID {get; set;}
public int DorrowingRecordID {get; set;}
public short NumberOfLateDays {get; set;}
public decimal FineAmount {get; set;}
public bool PaymentStatus {get; set;}
public int CreatedByUserID {get; set;}


public clsFine()
{
this.FineID = default;
this.UserID = default;
this.DorrowingRecordID = default;
this.NumberOfLateDays = default;
this.FineAmount = default;
this.PaymentStatus = default;
this.CreatedByUserID = default;


Mode = enMode.AddNew;

}

private clsFine( int FineID,  int UserID,  int DorrowingRecordID,  short NumberOfLateDays,  decimal FineAmount,  bool PaymentStatus,  int CreatedByUserID)
{
this.FineID = FineID;
this.UserID = UserID;
this.DorrowingRecordID = DorrowingRecordID;
this.NumberOfLateDays = NumberOfLateDays;
this.FineAmount = FineAmount;
this.PaymentStatus = PaymentStatus;
this.CreatedByUserID = CreatedByUserID;


Mode = enMode.Update;

}

private bool _AddNewFine()
{
//call DataAccess Layer 

this.FineID = clsFinesDataAccess.AddNewFine(this.UserID, this.DorrowingRecordID, this.NumberOfLateDays, this.FineAmount, this.PaymentStatus, this.CreatedByUserID);

return (this.FineID != -1);

}

private bool _UpdateFine()
{
//call DataAccess Layer 

return clsFinesDataAccess.UpdateFine(this.FineID, this.UserID, this.DorrowingRecordID, this.NumberOfLateDays, this.FineAmount, this.PaymentStatus, this.CreatedByUserID);

}

public static clsFine Find(int FineID)
{
int UserID = default;
int DorrowingRecordID = default;
short NumberOfLateDays = default;
decimal FineAmount = default;
bool PaymentStatus = default;
int CreatedByUserID = default;


if(clsFinesDataAccess.GetFineInfoByID(FineID, ref UserID, ref DorrowingRecordID, ref NumberOfLateDays, ref FineAmount, ref PaymentStatus, ref CreatedByUserID))
return new clsFine( FineID,  UserID,  DorrowingRecordID,  NumberOfLateDays,  FineAmount,  PaymentStatus,  CreatedByUserID);
else
return null;

}

        public bool Save()
        {
            

            switch  (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewFine())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateFine();

            }




            return false;
        }

public static DataTable GetAllFines(){return clsFinesDataAccess.GetAllFines();}
public static decimal SumFineAmount(){return clsFinesDataAccess.GetSumFineAmount();}

public static bool DeleteFine(int FineID){return  clsFinesDataAccess.DeleteFine(FineID);}

public static bool isFineExist(int FineID){return clsFinesDataAccess.IsFineExist(FineID);}


}

}
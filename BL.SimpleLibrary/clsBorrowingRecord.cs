using System;
using System.Data;
using System.Net.NetworkInformation;
using BookCopiesBusinessLayer;
using BooksBusinessLayer;
using DB_Simple_LibraryDataAccessLayer;
namespace BorrowingRecordsBusinessLayer
{

public class clsBorrowingRecord
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int BorrowingRecordID { get; set; }
        public int UserID { get; set; }
        public int CopyID { get; set; }
        public clsBookCopies CopyInfo { get; set; }
        public DateTime BorrowingDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public decimal BorrowCost { get; set; }
        public clsBook BookInfo {  get; set; }


        public clsBorrowingRecord()
        {
            this.BorrowingRecordID = default;
            this.UserID = default;
            this.CopyID = default;
            this.BorrowingDate = default;
            this.DueDate = default;
            this.ActualReturnDate = default;
            this.BorrowCost = default;
            this.CopyInfo = default;
            this.BookInfo = default;


            Mode = enMode.AddNew;

        }

        private clsBorrowingRecord(int BorrowingRecordID, int UserID, int CopyID, DateTime BorrowingDate, DateTime DueDate, DateTime ActualReturnDate, decimal BorrowCost)
        {
            this.BorrowingRecordID = BorrowingRecordID;
            this.UserID = UserID;
            this.CopyID = CopyID;
            this.BorrowingDate = BorrowingDate;
            this.DueDate = DueDate;
            this.ActualReturnDate = ActualReturnDate;
            this.BorrowCost = BorrowCost;
            this.CopyInfo = clsBookCopies.Find(CopyID);
            this.BookInfo = clsBook.Find(CopyInfo.BookID);

            Mode = enMode.Update;

        }

        private bool _AddNewBorrowingRecord()
        {
            //call DataAccess Layer 

            this.BorrowingRecordID = clsBorrowingRecordsDataAccess.AddNewBorrowingRecord(this.UserID, this.CopyID, this.BorrowingDate, this.DueDate, this.ActualReturnDate, this.BorrowCost);

            return (this.BorrowingRecordID != -1);

        }

        private bool _UpdateBorrowingRecord()
        {
            //call DataAccess Layer 

            return clsBorrowingRecordsDataAccess.UpdateBorrowingRecord(this.BorrowingRecordID, this.UserID, this.CopyID, this.BorrowingDate, this.DueDate, this.ActualReturnDate, this.BorrowCost);

        }

        public static clsBorrowingRecord Find(int BorrowingRecordID)
        {
            int UserID = default;
            int CopyID = default;
            DateTime BorrowingDate = default;
            DateTime DueDate = default;
            DateTime ActualReturnDate = default;
            decimal BorrowCost = default;


            if (clsBorrowingRecordsDataAccess.GetBorrowingRecordInfoByID(BorrowingRecordID, ref UserID, ref CopyID, ref BorrowingDate, ref DueDate, ref ActualReturnDate, ref BorrowCost))
                return new clsBorrowingRecord(BorrowingRecordID, UserID, CopyID, BorrowingDate, DueDate, ActualReturnDate, BorrowCost);
            else
                return null;

        }

        public bool Save()
        {
            

            switch  (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBorrowingRecord())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateBorrowingRecord();

            }




            return false;
        }

public static DataTable GetTop5BooksBorrowing(){return clsBorrowingRecordsDataAccess.GetTop5BooksBorrowing();}
public static decimal SumBilling(){return clsBorrowingRecordsDataAccess.GetSumOfBilling();}
public static int LateDays(int BorrowingRecordID) {return clsBorrowingRecordsDataAccess.GetLateDays(BorrowingRecordID);}
public static DataTable GetAllBorrowingRecordsForUser(int UserID){return clsBorrowingRecordsDataAccess.GetAllBorrowingRecordsForUser(UserID);}
public static DataTable GetAllBorrowingRecords(){return clsBorrowingRecordsDataAccess.GetAllBorrowingRecords();}

public static bool DeleteBorrowingRecord(int BorrowingRecordID){return  clsBorrowingRecordsDataAccess.DeleteBorrowingRecord(BorrowingRecordID);}
public bool ReturnBook (){return  clsBorrowingRecordsDataAccess.ReturnBook(this.BorrowingRecordID,this.CopyID);}

public static bool isBorrowingRecordExist(int BorrowingRecordID){return clsBorrowingRecordsDataAccess.IsBorrowingRecordExist(BorrowingRecordID);}
public static bool isUserBorrowBook(int BookID,int UserID){return clsBorrowingRecordsDataAccess.IsUserBorrowBook(BookID,UserID);}


}

}
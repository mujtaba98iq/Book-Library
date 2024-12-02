using System;
using System.Data;
using DB_Simple_LibraryDataAccessLayer;
namespace BookCopiesBusinessLayer
{

public class clsBookCopies
{
public enum enMode { AddNew = 0, Update = 1 };
public enMode Mode = enMode.AddNew;
public int CopyID {get; set;}
public int BookID {get; set;}
public bool AvailabilityStatus {get; set;}
public int CreateByUserID {get; set;}


public clsBookCopies()
{
this.CopyID = default;
this.BookID = default;
this.AvailabilityStatus = default;
this.CreateByUserID = default;


Mode = enMode.AddNew;

}

private clsBookCopies( int CopyID,  int BookID,  bool AvailabilityStatus,  int CreateByUserID)
{
this.CopyID = CopyID;
this.BookID = BookID;
this.AvailabilityStatus = AvailabilityStatus;
this.CreateByUserID = CreateByUserID;


Mode = enMode.Update;

}

private bool _AddNewCopy()
{
//call DataAccess Layer 

this.CopyID = clsBookCopiesDataAccess.AddNewCopy(this.BookID, this.AvailabilityStatus, this.CreateByUserID);

return (this.CopyID != -1);

        }

       static public bool AddBookCopy(int BookID,int Quentity,int CreatedByUserID)
        {
            //call DataAccess Layer 

            return clsBookCopiesDataAccess.AddBookCopy(BookID,Quentity, CreatedByUserID);


        }

        private bool _UpdateCopy()
{
//call DataAccess Layer 

return clsBookCopiesDataAccess.UpdateCopy(this.CopyID, this.BookID, this.AvailabilityStatus, this.CreateByUserID);

}

public static clsBookCopies Find(int CopyID)
{
int BookID = default;
bool AvailabilityStatus = default;
int CreateByUserID = default;


if(clsBookCopiesDataAccess.GetCopyInfoByID(CopyID, ref BookID, ref AvailabilityStatus, ref CreateByUserID))
return new clsBookCopies( CopyID,  BookID,  AvailabilityStatus,  CreateByUserID);
else
return null;

}

        public bool Save()
        {
            

            switch  (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCopy())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateCopy();

            }




            return false;
        }

public static DataTable GetAllBookCopies(){return clsBookCopiesDataAccess.GetAllBookCopies();}

public static bool DeleteCopy(int CopyID){return  clsBookCopiesDataAccess.DeleteCopy(CopyID);}
public static int NumberOfCopiesBook(int BookID){return  clsBookCopiesDataAccess.GetNumberOfCopiesBook(BookID);}
public static int GetAvailabelCopyID(){return  clsBookCopiesDataAccess.GetAvailabelCopyID();}
public static int GetAvailabelCopyIDForBookID(int BookID){return  clsBookCopiesDataAccess.GetAvailabelCopyIDForBookID(BookID);}

public static bool isCopyExist(int CopyID){return clsBookCopiesDataAccess.IsCopyExist(CopyID);}
public static bool SetBookCopyNotAvailabe(int CopyID){return clsBookCopiesDataAccess.SetBookCopyNotAvailabe(CopyID);}


}

}
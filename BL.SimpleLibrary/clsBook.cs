using System;
using System.Data;
using System.Runtime.CompilerServices;
using DB_Simple_LibraryDataAccessLayer;
namespace BooksBusinessLayer
{

public class clsBook
{
public enum enMode { AddNew = 0, Update = 1 };
public enMode Mode = enMode.AddNew;
public int BookID {get; set;}
public string Auther {get; set;}
public string Title {get; set;}
public string ISBN {get; set;}
public DateTime PublicationDate {get; set;}
public string Genre {get; set;}
public string AdditionalDetails {get; set;}
public string Image {get; set;}
public int CreatedByUserID {get; set;}


public clsBook()
{
this.BookID = default;
            this.Auther = default;
this.Title = default;
this.ISBN = default;
this.PublicationDate = default;
this.Genre = default;
this.AdditionalDetails = default;
this.CreatedByUserID = default;
this.Image = default;


Mode = enMode.AddNew;

}

private clsBook( int BookID,  string Title, string Auther, string ISBN,  DateTime PublicationDate,  string Genre,  string AdditionalDetails,string Image,  int CreatedByUserID)
{
this.BookID = BookID;
            this.Auther = Auther;
this.Title = Title;
this.ISBN = ISBN;
this.PublicationDate = PublicationDate;
this.Genre = Genre;
this.AdditionalDetails = AdditionalDetails;
this.CreatedByUserID = CreatedByUserID;
this.Image = Image;


Mode = enMode.Update;

}

private bool _AddNewBook()
{
//call DataAccess Layer 

this.BookID = clsBooksDataAccess.AddNewBook(this.Auther,this.Title, this.ISBN, this.PublicationDate, this.Genre, this.AdditionalDetails, this.Image, this.CreatedByUserID);

return (this.BookID != -1);

}

private bool _UpdateBook()
{
//call DataAccess Layer 

return clsBooksDataAccess.UpdateBook(this.BookID, this.Auther, this.Title, this.ISBN, this.PublicationDate, this.Genre, this.AdditionalDetails, this.Image, this.CreatedByUserID);

}

public static clsBook Find(int BookID)
{
string Auther = default;
string Title = default;
string ISBN = default;
DateTime PublicationDate = default;
string Genre = default;
string AdditionalDetails = default; 
string Image = default; 
int CreatedByUserID = default;


if(clsBooksDataAccess.GetBookInfoByID(BookID,ref Auther,ref Title, ref ISBN, ref PublicationDate, ref Genre, ref AdditionalDetails, ref Image,ref CreatedByUserID))
return new clsBook( BookID, Auther, Title,  ISBN,  PublicationDate,  Genre,  AdditionalDetails,Image,  CreatedByUserID);
else
return null;

}
public static clsBook FindByTitle(string Title)
{
string Auther = default;
int BookID = default;
string ISBN = default;
DateTime PublicationDate = default;
string Genre = default;
string AdditionalDetails = default; 
string Image = default; 
int CreatedByUserID = default;


if(clsBooksDataAccess.GetBookInfoByTitle(ref BookID,ref Auther, Title, ref ISBN, ref PublicationDate, ref Genre, ref AdditionalDetails, ref Image,ref CreatedByUserID))
return new clsBook( BookID, Auther, Title,  ISBN,  PublicationDate,  Genre,  AdditionalDetails,Image,  CreatedByUserID);
else
return null;

}

        public bool Save()
        {
            

            switch  (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBook())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateBook();

            }




            return false;
        }

public static DataTable GetAllBooks(){return clsBooksDataAccess.GetAllBooks();}
public static DataTable GetAllBooksUnAvailabel(){return clsBooksDataAccess.GetAllBooksUnAvailabel();}

public static bool DeleteBook(int BookID){return  clsBooksDataAccess.DeleteBook(BookID);}
static public bool IsAvailabel(int BookID){return  clsBooksDataAccess.IsAvailabel(BookID);}

public static bool isBookExist(int BookID){return clsBooksDataAccess.IsBookExist(BookID);}


}

}
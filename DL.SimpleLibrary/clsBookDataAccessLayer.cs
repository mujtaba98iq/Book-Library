using DL.SimpleLibrary;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace DB_Simple_LibraryDataAccessLayer
{
public static class clsBooksDataAccess
{
public static bool GetBookInfoByID(int BookID, ref string Auther, ref string Title, ref string ISBN, ref DateTime PublicationDate, ref string Genre, ref string AdditionalDetails, ref string Image,ref int CreatedByUserID)
{
	bool isFound = false;

	try
	{

using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
{
	string query = @"exec sp_GetBookInfoByID @BookID=@BookID";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{
	command.Parameters.AddWithValue("@BookID", BookID);

		connection.Open();
		using(SqlDataReader reader = command.ExecuteReader())
{

		if (reader.Read())
		{
			isFound = true;

			BookID = (int)reader["BookID"];
            Auther = (string)reader["Auther"];
			Title = (string)reader["Title"];
			ISBN = (string)reader["ISBN"];
			PublicationDate = (DateTime)reader["PublicationDate"];
			Genre = (string)reader["Genre"];
			AdditionalDetails = (string)reader["AdditionalDetails"];
			Image = (string)reader["Image"];
			CreatedByUserID = (int)reader["CreatedByUserID"];

		}
		else
		{
			isFound = false;
		}
}
}
}
	}
	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}
	return isFound;

}

public static bool GetBookInfoByTitle(ref int BookID, ref string Auther, string Title, ref string ISBN, ref DateTime PublicationDate, ref string Genre, ref string AdditionalDetails, ref string Image,ref int CreatedByUserID)
{
	bool isFound = false;

	try
	{

using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
{
	string query = @"exec sp_GetBookInfoByTitle @Title =@Title";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{
	command.Parameters.AddWithValue("@Title", Title);

		connection.Open();
		using(SqlDataReader reader = command.ExecuteReader())
{

		if (reader.Read())
		{
			isFound = true;

			BookID = (int)reader["BookID"];
            Auther = (string)reader["Auther"];
			Title = (string)reader["Title"];
			ISBN = (string)reader["ISBN"];
			PublicationDate = (DateTime)reader["PublicationDate"];
			Genre = (string)reader["Genre"];
			AdditionalDetails = (string)reader["AdditionalDetails"];
			Image = (string)reader["Image"];
			CreatedByUserID = (int)reader["CreatedByUserID"];

		}
		else
		{
			isFound = false;
		}
}
}
}
	}
	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}
	return isFound;

}
public static int AddNewBook( string Auther, string Title,  string ISBN,  DateTime PublicationDate,  string Genre,  string AdditionalDetails, string Image, int CreatedByUserID) {

    int ID = -1;
    try{
    using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
    {

        string query = @"exec sp_AddNewBook
                         @Title =@Title,
                         @Auther =@Auther,
                         @ISBN =@ISBN,
                         @PublicationDate =@PublicationDate,
                         @Genre =@Genre,
                         @AdditionalDetails =@AdditionalDetails,
                         @CreatedByUserID =@CreatedByUserID,
                         @Image =@Image";

    using (	SqlCommand command = new SqlCommand(query, connection))
        {

        
	command.Parameters.AddWithValue("@Auther", Auther);
	command.Parameters.AddWithValue("@Title", Title );

	command.Parameters.AddWithValue("@ISBN", ISBN );

	command.Parameters.AddWithValue("@PublicationDate", PublicationDate );

	command.Parameters.AddWithValue("@Genre", Genre );

	command.Parameters.AddWithValue("@AdditionalDetails", AdditionalDetails );
	command.Parameters.AddWithValue("@Image", Image);

	command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID );




                connection.Open();

                object result = command.ExecuteScalar();
            

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ID = insertedID;
                }
            }
        }          
    }
    
	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}
    return ID;

}


public static bool UpdateBook( int BookID,string Auther, string Title,  string ISBN,  DateTime PublicationDate,  string Genre,  string AdditionalDetails, string Image, int CreatedByUserID)
{
	int rowsAffected=0;

	try{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
	{

	string query = @"exec sp_UpdateBook
@BookID=@BookID,
Title = @Title,
Auther = @Auther,
	ISBN = @ISBN,
	PublicationDate = @PublicationDate,
	Genre = @Genre,
	AdditionalDetails = @AdditionalDetails,
	CreatedByUserID = @CreatedByUserID,
	Image = @Image";
	using(	SqlCommand command = new SqlCommand(query, connection)) 
		{


	command.Parameters.AddWithValue("@BookID", BookID );

	command.Parameters.AddWithValue("@Auther", Auther);
	command.Parameters.AddWithValue("@Title", Title );

	command.Parameters.AddWithValue("@ISBN", ISBN );

	command.Parameters.AddWithValue("@PublicationDate", PublicationDate );

	command.Parameters.AddWithValue("@Genre", Genre );

	command.Parameters.AddWithValue("@AdditionalDetails", AdditionalDetails );
	command.Parameters.AddWithValue("@Image", Image);

	command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID );


		connection.Open(); rowsAffected = command.ExecuteNonQuery();		}
	}
}

	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}
	return (rowsAffected > 0);

}
public static bool DeleteBook(int BookID)
{
	int rowsAffected = 0;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
{
	string query = @"exec sp_DeleteBook @BookID=@BookID";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{

	command.Parameters.AddWithValue("@BookID", BookID );

		connection.Open();
		rowsAffected = command.ExecuteNonQuery();
}
}
	}
	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}

	return (rowsAffected > 0);

}

public static bool IsBookExist(int BookID)
{
	bool isFound = false;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = @"exec sp_IsBookExist @BookID=34"; 
using(	SqlCommand command = new SqlCommand(query, connection)) 
{

	command.Parameters.AddWithValue("@BookID", BookID );

		connection.Open();
		using(SqlDataReader reader = command.ExecuteReader()){
			isFound = reader.HasRows;
}
}
}
	}
	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}

	return isFound;

}
		public static bool IsAvailabel(int BookID)
{
	bool isFound = false;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = "exec sp_IsAvailabel @BookID=@BookID"; 
using(	SqlCommand command = new SqlCommand(query, connection)) 
{

	command.Parameters.AddWithValue("@BookID", BookID );

		connection.Open();
		using(SqlDataReader reader = command.ExecuteReader()){
			isFound = reader.HasRows;
}
}
}
	}
	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}

	return isFound;

}

public static DataTable GetAllBooks()
{

	DataTable dt = new DataTable();

	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = "exec sp_GetAllBooks";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{
		connection.Open();
		using(SqlDataReader reader = command.ExecuteReader()){
		if (reader.HasRows)dt.Load(reader);
		reader.Close();
}
}
	}}

	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}

	return dt;
}

public static DataTable GetAllBooksUnAvailabel()
{

	DataTable dt = new DataTable();

	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = @"exec sp_GetAllBooksUnAvailabel";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{
		connection.Open();
		using(SqlDataReader reader = command.ExecuteReader()){
		if (reader.HasRows)dt.Load(reader);
		reader.Close();
}
}
	}}

	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}

	return dt;
}


}

}
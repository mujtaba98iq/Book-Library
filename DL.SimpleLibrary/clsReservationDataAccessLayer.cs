using DL.SimpleLibrary;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DB_Simple_LibraryDataAccessLayer
{
public static class clsReservationsDataAccess
{
public static bool GetReservationInfoByID(int ReservationID, ref int UserID, ref int BookID, ref DateTime ReservationDate, ref int CreatedByUserID)
{
	bool isFound = false;

	try
	{

using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
{
	string query = "exec sp_GetReservationInfoByID @ReservationID= @ReservationID";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{
	command.Parameters.AddWithValue("@ReservationID", ReservationID);

		connection.Open();
		using(SqlDataReader reader = command.ExecuteReader())
{

		if (reader.Read())
		{
			isFound = true;

			ReservationID = (int)reader["ReservationID"];
			UserID = (int)reader["UserID"];
			BookID = (int)reader["BookID"];
			ReservationDate = (DateTime)reader["ReservationDate"];
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

public static bool GetReservationInfoByUserIDAndBookID(ref int ReservationID,  int UserID,  int BookID, ref DateTime ReservationDate, ref int CreatedByUserID)
{
	bool isFound = false;

	try
	{

using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
{
	string query = "exec sp_GetReservationInfoByUserIDAndBookID UserID = @UserID , BookID=@BookID;";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{
	command.Parameters.AddWithValue("@UserID", UserID);
	command.Parameters.AddWithValue("@BookID", BookID);

		connection.Open();
		using(SqlDataReader reader = command.ExecuteReader())
{

		if (reader.Read())
		{
			isFound = true;

			ReservationID = (int)reader["ReservationID"];
			UserID = (int)reader["UserID"];
			BookID = (int)reader["BookID"];
			ReservationDate = (DateTime)reader["ReservationDate"];
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
public static int AddNewReservation( int UserID,  int BookID,  DateTime ReservationDate) {

    int ID = -1;
    try{
    using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
    {

        string query = @"exec sp_AddNewReservation
                               @BookID=@BookID,
                               @UserID=@UserID,
                               @ReservationDate=@ReservationDate";

    using (	SqlCommand command = new SqlCommand(query, connection))
        {

        
	command.Parameters.AddWithValue("@UserID", UserID );

	command.Parameters.AddWithValue("@BookID", BookID );

	command.Parameters.AddWithValue("@ReservationDate", ReservationDate );





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


public static bool UpdateReservation( int ReservationID,  int UserID,  int BookID,  DateTime ReservationDate)
{
	int rowsAffected=0;

	try{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
	{

	string query = @"exec sp_UpdateReservation
                      @ReservationID=@ReservationID,
                      @BookID=@BookID,
                      @UserID=@UserID,
                      @ReservationDate=@ReservationDate";
	using(	SqlCommand command = new SqlCommand(query, connection)) 
		{


	command.Parameters.AddWithValue("@ReservationID", ReservationID );

	command.Parameters.AddWithValue("@UserID", UserID );

	command.Parameters.AddWithValue("@BookID", BookID );

	command.Parameters.AddWithValue("@ReservationDate", ReservationDate );



		connection.Open(); rowsAffected = command.ExecuteNonQuery();		}
	}
}

	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}
	return (rowsAffected > 0);

}
public static bool DeleteReservation(int ReservationID)
{
	int rowsAffected = 0;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
{
	string query = "exec sp_DeleteReservation @ReservationID=@ReservationID";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{

	command.Parameters.AddWithValue("@ReservationID", ReservationID );

		connection.Open();
		rowsAffected = command.ExecuteNonQuery();
}
}
	}
	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}

	return (rowsAffected > 0);

}

public static bool IsReservationExist(int ReservationID)
{
	bool isFound = false;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = "exec sp_IsReservationExist @ReservationID= @ReservationID"; 
using(	SqlCommand command = new SqlCommand(query, connection)) 
{

	command.Parameters.AddWithValue("@ReservationID", ReservationID );

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
public static bool isUserReserveThisBook(int UserID,int BookID)
{
	bool isFound = false;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = "exec sp_isUserReserveThisBook UserID= @UserID , BookID=@BookID"; 
using(	SqlCommand command = new SqlCommand(query, connection)) 
{

	command.Parameters.AddWithValue("@UserID", UserID);
	command.Parameters.AddWithValue("@BookID", BookID);

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

public static DataTable GetAllReservations()
{

	DataTable dt = new DataTable();

	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = "exec sp_GetAllReservations";
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
using DL.SimpleLibrary;
using System;
using System.Data;
using Microsoft.Data.SqlClient;


namespace DB_Simple_LibraryDataAccessLayer
{
public static class clsNotificaitonsDataAccess
{
public static bool GetNotificationInfoByID(int NotificationID, ref int UserID, ref string Description)
{
	bool isFound = false;

	try
	{

using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
{
	string query = @"exec sp_GetNotificationInfoByID @NotificationID = @NotificationID";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{
	command.Parameters.AddWithValue("@NotificationID", NotificationID);

		connection.Open();
		using(SqlDataReader reader = command.ExecuteReader())
{

		if (reader.Read())
		{
			isFound = true;

			NotificationID = (int)reader["NotificationID"];
			UserID = (int)reader["UserID"];
			Description = (string)reader["Description"];

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
public static int AddNewNotification( int UserID,  string Description) {

    int ID = -1;
    try{
    using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
    {

        string query = @"exec sp_AddNewNotification
                        @UserID=@UserID,
                        @Description=@Description";

    using (	SqlCommand command = new SqlCommand(query, connection))
        {

        
	command.Parameters.AddWithValue("@UserID", UserID );

	command.Parameters.AddWithValue("@Description", Description );




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


public static bool UpdateNotification( int NotificationID,  int UserID,  string Description)
{
	int rowsAffected=0;

	try{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
	{

	string query = @"exec sp_UpdateNotification
                    @NotificationID=@NotificationID,
                    @UserID=@UserID,
                    @Description=@Description";
	using(	SqlCommand command = new SqlCommand(query, connection)) 
		{


	command.Parameters.AddWithValue("@NotificationID", NotificationID );

	command.Parameters.AddWithValue("@UserID", UserID );

	command.Parameters.AddWithValue("@Description", Description );


		connection.Open(); rowsAffected = command.ExecuteNonQuery();		}
	}
}

	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}
	return (rowsAffected > 0);

}
public static bool DeleteNotification(int NotificationID)
{
	int rowsAffected = 0;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
{
	string query = @"exec sp_DeleteNotification @NotificationID= @NotificationID";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{

	command.Parameters.AddWithValue("@NotificationID", NotificationID );

		connection.Open();
		rowsAffected = command.ExecuteNonQuery();
}
}
	}
	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}

	return (rowsAffected > 0);

}
public static bool DeleteAllNotificationsForUserID(int UserID)
{
	int rowsAffected = 0;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
{
	string query = "exec sp_DeleteAllNotificationsForUserID @UserID=@UserID;";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{
                        command.Parameters.AddWithValue("@UserID", UserID);



                        connection.Open();
		rowsAffected = command.ExecuteNonQuery();
}
}
	}
	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}

	return (rowsAffected > 0);

}

public static bool IsNotificationExist(int NotificationID)
{
	bool isFound = false;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = "exec sp_IsNotificationExist @NotificationID=@NotificationID"; 
using(	SqlCommand command = new SqlCommand(query, connection)) 
{

	command.Parameters.AddWithValue("@NotificationID", NotificationID );

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

public static DataTable GetAllNotificaitons()
{

	DataTable dt = new DataTable();

	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = "exec sp_GetAllNotificaitons";
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

public static DataTable GetAllNotificaitonsForUser(int UserID)
{

	DataTable dt = new DataTable();

			try
			{
				using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
				{
					string query = @"exec sp_GetAllNotificaitonsForUser @UserID=@UserID";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@UserID", UserID);
						{
							connection.Open();
							using (SqlDataReader reader = command.ExecuteReader())
							{
								if (reader.HasRows) dt.Load(reader);
								reader.Close();
							}
						}
					}
				}
			}

			catch (Exception ex) { clsErrorHandling.HandleError(ex.ToString()); }

	return dt;
}


}

}
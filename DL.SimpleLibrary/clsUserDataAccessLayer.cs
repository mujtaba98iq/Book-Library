using DL.SimpleLibrary;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DB_Simple_LibraryDataAccessLayer
{
public static class clsUsersDataAccess
{
public static bool GetUserInfoByID(int UserID, ref int PersonID, ref string UserName, ref string LibraryCardNumber, ref bool IsActive,ref bool IsAdmin,ref DateTime DateTime, ref int CreatedByUserID)
{
	bool isFound = false;

	try
	{

using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
{
	string query = "SELECT * FROM Users WHERE UserID = @UserID";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{
	command.Parameters.AddWithValue("@UserID", UserID);

		connection.Open();
		using(SqlDataReader reader = command.ExecuteReader())
{

		if (reader.Read())
		{
			isFound = true;

			UserID = (int)reader["UserID"];
			PersonID = (int)reader["PersonID"];
			UserName = (string)reader["UserName"];
			LibraryCardNumber = (string)reader["LibraryCardNumber"];
			IsActive = (bool)reader["IsActive"];
                                IsAdmin = (bool)reader["IsAdmin"];
        
                                CreatedByUserID = (int)reader["CreatedByUserID"];
			DateTime = (DateTime)reader["DateTime"];

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

        public static bool GetUserInfoByIDUserNameAndLibraryCardNumber(ref int UserID, ref int PersonID,  string UserName,  string LibraryCardNumber, ref bool IsActive, ref bool IsAdmin,ref DateTime DateTime ,ref int CreatedByUserID)
        {
            bool isFound = false;

            try
            {


                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "SELECT * FROM Users WHERE UserName = @UserName and LibraryCardNumber=@LibraryCardNumber";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@LibraryCardNumber", LibraryCardNumber);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;

                                UserID = (int)reader["UserID"];
                                PersonID = (int)reader["PersonID"];
                                UserName = (string)reader["UserName"];
                                LibraryCardNumber = (string)reader["LibraryCardNumber"];
                                IsActive = (bool)reader["IsActive"];
                                IsAdmin = (bool)reader["IsAdmin"];
                                DateTime = (DateTime)reader["DateTime"];
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
            catch (Exception ex) { clsErrorHandling.HandleError(ex.ToString()); }
            return isFound;

        }
        public static int AddNewUser( int PersonID,  string UserName,  string LibraryCardNumber,  bool IsActive,  bool IsAdmin,DateTime DateTime, int CreatedByUserID) {

    int ID = -1;
    try{
    using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
    {

        string query = @"INSERT INTO Users VALUES (@PersonID, @UserName, @LibraryCardNumber, @IsActive,@IsAdmin, @DateTime,@CreatedByUserID)
        SELECT SCOPE_IDENTITY()";

    using (	SqlCommand command = new SqlCommand(query, connection))
        {

        
	command.Parameters.AddWithValue("@PersonID", PersonID );

	command.Parameters.AddWithValue("@UserName", UserName );

	command.Parameters.AddWithValue("@LibraryCardNumber", LibraryCardNumber );

	command.Parameters.AddWithValue("@IsActive", IsActive );
	command.Parameters.AddWithValue("@IsAdmin", IsAdmin);
	command.Parameters.AddWithValue("@DateTime", DateTime);

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


public static bool UpdateUser( int UserID,  int PersonID,  string UserName,  string LibraryCardNumber,  bool IsActive, bool IsAdmin,DateTime DateTime, int CreatedByUserID)
{
	int rowsAffected=0;

	try{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
	{

	string query = @"UPDATE Users
	SET	PersonID = @PersonID,
	UserName = @UserName,
	LibraryCardNumber = @LibraryCardNumber,
	IsActive = @IsActive,
	IsAdmin = @IsAdmin,
	DateTime = @DateTime,
	CreatedByUserID = @CreatedByUserID	WHERE UserID = @UserID";
	using(	SqlCommand command = new SqlCommand(query, connection)) 
		{


	command.Parameters.AddWithValue("@UserID", UserID );

	command.Parameters.AddWithValue("@PersonID", PersonID );

	command.Parameters.AddWithValue("@UserName", UserName );

	command.Parameters.AddWithValue("@LibraryCardNumber", LibraryCardNumber );

	command.Parameters.AddWithValue("@IsActive", IsActive );
	command.Parameters.AddWithValue("@IsAdmin", IsAdmin);
	command.Parameters.AddWithValue("@DateTime", DateTime);

	command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID );


		connection.Open(); rowsAffected = command.ExecuteNonQuery();		}
	}
}

	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}
	return (rowsAffected > 0);

}
public static bool DeleteUser(int UserID)
{
	int rowsAffected = 0;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
{
	string query = "DELETE Users WHERE UserID = @UserID";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{

	command.Parameters.AddWithValue("@UserID", UserID );

		connection.Open();
		rowsAffected = command.ExecuteNonQuery();
}
}
	}
	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}

	return (rowsAffected > 0);

}

public static bool IsUserExist(int UserID)
{
	bool isFound = false;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = "SELECT Found=1 FROM Users WHERE UserID= @UserID"; 
using(	SqlCommand command = new SqlCommand(query, connection)) 
{

	command.Parameters.AddWithValue("@UserID", UserID );

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
		public static bool IsUserAdmin(int UserID)
{
	bool isAdmin = false;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = "select IsAdmin=1 from Users where UserID=@UserID and IsAdmin=1"; 
using(	SqlCommand command = new SqlCommand(query, connection)) 
{

	command.Parameters.AddWithValue("@UserID", UserID );

		connection.Open();
		using(SqlDataReader reader = command.ExecuteReader()){
                            isAdmin = reader.HasRows;
}
}
}
	}
	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}

	return isAdmin;

}
public static bool IsUserExistByUserName(string UserName)
{
	bool isFound = false;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = "SELECT Found=1 FROM Users WHERE UserName= @UserName"; 
using(	SqlCommand command = new SqlCommand(query, connection)) 
{

	command.Parameters.AddWithValue("@UserName", UserName);

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

public static DataTable GetAllUsers()
{

	DataTable dt = new DataTable();

	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = "SELECT * FROM Users";
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

public static DataTable GetNewUsers()
{

	DataTable dt = new DataTable();

	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = @"SELECT   Top 5   People.FirstName +' '+ People.SecondName as Name, People.Email, Users.DateTime
                       FROM            People INNER JOIN
                         Users ON People.PersonID = Users.PersonID";
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
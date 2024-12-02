using DL.SimpleLibrary;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DB_Simple_LibraryDataAccessLayer
{
public static class clsPeopleDataAccess
{
public static bool GetPersonInfoByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath, ref int CreatedByUserID)
{
	bool isFound = false;

	try
	{

using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
{
	string query = "exec sp_GetPersonInfoByID @PersonID=@PersonID";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{
	command.Parameters.AddWithValue("@PersonID", PersonID);

		connection.Open();
		using(SqlDataReader reader = command.ExecuteReader())
{

		if (reader.Read())
		{
			isFound = true;

			PersonID = (int)reader["PersonID"];
			NationalNo = (string)reader["NationalNo"];
			FirstName = (string)reader["FirstName"];
			SecondName = (string)reader["SecondName"];
			ThirdName = reader["ThirdName"] != DBNull.Value ?(string)reader["ThirdName"] : ThirdName = default;
			LastName = (string)reader["LastName"];
			DateOfBirth = (DateTime)reader["DateOfBirth"];
			Gendor = (byte)reader["Gendor"];
			Address = (string)reader["Address"];
			Phone = (string)reader["Phone"];
			Email = reader["Email"] != DBNull.Value ?(string)reader["Email"] : Email = default;
			NationalityCountryID = (int)reader["NationalityCountryID"];
			ImagePath = reader["ImagePath"] != DBNull.Value ?(string)reader["ImagePath"] : ImagePath = default;
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

}public static bool GetPersonInfoByIDNationalNo(ref int PersonID, string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref byte Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath, ref int CreatedByUserID)
{
	bool isFound = false;

	try
	{

using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
{
	string query = @"exec sp_GetPersonInfoByIDNationalNo
                 @NationalNo=@NationalNo";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{
	command.Parameters.AddWithValue("@NationalNo", NationalNo);

		connection.Open();
		using(SqlDataReader reader = command.ExecuteReader())
{

		if (reader.Read())
		{
			isFound = true;

			PersonID = (int)reader["PersonID"];
			NationalNo = (string)reader["NationalNo"];
			FirstName = (string)reader["FirstName"];
			SecondName = (string)reader["SecondName"];
			ThirdName = reader["ThirdName"] != DBNull.Value ?(string)reader["ThirdName"] : ThirdName = default;
			LastName = (string)reader["LastName"];
			DateOfBirth = (DateTime)reader["DateOfBirth"];
			Gendor = (byte)reader["Gendor"];
			Address = (string)reader["Address"];
			Phone = (string)reader["Phone"];
			Email = reader["Email"] != DBNull.Value ?(string)reader["Email"] : Email = default;
			NationalityCountryID = (int)reader["NationalityCountryID"];
			ImagePath = reader["ImagePath"] != DBNull.Value ?(string)reader["ImagePath"] : ImagePath = default;
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
public static int AddNewPerson( string NationalNo,  string FirstName,  string SecondName,  string ThirdName,  string LastName,  DateTime DateOfBirth,  byte Gendor,  string Address,  string Phone,  string Email,  int NationalityCountryID,  string ImagePath,  int CreatedByUserID) {

    int ID = -1;
    try{
    using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
    {

        string query = @"exec sp_AddNewPerson
                           @NationalNo=@NationalNo,
                           @FirstName=@FirstName,
                           @SecondName=@SecondName,
                           @ThirdName=@ThirdName,
                           @LastName=@LastName,
                           @DateOfBirth=@DateOfBirth,
                           @Gendor=@Gendor,
                           @Address=@Address,
                           @Phone=@Phone,
                           @Email=@Email,
                           @NationalityCountryID=@NationalityCountryID,
                           @ImagePath=@ImagePath,
                           @CreatedByUserID=@CreatedByUserID";

    using (	SqlCommand command = new SqlCommand(query, connection))
        {

        
	command.Parameters.AddWithValue("@NationalNo", NationalNo );

	command.Parameters.AddWithValue("@FirstName", FirstName );

	command.Parameters.AddWithValue("@SecondName", SecondName );

	if(ThirdName == null)
		command.Parameters.AddWithValue("@ThirdName", DBNull.Value );
	else
		command.Parameters.AddWithValue("@ThirdName", ThirdName );
	command.Parameters.AddWithValue("@LastName", LastName );

	command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth );

	command.Parameters.AddWithValue("@Gendor", Gendor );

	command.Parameters.AddWithValue("@Address", Address );

	command.Parameters.AddWithValue("@Phone", Phone );

	if(Email == null)
		command.Parameters.AddWithValue("@Email", DBNull.Value );
	else
		command.Parameters.AddWithValue("@Email", Email );
	command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID );

	if(ImagePath == null)
		command.Parameters.AddWithValue("@ImagePath", DBNull.Value );
	else
		command.Parameters.AddWithValue("@ImagePath", ImagePath );
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


public static bool UpdatePerson( int PersonID,  string NationalNo,  string FirstName,  string SecondName,  string ThirdName,  string LastName,  DateTime DateOfBirth,  byte Gendor,  string Address,  string Phone,  string Email,  int NationalityCountryID,  string ImagePath,  int CreatedByUserID)
{
	int rowsAffected=0;

	try{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
	{

	string query = @"exec sp_UpdatePerson
                           @PersonID=@PersonID,
                           @NationalNo=@NationalNo,
                           @FirstName=@FirstName,
                           @SecondName=@SecondName,
                           @ThirdName=@ThirdName,
                           @LastName=@LastName,
                           @DateOfBirth=@DateOfBirth,
                           @Gendor=@Gendor,
                           @Address=@Address,
                           @Phone=@Phone,
                           @Email=@Email,
                           @NationalityCountryID=@NationalityCountryID,
                           @ImagePath=@ImagePath,
                           @CreatedByUserID=@CreatedByUserID";
	using(	SqlCommand command = new SqlCommand(query, connection)) 
		{


	command.Parameters.AddWithValue("@PersonID", PersonID );

	command.Parameters.AddWithValue("@NationalNo", NationalNo );

	command.Parameters.AddWithValue("@FirstName", FirstName );

	command.Parameters.AddWithValue("@SecondName", SecondName );

	if(ThirdName == null)
		command.Parameters.AddWithValue("@ThirdName", DBNull.Value );
	else
		command.Parameters.AddWithValue("@ThirdName", ThirdName );
	command.Parameters.AddWithValue("@LastName", LastName );

	command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth );

	command.Parameters.AddWithValue("@Gendor", Gendor );

	command.Parameters.AddWithValue("@Address", Address );

	command.Parameters.AddWithValue("@Phone", Phone );

	if(Email == null)
		command.Parameters.AddWithValue("@Email", DBNull.Value );
	else
		command.Parameters.AddWithValue("@Email", Email );
	command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID );

	if(ImagePath == null)
		command.Parameters.AddWithValue("@ImagePath", DBNull.Value );
	else
		command.Parameters.AddWithValue("@ImagePath", ImagePath );
	command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID );


		connection.Open(); rowsAffected = command.ExecuteNonQuery();		}
	}
}

	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}
	return (rowsAffected > 0);

}
public static bool DeletePerson(int PersonID)
{
	int rowsAffected = 0;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
{
	string query = @"exec sp_DeletePerson @PersonID= @PersonID";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{

	command.Parameters.AddWithValue("@PersonID", PersonID );

		connection.Open();
		rowsAffected = command.ExecuteNonQuery();
}
}
	}
	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}

	return (rowsAffected > 0);

}

public static bool IsPersonExist(int PersonID)
{
	bool isFound = false;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = @"exec sp_IsPersonExist @PersonID=@PersonID"; 
using(	SqlCommand command = new SqlCommand(query, connection)) 
{

	command.Parameters.AddWithValue("@PersonID", PersonID );

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
		
public static bool IsPersonExistByNationalNo(string NationalNo)
{
	bool isFound = false;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = @"exec sp_IsPersonExistByNationalNo @NationalNo= @NationalNo"; 
using(	SqlCommand command = new SqlCommand(query, connection)) 
{

	command.Parameters.AddWithValue("@NationalNo", NationalNo);

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

public static DataTable GetAllPeople()
{

	DataTable dt = new DataTable();

	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = "exec sp_GetALlPeople";
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
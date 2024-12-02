using DL.SimpleLibrary;
using System;
using System.Data;
using Microsoft.Data.SqlClient;


namespace DB_Simple_LibraryDataAccessLayer
{
public static class clsSettingsDataAccess
{
public static bool GetDefualtBorrowDaInfoByID(byte DefualtBorrowDays, ref byte DefualtFineDay)
{
	bool isFound = false;

	try
	{

using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
{
	string query = "SELECT * FROM Settings WHERE DefualtBorrowDays = @DefualtBorrowDays";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{
	command.Parameters.AddWithValue("@DefualtBorrowDays", DefualtBorrowDays);

		connection.Open();
		using(SqlDataReader reader = command.ExecuteReader())
{

		if (reader.Read())
		{
			isFound = true;

			DefualtBorrowDays = (byte)reader["DefualtBorrowDays"];
			DefualtFineDay = (byte)reader["DefualtFineDay"];

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
public static int AddNewDefualtBorrowDa( byte DefualtFineDay) {

    int ID = -1;
    try{
    using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
    {

        string query = @"
INSERT INTO [dbo].[Settings]
           ([DefualtBorrowDays]
           ,[DefualtFineDay])
     VALUES
           (1,2)
        SELECT SCOPE_IDENTITY()";

    using (	SqlCommand command = new SqlCommand(query, connection))
        {

        
	command.Parameters.AddWithValue("@DefualtFineDay", DefualtFineDay );




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

		public static int GetDeffultBorrowDays( ) {

    int NumberOfDays = -1;
    try{
    using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
    {

        string query = @"exec sp_GetDeffultBorrowDays";

    using (	SqlCommand command = new SqlCommand(query, connection))
        {

        




                connection.Open();

                object result = command.ExecuteScalar();
            

                if (result != null && int.TryParse(result.ToString(), out int Days))
                {
                            NumberOfDays = Days;
                }
            }
        }          
    }
    
	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}
    return NumberOfDays;

}
		
		public static int GetDeffultBorrowCost( ) {

    int NumberOfDays = -1;
    try{
    using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
    {

        string query = @"exec sp_GetDeffultBorrowCost";

    using (	SqlCommand command = new SqlCommand(query, connection))
        {

        




                connection.Open();

                object result = command.ExecuteScalar();
            

                if (result != null && int.TryParse(result.ToString(), out int Days))
                {
                            NumberOfDays = Days;
                }
            }
        }          
    }
    
	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}
    return NumberOfDays;

}


public static bool UpdateDefualtBorrowDa( byte DefualtBorrowDays,  byte DefualtFineDay)
{
	int rowsAffected=0;

	try{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
	{

	string query = @"UPDATE Settings
	SET	DefualtFineDay = @DefualtFineDay	WHERE DefualtBorrowDays = @DefualtBorrowDays";
	using(	SqlCommand command = new SqlCommand(query, connection)) 
		{


	command.Parameters.AddWithValue("@DefualtBorrowDays", DefualtBorrowDays );

	command.Parameters.AddWithValue("@DefualtFineDay", DefualtFineDay );


		connection.Open(); rowsAffected = command.ExecuteNonQuery();		}
	}
}

	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}
	return (rowsAffected > 0);

}
public static bool DeleteDefualtBorrowDa(byte DefualtBorrowDays)
{
	int rowsAffected = 0;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
{
	string query = "DELETE Settings WHERE DefualtBorrowDays = @DefualtBorrowDays";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{

	command.Parameters.AddWithValue("@DefualtBorrowDays", DefualtBorrowDays );

		connection.Open();
		rowsAffected = command.ExecuteNonQuery();
}
}
	}
	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}

	return (rowsAffected > 0);

}

public static bool IsDefualtBorrowDaExist(byte DefualtBorrowDays)
{
	bool isFound = false;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = "SELECT Found=1 FROM Settings WHERE DefualtBorrowDays= @DefualtBorrowDays"; 
using(	SqlCommand command = new SqlCommand(query, connection)) 
{

	command.Parameters.AddWithValue("@DefualtBorrowDays", DefualtBorrowDays );

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

public static DataTable GetAllSettings()
{

	DataTable dt = new DataTable();

	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = "SELECT * FROM Settings";
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
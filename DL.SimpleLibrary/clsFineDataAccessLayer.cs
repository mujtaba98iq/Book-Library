using DL.SimpleLibrary;
using System;
using System.Data;
using Microsoft.Data.SqlClient;


namespace DB_Simple_LibraryDataAccessLayer
{
public static class clsFinesDataAccess
{
public static bool GetFineInfoByID(int FineID, ref int UserID, ref int DorrowingRecordID, ref short NumberOfLateDays, ref decimal FineAmount, ref bool PaymentStatus, ref int CreatedByUserID)
{
	bool isFound = false;

	try
	{

using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
{
	string query = "exec sp_GetFineInfoByID @FineID= @FineID";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{
	command.Parameters.AddWithValue("@FineID", FineID);

		connection.Open();
		using(SqlDataReader reader = command.ExecuteReader())
{

		if (reader.Read())
		{
			isFound = true;

			FineID = (int)reader["FineID"];
			UserID = (int)reader["UserID"];
			DorrowingRecordID = (int)reader["DorrowingRecordID"];
			NumberOfLateDays = (short)reader["NumberOfLateDays"];
			FineAmount = (decimal)reader["FineAmount"];
			PaymentStatus = (bool)reader["PaymentStatus"];
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
public static int AddNewFine( int UserID,  int DorrowingRecordID,  short NumberOfLateDays,  decimal FineAmount,  bool PaymentStatus,  int CreatedByUserID) {

    int ID = -1;
    try{
    using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
    {

        string query = @"exec sp_AddNewFine
                       @UserID=@UserID,
                       @DorrowingRecordID=@DorrowingRecordID,
                       @NumberOfLateDays=@NumberOfLateDays,
                       @FineAmount=@FineAmount,
                       @PaymentStatus=@PaymentStatus,
                       @CreatedByUserID=@CreatedByUserID";

    using (	SqlCommand command = new SqlCommand(query, connection))
        {

        
	command.Parameters.AddWithValue("@UserID", UserID );

	command.Parameters.AddWithValue("@DorrowingRecordID", DorrowingRecordID );

	command.Parameters.AddWithValue("@NumberOfLateDays", NumberOfLateDays );

	command.Parameters.AddWithValue("@FineAmount", FineAmount );

	command.Parameters.AddWithValue("@PaymentStatus", PaymentStatus );

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


public static bool UpdateFine( int FineID,  int UserID,  int DorrowingRecordID,  short NumberOfLateDays,  decimal FineAmount,  bool PaymentStatus,  int CreatedByUserID)
{
	int rowsAffected=0;

	try{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
	{

	string query = @"exec sp_UpdateFine
                    @fineID=@fineID,
                     @UserID=@UserID,
                       @DorrowingRecordID=@DorrowingRecordID,
                       @NumberOfLateDays=@NumberOfLateDays,
                       @FineAmount=@FineAmount,
                       @PaymentStatus=@PaymentStatus,
                       @CreatedByUserID=@CreatedByUserID";
	using(	SqlCommand command = new SqlCommand(query, connection)) 
		{


	command.Parameters.AddWithValue("@FineID", FineID );

	command.Parameters.AddWithValue("@UserID", UserID );

	command.Parameters.AddWithValue("@DorrowingRecordID", DorrowingRecordID );

	command.Parameters.AddWithValue("@NumberOfLateDays", NumberOfLateDays );

	command.Parameters.AddWithValue("@FineAmount", FineAmount );

	command.Parameters.AddWithValue("@PaymentStatus", PaymentStatus );

	command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID );


		connection.Open(); rowsAffected = command.ExecuteNonQuery();		}
	}
}

	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}
	return (rowsAffected > 0);

}
public static bool DeleteFine(int FineID)
{
	int rowsAffected = 0;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
{
	string query = "exec sp_DeleteFine @fineID= @FineID";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{

	command.Parameters.AddWithValue("@FineID", FineID );

		connection.Open();
		rowsAffected = command.ExecuteNonQuery();
}
}
	}
	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}

	return (rowsAffected > 0);

}

public static bool IsFineExist(int FineID)
{
	bool isFound = false;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = "exec sp_IsFineExist @fineID= @FineID"; 
using(	SqlCommand command = new SqlCommand(query, connection)) 
{

	command.Parameters.AddWithValue("@FineID", FineID );

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
        public static DataTable GetAllFines()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "EXEC sp_GetAllFines";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader); 
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsErrorHandling.HandleError(ex.ToString());
            }

            return dt;
        }

        public static decimal GetSumFineAmount()
{

	decimal SumFineAmount = 0;

	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = "exec sp_GetSumFineAmount";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{
		connection.Open();
                        object result = command.ExecuteScalar();


                        if (result != null && decimal.TryParse(result.ToString(), out decimal FineAmount))
                        {
                            SumFineAmount = FineAmount;
                        }
                    }
}
	}

	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}

	return SumFineAmount;
}


}

}
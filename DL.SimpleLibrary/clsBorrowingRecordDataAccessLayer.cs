using DL.SimpleLibrary;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace DB_Simple_LibraryDataAccessLayer
{
public static class clsBorrowingRecordsDataAccess
    {
        public static bool GetBorrowingRecordInfoByID(int BorrowingRecordID, ref int UserID, ref int CopyID, ref DateTime BorrowingDate, ref DateTime DueDate, ref DateTime ActualReturnDate, ref decimal BorrowCost)
        {
            bool isFound = false;

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string query = "exec sp_GetBorrowingRecordInfoByID @BorrowingRecordID= @BorrowingRecordID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                isFound = true;

                                BorrowingRecordID = (int)reader["BorrowingRecordID"];
                                UserID = (int)reader["UserID"];
                                CopyID = (int)reader["CopyID"];
                                BorrowingDate = (DateTime)reader["BorrowingDate"];
                                DueDate = (DateTime)reader["DueDate"];
                                ActualReturnDate = reader["ActualReturnDate"] != DBNull.Value ? (DateTime)reader["ActualReturnDate"] : ActualReturnDate = default;
                                BorrowCost = (decimal)reader["BorrowCost"];

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
        public static int AddNewBorrowingRecord(int UserID, int CopyID, DateTime BorrowingDate, DateTime DueDate, DateTime ActualReturnDate, decimal BorrowCost)
        {

          

                    int ID = -1;
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                        {

                    string query = @"exec sp_AddNewBorrowingRecord
@UserID=@UserID,
@CopyID=@CopyID,
@BorrowingDate=@BorrowingDate,
@DueDate=@DueDate,
@BorrowCost=@BorrowCost";


                    using (SqlCommand command = new SqlCommand(query, connection))
                            {


                        command.Parameters.AddWithValue("@UserID", UserID);
                        command.Parameters.AddWithValue("@CopyID", CopyID);

                        command.Parameters.AddWithValue("@BorrowingDate", BorrowingDate);

                        command.Parameters.AddWithValue("@DueDate", DueDate);
                        if (ActualReturnDate == DateTime.MinValue)
                            command.Parameters.AddWithValue("@ActualReturnDate", DBNull.Value);
                       else
                            command.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);

                            command.Parameters.AddWithValue("@BorrowCost", BorrowCost);
                     

                        connection.Open();

                                object result = command.ExecuteScalar();


                                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                                {
                                    ID = insertedID;
                                }
                            }
                        }
                    }

                    catch (Exception ex) { clsErrorHandling.HandleError(ex.ToString()); }
                    return ID;
                }

        public static int GetLateDays(int BorrowingRecordID)
        {
                   int NumberOfDays = -1;
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                        {

                    string query = @"Execute sp_GetDeffrenceDate @RecordID=@BorrowingRecordID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                            {


                        command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);
                     
                        connection.Open();

                                object result = command.ExecuteScalar();


                                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                                {
                            NumberOfDays = insertedID;
                                }
                            }
                        }
                    }

                    catch (Exception ex) { clsErrorHandling.HandleError(ex.ToString()); }
                    return NumberOfDays;
                }


        public static bool UpdateBorrowingRecord(int BorrowingRecordID, int UserID, int CopyID, DateTime BorrowingDate, DateTime DueDate, DateTime ActualReturnDate, decimal BorrowCost)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"exec sp_UpdateBorrowingRecord
	@BorrowingRecordID=@BorrowingRecordID,

           @UserID=@UserID,
           @CopyID=@CopyID,
           @BorrowingDate=@BorrowingDate,
           @ActualReturnDate=@ActualReturnDate,
           @DueDate=@DueDate,
           @BorrowCost=@BorrowCost";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {


                        command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID);

                        command.Parameters.AddWithValue("@UserID", UserID);

                        command.Parameters.AddWithValue("@CopyID", CopyID);

                        command.Parameters.AddWithValue("@BorrowingDate", BorrowingDate);

                        command.Parameters.AddWithValue("@DueDate", DueDate);

                        if (ActualReturnDate == null)
                            command.Parameters.AddWithValue("@ActualReturnDate", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);
                        command.Parameters.AddWithValue("@BorrowCost", BorrowCost);


                        connection.Open(); rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex) { clsErrorHandling.HandleError(ex.ToString()); }
            return (rowsAffected > 0);

        }
        public static bool DeleteBorrowingRecord(int BorrowingRecordID)
{
	int rowsAffected = 0;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
{
	string query = "exec sp_DeleteBorrowingRecord @BorrowingRecordID= @BorrowingRecordID";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{

	command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID );

		connection.Open();
		rowsAffected = command.ExecuteNonQuery();
}
}
	}
	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}

	return (rowsAffected > 0);

}
        public static bool ReturnBook(int BorrowingRecordID,int CopyID)
{
	int rowsAffected = 0;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) 
{
	string query = @"exec sp_ReturnBook
@BorrowingRecordID=@BorrowingRecordID,
@CopyID=@CopyID;";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{

	command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID );
	command.Parameters.AddWithValue("@CopyID", CopyID);

		connection.Open();
		rowsAffected = command.ExecuteNonQuery();
}
}
	}
	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}

	return (rowsAffected > 0);

}

public static bool IsBorrowingRecordExist(int BorrowingRecordID)
{
	bool isFound = false;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = "exec sp_IsBorrowingRecordExist @BorrowingRecordID=@BorrowingRecordID"; 
using(	SqlCommand command = new SqlCommand(query, connection)) 
{

	command.Parameters.AddWithValue("@BorrowingRecordID", BorrowingRecordID );

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

public static bool IsUserBorrowBook(int BookID, int UserID)
{
	bool isFound = false;
	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = @"exec sp_IsUserBorrowBook
@BookID=@BookID,@UserID=@UserID
"; 
using(	SqlCommand command = new SqlCommand(query, connection))
                    {

	command.Parameters.AddWithValue("@BookID", BookID);
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

public static DataTable GetAllBooksBorrowingForUser(int UserID)
{

	DataTable dt = new DataTable();

	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = @"exec sp_GetAllBooksBorrowingForUser @UserID=@UserID";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{
                        command.Parameters.AddWithValue("@UserID", UserID);
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
        

public static DataTable GetTop5BooksBorrowing()
{

	DataTable dt = new DataTable();

	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = @"exec sp_GetTop5BooksBorrowing";
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

public static decimal GetSumOfBilling()
{

            decimal SumBilling = 0;

	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = @"exec sp_GetSumOfBilling";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{
		connection.Open();
                        object result = command.ExecuteScalar();


                        if (result != null && decimal.TryParse(result.ToString(), out decimal Billing))
                        {
                            SumBilling = Billing;
                        }
                    }
	}}

	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}

	return SumBilling;
}
        
public static DataTable GetAllBorrowingRecords()
{

	DataTable dt = new DataTable();

	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = @"exec sp_GetAllBorrowingRecords; ";
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

public static DataTable GetAllBorrowingRecordsForUser(int UserID)
{

	DataTable dt = new DataTable();

	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = @"exec sp_GetAllBorrowingRecordsForUser @UserID=@UserID; ";
using(	SqlCommand command = new SqlCommand(query, connection)) 
{
                        command.Parameters.AddWithValue("@UserID", UserID);
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
using DL.SimpleLibrary;
using System;
using System.Data;
using Microsoft.Data.SqlClient;


namespace DB_Simple_LibraryDataAccessLayer
{
	public static class clsBookCopiesDataAccess
	{
		public static bool GetCopyInfoByID(int CopyID, ref int BookID, ref bool AvailabilityStatus, ref int CreateByUserID)
		{
			bool isFound = false;

			try
			{

				using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
				{
					string query = "exec sp_GetCopyInfoByID @copyID= @CopyID";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@CopyID", CopyID);

						connection.Open();
						using (SqlDataReader reader = command.ExecuteReader())
						{

							if (reader.Read())
							{
								isFound = true;

								CopyID = (int)reader["CopyID"];
								BookID = (int)reader["BookID"];
								AvailabilityStatus = (bool)reader["AvailabilityStatus"];
								CreateByUserID = (int)reader["CreateByUserID"];

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
		public static int AddNewCopy(int BookID, bool AvailabilityStatus, int CreateByUserID) {

			int ID = -1;
			try {
				using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
				{

					string query = @"exec sp_AddNewCopy
                                    @BookID=@BookID,
                                    @AvailabilityStatus=@AvailabilityStatus,
                                    @CreateByUserID=@CreateByUserID";

					using (SqlCommand command = new SqlCommand(query, connection))
					{


						command.Parameters.AddWithValue("@BookID", BookID);

						command.Parameters.AddWithValue("@AvailabilityStatus", AvailabilityStatus);

						command.Parameters.AddWithValue("@CreateByUserID", CreateByUserID);




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


		public static bool AddBookCopy(int BookID, int Quentity, int CreateByUserID)
		{
			int result = 0;

			try
			{
				using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
				{

					string query = @"exec sp_AddNewCopy
                                    @BookID=@BookID,
                                    @AvailabilityStatus=1,
                                    @CreateByUserID=@CreateByUserID;";

					using (SqlCommand command = new SqlCommand(query, connection))
					{


						command.Parameters.AddWithValue("@BookID", BookID);
						command.Parameters.AddWithValue("@CreateByUserID", CreateByUserID);




						connection.Open();

						for (int i = 0; i < Quentity; i++)
						{
							result = command.ExecuteNonQuery();

						}
						connection.Close();

					}
				}
			}
			catch (Exception ex) { clsErrorHandling.HandleError(ex.ToString()); }
			return result > 0;

		}


		public static bool UpdateCopy(int CopyID, int BookID, bool AvailabilityStatus, int CreateByUserID)
		{
			int rowsAffected = 0;

			try {
				using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
				{

					string query = @"exec sp_UpdateCopy
                                    @CopyID=@CopyID,
                                    @BookID=@BookID,
                                    @AvailabilityStatus=@AvailabilityStatus,
                                    @CreateByUserID=@CreateByUserID";
					using (SqlCommand command = new SqlCommand(query, connection))
					{


						command.Parameters.AddWithValue("@CopyID", CopyID);

						command.Parameters.AddWithValue("@BookID", BookID);

						command.Parameters.AddWithValue("@AvailabilityStatus", AvailabilityStatus);

						command.Parameters.AddWithValue("@CreateByUserID", CreateByUserID);


						connection.Open(); rowsAffected = command.ExecuteNonQuery(); }
				}
			}

			catch (Exception ex) { clsErrorHandling.HandleError(ex.ToString()); }
			return (rowsAffected > 0);

		}
		public static int GetNumberOfCopiesBook(int BookID)
		{
			int NumberOfCopiesBook = 0;
			try
			{
				using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
				{
					string query = "exec sp_GetNumberOfCopiesBook @BookID=@BookID";
					using (SqlCommand command = new SqlCommand(query, connection))
					{

						command.Parameters.AddWithValue("@BookID", BookID);

						connection.Open();
						object result = command.ExecuteScalar();


						if (result != null && int.TryParse(result.ToString(), out int insertedID))
						{
							NumberOfCopiesBook = insertedID;
						}
					}
				}
			}
			catch (Exception ex) { clsErrorHandling.HandleError(ex.ToString()); }

			return NumberOfCopiesBook;

		}
		public static bool DeleteCopy(int CopyID)
		{
			int rowsAffected = 0;
			try
			{
				using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
				{
					string query = "exec sp_DeleteCopy @CopyID=@CopyID";
					using (SqlCommand command = new SqlCommand(query, connection))
					{

						command.Parameters.AddWithValue("@CopyID", CopyID);

						connection.Open();
						rowsAffected = command.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex) { clsErrorHandling.HandleError(ex.ToString()); }

			return (rowsAffected > 0);

		}

		public static int GetAvailabelCopyID()
		{
			int CopyID = 0;
			try
			{
				using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
				{
					string query = "exec sp_GetAvailabelCopyID";
					using (SqlCommand command = new SqlCommand(query, connection))
					{


						connection.Open();
						object result = command.ExecuteScalar();


						if (result != null && int.TryParse(result.ToString(), out int insertedID))
						{
                            CopyID = insertedID;
						}
					}
				}
			}
			catch (Exception ex) { clsErrorHandling.HandleError(ex.ToString()); }

			return CopyID;

		}
		public static int GetAvailabelCopyIDForBookID(int BookID)
		{
			int NumberOfCopiesBook = -1;
			try
			{
				using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
				{
					string query = @"exec sp_GetAvailabelCopyIDForBookID @BookID=@BookID";
					using (SqlCommand command = new SqlCommand(query, connection))
					{
						command.Parameters.AddWithValue("@BookID", BookID);

						connection.Open();
						object result = command.ExecuteScalar();


						if (result != null && int.TryParse(result.ToString(), out int insertedID))
						{
							NumberOfCopiesBook = insertedID;
						}
					}
				}
			}
			catch (Exception ex) { clsErrorHandling.HandleError(ex.ToString()); }

			return NumberOfCopiesBook;

		}
		

		public static bool IsCopyExist(int CopyID)
		{
			bool isFound = false;
			try
			{
				using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
				{
					string query = "exec sp_IsCopyExist @copyID= @CopyID";
					using (SqlCommand command = new SqlCommand(query, connection))
					{

						command.Parameters.AddWithValue("@CopyID", CopyID);

						connection.Open();
						using (SqlDataReader reader = command.ExecuteReader()) {
							isFound = reader.HasRows;
						}
					}
				}
			}
			catch (Exception ex) { clsErrorHandling.HandleError(ex.ToString()); }

			return isFound;

		}
		public static bool SetBookCopyNotAvailabe(int CopyID)
		{
			int rowsAffected = 0;
			try
			{
				using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
				{
					string query = @"exec sp_SetBookCopyNotAvailabe @copyID=@CopyID;";
					using (SqlCommand command = new SqlCommand(query, connection))
					{

						command.Parameters.AddWithValue("@CopyID", CopyID);

						connection.Open(); rowsAffected = command.ExecuteNonQuery();
					}
				}
			
	}
	catch (Exception ex) {clsErrorHandling.HandleError(ex.ToString());}

	return rowsAffected>0;

}

public static DataTable GetAllBookCopies()
{

	DataTable dt = new DataTable();

	try
	{
using(	SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
{
	string query = "exec sp_GetAllBookCopies";
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
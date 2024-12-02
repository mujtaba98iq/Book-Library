using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace DL.SimpleLibrary
{
    public class clsRatingsData
    {
        public static short GetBookRate(int BookID)
        {
            short rate = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "exec sp_GetBookRate @BookID= @BookID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("BookID", BookID);

            connection.Open();
            object obj = command.ExecuteScalar();

            if (obj != DBNull.Value)
                rate = Convert.ToInt16(obj);

            connection.Close();


            return rate;
        }

        public static short GetBookRate(int BookID, int UserID)
        {
            short rate = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "exec sp_GetBookRateForUser @BookID=@BookID and @UserID = @UserID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("BookID", BookID);
            command.Parameters.AddWithValue("UserID", UserID);

            connection.Open();
            object obj = command.ExecuteScalar();

            if (obj != DBNull.Value)
                rate = Convert.ToInt16(obj);

            connection.Close();


            return rate;
        }




        public static bool RateABook(int BookID, int UserID, int Rate)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"exec sp_RateABook
                              @BookID=@BookID,
                              @UserID=@UserID,
                              @Rate=@Rate;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("BookID", BookID);
            command.Parameters.AddWithValue("UserID", UserID);
            command.Parameters.AddWithValue("Rate", Rate);

            connection.Open();

            int result = command.ExecuteNonQuery();

            connection.Close();

            return result > 0;
        }



        public static bool CanRate(int BookID, int UserID)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"exec sp_CanRate
                       @BookID=@BookID,
                       @UserID=@UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("BookID", BookID);
            command.Parameters.AddWithValue("UserID", UserID);

            connection.Open();
            int result = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return result < 1;
        }
    }
}

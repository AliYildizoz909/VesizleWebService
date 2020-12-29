using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VesizleWebService.DataAccess
{
    public class CountService
    {
        private string _connString =
            "Server=(localdb)\\MSSQLLocalDB;Database= VesizleDb;Trusted_Connection=True;MultipleActiveResultSets=true";

        public int FavoriteCount(string userId)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"select sum(case UserId when '{userId}' then 1 else 0 end) from Favorites", connection))
                {
                    var data = command.ExecuteScalar();
                    connection.Close();
                    return Convert.ToInt32(data);
                }

            }

        }

        public int WatchListCount(string userId)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"select sum(case UserId when '{userId}' then 1 else 0 end) from WatchedList", connection))
                {

                    command.Parameters.AddWithValue("@userID", userId);
                    var data = command.ExecuteScalar();
                    connection.Close();
                    return Convert.ToInt32(data);
                }

            }
        }

        public int WatchedListCount(string userId)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"select sum(case UserId when '{userId}' then 1 else 0 end) from WatchList", connection))
                {
                    var data = command.ExecuteScalar();
                    connection.Close();
                    return Convert.ToInt32(data);
                }
            }
        }
    }
}
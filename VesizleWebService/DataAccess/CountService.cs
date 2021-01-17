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
                using (SqlCommand command = new SqlCommand("Sp_FavoritesCountByUserId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("UserId", userId);
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
                using (SqlCommand command = new SqlCommand("Sp_WatchListCountByUserId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("UserId", userId);
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
                using (SqlCommand command = new SqlCommand("Sp_WatchedListCountByUserId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("UserId", userId);
                    var data = command.ExecuteScalar();
                    connection.Close();
                    return Convert.ToInt32(data);
                }
            }
        }
    }
}
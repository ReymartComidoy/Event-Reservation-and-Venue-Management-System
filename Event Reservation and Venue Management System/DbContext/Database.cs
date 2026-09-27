using Microsoft.Data.SqlClient;
using System.Data;

namespace Event_Reservation_and_Venue_Management_System.DbContext
{
    public static class Database
    {
        public const string ConnectionString ="Server=(localdb)\\MSSQLLocalDB;Database=EventReservationDb;Trusted_Connection=True;TrustServerCertificate=True;";
        public static SqlConnection CreateConnection() => new(ConnectionString);

        public static DataTable ExecuteTable(string procedureName, params SqlParameter[] parameters)
        {
            using SqlConnection connection = CreateConnection();
            using SqlCommand command = new(procedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddRange(parameters);
            using SqlDataAdapter adapter = new(command);
            DataTable table = new();
            adapter.Fill(table);
            return table;
        }

        public static int ExecuteNonQuery(string procedureName, params SqlParameter[] parameters)
        {
            using SqlConnection connection = CreateConnection();
            using SqlCommand command = new(procedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddRange(parameters);
            connection.Open();
            return command.ExecuteNonQuery();
        }

        public static object? ExecuteScalar(string procedureName, params SqlParameter[] parameters)
        {
            using SqlConnection connection = CreateConnection();
            using SqlCommand command = new(procedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.AddRange(parameters);
            connection.Open();
            return command.ExecuteScalar();
        }
    }
}

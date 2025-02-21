using System.Data.SqlClient;
using System.Data;

public static class DatabaseHelper
{
    public static readonly string ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=LynnSmithUniversityDB;Trusted_Connection=True;";

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(ConnectionString);
    }

    public static DataTable ExecuteQuery(string query)
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }

    public static void ExecuteNonQuery(string query)
    {
        using (SqlConnection conn = GetConnection())
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}

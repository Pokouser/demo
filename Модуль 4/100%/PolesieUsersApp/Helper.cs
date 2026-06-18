using System.Data.SqlClient;

namespace PolesieUsersApp.classes
{
    internal class Helper
    {
        public static string connectionString = @"Server=(localdb)\MSSQLLocalDB;
        Database=demo;
        Integrated Security=True;
        TrustServerCertificate=True;";

        //public static string connectionString = @"Server=ИМЯ_СЕРВЕРА_ИЛИ_IP;
        //Database=demo;
        //User Id=demo;
        //Password=demo;
        //TrustServerCertificate=True;";

        public static int userId;
        public static string userLogin = "";
        public static string userRole = "";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}

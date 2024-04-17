using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Reflection;

namespace AthleteTrackDAL
{
    public class Dataconnection
    {
        private const string connectionstring = "Server=mssqlstud.fhict.local;Database=dbi536130_athletet;User Id=dbi536130_athletet;Password=123;TrustServerCertificate=True;";
        SqlConnection s = new SqlConnection(connectionstring);

        public Dataconnection()
        {
            s.Open();
        }
        ~Dataconnection()
        {
            s.Close();
        }
 
    }
}

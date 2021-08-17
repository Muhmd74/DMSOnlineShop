using Microsoft.Data.SqlClient;

namespace DMSOnlineStore.Infrastructure.Data.Tools
{
   public class ConnectionOptions 
    {

        public static string Create()
        {
            return SqlServerConnection();
        }

        private static string SqlServerConnection()
        {
            var builder=new SqlConnectionStringBuilder()
            {
                DataSource = @".",
                InitialCatalog = "DMSOnlineStore",
                ApplicationName = "DMS Online Store",
                IntegratedSecurity = true,
                MultipleActiveResultSets = true
            };
            return builder.ConnectionString;
        }
    }
}

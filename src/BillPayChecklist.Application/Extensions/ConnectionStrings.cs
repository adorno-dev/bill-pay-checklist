using Microsoft.Extensions.Configuration;

namespace BillPayChecklist.Application.Extensions
{
    public static class ConnectionStrings
    {
        public static string? GetFromUserSecrets<TContextFactory>(string connectionString) where TContextFactory : class
            => new ConfigurationBuilder()
                  .AddUserSecrets<TContextFactory>()
                  .Build()
                  .GetConnectionString(connectionString);
    }
}
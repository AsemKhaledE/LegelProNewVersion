using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace LegelProNewVersion
{
    public class ClassFunction

    {
        public   string GetConnectionString()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            var configuration = builder.Build();
          
            var connString = configuration.GetConnectionString("cs");
            return connString.ToString();
        }
    }
}

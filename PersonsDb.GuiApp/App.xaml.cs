using System.IO;
using System.Windows;
using Microsoft.Extensions.Configuration;

namespace PersonsDb.GuiApp
{
    public partial class App : Application
    {
        public App()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            Resources.Add("ConnectionString", config.GetConnectionString("DefaultConnection"));
        }
    }
}
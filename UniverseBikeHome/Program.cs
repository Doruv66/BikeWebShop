using BikeClassLibrary.DBL;
using BikeClassLibrary;
using BikeLibrary.BLL.Interfaces;
using BikeLibrary.BLL;
using BikeLibrary.DBL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniverseBikeHome
{
	internal static class Program
	{
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<Login>());
		}

        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    var connString = "Data Source=mssqlstud.fhict.local; Initial Catalog=dbi507644_managestu;User ID=dbi507644_managestu;Password=Otilia_1995";
                    services.AddTransient<IAccountRepository>(s => new DBAccounts(connString));
                    services.AddTransient<IBikeRepository>(s => new DBBikes(connString));
                    services.AddTransient<IOrderRepository>(s => new DBOrders(connString));
                    services.AddTransient<IOrderService, OrderService>();
                    services.AddTransient<IAccountService, AccountService>();
                    services.AddTransient<IInventory, Inventory>();
                    services.AddTransient<Login>();
                }); 
        }
    }
}

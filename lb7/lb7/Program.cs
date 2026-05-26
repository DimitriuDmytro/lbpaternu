using System;
using Microsoft.Extensions.DependencyInjection;
using lb7;

namespace lb7
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddSingleton<Logger>();
            services.AddSingleton<Config>();
            services.AddSingleton<DataProvider>();
            services.AddSingleton<Repository>();
            services.AddSingleton<Service>();

            var provider = services.BuildServiceProvider();

            var app = provider.GetRequiredService<Service>();
            app.Run();

            Console.WriteLine("Натисни будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}
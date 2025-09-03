using LogLog.Console.Commands.Parser;
using LogLog.Console.Shell;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LogLog.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) => 
                {
                    services.AddSingleton<ICommandParser, CliCommandParser>();



                    services.AddSingleton<IShell, CliShell>();
                })
                .Build();

            var app = host.Services.GetRequiredService<IShell>();
            app.Run();

        }
    }
}
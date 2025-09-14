using LogLog.Console.Commands.Executor;
using LogLog.Console.Commands.Executors;
using LogLog.Console.Commands.Executors.Workspace;
using LogLog.Console.Commands.Parser;
using LogLog.Console.Commands.Validators;
using LogLog.Console.Shell;
using LogLog.Domain.Interfaces.Repositories;
using LogLog.Infrastructure.SQLite.Repositories;
using LogLog.Infrastructure.SqlLite;
using LogLog.UseCases;
using LogLog.UseCases.Groups.Create;
using LogLog.UseCases.Groups.Delete;
using LogLog.UseCases.Groups.Find;
using LogLog.UseCases.Groups.GetAll;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LogLog.Console
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) => 
                {
                    // DB
                    RegisterDb(services);

                    // Use Cases
                    RegisterUseCases(services);

                    RegisterCommandExecutors(services);


                    services.AddScoped<ICommandParser, CommandParser>();
                    services.AddScoped<ICommandValidator, CommandValidator>();

                    services.AddSingleton<IShell, Cli>();
                })
                .Build();

            var app = host.Services.GetRequiredService<IShell>();
            await app.Run();

        }

        private static void RegisterDb(IServiceCollection services)
        {
            services.AddSingleton<SQLiteDbContext>();
            services.AddSingleton<IGroupsRepository, GroupsRepository>();
        }


        private static void RegisterUseCases(IServiceCollection services)
        {
            // Groups
            services.AddTransient<IUseCase<CreateGroupUseCaseRequest, CreateGroupUseCaseResponse>, CreateGroupUseCase>();
            services.AddTransient<IUseCase<GetAllGroupsUseCaseRequest, GetAllGroupsUseCaseResponse>, GetAllGroupsUseCase>();
            services.AddTransient<IUseCase<FindGroupUseCaseRequest, FindGroupUseCaseResponse>, FindGroupUseCase>();
            services.AddTransient<IUseCase<DeleteGroupUseCaseRequest, DeleteGroupUseCaseResponse>, DeleteGroupUseCase>();
        }

        private static void RegisterCommandExecutors(IServiceCollection services)
        {
            services.AddScoped<ICommandExecutor, RootCommandExecutor>();
            services.AddScoped<IWorkspaceCommandExecutor, WorkspaceCommandExecutor>();

        }

    }
}
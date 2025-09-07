using LogLog.Console.Commands.Executor;
using LogLog.Console.Commands.Parser;
using LogLog.Console.Commands.Validators;
using LogLog.Console.Context;
using LogLog.Console.Contexts.Types;
using LogLog.Console.Shell;
using LogLog.Domain.Interfaces.Repositories;
using LogLog.Infrastructure.SQLite.Repositories.Group;
using LogLog.Infrastructure.SqlLite;
using LogLog.UseCases;
using LogLog.UseCases.Groups.Create;
using LogLog.UseCases.Groups.GetAll;
using LogLog.Workflows;
using LogLog.Workflows.Groups.Create;
using LogLog.Workflows.Groups.GetAll;
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
                    // DB
                    RegisterDb(services);


                    // Use Cases
                    RegisterUseCases(services);

                    // Workflows
                    RegisterWorkflows(services);



                    services.AddSingleton<IContext, GlobalContext>();

                    services.AddScoped<ICommandParser, CliCommandParser>();
                    services.AddScoped<ICommandValidator, CliCommandValidator>();


                    services.AddSingleton<IShell, CliShell>();
                })
                .Build();

            var app = host.Services.GetRequiredService<IShell>();
            app.Run();

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
        }

        private static void RegisterWorkflows(IServiceCollection services)
        {
            // Groups
            services.AddTransient<IWorkflow<CreateGroupWorkflowRequest, CreateGroupWorkflowResponse>, CreateGroupWorkflow>();
            services.AddTransient<IWorkflow<GetAllGroupsWorkflowRequest, GetAllGroupsWorkflowResponse>, GetAllGroupsWorkflow>();
        }
    }
}
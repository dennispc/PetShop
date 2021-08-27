using DPcode.Core.IModel;
using DPcode.Core.Models;
using DPcode.Domain.IServices;
using DPcode.Domain.Services;
using DPcode.Infrastructure.Data.IRepositories;
using DPcode.Infrastructure.Data.Repositories;
using DPcode.Infrastructure.UI.IService;
using DPcode.Infrastructure.UI.Services;
using DPcode.UI.IService;
using DPcode.UI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DPcode.UI
{
    class Program
    {

        /*
        done    Show list of choices (Pure UI, Add one choice at a time) 
        done    Show list of all Pets
        done    Use dependency injection with service collection
        TODO    Search Pets by Type (Cat, Dog, Goat) *Yes Goats can be pets :D
        TODO    Find a way to make constants less coupled
        done    Create a new Pet
        done    Delete Pet
        done    Update a Pet
        TODO    Sort Pets By Price
        TODO    Get 5 cheapest available Pets
        done    Code Available on Github
        asd
        */

        static bool stop = false;

        

            static IConsoleTreeHandlerService consoleTreeHandlerService;
            static IConsoleResponseHandlerService consoleResponseHandlerService;

        static void Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IMenu,Menu>();
            serviceCollection.AddScoped<IFakeDB,FakeDB>();
            serviceCollection.AddScoped<IPetTypeRepository,PetTypeRepository>();
            serviceCollection.AddScoped<IPetTypeService,PetTypeService>();
            serviceCollection.AddScoped<IDataService,DataService>();
            serviceCollection.AddScoped<IConsoleAskerService,ConsoleAskerService>();
            serviceCollection.AddScoped<IConsoleTreeHandlerService,ConsoleTreeHandlerService>();
            serviceCollection.AddScoped<IConsoleResponseHandlerService,ConsoleResponseHandlerService>();

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            consoleTreeHandlerService = serviceProvider.GetRequiredService<IConsoleTreeHandlerService>();
            consoleResponseHandlerService = serviceProvider.GetRequiredService<IConsoleResponseHandlerService>();
            Init();
        }

        public static void Init()
        {
            if (!stop)
            {
                consoleTreeHandlerService.PrintMenu();
                consoleResponseHandlerService.HandleResonse(consoleTreeHandlerService.GetResponse());
            }
        }

        public static void FlipStopBool()
        {
            stop = !stop;
        }
    }
}

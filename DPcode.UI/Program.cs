using DPcode.Core.Models;
using DPcode.UI.Core.IModels;
using DPcode.UI.Core.Models;
using DPcode.Domain.IServices;
using DPcode.Domain.Services;
using DPcode.Infrastructure.UI.IService;
using DPcode.Infrastructure.UI.Services;
using DPcode.UI.IService;
using Microsoft.Extensions.DependencyInjection;
using DPcode.Infrastructure.Static.Data.Repositories;
using DPcode.Domain.IRepositories;

namespace DPcode.UI
{
    class Program
    {

        /*
        done    Show list of choices (Pure UI, Add one choice at a time) 
        done    Show list of all Pets
        done    Use dependency injection with service collection
        done    Search Pets by Type (Cat, Dog, Goat) *Yes Goats can be pets :D
        done    Create a new Pet
        done    Delete Pet
        done    Update a Pet
        done    Code Available on Github
        done    Sort Pets By Price
        done    Get 5 cheapest available Pets
        TODO    Clean this stuff up
        */

        static bool stop = false;

        static IConsoleTreeHandlerService consoleTreeHandlerService;
        static IConsoleResponseHandlerService consoleResponseHandlerService;

        static void Main(string[] args)
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IMenu, Menu>();
            serviceCollection.AddScoped<IRepository<Pet>,PetRepository>();
            serviceCollection.AddScoped<IService<Pet>,PetService>();
            serviceCollection.AddScoped<IRepository<PetType>, PetTypeRepository>();
            serviceCollection.AddScoped<IService<PetType>, PetTypeService>();
            serviceCollection.AddScoped<IConsoleAskerService, ConsoleAskerService>();
            serviceCollection.AddScoped<IConsoleTreeHandlerService, ConsoleTreeHandlerService>();
            serviceCollection.AddScoped<IConsoleResponseHandlerService, ConsoleResponseHandlerService>();
            serviceCollection.AddScoped<IRepository<Owner>, OwnerRepository>();
            serviceCollection.AddScoped<IService<Owner>, OwnerService>();
            

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

using DPcode.Domain.IServices;
using DPcode.Domain.Services;
using DPcode.Infrastructure.Data.IRepositories;
using DPcode.Infrastructure.Data.Repositories;
using DPcode.Infrastructure.UI.IService;
using DPcode.Infrastructure.UI.Services;
using DPcode.UI.IService;
using DPcode.UI.Services;

namespace DPcode.UI
{
    class Program
    {

        /*
        done    Show list of choices (Pure UI, Add one choice at a time) 
        done    Show list of all Pets
        TODO    Search Pets by Type (Cat, Dog, Goat) *Yes Goats can be pets :D
        done    Create a new Pet
        done    Delete Pet
        done    Update a Pet
        TODO    Sort Pets By Price
        TODO    Get 5 cheapest available Pets
        done    Code Available on Github
        */

        static IFakeDB fakeDB = new FakeDB();
        static IDataService dataService = new DataService(fakeDB);
        static IPetTypeRepository petTypeRepository = new PetTypeRepository();
        static IPetTypeService petTypeService = new PetTypeService(petTypeRepository);
        static IConsoleAskerService consoleAskerService = new ConsoleAskerService(petTypeService, dataService);
        static IConsoleTreeHandlerService consoleTreeHandlerService = new ConsoleTreeHandlerService(Constants.menu, consoleAskerService, Constants.endSessionString);
        static IConsoleResponseHandlerService consoleResponseHandlerService = new ConsoleResponseHandlerService(consoleAskerService, dataService, petTypeService);
        static bool stop = false;

        static void Main(string[] args)
        {
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

using System;
using DPcode.Core.IModel;
using DPcode.Core.Model;
using DPcode.Domain.IService;
using DPcode.Domain.Service;
using DPcode.Infrastructure.Data.IRepositories;
using DPcode.Infrastructure.Data.Repositories;
using DPcode.Infrastructure.UI.IService;
using DPcode.Infrastructure.UI.Services;
using DPcode.UI.IService;
using DPcode.UI;

namespace DPcode.UI
{
   class Program
    {
        static void Main(string[] args){
            Init();
        }
            public static IMenu menu = new Menu("intial menu");

            public static IMenu menu1 = new Menu(Constants.addPetCommand);

            static IFakeDB fakeDB = new FakeDB();
            static IDataService dataService = new DataService();
            static IConsoleAsker consoleAsker = new ConsoleAsker();
            static IConsoleTreeHandler consoleTreeHandler = new ConsoleTreeHandler(menu, consoleAsker);
            static IConsoleResponseHandler consoleResponseHandler = new ConsoleResponseHandler();

            static bool stop = false;


        

        public static void Init(){
            if(!stop){
            consoleTreeHandler.PrintMenu();
            consoleResponseHandler.HandleResonse(consoleTreeHandler.GetResponse());
            }
        }

        public static void FlipStopBool(){
            stop = ! stop;
        }
    }
}

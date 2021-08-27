using System;
using System.Collections.Generic;
using DPcode.Core.IModel;
using DPcode.Infrastructure.UI.IService;
using DPcode.UI.IService;

namespace DPcode.Infrastructure.UI.Services
{
    public class ConsoleTreeHandlerService : IConsoleTreeHandlerService
    {
        private IMenu _menu;

        private IConsoleAskerService _consoleAskerService;

        private string _endSessionString;

        public ConsoleTreeHandlerService(IMenu menu, IConsoleAskerService consoleAskerService, string endSessionString)
        {
            this._menu = menu;
            this._consoleAskerService = consoleAskerService;
            this._endSessionString = endSessionString;
        }
        public IMenu GetCurrentBranch()
        {
            return _menu;
        }

        public string GetResponse()
        {
            int number = _consoleAskerService.GetIntFromTerminal("");
            if (number <= 0)
                return _endSessionString;
            if (number <= _menu.GetBraches().Count)
                return _menu.GetBraches()[number - 1].GetDescriptor();
            else{
                return "";
                }
        }

        public void PrintMenu()
        {
            Console.WriteLine();
            List<IMenu> menus = _menu.GetBraches();
            for (int i = 0; i < menus.Count; i++)
            {
                Console.WriteLine($"{(i + 1)} : {menus[i].GetDescriptor()}");
            }
            Console.WriteLine($"0 : {_endSessionString}");
        }
        
        public void PrintMenu(IMenu menu)
        {
            List<IMenu> menus = menu.GetBraches();
            for (int i = 0; i < menus.Count; i++)
            {
                Console.WriteLine($"{i} : {menus[i].GetDescriptor()}");
            }
        }
    }
}
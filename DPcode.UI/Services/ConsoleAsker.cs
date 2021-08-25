using System;
using DPcode.Core.Models;
using DPcode.Domain.IService;
using DPcode.UI.IService;

namespace DPcode.Infrastructure.UI.Services
{
    public class ConsoleAsker : IConsoleAsker
    {
        public Pet CreateNewPet()
        {
            throw new NotImplementedException();
        }
        public bool UpdatePet()
        {
            throw new NotImplementedException();
        }

        public bool DeletePet()
        {
            throw new NotImplementedException();
        }

        public int GetIntFromTerminal(string str)
        {
            Console.Write(str);
            string year = Console.ReadLine();
            int validYear;

            while (!int.TryParse(year, out validYear))
            {
                Console.WriteLine("That's not valid.");
                Console.Write(str);
                year = Console.ReadLine();
            }
            return validYear;
        }

        public string GetStringFromTerminal(string str)
        {
            string text = "";
            while (text.Trim() == "")
            {
                Console.Write(str);
                text = Console.ReadLine();
            }
            return text;
        }

        
    }
}
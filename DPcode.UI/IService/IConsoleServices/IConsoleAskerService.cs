using System;
using DPcode.Core.Models;

namespace DPcode.UI.IService{
    
    public interface IConsoleAskerService{

        string GetStringFromTerminal(string str);

        int GetIntFromTerminal(string str);

        double GetDoubleFromTerminal(string str);

        DateTime? GetDateTimeFromTerminal(string str);

        bool GetConfirmation(string str);

        Pet CreateNewPet();

        int? GetPetIdFromTerminal(string str);
        void DeletePet();
        void UpdatePet();

        void GetPetsOfType();
        void PrintPetsByPriceAscending();
    }
}
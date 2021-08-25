using DPcode.Core.Models;

namespace DPcode.UI.IService{
    
    public interface IConsoleAsker{
        string GetStringFromTerminal(string str);
        int GetIntFromTerminal(string str);

        Pet CreateNewPet();
        bool UpdatePet();

        bool DeletePet();
    }
}
using DPcode.UI.Core.IModels;

namespace DPcode.Infrastructure.UI.IService{
    public interface IConsoleTreeHandlerService{

        void PrintMenu();

        void PrintMenu(IMenu menu);
        string GetResponse();

        IMenu GetCurrentBranch();

    }
}
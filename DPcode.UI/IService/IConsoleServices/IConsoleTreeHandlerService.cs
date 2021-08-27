using DPcode.Core.IModel;

namespace DPcode.Infrastructure.UI.IService{
    public interface IConsoleTreeHandlerService{

        void PrintMenu();

        void PrintMenu(IMenu menu);
        string GetResponse();

        IMenu GetCurrentBranch();

    }
}
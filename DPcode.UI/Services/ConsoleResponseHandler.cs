using DPcode.UI;
using DPcode.UI.IService;

namespace DPcode.Infrastructure.UI.Services
{
    public class ConsoleResponseHandler : IConsoleResponseHandler
    {

        public void HandleResonse(string str)
        {
            switch(str){
            case Constants.addPetCommand :
            CreatePet();
            break;
            default:
            throw new System.NotImplementedException();
            }
            
            Program.Init();
        }
        public void CreatePet()
        {
            throw new System.NotImplementedException();
        }

        public void DeletePet()
        {
            throw new System.NotImplementedException();
        }

        public void ListPets()
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePet()
        {
            throw new System.NotImplementedException();
        }
    }
}
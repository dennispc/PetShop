namespace DPcode.UI.IService
{
    public interface IConsoleResponseHandlerService
    {
        
        void HandleResonse(string str);

        void CreatePet();

        void ListPets();

        void UpdatePet();

        void DeletePet();

        void PrintPetsByPriceAscending();


        void PrintFiveCheapestPets();
    }
}
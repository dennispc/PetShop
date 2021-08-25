namespace DPcode.UI.IService
{
    public interface IConsoleResponseHandler
    {
        void HandleResonse(string str);

        void CreatePet();
        void ListPets();
        void UpdatePet();
        void DeletePet();
    }
}
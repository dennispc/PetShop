using System;
using System.Collections.Generic;
using System.Linq;
using DPcode.Core.Models;
using DPcode.Domain.IServices;
using DPcode.UI;
using DPcode.UI.IService;

namespace DPcode.Infrastructure.UI.Services
{
    public class ConsoleResponseHandlerService : IConsoleResponseHandlerService
    {
        private IConsoleAskerService _consoleAskerService;

        private IService<Pet> _petService;

        private IService<PetType> _petTypeService;

        public ConsoleResponseHandlerService(IConsoleAskerService consoleAskerService, IService<Pet> petService, IService<PetType> petTypeService)
        {
            this._consoleAskerService = consoleAskerService;
            this._petService = petService;
            this._petTypeService = petTypeService;
        }

        public void HandleResonse(string str)
        {
            switch (str)
            {
                case Constants.addPetCommand: CreatePet(); break;
                case Constants.listPetsCommand: ListPets(); break;
                case Constants.updatePetCommand: UpdatePet(); break;
                case Constants.deletePetCommand: DeletePet(); break;
                case Constants.printPetsByPriceAscending: PrintPetsByPriceAscending(); break;
                case Constants.searchPetsByType: SearchPetsByType(); break;
                case Constants.endSessionString: Program.FlipStopBool(); break;
                case Constants.printFiveCheapestPets: PrintFiveCheapestPets(); break;
                default: Console.WriteLine(Constants.invalidAction); break;
            }
            Program.Init();
        }

        #region simpleQueries
        public void CreatePet()
        {
            _petService.Make(_consoleAskerService.CreateNewPet());
        }

        public void ListPets()
        {
            foreach (Pet pet in _petService.Get().ToList())
            {
                Console.WriteLine(pet.ToString());
            }
        }

        public void DeletePet()
        {
            _consoleAskerService.DeletePet();
        }

        public void UpdatePet()
        {
            _consoleAskerService.UpdatePet();
        }

        public void SearchPetsByType(){
            _consoleAskerService.GetPetsOfType();
        }

        public void PrintPetsByPriceAscending(){
            _consoleAskerService.PrintPetsByPriceAscending();
        }

        public void PrintFiveCheapestPets(){

            List<Pet> pets = _petService.Get().OrderBy(pet=>pet.price).ToList();
            for(int i = 0 ; i < 5 ; i++)
                Console.WriteLine(pets[i].ToString());
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using DPcode.Core.Models;
using DPcode.Domain.IServices;
using DPcode.UI;
using DPcode.UI.IService;

namespace DPcode.Infrastructure.UI.Services
{
    public class ConsoleResponseHandlerService : IConsoleResponseHandlerService
    {
        private IConsoleAskerService _consoleAskerService;

        private IDataService _dataService;

        private IPetTypeService _petTypeService;

        public ConsoleResponseHandlerService(IConsoleAskerService consoleAskerService, IDataService dataService, IPetTypeService petTypeService)
        {
            this._consoleAskerService = consoleAskerService;
            this._dataService = dataService;
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
                case Constants.endSessionString: Program.FlipStopBool(); break;
                default: Console.WriteLine(Constants.invalidAction); break;
            }
            Program.Init();
        }

        #region simpleQueries
        public void CreatePet()
        {
            _dataService.AddPet(_consoleAskerService.CreateNewPet());
        }

        public void ListPets()
        {
            foreach (Pet pet in _dataService.GetAllPets())
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

        #endregion
    }
}
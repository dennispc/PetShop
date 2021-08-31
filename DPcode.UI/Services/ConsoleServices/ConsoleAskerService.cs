using System;
using System.Collections.Generic;
using DPcode.Core.Models;
using DPcode.Domain.IServices;
using DPcode.Infrastructure.UI.IService;
using DPcode.UI;
using DPcode.UI.IService;

namespace DPcode.Infrastructure.UI.Services
{
    public class ConsoleAskerService : IConsoleAskerService
    {

        private IPetTypeService _petTypeService;
        private IDataService _dataService;

        public ConsoleAskerService(IPetTypeService petTypeService, IDataService dataService)
        {
            this._petTypeService = petTypeService;
            this._dataService = dataService;
        }

        #region terminalqueries
        public int GetIntFromTerminal(string str)
        {
            Console.Write(str);
            string myInteger = Console.ReadLine();
            int validInteger;

            while (!int.TryParse(myInteger, out validInteger))
            {
                Console.WriteLine(Constants.invalidAction);
                Console.Write(str);
                myInteger = Console.ReadLine();
            }
            return validInteger;
        }

        public double GetDoubleFromTerminal(string str)
        {
            Console.Write(str);
            string myDouble = Console.ReadLine();
            int validDouble;

            while (!int.TryParse(myDouble, out validDouble))
            {
                Console.WriteLine(Constants.invalidAction);
                Console.Write(str);
                myDouble = Console.ReadLine();
            }
            return validDouble;
        }

        public DateTime? GetDateTimeFromTerminal(string str)
        {
            string attempt = GetStringFromTerminal(str);
            DateTime dateTime;
            while (!DateTime.TryParse(attempt, out dateTime))
            {
                if (attempt == "0")

                    return null;
                attempt = GetStringFromTerminal(str);
            }
            return dateTime;
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

        public bool GetConfirmation(string str)
        {
            Console.WriteLine(str);
            string confirmation = GetStringFromTerminal("Write YES to confirm: ");
            return (confirmation.ToLower() == "yes" || confirmation == "YES to confirm:");
        }

        public int? GetPetIdFromTerminal(string str)
        {
            int id = GetIntFromTerminal($"{str} (0 to cancel): ");
            if (id > 0)
            {
                return id;
            }
            return null;
        }
        #endregion

        #region CRUDqueries
        public Pet CreateNewPet()
        {
            Pet pet = new Pet();
            pet.name = GetStringFromTerminal("Name: ");
            pet.birthDate = GetDateTimeFromTerminal("BirthDate(type 0 if unknown): ");
            pet.price = GetDoubleFromTerminal("Price: ");
            pet.type = _petTypeService.GetAsPetType(GetStringFromTerminal("Type: "));

            return pet;
        }

        public void DeletePet()
        {
            List<Pet> pets = _dataService.GetAllPets();
            int? id = GetPetIdFromTerminal("Id of pet to delete");
            if (id != null)
            {
                Pet p = pets.Find(p => p.GetId() == id);
                if (p != null && GetConfirmation($"Confirm deleting pet ({p.ToString()})"))
                    _dataService.DeletePet(p);
                else
                {
                    Console.WriteLine(Constants.petNotFound);
                }
            }
        }


        public void GetPetsOfType()
        {
            string str = GetStringFromTerminal("PetType: ");
            List<Pet> petsOfType = _dataService.GetPetsOfType(str);
            if (petsOfType != null)
            {
                foreach (Pet p in petsOfType)
                    Console.WriteLine(p.ToString());
            }
        }

        public void UpdatePet()
        {
            List<Pet> pets = _dataService.GetAllPets();
            int? id = GetPetIdFromTerminal("Id of pet to update");
            if (id != null)
            {
                Pet p = pets.Find(p => p.GetId() == id);
                if (p != null && GetConfirmation($"Confirm updating pet ({p.ToString()})"))
                {
                    IConsoleTreeHandlerService consoleTreeHandler = new ConsoleTreeHandlerService(Constants.updateMenu, this, Constants.stopUpdate);
                    string response = "";
                    Pet p2 = p.ClonePet();

                    while (response != Constants.stopUpdate)
                    {
                        consoleTreeHandler.PrintMenu();
                        Console.WriteLine($"Current: {p2.ToString()}");
                        response = consoleTreeHandler.GetResponse();
                        switch (response)
                        {
                            case "name":
                                {
                                    p2.name = GetStringFromTerminal($"new name(old: {p2.name}): ");
                                    break;
                                }
                            case "price":
                                {
                                    p2.price = GetDoubleFromTerminal($"new price(old: {p2.price}): ");
                                    break;
                                }
                            case "type":
                                {
                                    p2.type = _petTypeService.GetAsPetType(GetStringFromTerminal($"new type(old: {p2.GetPetTypeAsString() }): "));
                                    break;
                                }
                            case "birthDate":
                                {
                                    p2.birthDate = GetDateTimeFromTerminal($"new birthdate(old: {p2.GetBirthDateAsString()}): ");
                                    break;
                                }
                            case "soldDate":
                                {
                                    p2.soldDate = GetDateTimeFromTerminal($"new sold date(old: {p2.GetSoldDateAsString()}): ");
                                    break;
                                }
                        }
                    }
                    if (GetConfirmation($"Confirm Changes: {p.ToString()} => {p2.ToString()}"))
                    {
                        _dataService.UpdatePet(p2);
                        Console.WriteLine(Constants.successfullAction);
                    }
                    else
                        Console.WriteLine(Constants.updateStopped);
                }
                else
                    Console.WriteLine(Constants.petNotFound);
            }
        }
    }



    #endregion
}
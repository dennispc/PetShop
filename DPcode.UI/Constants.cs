
using DPcode.Core.Models;
using DPcode.UI.Core.IModels;
using DPcode.UI.Core.Models;

namespace DPcode.UI
{
    public class Constants
    {
        #region general

        public const string petNotFound = "Pet not found.";

        public const string successfullAction = "Success!";

        public const string updateStopped = "update cancelled.";

        public const string invalidAction = "Invalid action!";

        #endregion

        #region Main menu   

        public const string addPetCommand = DPcode.UI.Core.Constants.addPetCommand;

        public const string updatePetCommand = DPcode.UI.Core.Constants.updatePetCommand;

        public const string listPetsCommand = DPcode.UI.Core.Constants.listPetsCommand;

        public const string deletePetCommand = DPcode.UI.Core.Constants.deletePetCommand;

        public const string printPetsByPriceAscending = DPcode.UI.Core.Constants.printPetsByPriceAscending;
        public const string searchPetsByType = DPcode.UI.Core.Constants.searchPetsByType;

        public const string printFiveCheapestPets = DPcode.UI.Core.Constants.printFiveCheapestPets;
        
        public const string endSessionString = "Exit.";

        #endregion

        #region Update menu

        
        public const string stopUpdate = "Finish updating";

        public static IMenu[] updateMenuSubMenus = new IMenu[]{
        new Menu(PetAttribute.name.ToString()),
        new Menu(PetAttribute.price.ToString()),
        new Menu(PetAttribute.type.ToString()),
        new Menu(PetAttribute.owner.ToString()),
        new Menu(PetAttribute.birthDate.ToString()),
        new Menu(PetAttribute.soldDate.ToString())};
        
        public static IMenu updateMenu = new Menu("UpdateMenu", updateMenuSubMenus);

        #endregion
    }
}
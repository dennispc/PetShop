
using DPcode.Core.Models;
using DPcode.Core.IModel;

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

        public const string addPetCommand = "Add pet";

        public const string updatePetCommand = "Update pet";

        public const string listPetsCommand = "List pets";

        public const string deletePetCommand = "Delete pet";
        
        public const string endSessionString = "End session.";

        public static IMenu[] menus = new IMenu[]{
        new Menu(Constants.addPetCommand),
        new Menu(Constants.listPetsCommand),
        new Menu(Constants.updatePetCommand),
        new Menu(Constants.deletePetCommand)};

        public static IMenu menu = new Menu("intial menu", menus);

        #endregion

        #region Update menu

        
        public const string stopUpdate = "End updating";

        public static IMenu[] updateMenuSubMenus = new IMenu[]{
        new Menu(PetAttribute.name.ToString()),
        new Menu(PetAttribute.price.ToString()),
        new Menu(PetAttribute.type.ToString()),
        new Menu(PetAttribute.birthDate.ToString()),
        new Menu(PetAttribute.soldDate.ToString())};
        
        public static IMenu updateMenu = new Menu("UpdateMenu", updateMenuSubMenus);

        #endregion
    }
}
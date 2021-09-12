namespace DPcode.Domain
{
    public class Constants
    {
        public static string IvalidPetType(int id){
            return $"No pet type with id: {id}";
        }
        public static string IvalidOwnerType(int id){
            return $"No owner with id: {id}";
        }
    }
}
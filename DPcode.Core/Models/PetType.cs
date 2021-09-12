namespace DPcode.Core.Models
{
    public class PetType : Identifyable
    {
        public PetType(string type){
            this.type = type;
        }
        public string type{get;set;}

        public PetType(){}
    }
}
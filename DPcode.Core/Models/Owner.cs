namespace DPcode.Core.Models
{
    public class Owner : Identifyable
    {
        public string name{get;set;}
     

        public Owner(string name){
            this.name = name;
        }

        public Owner(){}

    }
}
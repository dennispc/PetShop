namespace DPcode.Core.Models
{
    public class PetType : IIdentifyable
    {
        private int _id;
        public PetType(string type){
            this.type = type;
        }
        public string type{get;set;}
        public int? GetId()
        {
            return _id;
        }

        public void SetId(int id)
        {
            this._id=id;
        }
        
    }
}
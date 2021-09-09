namespace DPcode.Core.Models
{
    public abstract class Identifyable
    {
        protected int _id;

        public virtual int? GetId(){
            return _id;
        }

        public virtual void SetId(int id){
            _id=id;
        }
        
    }
}
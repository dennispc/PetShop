using DPcode.Core.Models;
namespace DPcode.WebApi.Dtos
{
    public class OwnerDto
    {
        public string name { get; set; }

        public OwnerDto(Owner owner)
        {
            name=owner.name;
        }

        public OwnerDto() {}
    }
}
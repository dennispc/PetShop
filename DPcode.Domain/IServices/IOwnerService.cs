using DPcode.Core.Models;

namespace DPcode.Domain.IServices
{
    public interface IOwnerService
    {
        Owner GetAsOwner(string type);
    }
}
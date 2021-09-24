using System.Collections.Generic;

namespace DPcode.Infrastructure.Data.IRepositories
{
    public interface IRepository<T>
    {
        
        T Make(string name);
        
        bool Exists(string name);

        IEnumerable<T> Get();

        bool Remove(T t);
    }
}
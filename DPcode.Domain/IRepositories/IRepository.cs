using System.Collections.Generic;

namespace DPcode.Domain.IRepositories
{
    public interface IRepository<T>
    {
        
        T Make(T t);
        
        bool Exists(string name);

        IEnumerable<T> Get();

        bool Remove(T t);

        bool Update(T t);

        T Get(int id);

    }
}
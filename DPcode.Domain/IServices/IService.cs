using System.Collections.Generic;

namespace DPcode.Domain.IServices
{
    public interface IService<T>
    {
        T Make(T t);

        IEnumerable<T> Get();

        T Get(int id);

        bool Remove(int id);

        bool Update(T t);
    }
}
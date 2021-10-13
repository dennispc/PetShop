using System.Collections.Generic;

namespace DPcode.Core.IServices
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
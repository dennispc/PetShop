using System.Collections.Generic;
using DPcode.Core.Entities;

namespace DPcode.Core.IServices
{
    public interface IService<T>
    {
        T Make(T t);

        IEnumerable<T> Get(Filter filter);

        T Get(int id);

        bool Remove(int id);

        bool Update(T t);
    }
}
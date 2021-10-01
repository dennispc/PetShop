using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DPcode.Infrastructure.Data.IConverters
{
    public interface IConverter<T,T2>
    {
        T2 Convert(T t);
        
        T Convert(T2 t2);
    }
}
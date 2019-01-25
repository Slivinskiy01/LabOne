using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SberCAS.IServices
{
    /// <summary>
    /// 
    /// </summary>
    interface ICRUD <T>
    {
        List<T> GetRows();

        T GetByID(Guid guid);

        bool GetNew(T obj);

        bool Update(T obj, T obj1);

        bool Delete(Guid guid);
    }
}

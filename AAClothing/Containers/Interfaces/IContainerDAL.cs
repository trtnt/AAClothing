using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAClothing.Containers.Interfaces
{
    public interface IContainerDAL<T>
    {
        List<T> GetAll();
        T GetByID(long id);
    }
}

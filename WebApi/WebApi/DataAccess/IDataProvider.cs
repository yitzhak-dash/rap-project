using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DataAccess
{
    public interface IDataProvider<T>
    {
        IEnumerable<T> GetAll();

        bool AddItem(T item);
    }
}

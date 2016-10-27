using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csn.OrmEdd3b.Dal.DataMappers
{
    public interface IDataMapper<T> where T : class
    {
        int GetNextId();

        T Get(int id);

        List<T> GetAll();

        void Insert(T person);

        void Update(T person);

        void Delete(int id);
    }
}

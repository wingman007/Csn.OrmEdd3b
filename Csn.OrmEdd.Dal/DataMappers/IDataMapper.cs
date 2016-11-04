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

        List<T> GetAll();

        T Get(object id); // int object

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity); // (object id);// int
    }
}

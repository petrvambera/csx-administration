using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataAccess.Interface
{
    public interface IBaseRepository<T> where T : class, IEntity
    {

        IList<T> GetAll();

        IList<T> GetPagedEntities(int startIndex, int requestedCount, out int totalCount, string orderPropertyName = null, bool asc = true);

        object Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        T GetById(int id);

        int GetCount();

        IList<T> GetLatestEntities(string datePropertyName, int requestedCount, out int totalCount);
    }
}

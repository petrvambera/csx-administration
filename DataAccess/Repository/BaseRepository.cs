using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace DataAccess.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
    {
        protected ISession session;
        
        public BaseRepository()
        {
            session = NHibernateHelper.Session;
        }

        public IList<T> GetAll()
        {
            return session.QueryOver<T>().List();
        }

        public T GetById(int id)
        {
            return session.CreateCriteria<T>().Add(Restrictions.Eq("Id", id)).UniqueResult<T>();
        }


        public virtual object Create(T entity)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                object o = session.Save(entity);
                transaction.Commit();
                return o;
            }
        }

        public virtual void Update(T entity)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(entity);
                transaction.Commit();
            }
        }

        public virtual void Delete(T entity)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(entity);
                transaction.Commit();
            }
        }

        public int GetCount()
        {
            return session.CreateCriteria<T>().SetProjection(Projections.RowCount()).UniqueResult<int>();
        }

        public virtual IList<T> GetLatestEntities(string datePropertyName, int requestedCount, out int totalCount)
        {
            totalCount = GetCount();
            return session.CreateCriteria<T>().AddOrder(Order.Desc(datePropertyName)).SetMaxResults(requestedCount).List<T>();
        }

        public virtual IList<T> GetPagedEntities(int startIndex, int requestedCount, out int totalCount, string orderColumn = null, bool asc = true)
        {
            ICriteria criteria = session.CreateCriteria<T>().SetFirstResult(startIndex).SetMaxResults(requestedCount);

            if (!string.IsNullOrEmpty(orderColumn))
            {
                criteria.AddOrder(asc ? Order.Asc(orderColumn) : Order.Desc(orderColumn));
            }

            totalCount = GetCount();
            return criteria.List<T>();
        }
    }
}

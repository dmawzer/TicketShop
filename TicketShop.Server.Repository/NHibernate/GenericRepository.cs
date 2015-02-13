using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Server.Repository.Core;

namespace TicketShop.Server.Repository.NHibernate
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly ISessionFactory sessionFactory;

        public GenericRepository(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        public TModel GetBy(int id)
        {
            TModel model = ExecuteInTransaction<TModel>(session => session.Get<TModel>(id));
            return model;
        }

        public IList<TModel> GetAll()
        {
            IList<TModel> modelList = ExecuteInTransaction<IList<TModel>>(session => session.CreateCriteria<TModel>().List<TModel>());
            return modelList;
        }

        public void SaveOrUpdate(TModel model)
        {
            ExecuteInTransaction(session => session.SaveOrUpdate(model));
        }

        public void Delete(TModel model)
        {
            ExecuteInTransaction(session => session.Delete(model));
        }

        protected void ExecuteInTransaction(Action<ISession> func)
        {
            using (ISession session=sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        func(session);
                        transaction.Commit();
                    }
                    catch (HibernateException)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        protected T ExecuteInTransaction<T>(Func<ISession,T> func)
        {
            using (ISession session=sessionFactory.OpenSession())
            {
                using (ITransaction transaction=session.BeginTransaction())
                {
                    try
                    {
                        T t = func(session);
                        transaction.Commit();
                        return t;
                    }
                    catch (HibernateException)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}

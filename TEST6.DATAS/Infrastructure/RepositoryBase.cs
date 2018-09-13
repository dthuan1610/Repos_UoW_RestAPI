using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST6.MODELS.Model;
using System.Data.Entity;
using System.Linq.Expressions;

namespace TEST6.DATAS.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private northwind_databaseEntities datacontext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected northwind_databaseEntities DbContext
        {
            get { return datacontext ?? (datacontext = DbFactory.Init()); }
        }


        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        public T Add(T entity)
        {
            return dbSet.Add(entity);
        }


        public T Delete(int id)
        {
            var entity = dbSet.Find(id);
            return dbSet.Remove(entity);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public List<T> GetAll()
        {
            var list = datacontext.Set<T>().ToList();
            return list;
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            datacontext.Entry(entity).State = EntityState.Modified;
        }

        public int Count(Expression<Func<T, bool>> where)
        {
            return dbSet.Count(where);
        }
    }
}

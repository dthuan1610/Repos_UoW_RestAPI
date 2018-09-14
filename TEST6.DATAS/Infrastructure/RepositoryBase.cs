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

        public IQueryable<T> Search(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> _PageContent = predicate != null ? datacontext.Set<T>().Where<T>(predicate).AsQueryable() : datacontext.Set<T>().AsQueryable();
            return _PageContent;
        }

        public List<T> Paging(IQueryable<T> _PageContent, Expression<Func<T, string>> orderby, int pageNumber, int pageSize, bool asc)
        {
            if (asc == true)
            {
                _PageContent =_PageContent.OrderBy(orderby);
            }
            else
            {
                _PageContent = _PageContent.OrderByDescending(orderby);
            }

            int skipcount = (pageNumber - 1) * pageSize;
            _PageContent = skipcount == 0 ? _PageContent.Take(pageSize) : _PageContent.Skip(skipcount).Take(pageSize);

            return _PageContent.ToList();
        }
    }
}

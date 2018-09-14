using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST6.MODELS.Model;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.Data.SqlClient;

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

        public IQueryable<T> GetAll()
        {
            var list = datacontext.Set<T>();
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

        public IQueryable<T> Sort(string orderbyname, string table , bool asc)
        {
            if (orderbyname == "fullname")
            {
                orderbyname = "CONCAT(first_name,' ',last_name)";
            }
            var x = $"SELECT * FROM {table} order by {orderbyname}";
            if(asc != true)
            {
                 x = $"SELECT * FROM {table} order by {orderbyname} DESC";
            }
            IQueryable<T> sortresult = DbContext.Database.SqlQuery<T>(x).AsQueryable();
            return sortresult;
        }

        public IQueryable<T> Paging(IQueryable<T> _PageContent, int pageNumber, int pageSize)
        {
            int skipcount = (pageNumber - 1) * pageSize;
            _PageContent = skipcount == 0 ? _PageContent.Take(pageSize) : _PageContent.Skip(skipcount).Take(pageSize);

            return _PageContent;
        }

        public IQueryable<T> SearchSort(string table,string searchingstring , string searchfield , string orderbyname , bool asc)
        {
            if (orderbyname == "fullname")
            {
                orderbyname = "CONCAT(first_name,' ',last_name)";
            }
            var x = $"SELECT * FROM {table} where {searchfield} like '%{searchingstring}%' ORDER BY {orderbyname}";
            if (asc != true)
            {
                x = $"SELECT * FROM {table} where {searchfield} like '%{searchingstring}%' ORDER BY {orderbyname}";
            }
            IQueryable<T> searchresult = DbContext.Database.SqlQuery<T>(x).AsQueryable();
            return searchresult;
        }

    }
}

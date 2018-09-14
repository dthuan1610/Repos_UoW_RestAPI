using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TEST6.DATAS.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);

        void Update(T entity);

        T Delete(int id);

        T Get(int id);

        IQueryable<T> GetAll();

        int Count(Expression<Func<T, bool>> where);

        IQueryable<T> SearchSort(string table, string searchingstring, string searchfield , string orderbyname, bool asc);

        IQueryable<T> Sort(string orderbyname, string table , bool asc);

        IQueryable<T> Paging(IQueryable<T> _PageContent, int pageNumber, int pageSize);
    }
}

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

        List<T> GetAll();

        int Count(Expression<Func<T, bool>> where);

        IQueryable<T> Search(Expression<Func<T, bool>> predicate);

        List<T> Paging(IQueryable<T> _PageContent, Expression<Func<T, string>> orderby, int pageNumber, int pageSize, bool asc = true);
    }
}

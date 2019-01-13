using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IBasicMethods<T> where T :class
    {
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindEager(Expression<Func<T, bool>> predicate, List<string> paths);
        T FindSingleEager(Expression<Func<T, bool>> predicate, List<string> paths);
        T Get(int id);
        T Get(Guid id);

        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllEager(List<string> paths);
        T Remove(T entity);
        IEnumerable<T> RemoveRange(IEnumerable<T> entities);
        T FindFirst(Expression<Func<T, bool>> predicate);
        T FindFirstEager(Expression<Func<T, bool>> predicate, List<string> paths);

        Guid  GenerateGUID();
    }
}

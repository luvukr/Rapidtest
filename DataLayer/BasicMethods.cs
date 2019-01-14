using DBEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataLayer
{
    public class BasicMethods<T> :  IBasicMethods<T> where T : class
    {
        protected EmployeeDbModel Context { get; }

        public BasicMethods(EmployeeDbModel dbContext)
        {
            Context = dbContext;
        }

        public T Add(T entity)
        {
             return Context.Set<T>().Add(entity);
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities) => Context.Set<T>().AddRange(entities);

        public bool Any(Expression<Func<T, bool>> predicate) => Context.Set<T>().Any<T>(predicate);

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate) => Context.Set<T>().Where(predicate);

        public ICollection<TType> Find<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select) where TType : class => Context.Set<T>().Where(where).Select(select).ToList();

        public IQueryable<T> AsQueyable() => Context.Set<T>().AsQueryable();

        public IEnumerable<T> FindEager(Expression<Func<T, bool>> predicate, List<string> paths)
        {
            var query = Context.Set<T>().Where(predicate);

            foreach (string path in paths)
            {
                query = query.Include(path);
            }

            return query.AsEnumerable<T>();
        }

        public IEnumerable<T> FindNonTracking(Expression<Func<T, bool>> predicate) => Context.Set<T>().AsNoTracking<T>().Where(predicate);

        public T FindSingle(Expression<Func<T, bool>> predicate) => Context.Set<T>().SingleOrDefault(predicate);

        public T FindFirst(Expression<Func<T, bool>> predicate) => Context.Set<T>().FirstOrDefault(predicate);

        public T FindFirstEager(Expression<Func<T, bool>> predicate, List<string> paths)
        {
            var query = Context.Set<T>().Where(predicate);

            foreach (string path in paths)
            {
                query = query.Include(path);
            }

            return query.FirstOrDefault<T>();
        }

        public T FindSingleEager(Expression<Func<T, bool>> predicate, List<string> paths)
        {
            var query = Context.Set<T>().Where(predicate);

            foreach (string path in paths)
            {
                query = query.Include(path);
            }

            return query.SingleOrDefault<T>();
        }

        public T Get(int id) => Context.Set<T>().Find(id);



        public T Get(Guid id) => Context.Set<T>().Find(id);

        public IEnumerable<T> GetAll() => Context.Set<T>().AsEnumerable<T>();

        public ICollection<TType> GetAll<TType>(Expression<Func<T, TType>> select) where TType : class => Context.Set<T>().Select(select).ToList();

        public IEnumerable<T> GetAllEager(List<string> paths)
        {
            var query = Context.Set<T>().AsQueryable();

            foreach (string path in paths)
            {
                query = query.Include(path);
            }

            return query.AsEnumerable<T>();
        }

        public T Update(T entity)
        {
            Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity;
        }

        public T Remove(T entity)
        {
            entity = Context.Set<T>().Remove(entity);
            return entity;
        }

        public IEnumerable<T> RemoveRange(IEnumerable<T> entities)
        {
            entities = Context.Set<T>().RemoveRange(entities);
            return entities;
        }
        

        public Guid GenerateGUID( )
        {
            bool isUnique = true;
            while (isUnique)
            {
                Guid temp = Guid.NewGuid();
                var es = Get(temp);
                if (es == null)
                    return temp;
            }
            return new Guid();
        }
    }
}

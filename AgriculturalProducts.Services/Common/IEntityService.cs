using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AgriculturalProducts.Services
{
    public interface IEntityService<T>:IService
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RevmoveRange(IEnumerable<T> entities);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);
    }
}

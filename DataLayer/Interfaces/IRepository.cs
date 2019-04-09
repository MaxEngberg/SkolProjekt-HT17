using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DataLayer.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(int id);
        void Add(T item);
        void Edit(T item);
        void Remove(int id);
        void Save(T item);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> text);
        IQueryable<T> ShowAll();
    }
}
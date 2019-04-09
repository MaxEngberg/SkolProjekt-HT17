using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace DataLayer.Repositories.Bas
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public DbSet<T> Items => context.Set<T>();

        public void Add(T item)
        {
            Items.Add(item);
        }

        public void Edit(T item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public T GetById(int id)
        {
            return Items.Find(id);
        }

        public void Remove(int id)
        {
            var entity = GetById(id);
            Items.Remove(entity);
        }

        public void Save(T item)
        {
            context.SaveChanges();
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> text)
        {
            return Items.Where(text);
        }

        public IQueryable<T> ShowAll()
        {
            return Items;
        }
    }
}
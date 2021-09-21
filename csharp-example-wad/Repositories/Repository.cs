using csharp_example_wad.Models;
using csharp_example_wad.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace csharp_example_wad.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly ApplicationDbContext cnn;

        private readonly DbSet<T> tbl;

        public Repository()
        {
            cnn = new ApplicationDbContext();
            tbl = cnn.Set<T>();
        }

        public void Add(T e)
        {
            tbl.Add(e);
            cnn.SaveChanges();
        }

        public void AddRange(List<T> e)
        {
            tbl.AddRange(e);
            cnn.SaveChanges();
        }

        public bool CheckDuplicate(Expression<Func<T, bool>> predicate)
        {
            return tbl.AsNoTracking().Any(predicate);
        }

        public void Delete(object id)
        {
            var entity = Get(id);
            tbl.Remove(entity);
            cnn.SaveChanges();
        }

        public void Delete(T e)
        {
            tbl.Remove(e);
            cnn.SaveChanges();
        }

        public void Edit(T e)
        {
            cnn.Entry(e).State = EntityState.Modified;
            cnn.SaveChanges();
        }

        public IEnumerable<T> Get()
        {
            return tbl.AsEnumerable();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return tbl.Where(predicate).AsEnumerable();
        }

        public T Get(object id)
        {
            return tbl.Find(id);
        }

        public void Remove(object id)
        {
            var entity = Get(id);
            if (entity == null) return;
            tbl.Remove(entity);
            cnn.SaveChanges();
        }

        public void Update(T entity)
        {
            cnn.Entry(entity).State = EntityState.Modified;
            cnn.SaveChanges();
        }
    }
}
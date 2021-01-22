using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Northwind2.Entities;

namespace Northwind2.Repositories
{
    public class CrudRepository<T> : ICrudRepository<T> where T : class
    {
        private NorthwindContext _context = null;
        private DbSet<T> table = null;


        public CrudRepository(NorthwindContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}

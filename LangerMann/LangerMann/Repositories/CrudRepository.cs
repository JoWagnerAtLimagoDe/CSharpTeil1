using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LangerMann.Data;
using LangerMann.Repositories;
using Microsoft.EntityFrameworkCore;


namespace LangerMann.Repositories
{
    public class CrudRepository<T> : ICrudRepository<T> where T : class
    {
        private readonly BundesbankContext _context = null;
        private readonly DbSet<T> _table = null;


        public CrudRepository(BundesbankContext context)
        {
            this._context = context;
            _table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(object id)
        {
            return _table.Find(id);
        }

        public void Insert(T obj)
        {
            _table.Add(obj);
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}

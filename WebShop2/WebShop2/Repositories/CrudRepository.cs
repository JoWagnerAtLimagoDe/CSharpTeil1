using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebShop.Entities;

namespace WebShop.Repositories
{
    public class CrudRepository<T> : ICrudRepository<T> where T : class
    {
        private readonly WebShopContext _context = null;
        private readonly DbSet<T> _table = null;


        public CrudRepository(WebShopContext context)
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

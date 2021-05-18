using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BBk.Rc1.Ricis.CrudRepository
{
    public class CrudRepository<E> : ICrudRepository<E> 
        where E : class
    {
        private readonly DbContext _context;
        private readonly DbSet<E> _table;

        public CrudRepository(DbContext context)
        {
            _context = context;
            _table = _context.Set<E>();
        }

        public IEnumerable<E> GetAll()
        {
            return _table.ToList();
        }

        public E GetById(object id)
        {
            return _table.Find(id);
        }

        public void Insert(E obj)
        {
            _table.Add(obj);
        }

        public void Update(E obj)
        {
            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            E existing = _table.Find(id);
            _table.Remove(existing);
        }
        public void DeleteAll()
        {
            // Könnte noch optimiert werden!
            _table.RemoveRange(GetAll());
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

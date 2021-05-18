using System.Collections.Generic;

namespace BBk.Rc1.Ricis.CrudRepository
{
    public interface ICrudRepository<E> 
        where E : class
    {
        IEnumerable<E> GetAll();
        E GetById(object id);
        void Insert(E obj);
        void Update(E obj);
        void Delete(object id);
        void DeleteAll();
        void Save();
    }
}

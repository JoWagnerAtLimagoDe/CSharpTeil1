using System.Collections.Generic;
using System.Linq;
using BBk.Rc1.Ricis.CrudRepository;
using Microsoft.EntityFrameworkCore;

namespace BBk.Rc1.Ricis.DataImport.Step.Reader.Database.Repository
{
    public class RepositoryReader<E, C> : AbstractReader<List<E>> 
        where E : class
        where C : DbContext, new()
    {
        public override List<E> Read()
        {
            using (var context = new C())
            {
                return new CrudRepository<E>(context).GetAll().ToList();

                //Alternativ (ohne Linq):
                //return (List<E>)new CrudRepository<E>(context).GetAll();
            }
            
        }
    }
}

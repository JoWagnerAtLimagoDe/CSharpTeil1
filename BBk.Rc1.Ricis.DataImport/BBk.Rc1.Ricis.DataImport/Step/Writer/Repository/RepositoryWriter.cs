using BBk.Rc1.Ricis.CrudRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BBk.Rc1.Ricis.DataImport.Step.Writer.Repository
{
    public class RepositoryWriter<E, C> : AbstractWriter<IList<E>> 
        where E : class
        where C : DbContext, new()
    {
        public override void Write(IList<E> t)
        {
            using (var context = new C())
            {
                ICrudRepository<E> repo = new CrudRepository<E>(context);
                foreach (var item in t)
                {
                    repo.Insert(item);
                }
                repo.Save();
                
            }
        }
    }
}

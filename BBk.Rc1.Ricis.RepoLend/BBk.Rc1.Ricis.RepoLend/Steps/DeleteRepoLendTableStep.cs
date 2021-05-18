using BBk.Rc1.Ricis.CrudRepository;
using BBk.Rc1.Ricis.DataImport.Step;
using BBk.Rc1.Ricis.RepoLend.Data.Contexts;
using BBk.Rc1.Ricis.RepoLend.Data.Entites;

namespace BBk.Rc1.Ricis.RepoLend.Steps
{
    public class DeleteRepoLendTableStep:AbstractStep
    {
        public override void Execute()
        {
            using (var context = new RicisRawContext())
            {
                ICrudRepository<RepoLendIO> repo = new CrudRepository<RepoLendIO>(context);
                repo.DeleteAll();
                repo.Save();
            }
                
        }

        public static DeleteRepoLendTableStep GetInstance()
        {
            return new DeleteRepoLendTableStep();
        }
    }
}

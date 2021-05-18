using BBk.Rc1.Ricis.DataImport.Step.Writer.Repository;
using BBk.Rc1.Ricis.RepoLend.Data.Contexts;
using BBk.Rc1.Ricis.RepoLend.Data.Entites;

namespace BBk.Rc1.Ricis.RepoLend.Steps.Writer
{
    public class RepoLendRepositoryWriter : RepositoryWriter<RepoLendIO, RicisRawContext>
    {
        public static RepoLendRepositoryWriter GetInstance()
        {
            return new RepoLendRepositoryWriter();
        }
    }
}

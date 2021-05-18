using BBk.Rc1.Ricis.DataImport.Alerts;
using BBk.Rc1.Ricis.DataImport.Step.Processors.GenericProcessors;
using BBk.Rc1.Ricis.RepoLend.Data.Entites;
using System;
using System.Collections.Generic;
using BBk.Rc1.Ricis.RepoLend.Business;

namespace BBk.Rc1.Ricis.RepoLend.Steps.Processors
{
    public class RepoLendCheckerProcessor : CheckerTransformer<IList<RepoLendIO>, IList<RepoLendIO>>
    {
        public RepoLendCheckerProcessor(IList<IBusinessRulesChecker<IList<RepoLendIO>>> checkers, ITransformer<IList<RepoLendIO>, IList<RepoLendIO>> transformer) : base(checkers, transformer)
        {
        }

        public static RepoLendCheckerProcessor GetInstance()
        {
            IList<IBusinessRulesChecker<IList<RepoLendIO>>> checkers =
                new List<IBusinessRulesChecker<IList<RepoLendIO>>>();
            checkers.Add(new FieldChecker());
            checkers.Add(new MultiFieldChecker());
            checkers.Add(new MultiRecordChecker());
            return new RepoLendCheckerProcessor(checkers, new Transformer());
        }
    }

    class FieldChecker : IBusinessRulesChecker<IList<RepoLendIO>>
    {
        public IList<DataImportAlert> Check(IList<RepoLendIO> p)
        {
            new XYServive().foo();
            return new List<DataImportAlert>();
        }
    }
    class MultiFieldChecker : IBusinessRulesChecker<IList<RepoLendIO>>
    {
        public IList<DataImportAlert> Check(IList<RepoLendIO> p)
        {
            Console.WriteLine("MultiFieldChecker called");
            return new List<DataImportAlert>();
        }
    }
    class MultiRecordChecker : IBusinessRulesChecker<IList<RepoLendIO>>
    {
        public IList<DataImportAlert> Check(IList<RepoLendIO> p)
        {
            Console.WriteLine("MultiRecordChecker called");
            return new List<DataImportAlert>();
        }
    }

    class Transformer : ITransformer<IList<RepoLendIO>, IList<RepoLendIO>>
    {
        public IList<RepoLendIO> Transform(IList<RepoLendIO> p)
        {
            Console.WriteLine("Transformer called");
            return p;
        }
    }

}

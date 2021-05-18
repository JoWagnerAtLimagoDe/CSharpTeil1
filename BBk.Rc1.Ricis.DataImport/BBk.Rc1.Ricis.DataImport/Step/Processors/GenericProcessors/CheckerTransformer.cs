using BBk.Rc1.Ricis.DataImport.Alerts;
using System.Collections.Generic;

namespace BBk.Rc1.Ricis.DataImport.Step.Processors.GenericProcessors
{
    public class CheckerTransformer<P, R> : AbstractProcessor<P, R>
    {

        private readonly IList<IBusinessRulesChecker<P>> _checkers;

       
        private readonly ITransformer<P, R> _transformer;

        public CheckerTransformer(IList<IBusinessRulesChecker<P>> checkers,  
            ITransformer<P, R> transformer)
        {
            _checkers = checkers ?? (new List<IBusinessRulesChecker<P>>());
            
            this._transformer = transformer;
        }

        public override R Process(P p)
        {
            IList<IList<DataImportAlert>> warnings = new List<IList<DataImportAlert>>();

            foreach (var checker in _checkers)
            {
                warnings.Add(checker.Check(p));
            }
            
          
            return _transformer.Transform(p);
        }
    }
}

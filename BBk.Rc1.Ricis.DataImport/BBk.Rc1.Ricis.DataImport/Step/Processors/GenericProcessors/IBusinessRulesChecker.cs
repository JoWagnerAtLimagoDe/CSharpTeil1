using System.Collections.Generic;
using BBk.Rc1.Ricis.DataImport.Alerts;

namespace BBk.Rc1.Ricis.DataImport.Step.Processors.GenericProcessors
{
    public interface IBusinessRulesChecker<in P>
    {
        IList<DataImportAlert> Check(P p);
    }
}


namespace BBk.Rc1.Ricis.DataImport.Step.Processors.GenericProcessors
{
    public interface ITransformer<in P, out R>
    {
        R Transform(P p);
    }
}

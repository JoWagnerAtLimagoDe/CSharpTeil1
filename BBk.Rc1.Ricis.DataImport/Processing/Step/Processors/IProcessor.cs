namespace BBk.Rc1.Ricis.DataImport.Step.Processors
{
    public interface IProcessor<in P, out R>
    {
        R Process(P p);
    }
}

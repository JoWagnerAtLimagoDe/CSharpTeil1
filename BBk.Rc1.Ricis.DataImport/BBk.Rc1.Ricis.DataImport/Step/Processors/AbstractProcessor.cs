namespace BBk.Rc1.Ricis.DataImport.Step.Processors
{
    public abstract class AbstractProcessor<P, R> : IProcessor<P, R>
    {
        public abstract R Process(P p);
    }
}

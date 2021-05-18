namespace BBk.Rc1.Ricis.DataImport.Step.Processors
{
    public class IdentityProcessor<T>: AbstractProcessor<T,T>

    {
        public override T Process(T p)
        {
            return p;
        }
    }
}

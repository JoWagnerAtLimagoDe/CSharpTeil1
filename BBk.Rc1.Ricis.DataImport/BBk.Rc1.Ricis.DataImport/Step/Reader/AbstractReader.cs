namespace BBk.Rc1.Ricis.DataImport.Step.Reader
{
    public abstract class AbstractReader<T>: IReader<T>
    {
        public virtual void Dispose()
        {
            // Ok
        }

        public abstract T Read();
    }
}

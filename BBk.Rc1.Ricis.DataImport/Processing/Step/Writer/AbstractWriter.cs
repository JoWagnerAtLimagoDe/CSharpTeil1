namespace BBk.Rc1.Ricis.DataImport.Step.Writer
{
    public abstract class AbstractWriter<T> : IWriter<T>
    {
        public virtual void Dispose()
        {
            // Ok
        }

        public abstract void Write(T t);

       
    }
}

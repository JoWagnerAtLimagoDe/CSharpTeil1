namespace BBk.Rc1.Ricis.DataImport.Step
{
    public abstract class AbstractStep : IStep
    {
        public virtual void Dispose()
        {
            // Ok
        }

        public abstract void Execute();

        public virtual void Init()
        {
            // Ok
        }
    }
}


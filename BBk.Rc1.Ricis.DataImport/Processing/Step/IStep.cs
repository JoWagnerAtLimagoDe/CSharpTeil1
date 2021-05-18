using System;

namespace BBk.Rc1.Ricis.DataImport.Step
{
    public interface IStep: IDisposable
    {
        void Init();
        void Execute();
      
    }
}

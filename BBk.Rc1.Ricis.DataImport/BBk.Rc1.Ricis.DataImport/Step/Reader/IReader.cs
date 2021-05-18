using System;

namespace BBk.Rc1.Ricis.DataImport.Step.Reader
{
    public interface IReader<out T>: IDisposable
    {
        T Read();
    }
}

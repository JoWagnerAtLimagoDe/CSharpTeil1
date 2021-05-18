using System;

namespace BBk.Rc1.Ricis.DataImport.Step.Writer
{
    public interface IWriter<in T>:IDisposable
    {
        void Write(T t);
    }
}

using Newtonsoft.Json;

namespace BBk.Rc1.Ricis.DataImport.Step.Writer.Console
{
    public class ConsoleWriter<T>: AbstractWriter<T>
    {
        public override void Write(T t)
        {
            new JsonSerializer().Serialize(System.Console.Out, t, typeof(T));
        }
    }
}

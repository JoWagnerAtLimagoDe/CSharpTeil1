using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BBk.Rc1.Ricis.DataImport.Step.Reader.File.Resources
{
    public class StringStreamReaderResource: IStreamReaderResource
    {
        private readonly string _resourceString;

        public StringStreamReaderResource(string resourceString)
        {
            _resourceString = resourceString;
        }

        public StreamReader GetStreamReader()
        {
            return GenerateStreamReaderFromResourceString(_resourceString);
        }

        private static StreamReader GenerateStreamReaderFromResourceString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return new StreamReader(stream);
        }
    }
}

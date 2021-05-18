using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BBk.Rc1.Ricis.DataImport.Step.Reader.File.Resources
{
    public class FileStreamReaderResource: IStreamReaderResource
    {
        public FileInfo FileInfo { get; set; }

        public FileStreamReaderResource(FileInfo fileInfo)
        {
            FileInfo = fileInfo;
        }
        public FileStreamReaderResource(string filename)
        {
            FileInfo = new FileInfo(filename);
        }

        public StreamReader GetStreamReader()
        {
            return new StreamReader(FileInfo.FullName);
        }
    }
}

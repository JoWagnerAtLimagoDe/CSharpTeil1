using System.IO;

namespace BBk.Rc1.Ricis.DataImport.Step.Writer.File.Resources
{
    public class FileStreamWriterResource: IStreamWriterResource
    {
        public FileInfo FileInfo { get; set; }

        public FileStreamWriterResource(FileInfo fileInfo)
        {
            FileInfo = fileInfo;
        }
        public FileStreamWriterResource(string filename)
        {
            FileInfo = new FileInfo(filename);
        }

        public StreamWriter GetStreamWriter()
        {
            return new StreamWriter(FileInfo.FullName);
        }
    }
}

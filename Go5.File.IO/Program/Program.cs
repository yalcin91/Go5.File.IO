using System;
using System.IO;
using System.IO.Compression;
using Go5.File.IO.bestanden;

namespace Go5.File.IO
{
    class Program
    {
        static void Main(string[] args)
        {
            MakeDirectory makeDirectory = new MakeDirectory();
            StreamReaderClassen streamReaderClassen = new StreamReaderClassen();
            StreamReaderCsBestanden streamReaderCsBestanden = new StreamReaderCsBestanden();
            Write write = new Write();

            makeDirectory.MakeDirectoryNow();
            streamReaderClassen.StreamRead();
            streamReaderCsBestanden.StreamRead();
            write.WriteTxtClassInfo();
            write.WriteTxtCsBestanden();

            //makeDirectory.MakeFile();
        }
    }
}

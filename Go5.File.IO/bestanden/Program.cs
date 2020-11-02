using System;
using System.IO;
using System.IO.Compression;
using Go5.File.IO.classen;

namespace Go5.File.IO
{
    class Program
    {
        static void Main(string[] args)
        {
            I_O file = new I_O();

            file.MakeDirectory();
            file.StreamRead();
            file.Write();

            //file.MakeFile();
        }
    }
}

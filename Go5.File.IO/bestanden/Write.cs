using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.IO.Compression;

namespace Go5.File.IO.bestanden
{
    public class Write
    {
        MakeDirectory makeDirectory = new MakeDirectory();
        StreamReaderClassen StreamReaderClassen = new StreamReaderClassen();
        StreamReaderCsBestanden streamReaderCsBestanden = new StreamReaderCsBestanden();

        public void WriteTxtClassInfo()
        {
            string fullPath = makeDirectory.InputFolder + makeDirectory.FileNameForClass;
            FileInfo fi = new FileInfo(fullPath);
            using StreamWriter sw = fi.CreateText();
            for (int i = 0; i < StreamReaderClassen.GeefLijstOpgeslagen().Count; i++)
            {
                sw.WriteLine(StreamReaderClassen.GeefLijstOpgeslagen()[i]);
            }
            sw.Close();
        }

        public void WriteTxtCsBestanden()
        {
            string fullPath = makeDirectory.InputFolder + makeDirectory.FileNameForCsBestanden;
            FileInfo fi = new FileInfo(fullPath);
            using StreamWriter sw = fi.CreateText();
            for (int i = 0; i < streamReaderCsBestanden.GeefLijstOpgeslagen().Count; i++)
            {
                sw.WriteLine(streamReaderCsBestanden.GeefLijstOpgeslagen()[i]);
            }
            sw.Close();
        }
    }
}

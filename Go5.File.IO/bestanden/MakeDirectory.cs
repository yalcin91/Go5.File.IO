using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Go5.File.IO.bestanden
{
    public class MakeDirectory
    {
        public string InputFolder = @"D:\Users\Yalcin\Desktop\HBO5\Programmeren Gevorderd\Taak - 5) File-IO\InputFolder\";
        public string ZipBestand = @"D:\Users\Yalcin\Desktop\HBO5\Programmeren Gevorderd\Taak - 2) Collecties\Go5.Collecties.Nieuwste.zip";
        public string ToRead_cs = @"D:\Users\Yalcin\Desktop\HBO5\Programmeren Gevorderd\Taak - 5) File-IO\InputFolder\Go5.Collections_Nieuwste_Console\Go5.Collections.Nieuwste\Go5.Collections.Nieuwste\Collecties";   
        public string FileNameForClass = "Go5.ClassInfo.txt";
        public string FileNameForCsBestanden = "Go5.Analyse.txt";

        public void MakeDirectoryNow()
        {
            if (!Directory.Exists(InputFolder))
            {
                Directory.CreateDirectory(InputFolder);
                ZipFile.ExtractToDirectory(ZipBestand, InputFolder);
            }
        }
        //---------------------------------------------------
        //public void MakeFile()
        //{
        //    string fullPath = InputFolder + FileName;
        //    FileInfo fi = new FileInfo(fullPath);
        //    if (!fi.Exists)
        //    {
        //        fi.Create();
        //    }
        //}
        //---------------------------------------------------        
    }
}

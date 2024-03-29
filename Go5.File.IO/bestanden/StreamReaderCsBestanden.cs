﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Go5.File.IO.bestanden
{
    public class StreamReaderCsBestanden
    {
        MakeDirectory makeDirectory = new MakeDirectory();

        public static List<string> _LijstOpslagen = new List<string>();

        List<string> _Alles = new List<string>();
        List<string> _Namespace = new List<string>();
        List<string> _Klass = new List<string>();
        List<string> _Interface = new List<string>();
        List<string> _Lijn = new List<string>();
        List<string> _Foutmelding = new List<string>();
        int countLijn = 0;
        public void StreamRead()
        {
            string[] arrDirectoryFiles = Directory.GetFiles(makeDirectory.ToRead_cs);
            for (int i = 0; i < arrDirectoryFiles.Length; i++)
            {
                _Foutmelding.Add("FOUTMELDING: ");
                _Klass.Add("CLASS: ");
                _Interface.Add("Interface: ");
                _Lijn.Add("LIJNEN: ");
                _Namespace.Add("NAMESPACE: ");
                string path = arrDirectoryFiles[i];
                string fullPath = Path.Combine(makeDirectory.ToRead_cs, path);
                string line;
                string classnaam = "***";
                using (StreamReader reader = new StreamReader(fullPath))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains("namespace"))
                        {
                            _Namespace.Add(line.Trim());
                        }
                        if (line.Contains("class"))
                        {
                            string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                            if (parts[0] == "class")
                            {
                                _Klass.Add(parts[1].Trim());
                                classnaam = parts[1];
                            }
                            else
                            {
                                _Klass.Add(parts[2].Trim());
                                classnaam = parts[2];
                            }
                            _Alles.Add(line.Trim());
                            Array.Clear(parts, 0, parts.Length);
                        }
                        if (line.Contains("interface"))
                        {
                            string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                            if (parts[0] == "interface")
                            {
                                _Interface.Add(parts[1].Trim());
                                classnaam = parts[1];
                            }
                            else
                            {
                                _Interface.Add(parts[2].Trim());
                                classnaam = parts[2];
                            }
                            _Alles.Add(line.Trim());
                            Array.Clear(parts, 0, parts.Length);
                        }
                        if (!line.Contains("\n"))
                        {
                            countLijn++;
                        }
                    }
                    reader.Close();
                }
                if (_Alles.Count > 1)
                {
                    _Foutmelding.Add("FOUT!!  Er bevinden zich meer dan 1 class'e in een bestand!");
                }
                _Lijn.Add(countLijn.ToString());

                //_Namespace.ForEach(Console.WriteLine);
                //Console.WriteLine("------------------------------------------------------------------------------------");
                //_Klass.ForEach(Console.WriteLine);
                //Console.WriteLine("------------------------------------------------------------------------------------");
                //_Lijn.ForEach(Console.WriteLine);
                //Console.WriteLine("------------------------------------------------------------------------------------");
                //_Foutmelding.Add("______________________________________________________________________________________");
                //_Foutmelding.ForEach(Console.WriteLine);
                if (_Klass.Count == 1) _Klass.Add("Geen Classe!");
                if (_Interface.Count == 1) _Interface.Add("Geen Interface!");
                if (_Foutmelding.Count == 1) _Foutmelding.Add("Geen twee classen in  een bestand!");

                foreach (string s in _Namespace)
                {
                    _LijstOpslagen.Add(s);
                }
                _LijstOpslagen.Add("\n");
                foreach (string s in _Klass)
                {
                    _LijstOpslagen.Add(s);
                }
                _LijstOpslagen.Add("\n");
                foreach (string s in _Interface)
                {
                    _LijstOpslagen.Add(s);
                }
                _LijstOpslagen.Add("\n");
                foreach (string s in _Lijn)
                {
                    _LijstOpslagen.Add(s);
                }
                _LijstOpslagen.Add("\n");
                foreach (string s in _Foutmelding)
                {
                    _LijstOpslagen.Add(s);
                }
                _LijstOpslagen.Add("______________________________________________________________________________________");
                _Alles.Clear();
                _Foutmelding.Clear();
                _Klass.Clear();
                _Interface.Clear();
                _Lijn.Clear();
                _Namespace.Clear();
                countLijn = 0;
            }
        }
        public List<string> GeefLijstOpgeslagen()
        {
            return _LijstOpslagen;
        }
    }
}

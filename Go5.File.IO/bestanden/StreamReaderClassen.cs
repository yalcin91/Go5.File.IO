using System;
using System.Collections.Generic;
using System.IO;

namespace Go5.File.IO.bestanden
{
    public class StreamReaderClassen
    {
        MakeDirectory makeDirectory = new MakeDirectory();

        public static List<string> _LijstOpslagen = new List<string>();

        List<string> _Using = new List<string>();
        List<string> _Namespace = new List<string>();
        List<string> _Klass = new List<string>();
        List<string> _Method = new List<string>();
        List<string> _Properties = new List<string>();
        List<string> _Inherits = new List<string>();
        List<string> _Constructor = new List<string>();
        public void StreamRead()
        {
            string[] arrDirectoryFiles = Directory.GetFiles(makeDirectory.ToRead_cs);
            for (int i = 0; i < arrDirectoryFiles.Length; i++)
            {
                _Using.Add("USING: ");
                _Namespace.Add("NAMESPACE: ");
                _Klass.Add("CLASS: ");
                _Method.Add("METHODS: ");
                _Properties.Add("PROPERTIES: ");
                _Inherits.Add("INHERITS: ");
                _Constructor.Add("CONSTRUCTOR: ");
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
                            _Namespace.Add(line);
                        }
                        if (line.Contains("class"))
                        {
                            string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                            if (parts[0] == "class")
                            {
                                _Klass.Add(parts[1]);
                                classnaam = parts[1];
                            }
                            else
                            {
                                _Klass.Add(parts[2]);
                                classnaam = parts[2];
                            }
                        }
                        if (line.Contains("public " + classnaam))
                        {
                            _Constructor.Add(line);
                        }
                        if (line.Contains("public void"))
                        {
                            _Method.Add(line);
                        }
                        if (line.Contains("{ get; set; }"))
                        {
                            _Properties.Add(line);
                        }
                        if (line.Contains("using System"))
                        {
                            _Using.Add(line);
                        }
                        if (line.Contains("class") && line.Contains(":"))
                        {
                            _Inherits.Add(line);
                        }
                    }
                    reader.Close();
                }
                _Using.ForEach(Console.WriteLine);
                Console.WriteLine("------------------------------------------------------------------------------------");
                _Namespace.ForEach(Console.WriteLine);
                Console.WriteLine("------------------------------------------------------------------------------------");
                _Klass.ForEach(Console.WriteLine);
                Console.WriteLine("------------------------------------------------------------------------------------");
                _Method.ForEach(Console.WriteLine);
                Console.WriteLine("------------------------------------------------------------------------------------");
                _Properties.ForEach(Console.WriteLine);
                Console.WriteLine("------------------------------------------------------------------------------------");
                _Inherits.ForEach(Console.WriteLine);
                Console.WriteLine("------------------------------------------------------------------------------------");
                _Constructor.ForEach(Console.WriteLine);
                Console.WriteLine("______________________________________________________________________________________\n\n\n\n");

                foreach (string s in _Using)
                {
                    _LijstOpslagen.Add(s);
                }
                _LijstOpslagen.Add("\n");
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
                foreach (string s in _Method)
                {
                    _LijstOpslagen.Add(s);
                }
                _LijstOpslagen.Add("\n");
                foreach (string s in _Properties)
                {
                    _LijstOpslagen.Add(s);
                }
                _LijstOpslagen.Add("\n");
                foreach (string s in _Inherits)
                {
                    _LijstOpslagen.Add(s);
                }
                _LijstOpslagen.Add("\n");
                foreach (string s in _Constructor)
                {
                    _LijstOpslagen.Add(s);
                }
                _LijstOpslagen.Add("______________________________________________________________________________________\n\n\n\n");
                _Inherits.Clear();
                _Klass.Clear();
                _Method.Clear();
                _Namespace.Clear();
                _Properties.Clear();
                _Using.Clear();
                _Constructor.Clear();
            }
        }
        public List<string> GeefLijstOpgeslagen()
        {
            return _LijstOpslagen;
        }
    }
}

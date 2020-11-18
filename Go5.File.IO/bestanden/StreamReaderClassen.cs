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
        List<string> _VolledigString = new List<string>();
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
                string volledigString = "";
                using (StreamReader reader = new StreamReader(fullPath))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        volledigString += " " + line;
                    }
                    reader.Close();
                    string[] array = volledigString.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    for (int k = 0; k < array.Length; k++)
                    {
                        _VolledigString.Add(array[k]);
                    }

                    //-------------------------------------------------USING
                    for (int j = 0; j < _VolledigString.Count; j++)
                    {
                        if (_VolledigString[j] == "using")
                        {
                            _Using.Add(_VolledigString[j]);
                            int c = 0;
                            while(c == 0)
                            {
                                j++;
                                foreach (char m in _VolledigString[j])
                                {
                                    if (m.ToString() == ";") c = 1;
                                }
                                _Using[_Using.Count -1] += " " + (_VolledigString[j]);
                            }
                        }
                    }

                    //-------------------------------------------------NAMESPACE
                    for (int j = 0; j < _VolledigString.Count; j++)
                    {
                        if (_VolledigString[j] == "namespace")
                        {
                            _Namespace.Add(_VolledigString[j]);
                            j++;
                            _Namespace[_Namespace.Count -1] += " " + (_VolledigString[j]);
                        }
                    }

                    //-------------------------------------------------CLASS
                    for (int j = 0; j < _VolledigString.Count; j++)
                    {
                        if (_VolledigString[j] == "class")
                        {
                            _Klass.Add(_VolledigString[j+1]);
                            classnaam = _VolledigString[j + 1];
                        }
                    }

                    //-------------------------------------------------METHODE
                    for (int j = 0; j < _VolledigString.Count; j++)
                    {
                        if (_VolledigString[j] == "void")
                        {
                            _Method.Add(_VolledigString[j -1]);
                            _Method[_Method.Count - 1] += " " + _VolledigString[j];
                            int c = 0;
                            int open = 0;
                            int gesloten = 0;
                            while (c == 0)
                            {
                                j++;
                                foreach (char m in _VolledigString[j])
                                {
                                    if (m.ToString() == "(") open++;
                                    if (m.ToString() == ")") { gesloten++; if (gesloten == open) c = 1; }
                                }
                                _Method[_Method.Count - 1] += " " + (_VolledigString[j]);
                            }
                        }
                    }

                    //-------------------------------------------------PROPERTY
                    for (int j = 0; j < _VolledigString.Count; j++)
                    {
                        if (_VolledigString[j] == "{" && _VolledigString[j+1] == "get;")
                        {
                            _Properties.Add(_VolledigString[j - 3]);
                            _Properties[_Properties.Count - 1] += " " + _VolledigString[j-2] + " " + _VolledigString[j - 1] + " " + _VolledigString[j];
                            int c = 0;
                            int open = 1;
                            int gesloten = 0;
                            while (c == 0)
                            {
                                j++;
                                foreach (char m in _VolledigString[j])
                                {
                                    if (m.ToString() == "{") open++;
                                    if (m.ToString() == "}") { gesloten++; if (gesloten == open) c = 1; }
                                }
                                _Properties[_Properties.Count - 1] += " " + (_VolledigString[j]);
                            }
                        }
                    }

                    //-------------------------------------------------OVERERVING
                    for (int j = 0; j < _VolledigString.Count; j++)
                    {
                        if (_VolledigString[j] == "class" && _VolledigString[j + 2] == ":")
                        {
                            _Inherits.Add(_VolledigString[j +1]);
                            _Inherits[_Inherits.Count - 1] += " " + _VolledigString[j+2] + " " + _VolledigString[j +3];
                        }
                    }

                    //-------------------------------------------------CONSTRUCTOR
                    for (int j = 0; j < _VolledigString.Count; j++)
                    {
                        if (_VolledigString[j].Contains(classnaam + "("))
                        {
                            _Constructor.Add(_VolledigString[j]);
                            int c = 0;
                            int open = 1;
                            int gesloten = 0;
                            while (c == 0)
                            {
                                j++;
                                foreach (char m in _VolledigString[j])
                                {
                                    if (m.ToString() == "(") open++;
                                    if (m.ToString() == ")") { gesloten++; if (gesloten == open) c = 1; }
                                }
                                _Constructor[_Constructor.Count - 1] += " " + (_VolledigString[j]);
                            }
                            classnaam = "***";
                        }
                    }
                }
                //_VolledigString.ForEach(Console.WriteLine);

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
                _Using.Clear();
                _Namespace.Clear();
                _Klass.Clear();
                _Method.Clear();
                _Properties.Clear();
                _Inherits.Clear();
                _Constructor.Clear();
                _VolledigString.Clear();
            }
        }

        public List<string> GeefLijstOpgeslagen()
        {
            return _LijstOpslagen;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace nagarro_dotNet_mar19
{
    namespace design
    {
        abstract public class Parser
        {
            string inpFile;
            string outFile;

            public Parser(string _inpFile, string _outFile)
            {
                this.inpFile = _inpFile;
                this.outFile = _outFile;

                if (File.Exists(_outFile))
                {
                    File.Delete(_outFile);
                }

            }

            public String[] ReadFile(string filepath)
            {
                return System.IO.File.ReadAllLines(filepath);
            }

            public void WriteFile(string filepath, List<String> lines)
            {
                System.IO.File.AppendAllLines(filepath, lines);
            }

            public void Parse()
            {
                String[] inpLines = this.ReadFile(inpFile);
                List<String> outLines = new List<string>();

                foreach(string line in inpLines)
                {
                    Logging.Debug($"Reading line:{line}");
                    string[] lineVal = line.Split(',');
                    string[] reqVal = new string[2];

                    int nameIdx = 0;
                    int monthIdx = 1;

                    reqVal[nameIdx] = this.GetName(lineVal);

                    try
                    {
                        var bdate = this.GetDate(lineVal);
                        reqVal[monthIdx] = bdate.Month.ToString() + "M";
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Cannot convert date, line:{line}");
                        continue;
                    }
                    outLines.Add($"{reqVal[0]},{reqVal[1]}");
                }

                Logging.Info($"Writing File to {Path.Combine(Directory.GetCurrentDirectory(), outFile)}");
                this.WriteFile(outFile, outLines);
            }

            abstract public string GetName(string[] lineVal);
            abstract public DateTime GetDate(string[] lineVal);

        }
    }
}

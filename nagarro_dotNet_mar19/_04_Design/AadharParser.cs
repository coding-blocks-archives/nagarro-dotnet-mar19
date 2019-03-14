using System;
using System.Collections.Generic;
using System.Text;

namespace nagarro_dotNet_mar19
{
    namespace design
    {
        class AadharParser : Parser
        {
            public AadharParser(string infile, string outfile) :
               base(infile, outfile)
            {
            }

            override
            public string GetName(string[] row)
            {
                int nameIdx = 1;
                return row[nameIdx].Trim();
            }

            override
            public DateTime GetDate(string[] row)
            {
                int dateIdx = 2;
                DateTime dateStr = DateTime.ParseExact(row[dateIdx], "yyyy-MM-dd", null); // todo ParseExact
                return dateStr;
            }
        }
    }
}

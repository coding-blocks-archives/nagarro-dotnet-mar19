using System;
using System.Collections.Generic;
using System.Text;

namespace nagarro_dotNet_mar19
{
    namespace design
    {
        class FaceBookParser : Parser
        {
            public FaceBookParser(string infile, string outfile):
                base(infile, outfile)
            {
            }

            public string GetName(string[] row)
            {
                int nameIdx = 0;
                return row[nameIdx].Trim();
            }

            public DateTime GetDate(string[] row)
            {
                int dateIdx = 1;
                DateTime dateStr = DateTime.Parse(row[dateIdx]); // todo ParseExact
                return dateStr;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace nagarro_dotNet_mar19
{
    namespace design
    {
        class Main
        {
            public static void main()
            {
                string fbFile = @"C:\Users\deepak\source\repos\nagarro_dotNet_mar19\" +
                                  "nagarro_dotNet_mar19\_04_Design\aadhar.csv";
                string adFile = @"C:\Users\deepak\source\repos\nagarro_dotNet_mar19\" +
                                  "nagarro_dotNet_mar19\_04_Design\facebook.csv";

                string outFile = @"output.csv";

                FaceBookParser fbparser = new FaceBookParser(fbFile, outFile);
                AadharParser adparser = new AadharParser(adFile, outFile);

                fbparser.Parse();
                adparser.Parse();

            }
        }
    }
}

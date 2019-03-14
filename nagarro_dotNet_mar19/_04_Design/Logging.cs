using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace nagarro_dotNet_mar19
{
    namespace design
    {
        public class Logging
        {
            public static void Info(string message,
                            [CallerFilePath] string file = "",
                            [CallerLineNumber] int line = 0)
            {
                Logging.print(message, "INFO", file, line);
            }

            public static void Debug(string message,
                           [CallerFilePath] string file = "",
                           [CallerLineNumber] int line = 0)
            {
                Logging.print(message, "DEBUG", file, line);
            }

            public static void Error(string message,
                           [CallerFilePath] string file = "",
                           [CallerLineNumber] int line = 0)
            {
                Logging.print(message, "ERROR", file, line);
            }

            private static void print(string message,
                            string level,
                            string file, int line)
            {
                Console.WriteLine($"{DateTime.Now}-{level}-{file}:{line}-{message}");
            }
        }

    }
}
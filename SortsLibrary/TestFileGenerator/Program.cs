using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFileGenerator
{
    class Program
    {
        const string OutFileFormat = "{0} ";

        static void RandomArrayGeneration(StreamWriter outFile, int arraySize, int lowBound, int highBound)
        {
            var generator = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < arraySize; i++)
            {
                var nextValue = generator.Next(lowBound, highBound);
                outFile.Write(String.Format(OutFileFormat, nextValue));
            }
        }

        static void Main(string[] args)
        {
            var options = new CommandLineOptions();
            if (args.Length > 0)
            {
                using (var fs = new FileStream(options.FileName, FileMode.Create))
                using (var sw = new StreamWriter(new BufferedStream(fs)))
                {
                    sw.WriteLine(options.ArraySize);
                    var orderType = (ArrayOrder) options.OrderType;

                    switch(orderType)
                    {
                        case ArrayOrder.Random:
                            RandomArrayGeneration(sw, options.ArraySize, options.LowElementBound, options.HighElementBound);
                            break;
                        case ArrayOrder.Asc:
                            break;
                        case ArrayOrder.Desc:
                            break;
                    }

                    sw.Flush();
                }
            }
            else
            {
                Console.WriteLine(options.GetUsage());
            }
        }
    }
}

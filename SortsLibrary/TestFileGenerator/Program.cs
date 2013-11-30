﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

[assembly: AssemblyInformationalVersion("0.0.1.6")]

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
                var nextValue = generator.Next(lowBound, highBound +1);
                outFile.Write(String.Format(OutFileFormat, nextValue));
            }
        }

        static void AscArrayGeneration(StreamWriter outFile, int arraySize, int lowBound, int highBound)
        {
            for (int i = 0; i < arraySize; i++)
            {
                var nextValue = lowBound < highBound? lowBound++ : highBound;
                outFile.Write(String.Format(OutFileFormat, nextValue));
            }
        }

        static void DescArrayGeneration(StreamWriter outFile, int arraySize, int lowBound, int highBound)
        {
            for (int i = 0; i < arraySize; i++)
            {
                var nextValue = highBound > lowBound ? highBound-- : lowBound;
                outFile.Write(String.Format(OutFileFormat, nextValue));
            }
        }

        static void Main(string[] args)
        {
            var options = new CommandLineOptions();
            if (args.Length > 0)
            {
                if (CommandLine.CommandLineParser.Default.ParseArguments(args, options))
                {
                    new FileInfo(options.FileName).Directory.Create();
                    using (var fs = new FileStream(options.FileName, FileMode.Create))
                    using (var sw = new StreamWriter(new BufferedStream(fs)))
                    {
                        sw.WriteLine(options.ArraySize);
                        var orderType = (ArrayOrder)options.OrderType;

                        switch (orderType)
                        {
                            case ArrayOrder.Random:
                                RandomArrayGeneration(sw, options.ArraySize, options.LowElementBound, options.HighElementBound);
                                break;
                            case ArrayOrder.Asc:
                                AscArrayGeneration(sw, options.ArraySize, options.LowElementBound, options.HighElementBound);
                                break;
                            case ArrayOrder.Desc:
                                DescArrayGeneration(sw, options.ArraySize, options.LowElementBound, options.HighElementBound);
                                break;
                        }

                        sw.Flush();
                    }
                }
            }
            else
            {
                Console.WriteLine(options.GetUsage());
            }
        }
    }
}

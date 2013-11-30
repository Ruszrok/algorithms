using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortsLibrary;
using System.IO;
using System.Reflection;

[assembly: AssemblyInformationalVersion("0.0.1.6")]

namespace SortApplication
{
    class Program
    {
        static int[] ReadArrayFromFile(string fileName)
        {
            int[] result = null;
            using (var reader = new StreamReader(fileName))
            {
                var size = Convert.ToInt32(reader.ReadLine());
                result = reader.ReadLine()
                        .Split(new[]{' '}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(s=>Convert.ToInt32(s)).ToArray();
            }
            return result;
        }

        static void WriteAnswerToFile(string fileName, int[] answer)
        {
            using (var writer = new StreamWriter(fileName))
            {
                writer.WriteLine(answer.Length);
                writer.WriteLine(String.Join(" ", answer));
            }
        }

        static void WriteTimeToFile(string fileName, TimeSpan timeForSort)
        {
            using (var writer = new StreamWriter(fileName))
            {
                writer.WriteLine(timeForSort.TotalMilliseconds);
            }
        }


        static void Main(string[] args)
        {
            var options = new CommandLineOptions();
            if (args.Length > 0)
            {
                if (CommandLine.CommandLineParser.Default.ParseArguments(args, options))
                {
                    var inArray = ReadArrayFromFile(options.InFileName);
                    var sortType = (SortType)options.SortType;
                    SortResult result = null;
                    switch(sortType)
                    {
                        case SortType.Quick:
                            Sorts.Quick(new int[]{ 1 }); //For loading assembly
                            result = Sorts.Quick(inArray);
                            break;
                        case SortType.Heap:
                            Sorts.FiveHeap(new int[] { 1 }); //For loading assembly
                            result = Sorts.FiveHeap(inArray);
                            break;
                    }
                    WriteAnswerToFile(options.OutFileName, result.SortedArray);
                    WriteTimeToFile(options.TimeFileName, result.TimeSpentedForSort);
                }
            }
            else
            {
                Console.WriteLine(options.GetUsage());
            }
        }
    }
}

using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFileGenerator
{
    enum ArrayOrder
    {
        Random = 0,
        Asc = 1,
        Desc = 2
    }

    class CommandLineOptions
    {
        public CommandLineOptions()
        {
        }

        [Option("n", "array-size", DefaultValue = 100, HelpText = "This is size of output array")]
        public int ArraySize { get; set; }

        [Option("l", "low-bound", DefaultValue = 0, HelpText = "This is low bound for array elements")]
        public int LowElementBound { get; set; }

        [Option("h", "high-bound", DefaultValue = 100, HelpText = "This high bound for array elements")]
        public int HighElementBound { get; set; }

        [Option("o", "order", DefaultValue=0, HelpText = "Specify out order array. 0 - Random, 1 - Asc, 2 - Desc.")]
        public int OrderType { get; set; }

        [Option("f", "out-file-name", Required = true, HelpText = "Specify out file name.")]
        public string FileName { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this);
        }
    }
}

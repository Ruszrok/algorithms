using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortApplication
{
    class CommandLineOptions
    {
        public CommandLineOptions()
        {
        }

        [Option("i", "infile", Required=true, HelpText = "This is input for array file")]
        public string InFileName { get; set; }

        [Option("o", "outfile", Required = true, HelpText = "This is output for sorted array file name")]
        public string OutFileName { get; set; }

        [Option("t", "timefile", Required = true, HelpText = "This is output for time file")]
        public string TimeFileName { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this);
        }
    }
}

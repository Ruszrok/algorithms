using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortsLibrary
{
    public class SortResult
    {
        public int[] SortedArray{get; set;}
        public TimeSpan TimeSpentedForSort {get; set;}
    }

    public static partial class Sorts
    {
        private static SortResult GenerateResult(int[] array, TimeSpan spentTime)
        {
            return new SortResult 
                    {
                        SortedArray = array,
                        TimeSpentedForSort = spentTime 
                    };
        }

        public static  SortResult Quick(int[] originalArray)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = QuickRec(originalArray.ToList()).ToArray();
            stopwatch.Stop();
            return GenerateResult(result, stopwatch.Elapsed);
        }

        private static List<int> QuickRec(List<int> originalArray)
        {
            if (originalArray.Count < 2)
                return originalArray;

            int pivot = originalArray.Count / 2;
            int pivotElement = originalArray[pivot];

            var lessList = new List<int>(pivot);
            var greaterList = new List<int>(pivot);
            for(int i = 0; i < originalArray.Count; ++i)
            {
                if (i == pivot) continue;

                if (originalArray[i] <= pivotElement)
                    lessList.Add(originalArray[i]);
                else if (originalArray[i] > pivotElement)
                    greaterList.Add(originalArray[i]);
            }

            List<int> resultSet = new List<int>(originalArray.Count);
            resultSet.AddRange(QuickRec(lessList));
            resultSet.Add(pivotElement);
            resultSet.AddRange(QuickRec(greaterList));
            return resultSet;
        }
    }
}

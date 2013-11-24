using System;
using System.Collections.Generic;
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
        private static SortResult GenerateResult(int[] array, DateTime startTime)
        {
            return new SortResult 
                    {
                        SortedArray = array,
                        TimeSpentedForSort = (DateTime.Now - startTime) 
                    };
        }

        public static  SortResult Quick(int[] originalArray)
        {
            return GenerateResult(QuickRec(originalArray.ToList()).ToArray(), DateTime.Now);
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

        public static SortResult QuickInPlace(int[] originalArray)
        {
            QuickInPlaceRec(originalArray, 0, originalArray.Length - 1);
            return GenerateResult(originalArray, DateTime.Now);
        }

        private static void QuickInPlaceRec(int[] originalArray, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                var splitIndex = Split(originalArray, startIndex, endIndex);
                QuickInPlaceRec(originalArray, startIndex, splitIndex - 1);
                QuickInPlaceRec(originalArray, splitIndex + 1, endIndex);
            }
        }

        private static int Split(int[] originalArray, int startIndex, int endIndex)
        {
            var mediana = (startIndex + endIndex) / 2;
            var medElement = originalArray[mediana];
            originalArray.Swap(mediana, endIndex);
            var curLeft = startIndex;

            for (int i = startIndex; i < endIndex - 1; ++i)
            {
                if (originalArray[i] <= medElement)
                {
                    originalArray.Swap(i, curLeft);
                    curLeft++;
                }
            }
            originalArray.Swap(endIndex, curLeft);

                //do
                //{
                //    while (originalArray[curRight] > medElement && curRight > startIndex)
                //    {
                //        curRight--;
                //    }
                //    while (originalArray[curLeft] < medElement && curLeft < endIndex)
                //    {
                //        curLeft++;
                //    }
                //    if (curLeft <= curRight)
                //    {
                //        originalArray.Swap(curLeft, curRight);
                //        curLeft++;
                //        curRight--;
                //    }
                //} while (curLeft <= curRight);

            return curLeft;
        }

        private static void Swap(this int[] a, int left, int right)
        {
            var temp = a[left];
            a[left] = a[right];
            a[right] = temp;
        }
    }
}

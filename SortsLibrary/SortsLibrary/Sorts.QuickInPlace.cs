using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortsLibrary
{
    public static partial class Sorts
    {

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

            for (int i = startIndex; i < endIndex; ++i)
            {
                if (originalArray[i] <= medElement)
                {
                    originalArray.Swap(i, curLeft);
                    curLeft++;
                }
            }
            originalArray.Swap(endIndex, curLeft);

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

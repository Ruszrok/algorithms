using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortsLibrary
{
    public static partial class Sorts
    {
        public static SortResult FiveHeap(int[] originalArray)
        {
            return GenerateResult(FiveHeapSrt(originalArray), DateTime.Now);
        }

        private static int[] FiveHeapSrt(int[] array)
        {
            heapify(array);
            int end = array.Length - 1;
            while (end > 0)
            {
                array.Swap(end, 0);
                end--;
                siftDown(array, 0, end);
            }

            return array;
        }

        private static void heapify(int[] a)
        {
            int start = (a.Length - 5) / 5;
            while (start >= 0)
            {
                siftDown(a, start, a.Length - 1);
                start--;
            }
        }
        private static void siftDown(int[] a, int start, int end)
        {
            int root = start;

            while (root * 5 + 1 <= end)
            {
                int child = root * 5 + 1;
                int swap = root;
                if (a[swap] < a[child])
                    swap = child;
                if (child + 1 <= end && a[swap] < a[child + 1])
                    swap = child + 1;
                if (child + 2 <= end && a[swap] < a[child + 2])
                    swap = child + 2;
                if (child + 3 <= end && a[swap] < a[child + 3])
                    swap = child + 3;
                if (child + 4 <= end && a[swap] < a[child + 4])
                    swap = child + 4;
                if (swap != root)
                {
                    a.Swap(root, swap);
                    root = swap;
                }
                else
                    return;
            }
        }
    }
}

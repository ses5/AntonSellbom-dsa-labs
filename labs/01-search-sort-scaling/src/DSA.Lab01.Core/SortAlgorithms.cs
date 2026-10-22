using System;

namespace DSA.Lab01
{
    public static class SortAlgorithms
    {
        public static void InsertionSort(int[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            // TODO: Sort the array in ascending order using insertion sort.
            //
            // Think of values[0..i-1] as the already-sorted part.
            // For each next value:
            // 1. Store the value you want to insert.
            // 2. Shift larger values one position to the right.
            // 3. Put the stored value into the gap.
            
            int n = values.Length;

            for (int i = 1; i < n; ++i)
            {
                int key = values[i];
                int j = i - 1;

                while (j >= 0 && values[j] > key)
                {
                    values[j + 1] = values[j];
                    j = j - 1;
                }
                
                values[j + 1] = key;
                Console.WriteLine(string.Join(", ", values));
            }
        }
    }
}

using System;

namespace DSA.Lab01
{
    public static class SearchAlgorithms
    {
        public static int LinearSearch(int[] values, int target)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            for (int i = 0; i < values.Length; ++i)
            {
                if (values[i] == target)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int BinarySearch(int[] sortedValues, int target)
        {
            if (sortedValues == null)
            {
                throw new ArgumentNullException(nameof(sortedValues));
            }

            // TODO: Implement binary search.
            // The input to this method is guaranteed to be sorted in ascending order.
            //
            // Suggested plan:
            // 1. Keep track of a low and high index.
            // 2. Inspect the middle value.
            // 3. Return the index if it matches.
            // 4. Otherwise discard either the lower or upper half.
            // 5. Repeat while there is still a valid search range.
            
            int low = 0, high = sortedValues.Length - 1;
            
            Console.WriteLine($"Values in array: {string.Join(", ", sortedValues)}");

            while (low <= high)
            {
                Console.WriteLine($"Low: {sortedValues[low]}, High: {sortedValues[high]}");
                Console.WriteLine($"Target: {target}");
                
                int mid = low + (high - low) / 2;
                
                // Check if target is present at mid
                if (sortedValues[mid] == target)
                {
                    Console.WriteLine($"Target found: {sortedValues[mid]}");
                    return mid;
                }
                
                // If target is greater, ignore lower half
                else if (sortedValues[mid] < target)
                    low = mid + 1;
                
                // if target is smaller, ignore higher half
                else 
                    high = mid - 1;
            }
            
            // If we reach here, then element was not present
            Console.WriteLine("Target not in array");
            return -1;
        }
    }
}

using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        int[] userIds = { 101, 203, 304, 405, 506, 607, 708, 809, 910 };
        int[] emptyArray = { };
        int[] duplicatesArray = { 101, 203, 304, 405, 506, 607 };
        int target = GetTestTarget("valid");
        int index = BinarySearch(userIds, target);
        if (index != -1)
        {
            Console.WriteLine($"User ID {target} found at index {index}.");
        }
        else
        {
            Console.WriteLine($"User ID {target} not found.");
        }
        Console.WriteLine(BinarySearch(emptyArray, 101));
        Console.WriteLine(BinarySearch(duplicatesArray, 304));
        Console.WriteLine(BinarySearch(duplicatesArray, 999));

        int[] largeDataset = new int[1000000000];
        for (int i = 0; i < largeDataset.Length; i++)
        {
            largeDataset[i] = i;
        }
        int largeTarget = 999999999;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        int binarySearchResult = BinarySearch(largeDataset, largeTarget);
        stopwatch.Stop();
        Console.WriteLine($"Binary Search time: {stopwatch.ElapsedMilliseconds} ms");
        stopwatch.Restart();
        int linearSearchResult = LinearSearch(largeDataset, largeTarget);
        stopwatch.Stop();
        Console.WriteLine($"Linear Search time: {stopwatch.ElapsedMilliseconds} ms");
    }

    static int BinarySearch(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] == target)
            {
                return mid;
            }
            else if (arr[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return -1;
    }

    static int LinearSearch(int[] array, int target)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == target)
            {
                return i;
            }
        }
        return -1;
    }

    static int GetTestTarget(string type)
    {
        return type == "valid" ? 506 : 999;
    }
}
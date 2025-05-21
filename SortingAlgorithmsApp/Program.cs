using System.Collections.Concurrent;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        int[] arr = Enumerable.Range(1, 50000).OrderBy(x => rand.Next()).ToArray();
        Stopwatch stopwatch = Stopwatch.StartNew();
        int[] quicksortArray = (int[])arr.Clone();
        QuickSort(quicksortArray, 0, quicksortArray.Length - 1);
        stopwatch.Stop();
        Console.WriteLine("\nSorted array using QuickSort: ");
        Console.WriteLine($"\nTime taken: {stopwatch.ElapsedMilliseconds} ms");
        stopwatch.Restart();
        int[] mergesortArray = (int[])arr.Clone();
        MergeSort(mergesortArray, 0, mergesortArray.Length - 1);
        stopwatch.Stop();
        Console.WriteLine("\nSorted array using MergeSort: ");
        Console.WriteLine($"\nTime taken: {stopwatch.ElapsedMilliseconds} ms");
        stopwatch.Restart();
        int[] bubblesortArray = (int[])arr.Clone();
        BubbleSort(bubblesortArray);
        Console.WriteLine("\nSorted array using BubbleSort: ");
        stopwatch.Stop();
        Console.WriteLine($"\nTime taken: {stopwatch.ElapsedMilliseconds} ms");
    }

    static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                }
            }
        }
    }

    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);
            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = (low - 1);
        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }
        (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
        return i + 1;
    }

    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int[] leftArray = arr[left..(mid + 1)];
        int[] rightArray = arr[(mid + 1)..(right + 1)];
        int i = 0, j = 0, k = left;
        while (i < leftArray.Length && j < rightArray.Length)
        {
            if (leftArray[i] <= rightArray[j])
            {
                arr[k++] = leftArray[i++];
            }
            else
            {
                arr[k++] = rightArray[j++];
            }
        }
        while (i < leftArray.Length) arr[k++] = leftArray[i++];
        while (j < rightArray.Length) arr[k++] = rightArray[j++];
    }
}
class Program
{
    static void Main(string[] args)
    {
        //ArrayMethod();
        //LinkedListMethod();
        //StackMethod();
        QueueMethod();
    }

    static void ArrayMethod()
    {
        string[] inputHistory = { 
            "5 + 3",
            "10 - 2",
            "7 * 4",
            "20 / 5",
            "3 ^ 2"
        };

        Console.WriteLine("Original Input History:");
        foreach (string input in inputHistory)
        {
            Console.WriteLine(input);
        }

        inputHistory[1] = "10 / 2";

        Console.WriteLine("\nUpdated Input History:");
        foreach (string input in inputHistory)
        {
            Console.WriteLine(input);
        }
    }

    static void LinkedListMethod()
    {
        LinkedList<string> inputHistory = new LinkedList<string>();
        inputHistory.AddLast("Result: 8");
        inputHistory.AddLast("Result: 5");
        inputHistory.AddLast("Result: 28");
        inputHistory.AddLast("Result: 4");
        inputHistory.AddLast("Result: 9");
        Console.WriteLine("Original Input History:");
        foreach (string input in inputHistory)
        {
            Console.WriteLine(input);
        }

        inputHistory.Remove("Result: 5");
        Console.WriteLine("\nUpdated Input History:");
        foreach (string input in inputHistory)
        {
            Console.WriteLine(input);
        }
    }

    static void StackMethod()
    {
        Stack<string> inputHistory = new Stack<string>();
        inputHistory.Push("Entered 5 + 3");
        inputHistory.Push("Entered 10 - 2");
        inputHistory.Push("Entered 7 * 4");
        inputHistory.Push("Entered 20 / 5");
        inputHistory.Push("Entered 3 ^ 2");
        Console.WriteLine("Original Input History:");
        foreach (string input in inputHistory)
        {
            Console.WriteLine(input);
        }

        inputHistory.Pop();
        Console.WriteLine("\nUpdated Input History:");
        foreach (string input in inputHistory)
        {
            Console.WriteLine(input);
        }
    }

    static void QueueMethod()
    {
        Queue<string> inputHistory = new Queue<string>();
        inputHistory.Enqueue("Calculate: 15 + 5");
        inputHistory.Enqueue("Calculate: 12 - 3");
        inputHistory.Enqueue("Calculate: 9 * 2");
        inputHistory.Enqueue("Calculate: 16 / 4");
        inputHistory.Enqueue("Calculate: 2 ^ 3");
        Console.WriteLine("Original Input History:");
        foreach (string input in inputHistory)
        {
            Console.WriteLine(input);
        }

        inputHistory.Dequeue();
        Console.WriteLine("\nUpdated Input History:");
        foreach (string input in inputHistory)
        {
            Console.WriteLine(input);
        }
    }
}
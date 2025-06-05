class Program
{
    static async Task Main()
    {
        Console.WriteLine("Starting multiple API requests...");
        await HandleMultipleRequestsAsync();
        Console.WriteLine("Starting background task processing...");
        await ProcessBackgroundTasksAsync();
        Console.WriteLine("All background tasks completed.");
    }

    static async Task<string> FetchDataAsync(string requestName)
    {
        await Task.Delay(2000);
        return "API request completed.";
    }

    static async Task HandleMultipleRequestsAsync()
    {
        Task<string> task1 = FetchDataAsync("Request 1");
        Task<string> task2 = FetchDataAsync("Request 2");
        Task<string> task3 = FetchDataAsync("Request 3");
        string[] results = await Task.WhenAll(task1, task2, task3);
        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }

    static async Task ProcessBackgroundTasksAsync()
    {
        List<Task> tasks = new List<Task>();
        for (int i = 1; i <= 5; i++)
        {
            tasks.Add(ExecuteTaskAsync(i));
        }
        Console.WriteLine("(Task execution happening in parrallel)");
        await Task.WhenAll(tasks);
    }

    static async Task ExecuteTaskAsync(int taskId)
    {
        Console.WriteLine($"Task {taskId} started...");
        await Task.Delay(1000 * taskId);
        Console.WriteLine($"Task {taskId} completed.");
    }
}
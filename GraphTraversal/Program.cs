class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();
        graph.AddEdge(1, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(2, 4);
        graph.AddEdge(2, 5);
        graph.AddEdge(3, 6);
        graph.AddEdge(4, 5);
        Console.WriteLine("Depth-First Search (DFS):");
        graph.DFS(1);
        Console.WriteLine("Breadth-First Search (BFS):");
        graph.BFS(1);
    }
}
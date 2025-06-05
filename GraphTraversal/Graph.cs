class Graph
{
    private Dictionary<int, List<int>> adjacencyList;
    public Graph()
    {
        adjacencyList = new Dictionary<int, List<int>>();
    }

    public void AddEdge(int source, int destination)
    {
        if (!adjacencyList.ContainsKey(source))
        {
            adjacencyList[source] = new List<int>();
        }
        adjacencyList[source].Add(destination);
        if (!adjacencyList.ContainsKey(destination))
        {
            adjacencyList[destination] = new List<int>();
        }
        adjacencyList[destination].Add(source);
    }

    public void DFS(int start)
    {
        HashSet<int> visited = new HashSet<int>();
        DFSRecursive(start, visited);
        Console.WriteLine();
    }

    private void DFSRecursive(int node, HashSet<int> visited)
    {
        if (visited.Contains(node))
            return;
        Console.Write(node + " ");
        visited.Add(node);
        if (adjacencyList.ContainsKey(node))
        {
            foreach (var neighbor in adjacencyList[node])
            {
                DFSRecursive(neighbor, visited);
            }
        }
    }

    public void BFS(int start)
    {
        HashSet<int> visited = new HashSet<int>();
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        visited.Add(start);
        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            Console.Write(node + " ");
            if (adjacencyList.ContainsKey(node))
            {
                foreach (var neighbor in adjacencyList[node])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
        Console.WriteLine();
    }
}
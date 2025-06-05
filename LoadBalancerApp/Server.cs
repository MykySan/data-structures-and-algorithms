public class Server
{
    public string Id { get; set; }
    public int RequestCount { get; private set; }
    public Server(string id)
    {
        Id = id;
        RequestCount = 0;
    }

    public int HandleRequest()
    {
        RequestCount++;
        return RequestCount;
    }
}
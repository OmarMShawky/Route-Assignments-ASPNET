namespace EventHub;

public class Program
{
    public static void Main()
    {
        using var db = new EventHubDbContext();
    }
}

using System.Text.Json;

public class NodeObserver : IObserver
{
    public void nodeStatusUpdate(InfoNode infoNode)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        Console.WriteLine("Node Observer: "
                         + JsonSerializer.Serialize(infoNode, options)
                         + Environment.NewLine);
    }
}


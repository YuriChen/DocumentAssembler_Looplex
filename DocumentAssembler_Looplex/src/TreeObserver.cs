using System.Text.Json;

public class TreeObserver : IObserver 
{
    public void nodeStatusUpdate(InfoNode infoNode)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        Console.WriteLine("Tree Observer: " 
                         + JsonSerializer.Serialize(infoNode, options) 
                         + Environment.NewLine);
    }
}




internal class PrinterConsole : IPrinter
{
    public void printNode(Node node, int level)
    {
        Console.WriteLine($"node {node.id} text: " + node.text + Environment.NewLine);
    }
}


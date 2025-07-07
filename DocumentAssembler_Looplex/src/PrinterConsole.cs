internal class PrinterConsole : IPrinter
{
    public void printNode(Node node, int level)
    {
        Console.WriteLine(node.text + Environment.NewLine);
    }
}


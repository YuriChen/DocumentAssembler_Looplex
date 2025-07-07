using System.Threading;
using System.Diagnostics;
using System.Text.Json;

public class Tree : ISubject
{
    public Node root { get; set; }
    public List<IObserver> observers = new List<IObserver>();

    public Tree (Node root) 
    {
        this.root = root;
    }

    //método da interface ISubject que notifica o treeObserver
    public void notifyObservers(Node node, int level, string status, float? duration = null)
    {
        if (observers.Count == 0) return;

        InfoNode infoNode = new InfoNode 
                                {
                                    id = node.id, 
                                    branch = node.branch,
                                    level = level, 
                                    timeStamp = DateTime.Now.ToString("dd/mm/yyyy HH:mm:ss.fffffff K"),
                                    status = status,  
                                    duration = (duration != null ? $"{duration} milliseconds" : "")
                                };

        foreach (IObserver observer in observers)
        {
            observer.nodeStatusUpdate(infoNode);
        }
    }

    //método da interface ISubject que adiciona o observador na lista de observadores
    public void addObserver (IObserver observer)
    {
        observers.Add(observer);
    }

    //método da interface ISubject que remove o observador da lista de observadores
    public void removeObserver (IObserver observer)
    {
        observers.Remove(observer);
    }

    //printa o texto das folhas da árvore nível por nível, notificando o treeObserver ao iniciar e terminar de printar.
    //Foi colcado um delay de 2 segundos no print para simular como se estivesse feito um processamento mais demorado.
    public void printLeafsByLevel(IPrinter printer)
    {
        if (root == null) return;

        Queue<(Node node, int level)> queue = new Queue<(Node node, int level)>();
        queue.Enqueue((root,0));

        while (queue.Count > 0)
        {
            var (current,lvl) = queue.Dequeue();
            
            if(!current.branch)
                printNode(printer, current, lvl);

            foreach (Node child in current.children)
            {
                queue.Enqueue((child, lvl + 1));
            }
        }
    }

    public void printNode (IPrinter printer, Node node, int level)
    {
        //Execução em paralelo os métodos de notificação de observadores
        Task.Run(() => notifyObservers(node, level, "print started"));
        Task.Run(() => node.notifyObservers(node, level, "print started"));

        var stopwatch = Stopwatch.StartNew();

        Task.Delay(2000).Wait(); //Delay para simular um processamento mais demorado no nó
        printer.printNode(node, level);

        stopwatch.Stop();
        Task.Run(() => notifyObservers(node, level, "print ended", stopwatch.ElapsedMilliseconds));
        Task.Run(() => node.notifyObservers(node, level, "print ended", stopwatch.ElapsedMilliseconds));
    }

    #region outros métodos não usados/implementados
    public void addNode(Node node, int nodeToBeParentId)
    {

    }

    public void removeNode(int id)
    {

    }

    //busca recursivamente (profundidade) o nó pelo id
    public Node FindNodeRecursive(int id, Node node)
    {
        if (node == null)
            return null;

        if (node.id == id)
            return node;
        else if (node.children != null)
        {
            foreach (Node nodeChild in node.children)
            {
                Node found = FindNodeRecursive(id, nodeChild);
                if (found != null)
                    return found;
            }
            return null;
        }
        else return null;
    }

    //busca o nó pelo id por profundidade (pilha)
    public Node findNodeByIdDfs(int id)
    {
        if (root == null) return null;

        Stack<Node> stack = new Stack<Node>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            var current = stack.Pop();

            if (current.id == id)
                return current;

            // Adiciona os filhos na ordem inversa para manter a ordem correta
            for (int i = current.children.Count - 1; i >= 0; i--)
            {
                stack.Push(current.children[i]);
            }
        }

        return null;
    }

    //busca o nó pelo id por largura (fila)
    public Node findNodeByIdBfs(int id)
    {
        if (root == null) return null;

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current.id == id)
                return current;

            foreach (var child in current.children)
            {
                queue.Enqueue(child);
            }
        }

        return null;
    }

    public void findNodeAndPrintText(int nodeId){

    }
    #endregion
}

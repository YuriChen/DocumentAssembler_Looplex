public class Node : ISubject
{
    public int id { get; set; }
    public string? text { get; set;}

    public List<Node> children;
    public List<Node> Children
    {
        get => children;
        set
        {
            if(children.Count == 0) //Apenas folhas possuem texto, 
                this.text = null;
            children = value;
        }
    }

    public List<IObserver> observers = new List<IObserver>();

    public bool branch 
    {
        get 
        { 
            if(children.Count != 0) return true;
            else return false;
        }
    }

    public Node(int id, string text = "")
    {
        this.id = id;
        this.text = text;
        this.children = new List<Node>();
    }
    //
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
    public void addObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    //método da interface ISubject que remove o observador da lista de observadores
    public void removeObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void addChild (Node node)
    {
        children.Add(node);
    }

    public void removeChild (int id)
    {
        foreach (Node node in children)
        {
            if(node.id == id)
                children.Remove(node);
        }
    }
}
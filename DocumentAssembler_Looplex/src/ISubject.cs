public interface ISubject
{
    void addObserver(IObserver observer);
    void removeObserver(IObserver observer);
    void notifyObservers(Node node, int level, string status, float? duration = null);
}
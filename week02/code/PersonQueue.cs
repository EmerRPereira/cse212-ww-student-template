/// <summary>
/// A basic implementation of a Queue using FIFO (First-In-First-Out)
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the end of the queue
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
    {
        _queue.Add(person); // CORRIGIDO: Adiciona no final (FIFO)
    }

    /// <summary>
    /// Remove and return the person at the front of the queue
    /// </summary>
    public Person Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("Queue is empty");
        
        var person = _queue[0];
        _queue.RemoveAt(0);
        return person;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

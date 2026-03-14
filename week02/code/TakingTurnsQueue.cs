public class TakingTurnsQueue
{
    private readonly PersonQueue _queue = new PersonQueue(); // Usa PersonQueue corrigido

    public int Length => _queue.Length;

    public void AddPerson(string name, int turns)
    {
        _queue.Enqueue(new Person(name, turns));
    }

    public Person GetNextPerson()
    {
        if (_queue.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _queue.Dequeue();

        // Re-enqueue if they have turns left OR infinite turns
        if (person.Turns > 1) // Finite turns and still have turns left
        {
            // Decrement turns and re-enqueue
            person.Turns--;
            _queue.Enqueue(person);
        }
        else if (person.Turns <= 0) // Infinite turns (0 or negative)
        {
            // Re-enqueue without decrementing
            _queue.Enqueue(person);
        }
        // If Turns == 1, they use their last turn and are NOT re-enqueued

        return person;
    }
}

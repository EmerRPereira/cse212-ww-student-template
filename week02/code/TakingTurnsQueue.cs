public class TakingTurnsQueue
{
    private readonly Queue<Person> _queue = new Queue<Person>();

    public void AddPerson(string name, int turns)
    {
        _queue.Enqueue(new Person(name, turns));
    }

    public Person GetNextPerson()
    {
        if (_queue.Count == 0)
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
        else if (person.Turns <= 0) // Infinite turns
        {
            // Re-enqueue without decrementing
            _queue.Enqueue(person);
        }
        // If Turns == 1, they use their last turn and are NOT re-enqueued

        return person;
    }
}

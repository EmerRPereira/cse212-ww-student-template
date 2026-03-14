public class PriorityQueue
{
    private readonly Queue<PriorityItem> _queue = new Queue<PriorityItem>();

    public void Enqueue(string value, int priority)
    {
        _queue.Enqueue(new PriorityItem(value, priority));
    }

    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the item with the highest priority
        int highestPriorityIndex = 0;
        int highestPriority = _queue.Peek().Priority;
        
        // Need to examine all items to find highest priority
        // Since we can't index directly, we'll convert to list temporarily
        var items = _queue.ToList();
        
        for (int i = 1; i < items.Count; i++)
        {
            if (items[i].Priority > highestPriority)
            {
                highestPriority = items[i].Priority;
                highestPriorityIndex = i;
            }
        }

        // Remove and return the highest priority item
        // To remove from middle, we need to rebuild the queue
        string result = "";
        
        for (int i = 0; i < items.Count; i++)
        {
            if (i == highestPriorityIndex)
            {
                result = items[i].Value;
            }
            else
            {
                _queue.Enqueue(items[i]);
            }
        }
        
        return result;
    }
}

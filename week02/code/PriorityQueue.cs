public class PriorityQueue
{
    private readonly Queue<PriorityItem> _queue = new();

    public void Enqueue(string value, int priority)
    {
        _queue.Enqueue(new PriorityItem(value, priority));
    }

    public string Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        // Converter para lista para poder indexar
        var items = _queue.ToList();
        
        // Encontrar o item com maior prioridade
        // Em caso de empate, pegar o que está mais próximo da frente (menor índice)
        int highestPriorityIndex = 0;
        int highestPriority = items[0].Priority;

        for (int i = 1; i < items.Count; i++)
        {
            // Só atualiza se a prioridade for MAIOR (não usa >= para manter FIFO)
            if (items[i].Priority > highestPriority)
            {
                highestPriority = items[i].Priority;
                highestPriorityIndex = i;
            }
        }

        // Limpar a fila original
        _queue.Clear();

        // Reconstruir a fila sem o item removido
        string result = "";
        for (int i = 0; i < items.Count; i++)
        {
            if (i == highestPriorityIndex)
                result = items[i].Value;
            else
                _queue.Enqueue(items[i]);
        }

        return result;
    }

    // Classe interna para suportar PriorityQueue
    private class PriorityItem
    {
        public string Value { get; }
        public int Priority { get; }

        public PriorityItem(string value, int priority)
        {
            Value = value;
            Priority = priority;
        }
    }
}

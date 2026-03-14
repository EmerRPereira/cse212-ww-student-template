using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue um único item e dequeue
    // Expected Result: O mesmo item deve ser retornado
    // Defect(s) Found: Nenhum - caso básico funciona
    public void TestPriorityQueue_SingleItem()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("Item1", 1);

        var result = queue.Dequeue();

        Assert.AreEqual("Item1", result);
    }

    [TestMethod]
    // Scenario: Enqueue múltiplos itens com prioridades diferentes
    // Expected Result: Itens devem ser retornados em ordem de maior prioridade
    // Defect(s) Found: O algoritmo original não encontrava corretamente a maior prioridade
    public void TestPriorityQueue_DifferentPriorities()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("Baixa", 1);
        queue.Enqueue("Média", 5);
        queue.Enqueue("Alta", 10);

        Assert.AreEqual("Alta", queue.Dequeue());
        Assert.AreEqual("Média", queue.Dequeue());
        Assert.AreEqual("Baixa", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue múltiplos itens com a mesma prioridade
    // Expected Result: Itens devem ser retornados em ordem FIFO (primeiro que entrou, primeiro que sai)
    // Defect(s) Found: O algoritmo original não mantinha a ordem FIFO para prioridades iguais
    public void TestPriorityQueue_SamePriority_FIFO()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("Primeiro", 5);
        queue.Enqueue("Segundo", 5);
        queue.Enqueue("Terceiro", 3);

        Assert.AreEqual("Primeiro", queue.Dequeue()); // Mesma prioridade, primeiro da fila
        Assert.AreEqual("Segundo", queue.Dequeue()); // Mesma prioridade, segundo da fila
        Assert.AreEqual("Terceiro", queue.Dequeue()); // Prioridade menor
    }

    [TestMethod]
    // Scenario: Enqueue itens com prioridades misturadas e testar FIFO para empates
    // Expected Result: Ordem correta respeitando prioridade e FIFO
    // Defect(s) Found: O algoritmo original usava >=, o que pegava o último item em vez do primeiro
    public void TestPriorityQueue_MixedPrioritiesWithFIFO()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 3);
        queue.Enqueue("B", 5);
        queue.Enqueue("C", 5);
        queue.Enqueue("D", 2);
        queue.Enqueue("E", 7);
        queue.Enqueue("F", 7);
        queue.Enqueue("G", 5);

        // Ordem esperada:
        // E (7) - primeiro com prioridade 7
        // F (7) - segundo com prioridade 7
        // B (5) - primeiro com prioridade 5
        // C (5) - segundo com prioridade 5
        // G (5) - terceiro com prioridade 5
        // A (3) - prioridade 3
        // D (2) - prioridade 2

        Assert.AreEqual("E", queue.Dequeue());
        Assert.AreEqual("F", queue.Dequeue());
        Assert.AreEqual("B", queue.Dequeue());
        Assert.AreEqual("C", queue.Dequeue());
        Assert.AreEqual("G", queue.Dequeue());
        Assert.AreEqual("A", queue.Dequeue());
        Assert.AreEqual("D", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue de uma fila vazia
    // Expected Result: Deve lançar InvalidOperationException com mensagem "The queue is empty."
    // Defect(s) Found: A exceção era lançada, mas a mensagem precisava ser verificada
    public void TestPriorityQueue_EmptyQueue()
    {
        var queue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
        Assert.AreEqual("The queue is empty.", exception.Message);
    }

    [TestMethod]
    // Scenario: Enqueue e dequeue várias vezes, verificando que a fila funciona após operações
    // Expected Result: A fila deve manter o comportamento correto após múltiplas operações
    // Defect(s) Found: O algoritmo de reconstrução da fila precisava ser testado em cenários complexos
    public void TestPriorityQueue_MultipleOperations()
    {
        var queue = new PriorityQueue();

        // Primeira rodada
        queue.Enqueue("X", 1);
        queue.Enqueue("Y", 2);
        Assert.AreEqual("Y", queue.Dequeue()); // Prioridade 2
        Assert.AreEqual("X", queue.Dequeue()); // Prioridade 1

        // Segunda rodada (fila vazia)
        queue.Enqueue("Z", 3);
        queue.Enqueue("W", 2);
        queue.Enqueue("V", 3);

        // Z e V têm prioridade 3, Z entrou primeiro
        Assert.AreEqual("Z", queue.Dequeue());
        Assert.AreEqual("V", queue.Dequeue()); // Prioridade 3
        Assert.AreEqual("W", queue.Dequeue()); // Prioridade 2
    }

    [TestMethod]
    // Scenario: Prioridades negativas devem funcionar (menor número = menor prioridade)
    // Expected Result: Ordenação correta com números negativos
    // Defect(s) Found: O algoritmo precisava funcionar com qualquer inteiro
    public void TestPriorityQueue_NegativePriorities()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("Menor", -5);
        queue.Enqueue("Médio", 0);
        queue.Enqueue("Maior", 10);

        Assert.AreEqual("Maior", queue.Dequeue());
        Assert.AreEqual("Médio", queue.Dequeue());
        Assert.AreEqual("Menor", queue.Dequeue());
    }
}

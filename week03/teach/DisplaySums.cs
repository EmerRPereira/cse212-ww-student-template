/*
public static class DisplaySums {
    public static void Run() {
        DisplaySumPairs([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        // Should show something like (order does not matter):
        // 6 4
        // 7 3
        // 8 2
        // 9 1 

        Console.WriteLine("------------");
        DisplaySumPairs([-20, -15, -10, -5, 0, 5, 10, 15, 20]);
        // Should show something like (order does not matter):
        // 10 0
        // 15 -5
        // 20 -10

        Console.WriteLine("------------");
        DisplaySumPairs([5, 11, 2, -4, 6, 8, -1]);
        // Should show something like (order does not matter):
        // 8 2
        // -1 11
    }

    /// <summary>
    /// Display pairs of numbers (no duplicates should be displayed) that sum to
    /// 10 using a set in O(n) time.  We are assuming that there are no duplicates
    /// in the list.
    /// </summary>
    /// <param name="numbers">array of integers</param>
    private static void DisplaySumPairs(int[] numbers)
{
    var valoresVistos = new HashSet<int>();
    
    foreach (var n in numbers)
    {
        int complemento = 10 - n;
        
        if (valoresVistos.Contains(complemento))
        {
            Console.WriteLine($"{n} {complemento}");
        }
        
        valoresVistos.Add(n);
    }

}

*/

using System;
using System.Collections.Generic;

public static class DisplaySums 
{
    public static void Run() 
    {
        // Usando sintaxe compatível com versões mais antigas do C#
        DisplaySumPairs(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        // Deve mostrar algo como:
        // 6 4
        // 7 3
        // 8 2
        // 9 1 

        Console.WriteLine("------------");
        DisplaySumPairs(new int[] { -20, -15, -10, -5, 0, 5, 10, 15, 20 });
        // Deve mostrar:
        // 10 0
        // 15 -5
        // 20 -10

        Console.WriteLine("------------");
        DisplaySumPairs(new int[] { 5, 11, 2, -4, 6, 8, -1 });
        // Deve mostrar:
        // 8 2
        // -1 11
    }

    private static void DisplaySumPairs(int[] numbers) 
    {
        // HashSet para armazenar números já vistos (busca O(1))
        var valoresVistos = new HashSet<int>();
        
        foreach (var n in numbers)
        {
            int complemento = 10 - n;  // Qual número precisamos para somar 10?
            
            // Se o complemento já foi visto, encontramos um par
            if (valoresVistos.Contains(complemento))
            {
                Console.WriteLine($"{n} {complemento}");
            }
            
            // Adiciona o número atual ao conjunto para verificações futuras
            valoresVistos.Add(n);
        }
    }
}

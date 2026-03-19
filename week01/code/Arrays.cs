using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // PLANO DE IMPLEMENTAÇÃO:
        // 1. Precisamos criar um array de doubles com tamanho igual a 'length'
        // 2. O primeiro elemento deve ser o próprio 'number'
        // 3. Cada elemento subsequente deve ser o anterior + 'number' (ou number * (i+1))
        // 4. Usaremos um loop for para preencher cada posição do array
        // 5. Retornaremos o array preenchido
        
        // Exemplo: number = 3, length = 5
        // Posição 0: 3 * 1 = 3
        // Posição 1: 3 * 2 = 6
        // Posição 2: 3 * 3 = 9
        // Posição 3: 3 * 4 = 12
        // Posição 4: 3 * 5 = 15
        // Resultado: {3, 6, 9, 12, 15}
        
        // Implementação:
        
        // 1. Criar um array para armazenar os resultados
        double[] resultado = new double[length];
        
        // 2. Loop para preencher cada posição
        for (int i = 0; i < length; i++)
        {
            // O múltiplo na posição i é number * (i + 1)
            // i+1 porque começamos em 1, não em 0
            resultado[i] = number * (i + 1);
            
            // Poderíamos também fazer:
            // if (i == 0)
            //     resultado[i] = number;
            // else
            //     resultado[i] = resultado[i-1] + number;
        }
        
        // 3. Retornar o array preenchido
        return resultado;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // PLANO DE IMPLEMENTAÇÃO:
        // 
        // Exemplo: data = [1, 2, 3, 4, 5, 6, 7, 8, 9], amount = 3
        // Resultado esperado: [7, 8, 9, 1, 2, 3, 4, 5, 6]
        //
        // 1. Verificar se a lista não é nula ou vazia
        // 2. Como amount pode ser maior que o tamanho da lista, usar módulo: amount = amount % data.Count
        //    (mas o enunciado diz que amount está entre 1 e data.Count, então não precisamos)
        // 3. Calcular o ponto de divisão: splitIndex = data.Count - amount
        //    Para amount=3: splitIndex = 9 - 3 = 6
        //
        // 4. A lista pode ser visualmente dividida em duas partes:
        //    - Primeira parte: índices 0 até splitIndex-1 = [1, 2, 3, 4, 5, 6]
        //    - Segunda parte: índices splitIndex até o fim = [7, 8, 9]
        //
        // 5. Para rotacionar à direita, a segunda parte deve vir primeiro:
        //    - Extrair a segunda parte (GetRange)
        //    - Remover a segunda parte da lista original (RemoveRange)
        //    - Inserir a segunda parte no início da lista (InsertRange)
        //    OU
        //    - Criar uma nova lista combinando segunda parte + primeira parte
        //    - Limpar a lista original e adicionar todos os elementos da nova lista
        
        // Implementação usando a abordagem de criar nova lista (mais clara):

        // Verificação de segurança
        if (data == null || data.Count == 0 || amount <= 0)
        {
            return; // Não há o que rotacionar
        }
        
        // Ajustar amount se necessário (embora o enunciado garanta que está no range)
        amount = amount % data.Count;
        if (amount == 0) return; // Se amount é múltiplo do tamanho, não há mudança
        
        // Calcular o índice onde faremos a divisão
        int splitIndex = data.Count - amount;
        
        // Obter as duas partes da lista
        // Parte 1: do início até splitIndex-1
        List<int> primeiraParte = data.GetRange(0, splitIndex);
        
        // Parte 2: de splitIndex até o fim
        List<int> segundaParte = data.GetRange(splitIndex, amount);
        
        // Limpar a lista original
        data.Clear();
        
        // Reconstruir na ordem correta: segundaParte + primeiraParte
        data.AddRange(segundaParte);
        data.AddRange(primeiraParte);
        
        /* 
         * Visualização do processo:
         * 
         * Original: [1, 2, 3, 4, 5, 6, 7, 8, 9], amount = 3
         * splitIndex = 9 - 3 = 6
         * 
         * primeiraParte = GetRange(0, 6) = [1, 2, 3, 4, 5, 6]
         * segundaParte = GetRange(6, 3) = [7, 8, 9]
         * 
         * Após Clear() e AddRange:
         * data = [7, 8, 9, 1, 2, 3, 4, 5, 6]
         */
    }
}
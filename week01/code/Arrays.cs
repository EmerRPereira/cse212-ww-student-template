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
        // IMPLEMENTATION PLAN:
        // 1. Create a double array with size equal to 'length'
        // 2. The first element must be the 'number' itself
        // 3. Each subsequent element should be the previous + 'number' (or number * (i+1))
        // 4. Use a for loop to fill each position of the array
        // 5. Return the filled array
        
        // Example: number = 3, length = 5
        // Position 0: 3 * 1 = 3
        // Position 1: 3 * 2 = 6
        // Position 2: 3 * 3 = 9
        // Position 3: 3 * 4 = 12
        // Position 4: 3 * 5 = 15
        // Result: {3, 6, 9, 12, 15}
        
        // Implementation:
        
        // 1. Create an array to store the results
        double[] result = new double[length];
        
        // 2. Loop to fill each position
        for (int i = 0; i < length; i++)
        {
            // The multiple at position i is number * (i + 1)
            // i+1 because we start at 1, not 0
            result[i] = number * (i + 1);
            
            // We could also do:
            // if (i == 0)
            //     result[i] = number;
            // else
            //     result[i] = result[i-1] + number;
        }
        
        // 3. Return the filled array
        return result;
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
        // IMPLEMENTATION PLAN:
        // 
        // Example: data = [1, 2, 3, 4, 5, 6, 7, 8, 9], amount = 3
        // Expected result: [7, 8, 9, 1, 2, 3, 4, 5, 6]
        //
        // 1. Check if the list is not null or empty
        // 2. Since amount could be larger than the list size, use modulo: amount = amount % data.Count
        //    (but the statement says amount is between 1 and data.Count, so we don't need it)
        // 3. Calculate the split point: splitIndex = data.Count - amount
        //    For amount=3: splitIndex = 9 - 3 = 6
        //
        // 4. The list can be visually divided into two parts:
        //    - First part: indices 0 to splitIndex-1 = [1, 2, 3, 4, 5, 6]
        //    - Second part: indices splitIndex to the end = [7, 8, 9]
        //
        // 5. To rotate to the right, the second part should come first:
        //    - Extract the second part (GetRange)
        //    - Remove the second part from the original list (RemoveRange)
        //    - Insert the second part at the beginning of the list (InsertRange)
        //    OR
        //    - Create a new list combining second part + first part
        //    - Clear the original list and add all elements from the new list
        
        // Implementation using the approach of creating a new list (clearer):

        // Safety check
        if (data == null || data.Count == 0 || amount <= 0)
        {
            return; // Nothing to rotate
        }
        
        // Adjust amount if necessary (although the statement guarantees it's in range)
        amount = amount % data.Count;
        if (amount == 0) return; // If amount is a multiple of the size, no change
        
        // Calculate the index where we will split
        int splitIndex = data.Count - amount;
        
        // Get the two parts of the list
        // Part 1: from beginning to splitIndex-1
        List<int> firstPart = data.GetRange(0, splitIndex);
        
        // Part 2: from splitIndex to the end
        List<int> secondPart = data.GetRange(splitIndex, amount);
        
        // Clear the original list
        data.Clear();
        
        // Rebuild in the correct order: secondPart + firstPart
        data.AddRange(secondPart);
        data.AddRange(firstPart);
        
        /* 
         * Process visualization:
         * 
         * Original: [1, 2, 3, 4, 5, 6, 7, 8, 9], amount = 3
         * splitIndex = 9 - 3 = 6
         * 
         * firstPart = GetRange(0, 6) = [1, 2, 3, 4, 5, 6]
         * secondPart = GetRange(6, 3) = [7, 8, 9]
         * 
         * After Clear() and AddRange:
         * data = [7, 8, 9, 1, 2, 3, 4, 5, 6]
         */
    }
}
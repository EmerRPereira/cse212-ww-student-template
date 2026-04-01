using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case: if n <= 0, return 0
        if (n <= 0)
            return 0;
        
        // Recursive case: n^2 + sum of squares from 1 to n-1
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length 'size' from a list of 'letters'
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: if word length equals size, add to results
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }
        
        // Recursive case: try adding each remaining letter
        for (int i = 0; i < letters.Length; i++)
        {
            // Create new string without the current letter
            string remaining = letters.Substring(0, i) + letters.Substring(i + 1);
            // Recurse with the new word and remaining letters
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count ways to climb stairs with memoization
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Initialize memoization dictionary if null
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }
        
        // Check if we've already computed this value
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }
        
        decimal result;
        
        // Base Cases
        if (s == 0)
            result = 0;
        else if (s == 1)
            result = 1;
        else if (s == 2)
            result = 2;
        else if (s == 3)
            result = 4;
        else
        {
            // Recursive case with memoization
            result = CountWaysToClimb(s - 1, remember) + 
                     CountWaysToClimb(s - 2, remember) +
                     CountWaysToClimb(s - 3, remember);
        }
        
        // Store result in memoization dictionary
        remember[s] = result;
        return result;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Find the first '*' in the pattern
        int starIndex = pattern.IndexOf('*');
        
        // Base case: if no '*' found, pattern is a complete binary string
        if (starIndex == -1)
        {
            results.Add(pattern);
            return;
        }
        
        // Split the pattern into parts before and after the '*'
        // Using Substring (alternative to range syntax [..X] and [X..])
        string before = pattern.Substring(0, starIndex);
        string after = pattern.Substring(starIndex + 1);
        
        // Recursively generate with '0' at the star position
        WildcardBinary(before + "0" + after, results);
        
        // Recursively generate with '1' at the star position
        WildcardBinary(before + "1" + after, results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }
        
        // Add current position to the path
        currPath.Add((x, y));
        
        // Check if we reached the end
        if (maze.IsEnd(x, y))
        {
            // Found a complete path to the end
            results.Add(currPath.AsString());
            // Backtrack: remove current position before returning
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }
        
        // Define possible move directions: up, down, left, right
        int[] dx = { 0, 0, -1, 1 };
        int[] dy = { -1, 1, 0, 0 };
        
        // Try all four directions
        for (int i = 0; i < 4; i++)
        {
            int newX = x + dx[i];
            int newY = y + dy[i];
            
            // Check if the move is valid (within bounds, not a wall, not visited)
            if (maze.IsValidMove(currPath, newX, newY))
            {
                // Recursively explore the new position
                SolveMaze(results, maze, newX, newY, currPath);
            }
        }
        
        // Backtrack: remove current position before returning to explore other paths
        currPath.RemoveAt(currPath.Count - 1);
    }
}
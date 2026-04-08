// Trees.cs - Contains the BinarySearchTree class, the static Trees class for tree creation,
// and extension methods for IEnumerable<int>

using System.Collections;

// ============================================================================
// PART 1: BinarySearchTree Class - Main implementation of the BST data structure
// ============================================================================

/// <summary>
/// Binary Search Tree (BST) implementation.
/// A BST is a binary tree where for each node:
/// - All nodes in the left subtree have values less than the node's value
/// - All nodes in the right subtree have values greater than the node's value
/// This class implements IEnumerable<int> to support foreach iteration.
/// </summary>
public class BinarySearchTree : IEnumerable<int>
{
    // Private field that points to the root node of the tree
    // When the tree is empty, _root is null
    private Node? _root;

    /// <summary>
    /// Inserts a new value into the BST.
    /// Duplicate values are ignored (no effect on the tree).
    /// </summary>
    /// <param name="value">The integer value to insert</param>
    public void Insert(int value)
    {
        // Special case: tree is empty
        // Create the root node
        if (_root is null)
            _root = new Node(value);
        else
            // Tree has nodes - start recursive insertion from the root
            _root.Insert(value);
    }

    /// <summary>
    /// Checks whether a value exists in the BST.
    /// </summary>
    /// <param name="value">The integer value to search for</param>
    /// <returns>True if the value is found, false otherwise</returns>
    public bool Contains(int value)
    {
        // If tree is empty, return false
        // Otherwise, start recursive search from the root
        return _root != null && _root.Contains(value);
    }

    /// <summary>
    /// Calculates the height of the entire BST.
    /// Height is the maximum number of nodes from root to any leaf.
    /// An empty tree has height 0.
    /// A tree with only the root has height 1.
    /// </summary>
    /// <returns>The height of the tree</returns>
    public int GetHeight()
    {
        // If tree is empty, height is 0
        // Otherwise, get height starting from the root
        return _root?.GetHeight() ?? 0;
    }

    /// <summary>
    /// Returns all values in the BST in reverse order (descending).
    /// This is achieved by traversing: Right subtree -> Current node -> Left subtree
    /// </summary>
    /// <returns>IEnumerable of integers in descending order</returns>
    public IEnumerable<int> Reverse()
    {
        // Create a list to store the values in reverse order
        var numbers = new List<int>();
        
        // Perform reverse traversal starting from the root
        TraverseReverse(_root, numbers);
        
        // Return the list as IEnumerable (enables LINQ and foreach)
        return numbers;
    }

    /// <summary>
    /// Helper method for reverse (descending) traversal.
    /// Uses recursion to visit nodes in order: Right, Current, Left.
    /// This produces values from largest to smallest.
    /// </summary>
    /// <param name="node">Current node being visited</param>
    /// <param name="values">List to collect the values</param>
    private void TraverseReverse(Node? node, List<int> values)
    {
        // Base case: if node is null, do nothing (return)
        if (node is not null)
        {
            // Step 1: Traverse the right subtree (larger values)
            TraverseReverse(node.Right, values);
            
            // Step 2: Add the current node's value
            values.Add(node.Data);
            
            // Step 3: Traverse the left subtree (smaller values)
            TraverseReverse(node.Left, values);
        }
    }

    /// <summary>
    /// Returns a string representation of the BST.
    /// Format: "<Bst>{value1, value2, value3, ...}" in ascending order.
    /// This is used by the test assertions to verify tree contents.
    /// </summary>
    /// <returns>Formatted string with all values in ascending order</returns>
    public override string ToString()
    {
        // "this" refers to the BinarySearchTree object
        // Since the class implements IEnumerable<int>, we can iterate over it directly
        // string.Join will call GetEnumerator() automatically
        return $"<Bst>{{{string.Join(", ", this)}}}";
    }

    // ========================================================================
    // IEnumerable<int> Implementation - Enables foreach loops
    // ========================================================================

    /// <summary>
    /// Non-generic GetEnumerator required by IEnumerable interface.
    /// This method calls the generic version to maintain type safety.
    /// </summary>
    /// <returns>IEnumerator for iterating over integers</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // Call the typed version of GetEnumerator
        return GetEnumerator();
    }

    /// <summary>
    /// Generic GetEnumerator - returns an enumerator that iterates through
    /// all values in the BST in ascending order.
    /// This enables foreach loops and LINQ queries on the BST.
    /// </summary>
    /// <returns>IEnumerator<int> for iterating over integers</returns>
    public IEnumerator<int> GetEnumerator()
    {
        // Create a list to store values in ascending order
        var numbers = new List<int>();
        
        // Perform forward (in-order) traversal starting from the root
        TraverseForward(_root, numbers);
        
        // Yield return each number one at a time
        // This creates an iterator without needing to store the entire list in memory
        // (though we already have the list - this is just for demonstration)
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    /// <summary>
    /// Helper method for forward (ascending) traversal.
    /// This is an in-order traversal: Left subtree -> Current node -> Right subtree
    /// This produces values from smallest to largest.
    /// </summary>
    /// <param name="node">Current node being visited</param>
    /// <param name="values">List to collect the values</param>
    private void TraverseForward(Node? node, List<int> values)
    {
        // Base case: if node is null, do nothing (return)
        if (node is not null)
        {
            // Step 1: Traverse the left subtree (smaller values)
            TraverseForward(node.Left, values);
            
            // Step 2: Add the current node's value
            values.Add(node.Data);
            
            // Step 3: Traverse the right subtree (larger values)
            TraverseForward(node.Right, values);
        }
    }
}

// ============================================================================
// PART 2: Trees Static Class - Provides utility methods for creating balanced BSTs
// ============================================================================

/// <summary>
/// Static utility class for tree-related operations.
/// Contains the CreateTreeFromSortedList method that builds a balanced BST
/// from a sorted array by recursively inserting middle elements first.
/// </summary>
public static class Trees
{
    /// <summary>
    /// Creates a balanced Binary Search Tree from a sorted list of integers.
    /// If values were inserted in order from left to right, the tree would become
    /// unbalanced (like a linked list). To maintain balance, this method inserts
    /// the middle element first, then recursively processes the left and right halves.
    /// </summary>
    /// <param name="sortedNumbers">Already sorted array of integers</param>
    /// <returns>A balanced BinarySearchTree containing all the values</returns>
    /// <example>
    /// Input: [10, 20, 30, 40, 50, 60]
    /// Insertion order: 30, 10, 20, 50, 40, 60
    /// Result: Balanced BST with height 3 instead of 6
    /// </example>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        // Create an empty BST
        var bst = new BinarySearchTree();
        
        // Only process if the array is not empty
        if (sortedNumbers.Length > 0)
        {
            // Start the recursive middle insertion process
            // First call uses full range: from index 0 to last index
            InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        }
        
        return bst;
    }

    /// <summary>
    /// Recursively inserts the middle element of a subarray range into the BST.
    /// This ensures the tree remains balanced because:
    /// - The middle element becomes the root of each subtree
    /// - Left and right halves contain roughly equal numbers of elements
    /// - The process repeats recursively for each subarray
    /// </summary>
    /// <param name="sortedNumbers">The original sorted array (no slicing needed)</param>
    /// <param name="first">Starting index of the current subarray (inclusive)</param>
    /// <param name="last">Ending index of the current subarray (inclusive)</param>
    /// <param name="bst">The BST to insert values into</param>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Base case: if first > last, the subarray is empty
        // Nothing to insert - return
        if (first > last)
            return;
        
        // Calculate the middle index of the current range
        // Using integer division; for even-length arrays, picks the left-middle
        int mid = (first + last) / 2;
        
        // Insert the middle value into the BST
        // This value becomes the root of the current subtree
        bst.Insert(sortedNumbers[mid]);
        
        // Recursively process the left half (values before the middle)
        // Range: from first to mid-1
        InsertMiddle(sortedNumbers, first, mid - 1, bst);
        
        // Recursively process the right half (values after the middle)
        // Range: from mid+1 to last
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}

// ============================================================================
// PART 3: EnumerableExtensions - Extension methods for IEnumerable<int>
// ============================================================================

/// <summary>
/// Static class containing extension methods for IEnumerable<int>.
/// Extension methods allow us to "add" new methods to existing types without modifying them.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Converts an IEnumerable<int> to a comma-separated string.
    /// This extension method is used by the TreeReverseTests test.
    /// The test calls: tree.Reverse().AsString()
    /// </summary>
    /// <param name="source">The IEnumerable<int> to convert</param>
    /// <returns>A string with all values separated by commas and spaces</returns>
    /// <example>
    /// Input: [10, 7, 6, 5, 4, 3, 1]
    /// Output: "10, 7, 6, 5, 4, 3, 1"
    /// </example>
    public static string AsString(this IEnumerable<int> source)
    {
        // string.Join efficiently concatenates all values with a separator
        // This is much more efficient than manual string concatenation
        return string.Join(", ", source);
    }
}
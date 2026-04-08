// Node.cs - Represents a single node in the Binary Search Tree

/// <summary>
/// Represents a node in the binary search tree.
/// Each node contains data and references to left and right child nodes.
/// </summary>
public class Node
{
    // Public property to store the integer value of the node
    public int Data { get; set; }
    
    // Reference to the right child node (values greater than current node)
    // Private set ensures child nodes are only set internally during insertion
    public Node? Right { get; private set; }
    
    // Reference to the left child node (values less than current node)
    // Private set ensures child nodes are only set internally during insertion
    public Node? Left { get; private set; }

    /// <summary>
    /// Constructor - creates a new node with the specified data value.
    /// Left and Right children are initially null (no children yet).
    /// </summary>
    /// <param name="data">The integer value to store in this node</param>
    public Node(int data)
    {
        this.Data = data;
    }

    /// <summary>
    /// Inserts a new value into the subtree rooted at this node.
    /// Uses recursive approach to find the correct position.
    /// Values less than current node go to the left subtree.
    /// Values greater than current node go to the right subtree.
    /// Duplicate values are ignored (not inserted).
    /// </summary>
    /// <param name="value">The integer value to insert</param>
    public void Insert(int value)
    {
        // Case 1: Value is less than current node's data
        // Belongs in the left subtree
        if (value < Data)
        {
            // If left child doesn't exist, create a new node here
            if (Left is null)
                Left = new Node(value);
            else
                // Otherwise, recursively call Insert on the left child
                Left.Insert(value);
        }
        // Case 2: Value is greater than current node's data
        // Belongs in the right subtree
        else if (value > Data)
        {
            // If right child doesn't exist, create a new node here
            if (Right is null)
                Right = new Node(value);
            else
                // Otherwise, recursively call Insert on the right child
                Right.Insert(value);
        }
        // Case 3: value == Data (duplicate)
        // Do nothing - duplicates are not allowed in this BST implementation
    }

    /// <summary>
    /// Checks whether a value exists in the subtree rooted at this node.
    /// Uses recursive binary search algorithm.
    /// </summary>
    /// <param name="value">The integer value to search for</param>
    /// <returns>True if the value is found, false otherwise</returns>
    public bool Contains(int value)
    {
        // Base case: found the value in the current node
        if (value == Data)
            return true;
        
        // If value is smaller, search the left subtree
        if (value < Data)
            // Return false if left child doesn't exist, otherwise search recursively
            return Left != null && Left.Contains(value);
        else
            // If value is larger, search the right subtree
            // Return false if right child doesn't exist, otherwise search recursively
            return Right != null && Right.Contains(value);
    }

    /// <summary>
    /// Calculates the height of the subtree rooted at this node.
    /// Height is defined as the maximum number of nodes from this node to a leaf.
    /// A leaf node has height 1.
    /// </summary>
    /// <returns>The height of this subtree</returns>
    public int GetHeight()
    {
        // Recursively get the height of the left subtree
        // If left child doesn't exist, height is 0
        int leftHeight = Left?.GetHeight() ?? 0;
        
        // Recursively get the height of the right subtree
        // If right child doesn't exist, height is 0
        int rightHeight = Right?.GetHeight() ?? 0;
        
        // Height of current node = 1 + the maximum height of its children
        // The +1 accounts for the current node itself
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
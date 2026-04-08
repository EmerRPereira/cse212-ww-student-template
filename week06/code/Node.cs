public class Node
{
    public int Data { get; set; }
    public Node? Right { get; set; }
    public Node? Left { get; set; }

    public Node(int data)
    {
        this.Data = data;
    }

    /// <summary>
    /// Inserts a new value into the subtree rooted at this node.
    /// Values less than current node go to the left.
    /// Values greater than current node go to the right.
    /// Duplicates are ignored.
    /// </summary>
    public void Insert(int value)
    {
        if (value < Data)
        {
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        // value == Data: do nothing (no duplicates)
    }

    /// <summary>
    /// Checks whether a value exists in the subtree rooted at this node.
    /// </summary>
    public bool Contains(int value)
    {
        if (value == Data)
            return true;
        
        if (value < Data)
            return Left != null && Left.Contains(value);
        else
            return Right != null && Right.Contains(value);
    }

    /// <summary>
    /// Calculates the height of the subtree rooted at this node.
    /// Height is the maximum number of nodes from this node to a leaf.
    /// A leaf node has height 1.
    /// </summary>
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
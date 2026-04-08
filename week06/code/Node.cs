public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        // value == Data: do nothing (no duplicates)
    }

    public string Reverse()
    {
        var numbers = new List<int>();
        TraverseReverse(_root, numbers);
        return $"<IEnumerable>{{{string.Join(", ", numbers)}}}";
    }

    private void TraverseReverse(Node? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseReverse(node.Right, values);
            values.Add(node.Data);
            TraverseReverse(node.Left, values);
        }
    }

    public bool Contains(int value)
    {
        if (value == Data)
            return true;
        
        if (value < Data)
            return Left != null && Left.Contains(value);
        else
            return Right != null && Right.Contains(value);
    }

    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
public static class Trees
{
    /// <summary>
    /// Creates a balanced BST from a sorted list by recursively inserting the middle element.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();
        if (sortedNumbers.Length > 0)
        {
            InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        }
        return bst;
    }

    /// <summary>
    /// Recursively inserts the middle element of a subarray range into the BST.
    /// </summary>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Base case: empty range
        if (first > last)
            return;
        
        // Find the middle index
        int mid = (first + last) / 2;
        
        // Insert the middle value
        bst.Insert(sortedNumbers[mid]);
        
        // Recursively process left half (values before middle)
        InsertMiddle(sortedNumbers, first, mid - 1, bst);
        
        // Recursively process right half (values after middle)
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}
public class Tree<T> where T : IComparable<T>
{
    private TreeNode<T>? _root;

    /// <summary>
    /// Inserts the provided as the root if no root exists;
    /// otherwise, it inserts the provided value off the root node.
    /// Duplicate values are ignored.
    /// </summary>
    /// <param name="value">The provided data point to insert to the tree.</param>
    public void InsertNode(T value)
    {
        // Set root to incoming value if no root exists
        if (_root is null)
        {
            _root = new TreeNode<T>(value);
        }
        // Insert node branching off of root
        else
        {
            InsertNode(value, _root);
        }
    }

    /// <summary>
    /// Helper method to insert a node with a provided root.
    /// </summary>
    /// <param name="value">Value of the node to be inserted under a parent node.</param>
    /// <param name="parentNode">The parent node to place the new node containing the specified value under.</param>
    private void InsertNode(T value, TreeNode<T> parentNode)
    {
        var comparisonResult = value.CompareTo(parentNode.Data);

        // Value smaller than parent goes on left
        if (comparisonResult < 0)
        {
            if (parentNode.LeftChild is null)
            {
                parentNode.LeftChild = new TreeNode<T>(value); // Insert to the left of this parent node
            }
            else
            {
                InsertNode(value, parentNode.LeftChild); // Recurse to the left node
            }
        }
        // Value greater than parent goes on right
        else if (comparisonResult > 0)
        {
            if (parentNode.RightChild is null)
            {
                parentNode.RightChild = new TreeNode<T>(value); // Insert to the right of this parent node
            }
            else
            {
                InsertNode(value, parentNode.RightChild); // Recurse to the right node
            }
        }
        
        // Do not insert if duplicate node
    }

    /// <summary>
    /// Print the values of the tree by left child, root, right child; recursively.
    /// </summary>
    /// <param name="printAction"></param>
    public void InOrderTraversal(Action<string> printAction)
    {
        Console.WriteLine("Flat Print:");
        FlatInOrderTraversal(_root, printAction);
        Console.WriteLine();
        Console.WriteLine("Pretty Print (didn't turn out quite right, but looks nice):");
        PrettyPrintInOrderTraversal(_root, printAction, string.Empty, true);
    }

    private void FlatInOrderTraversal(TreeNode<T>? parentNode, Action<string> printAction)
    {
        if (parentNode is null) return;

        FlatInOrderTraversal(parentNode.LeftChild, printAction);
        Console.Write($"{parentNode.Data} ");
        FlatInOrderTraversal(parentNode.RightChild, printAction);
    }

    /// <summary>
    /// Helper method to avoid publicly exposing the parent node.
    /// </summary>
    /// <param name="parentNode"></param>
    /// <param name="printAction"></param>
    /// <param name="indent">The indentation string for visualizing the tree.</param>
    /// <param name="isTail">Whether to visually show if nodes are sub-nodes under a parent node.</param>
    private void PrettyPrintInOrderTraversal(TreeNode<T>? parentNode, Action<string> printAction, string indent, bool isTail)
    {
        if (parentNode is null) return;
        
        printAction($"{indent}{(isTail ? "└── " : "├── ")}{parentNode.Data}");
        indent += isTail ? "    " : "│   ";
        PrettyPrintInOrderTraversal(parentNode.LeftChild, printAction, indent, false);
        PrettyPrintInOrderTraversal(parentNode.RightChild, printAction, indent, true);
    }
}
public record TreeNode<T>(T Data)
    where T : IComparable<T>
{
    public TreeNode<T>? LeftChild { get; set; }
    public TreeNode<T>? RightChild { get; set; }
}
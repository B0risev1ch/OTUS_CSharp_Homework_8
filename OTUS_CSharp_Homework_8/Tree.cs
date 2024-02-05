public class TreeNode <T>
{
    public int Salary { get; set; }

    public string? Name { get; set; }

    public TreeNode<T>? Left { get; set; }

    public TreeNode<T>? Right { get; set; }
}
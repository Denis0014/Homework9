namespace BinaryTrees;

/// <summary>
/// Узел бинарного дерева
/// </summary>
public class TreeNode<T>
{
    /// <summary>
    /// Поле данных
    /// </summary>
    public T Data;

    /// <summary>
    /// Левое поддерево
    /// </summary>
    public TreeNode<T>? Left;

    /// <summary>
    /// Правое поддерево
    /// </summary>
    public TreeNode<T>? Right;

    /// <summary>
    /// Инициализирует узел бинарного дерева значением data поля данных
    /// и поддеревьями left, right
    /// </summary>
    /// <param name="data">Значение поля данных узла</param>
    /// <param name="left">Левое поддерево</param>
    /// <param name="right">Правое поддерево</param>
    public TreeNode(T data, TreeNode<T>? left = null, TreeNode<T>? right = null)
    {
        Data = data;
        Left = left;
        Right = right;
    }

    public TreeNode<T>? Copy()
    {
        if (this == null)
            return null;
        return new TreeNode<T>(Data, this.Left?.Copy(), this.Right?.Copy());
    }
}
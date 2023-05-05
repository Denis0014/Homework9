namespace BinaryTrees;
public class BinarySearchTree
{
    /// <summary>
    /// Создание экземпляра дерева
    /// </summary>
    private TreeNode<int> root;
    /// <summary>
    /// Добавляет целое в ДБП с сохранением упорядоченности
    /// </summary>
    /// <param name="node">Ссылка на корень</param>
    /// <param name="x">Целое число</param>
    void Add(TreeNode<int> node, int x)
    {
        if (node == null)
        {
            return;
        }
        if (node.Data >= x)
        {
            if (node.Left == null)
            {
                node.Left = new TreeNode<int>(x);
                return;
            }
            Add(node.Left, x);
        }
        else
        {
            if (node.Right == null)
            {
                node.Right = new TreeNode<int>(x);
                return;
            }
            Add(node.Right, x);
        }
    }
    /// <summary>
    /// Поиск целого в ДБП
    /// </summary>
    /// <param name="num">Целое число</param>
    /// <returns>Найден элемент или нет</returns>
    public bool Search(int num)
    {
        var node = root;
        bool BinarySearch(TreeNode<int> node)
        {
            if (node == null)
                return false;
            if (node.Data == num)
                return true;
            return BinarySearch(num <= node.Data ? node.Left : node.Right);
        }
        return BinarySearch(root);
    }
    /// <summary>
    /// Инициализирует дерево бинарного поиска по исходому массиву целых
    /// </summary>
    /// <param name="arr">массив целых чисел</param>
    public BinarySearchTree(params int[] arr)
    {
        root = new TreeNode<int>(arr[0]);
        for (int i = 1; i < arr.Length; i++)
            Add(root, arr[i]);
    }
    /// <summary>
    /// Печатает ДБП инфиксным обходом. Если дерево пустое, выводится &lt;empty tree&gt;
    /// </summary>
    public void Print() => TreeUtils.PrintTreeInfix(root);
}
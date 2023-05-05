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
        bool BinarySearch(TreeNode<int>? node)
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
    /// Возращает минимальный элемент дерева
    /// </summary>
    /// <returns>Целое число</returns>
    public int Min()
    {
        var node = root;
        while (node.Left != null)
            node = node.Left;
        return node.Data;
    }
    /// <summary>
    /// Возращает Максимальный элемент дерева
    /// </summary>
    /// <returns>Целое число</returns>
    public int Max()
    {
        var node = root;
        while (node.Right != null)
            node = node.Right;
        return node.Data;
    }
    /// <summary>
    /// Возращает сумму N минимальных элементов дерева
    /// </summary>
    /// <param name="n">Число элементов суммы</param>
    /// <returns>Целое число</returns>
    public int GetMinSum(int n)
    {
        if (root == null)
            return 0;
        int sum = 0;
        void Pass(TreeNode<int>? node)
        {
            if (node == null)
                return;
            Pass(node.Left);
            if (n == 0)
                return;
            sum += node.Data;
            n--;
            Pass(node.Right);
        }
        Pass(root);
        return sum;
    }

    /// <summary>
    /// Печатает ДБП инфиксным обходом. Если дерево пустое, выводится &lt;empty tree&gt;
    /// </summary>
    public void Print() => TreeUtils.PrintTreeInfix(root);
}
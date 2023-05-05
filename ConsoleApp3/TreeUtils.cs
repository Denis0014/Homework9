using System.Numerics;
using System.Reflection.Emit;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BinaryTrees;

public static class TreeUtils
{
    private static Random _random = new();

    /// <summary>
    /// Печатает дерево инфиксным обходом. Если дерево пустое, выводится &lt;empty tree&gt;
    /// </summary>
    /// <param name="root"></param>
    public static void PrintTreeInfix<T>(TreeNode<T>? root)
    {
        if (root == null)
            Console.WriteLine("<empty tree>");
        PrintNodeInfix(root);
        Console.WriteLine();

        void PrintNodeInfix(TreeNode<T>? node)
        {
            if (node == null)
                return;
            PrintNodeInfix(node.Left);
            Console.Write($"{node.Data} ");
            PrintNodeInfix(node.Right);
        }
    }

    /// <summary>
    /// Создаёт рандомное бинарное дерево.
    /// </summary>
    /// <param name="count">Количество узлов в дереве</param>
    /// <param name="minVal">Левая граница значений узлов</param>
    /// <param name="maxVal">Правая граница значений узлов (не включая)</param>
    public static TreeNode<int>? GetRandomTree(int count, int minVal = -10, int maxVal = 10)
    {
        if (count < 0)
            throw new ArgumentException("Count must be >= 0.");
        if (minVal > maxVal)
            throw new ArgumentException("Min value must be greater than or equal to Max value.");
        if (count == 0)
            return null;
        var leftNodesCount = _random.Next(0, count - 1);
        return new TreeNode<int>(_random.Next(minVal, maxVal),
            GetRandomTree(leftNodesCount, minVal, maxVal),
            GetRandomTree(count - leftNodesCount - 1, minVal, maxVal));
    }

    /// <summary>
    /// Копирует узел и всех его потомков
    /// </summary>
    /// <returns>Ссылка на этот узел</returns>
    public static TreeNode<T>? Copy<T>(TreeNode<T>? root)
    {
        if (root == null)
            return null;
        return new TreeNode<T>(root.Data, Copy(root.Left), Copy(root.Right));
    }
    /// <summary>
    /// Возвращает сумму значений в листьях
    /// </summary>
    /// <param name="root">Ссылка на корень дерева</param>
    /// <returns>Целое число</returns>
    public static int LeafSum(TreeNode<int>? root)
    {
        if (root == null)
            return 0;
        if (root.Left == null && root.Right == null)
            return root.Data;
        return LeafSum(root.Left) + LeafSum(root.Right);
    }
    /// <summary>
    /// Возвращает <i>ширину уровня</i> с заданным номером
    /// </summary>
    /// <param name="root">Ссылка на корень дерева</param>
    /// <param name="level">Номер уровня, для которго нужно найти ширину</param>
    /// <returns>Целое число</returns>
    public static int LevelWidth(TreeNode<int>? root, int level)
    {
        int res = 0;
        void Pass(TreeNode<int>? node, int curLevel)
        {
            if (node == null)
            {
                return;
            }
            if (curLevel == level)
            {
                res++;
            }
            Pass(node.Left, curLevel++);
            Pass(node.Right, curLevel++);
            curLevel--;
        }
        Pass(root, 0);
        return res;
    }
    /// <summary>
    /// Возвращает является ли дерево деревом сумм
    /// </summary>
    /// <param name="root">Ссылка на корень дерева</param>
    /// <returns>Истина или Ложь</returns>
    public static bool IsSumTree(TreeNode<int>? root)
    {
        if (root == null)
        {
            return false;
        }
        bool flag = true;
        void Pass(TreeNode<int>? node, int sum)
        {
            if (node == null || (node.Left == null && node.Right == null) || !flag)
            {
                return;
            }
            Pass(node.Left, sum);
            Pass(node.Right, sum);
            sum += node.Data;
            flag = sum == node.Data;
        }
        Pass(root, 0);
        return flag;
    }

    #region GetSampleIntTree
    /// <summary>
    /// Создаёт бинарное дерево из 6 целых чисел
    /// </summary>
    ///      7
    ///    /   \
    ///   -6    32
    ///  /  \     \
    /// 0   11     -5
    public static TreeNode<int> GetSampleIntTree1()
    {
        return new TreeNode<int>(7,
            new TreeNode<int>(-6,
                new TreeNode<int>(0),
                new TreeNode<int>(11)
            ),
            new TreeNode<int>(32,
                right: new TreeNode<int>(-5)
            )
        );
    }

    /// <summary>
    /// Создаёт бинарное дерево из 5 первых натуральных чисел
    /// </summary>
    ///      1
    ///    /   \
    ///   2     3
    ///  	   / \
    ///       4   5
    public static TreeNode<int> GetSampleIntTree2()
    {
        return new TreeNode<int>(1,
            new TreeNode<int>(2),
            new TreeNode<int>(3,
                new TreeNode<int>(4),
                new TreeNode<int>(5)
            )
        );
    }

    /// <summary>
    /// Создаёт бинарное дерево из 4 целых чисел,
    /// расположенных в левой крайней ветви
    /// </summary>
    ///       -1001
    ///       /   
    ///     999   
    ///     /  
    ///    0
    ///   / 
    /// -57 
    public static TreeNode<int> GetSampleIntTree3()
    {
        return new TreeNode<int>(-1001,
            new TreeNode<int>(999,
                new TreeNode<int>(0,
                    new TreeNode<int>(-57)
                )
            )
        );
    }

    /// <summary>
    /// Создаёт бинарное дерево из 3 целых чисел,
    /// расположенных в правой крайней ветви
    /// </summary>
    ///      3
    ///    	  \
    ///  	   5
    ///  	    \ 
    ///      	 8 
    public static TreeNode<int> GetSampleIntTree4()
    {
        return new TreeNode<int>(3,
            right: new TreeNode<int>(5,
                right: new TreeNode<int>(8)
            )
        );
    }


    /// <summary>
    /// Создаёт бинарное дерево из 6 целых чисел,
    /// расположенных в крайних ветвях
    /// </summary>
    ///      18
    ///    	/  \
    ///   -20  35
    ///   /	     \ 
    /// -75       66
    ///	           \
    ///				94
    public static TreeNode<int> GetSampleIntTree5()
    {
        return new TreeNode<int>(18,
            new TreeNode<int>(-20,
                new TreeNode<int>(-75)
            ),
            new TreeNode<int>(35,
                right: new TreeNode<int>(66,
                    right: new TreeNode<int>(94)
                )
            )
        );
    }
    /// <summary>
    /// Создаёт бинарное дерево сумм
    /// </summary>
    ///      26
    ///    /   \
    ///   10    3
    ///  /  \    \
    /// 4    6    3
    public static TreeNode<int> GetSampleIntTree6()
    {
        return new TreeNode<int>(26,
            new TreeNode<int>(10,
                new TreeNode<int>(4),
                new TreeNode<int>(6)
            ),
            new TreeNode<int>(3,
                right: new TreeNode<int>(3)
            )
        );
    }

    #endregion
}
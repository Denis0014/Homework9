using BinaryTrees;
using System;

namespace Homework9
{
    class Program
    { 
        ///      1             26
        ///    /   \         /   \
        ///   2     3       10    3
        ///  	   / \     /  \    \
        ///       4   5   4    6    3
        static void Main(string[] args)
        {
            var tree = new BinarySearchTree(5, 1, 34, 7, 4, 18, 63, 22, 31, 10);
            tree.Print();
            Console.WriteLine(tree.Min());
            Console.WriteLine(tree.Max());
            Console.WriteLine(tree.GetMinSum(2));
            int[] arr = tree.ToSortedArray();
            Console.WriteLine(string.Join(" ", arr));
            var tree = TreeUtils.GetSampleIntTree2();
            TreeUtils.PrintTreeInfix(tree);
            var tree1 = TreeUtils.Copy(tree.Right);
            TreeUtils.PrintTreeInfix(tree1);
            Console.WriteLine(TreeUtils.LeafSum(tree1));
            TreeUtils.PrintTreeInfix(tree);
            Console.WriteLine(TreeUtils.LevelWidth(tree, 1));
            var tree2 = TreeUtils.GetSampleIntTree6();
            Console.WriteLine(TreeUtils.IsSumTree(tree2));
        }
    }
}

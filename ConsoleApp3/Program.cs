using System;
using BinaryTrees;

namespace Homework9
{
    class Program
    {
        ///      1
        ///    /   \
        ///   2     3
        ///  	   / \
        ///       4   5
        static void Main(string[] args)
        {
            var tree = TreeUtils.GetSampleIntTree2();
            TreeUtils.PrintTreeInfix(tree);
            var tree1 = TreeUtils.Copy(tree.Right);
            TreeUtils.PrintTreeInfix(tree1);
            Console.WriteLine(TreeUtils.LeafSum(tree1));
            TreeUtils.PrintTreeInfix(tree);
            Console.WriteLine(TreeUtils.LevelWidth(tree, 1));
        }
    }
}
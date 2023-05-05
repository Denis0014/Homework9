using System;
using BinaryTrees;

namespace Homework9
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = TreeUtils.GetSampleIntTree2();
            TreeUtils.PrintTreeInfix(tree);
            tree = tree.Right;
            var tree1 = TreeUtils.Copy(tree);
            TreeUtils.PrintTreeInfix(tree1);
            Console.WriteLine(TreeUtils.LeafSum(tree1));
        }
    }
}
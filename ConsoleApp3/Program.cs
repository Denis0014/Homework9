using BinaryTrees;
using System;

namespace Homework9
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinarySearchTree(5, 1, 34, 7, 4, 18, 63, 22, 31, 10);
            Console.WriteLine(tree.Min());
            Console.WriteLine(tree.Max());

        }
    }
}
/*
 Рекурсивный алгоритм бинарного дерева поиска
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTreeCS1._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            int[] ArrayTree = new int[10] { 4, 5, 2, 3, 6, 1, 9, 7, 8, 0 };
            tree.Root = null;
            for (int i = 0; i < 10; i++)
            {
                tree.Root=tree.Add(tree.Root, ArrayTree[i]);
            }
            tree.Print(tree.Root, 0);
            tree.Delete(tree.Root, 2);
            tree.Print(tree.Root, 0);
            Console.ReadKey();
        }
    }

    public class Tree<T> where T : IComparable<T>
    {
        public class Node 
        {
            public T Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node() { }
            public Node(T data)
            {
                Data = data;
            }
            public Node(T data, Node left, Node right)
            {
                Data = data;
                Left = left;
                Right = right;
            }
            public static bool operator >(Node a, Node b)
            {
                return a.Data.CompareTo(b.Data) == 1;
            }
            public static bool operator <(Node a, Node b)
            {
                return a.Data.CompareTo(b.Data) == -1;
            }
        }

        public Node Root { get; set; }

        //public Node Add(Node root, T data)
        //{
        //    Node node = new Node(data);
        //    if (Root == null)
        //    {
        //        Root = node;
        //        return Root;
        //    }

        //    //Node current = Root;
        //    if (root.Data.CompareTo(node.Data) < 0)
        //    {
        //        if (Root.Right == null)
        //        {
        //            Root.Right = node;

        //        }
        //        else
        //        {
        //            Root.Right = Add(node, data);
        //        }
        //        //return Root;
        //    }
        //    else
        //    {
        //        if (Root.Left == null)
        //        {
        //            Root.Left = node;

        //        }
        //        else
        //        {
        //            Root.Left = Add(node, data);
        //        }
        //        //return Root;
        //    }
        //    return root;
        //}

        public Node Add(Node node, T data)
        {
            if (node == null)
            {
                Node current = new Node(data);
                current.Data = data;
                current.Left = null;
                current.Right = null;
                return current;
            }

            //Node current = Root;
            if (node.Data.CompareTo(data) < 0)
            {
                node.Right = Add(node.Right, data);
            }
            else
            {
                node.Left = Add(node.Left, data);
            }
            return node;
        }

        public Node serchNode(Node node)
        {
            Node current = node;
            while (current.Left != null)
            {
                current = current.Left;
            }
            return current;
        }

        public Node Delete(Node node, T data)
        {
            if (node == null)
            {
                return node;
            }

            if (node.Data.CompareTo(data) < 0)
            {
                node.Right = Delete(node.Right, data);
            }
            else if (node.Data.CompareTo(data) > 0)
            {
                node.Left = Delete(node.Left, data);
            }
            else
            {
                Node current;
                if (node.Left == null)
                {
                    current = node.Right;
                    node = null;
                    return current;
                }
                else if (node.Right == null)
                {
                    current = node.Left;
                    node = null;
                    return current;
                }
                else
                {
                    current = node.Right;
                    while (current.Left != null)
                    {
                        current = current.Left;
                    }
                    node.Data = current.Data;
                    node.Right = Delete(node.Right, current.Data);
                }
            }
            return node;
        }

        public void Print(Node node, int indent)
        {
            if (node != null)
            {
                Print(node.Right, indent + 2);
                for (int i = 0; i < indent; i++)
                {
                    Console.Write(" ");
                }
                Console.Write(node.Data);
                Print(node.Left, indent + 2);
            }
            else {
                Console.Write("\n");
            }
        }
    }
}


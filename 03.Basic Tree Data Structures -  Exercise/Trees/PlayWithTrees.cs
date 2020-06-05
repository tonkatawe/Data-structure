using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;


class Program
{
    static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();
    static void Main(string[] args)
    {
        ReadTree();
        var root = GetRootNode();

        foreach (var node in GetSubTreesWithSum(root))
        {
            PrintPreOrder(node);
            Console.WriteLine();
        }


    }

    private static void PrintPreOrder(Tree<int> node)
    {
        Console.Write(node.Value + " ");
        foreach (var child in node.Children)
        {
            PrintPreOrder(child);
        }

    }

    public static List<Tree<int>> GetSubTreesWithSum(Tree<int> root)
    {
        var target = int.Parse(Console.ReadLine());
        Console.WriteLine($"Subtrees of sum {target}:");
        var roots = new List<Tree<int>>();
        DFSSub(root, target, 0, roots);

        return roots;
    }

    private static int DFSSub(Tree<int> node, int target, int current, List<Tree<int>> roots)
    {
        if (node == null)
        {
            return 0;
        }

        current = node.Value;

        foreach (var child in node.Children)
        {
            current += DFSSub(child, target, current, roots);
        }

        if (current == target)
        {
            roots.Add(node);
        }

        return current;
    }

    public static List<Tree<int>> GetPathWithSum(Tree<int> root)
    {
        var target = int.Parse(Console.ReadLine());
        Console.WriteLine($"Paths of sum {target}:");
        var leafs = new List<Tree<int>>();

        DFS(root, target, 0, leafs);

        return leafs;
    }

    static Stack<int> FindLongestPath(Tree<int> root)
    {
        var queue = new Queue<Tree<int>>();
        queue.Enqueue(root);
        Tree<int> current = null;
        while (queue.Count > 0)
        {
            current = queue.Dequeue();
            for (int i = current.Children.Count - 1; i >= 0; i--)
            {
                queue.Enqueue(current.Children[i]);
            }
        }
        var result = new Stack<int>();
        result.Push(current.Value);
        while (current.Parent != null)
        {
            result.Push(current.Parent.Value);
            current.Parent = current.Parent.Parent;
        }

        return result;
    }

    static void PrintDeepestNodes(Tree<int> root)
    {
        var queue = new Queue<Tree<int>>();
        queue.Enqueue(root);
        Tree<int> current = null;
        while (queue.Count > 0)
        {
            current = queue.Dequeue();
            for (int i = current.Children.Count - 1; i >= 0; i--)
            {
                queue.Enqueue(current.Children[i]);
            }
        }

        Console.WriteLine($"Deepest node: {current.Value}");
    }
    static void PrintMiddleNodes(IEnumerable<Tree<int>> trees)
    {
        var result = new List<int>();
        var queue = new Queue<Tree<int>>();
        queue.Enqueue(trees.FirstOrDefault(x => x.Parent == null));
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current.Children.Count != 0 && current.Parent != null)
            {
                result.Add(current.Value);
            }
            foreach (var child in current.Children)
            {
                queue.Enqueue(child);
            }
        }
        Console.WriteLine($"Middle nodes: {string.Join(" ", result.OrderBy(x => x))}");
    }
    static void PrintLeafNodes(IEnumerable<Tree<int>> trees)
    {
        var result = new List<int>();
        var queue = new Queue<Tree<int>>();
        queue.Enqueue(trees.FirstOrDefault(x => x.Parent == null));
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current.Children.Count == 0)
            {
                result.Add(current.Value);
            }
            foreach (var child in current.Children)
            {
                queue.Enqueue(child);
            }
        }
        Console.WriteLine($"Leaf nodes: {string.Join(" ", result.OrderBy(x => x))}");
    }

    static void Print(Tree<int> root, int indent = 0)
    {
        Console.Write(new string(' ', indent * 2));
        Console.WriteLine(root.Value);
        foreach (var child in root.Children)
        {
            Print(child, indent + 1);
        }

    }
    static void AddEdge(int parent, int child)
    {
        Tree<int> parentNode = GetTreeNodeByValue(parent);
        Tree<int> childNode = GetTreeNodeByValue(child);
        parentNode.Children.Add(childNode);
        childNode.Parent = parentNode;

    }

    static void ReadTree()
    {
        int nodeCount = int.Parse(Console.ReadLine());
        for (int i = 1; i < nodeCount; i++)
        {
            string[] edge = Console.ReadLine().Split(' ');
            AddEdge(int.Parse(edge[0]), int.Parse(edge[1]));
        }
    }

    static Tree<int> GetRootNode()
    {
        return nodeByValue.Values
            .FirstOrDefault(x => x.Parent == null);
    }
    static Tree<int> GetTreeNodeByValue(int value)
    {
        if (!nodeByValue.ContainsKey(value))
        {
            nodeByValue[value] = new Tree<int>(value);
        }

        return nodeByValue[value];
    }
    private static void DFS(Tree<int> x, int target, int current, List<Tree<int>> leafs)
    {
        if (x == null)
        {
            return;
        }
        current += x.Value;
        foreach (var child in x.Children)
        {
            DFS(child, target, current, leafs);
        }
        if (target == current && x.Children.Count == 0)
        {
            leafs.Add(x);
        }
    }
    private static void PrintPath(Tree<int> leaf)
    {
        var result = new Stack<int>();
        result.Push(leaf.Value);
        while (leaf.Parent != null)
        {
            result.Push(leaf.Parent.Value);
            leaf.Parent = leaf.Parent.Parent;
        }

        Console.WriteLine(string.Join(" ", result));
    }
}
using System;
using System.Linq;
public class LinkedStack<T>
{
    private class Node<T>
    {
        public T Value;
        public Node<T> NextNode { get; set; }

        public Node(T value, Node<T> nextNode)
        {
            this.Value = value;
            NextNode = nextNode;
        }
    }

    private Node<T> firstNode;


    public int Count { get; private set; }

    //public LinkedStack()
    //{
    //    this.firstNode = null;
    //}

    public void Push(T element)
    {
        this.firstNode = new Node<T>(element, this.firstNode);
        this.Count++;
    }



    // Should throw InvalidOperationException if the queue is empty
    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty!");
        }

        var element = this.firstNode.Value;
        this.firstNode = this.firstNode.NextNode;
        this.Count--;
        return element;
    }

    public T[] ToArray()
    {
       var array = new T[this.Count];
        var index = 0;
        var currentNode = this.firstNode;
        while (currentNode != null)
        {
            array[index++] = currentNode.Value;
            currentNode = currentNode.NextNode;
        }
        return array;
    }
}


public class Example
{
    public static void Main()
    {

        //LinkedStack<int> linkedStack = new LinkedStack<int>();

        //linkedStack.Push(1);
        //linkedStack.Push(2);
        //linkedStack.Push(3);
        //linkedStack.Push(4);
        //linkedStack.Push(5);
        //linkedStack.Push(6);

        //Console.WriteLine("Count = {0}", linkedStack.Count);
        //Console.WriteLine(string.Join(", ", linkedStack.ToArray()));
        //Console.WriteLine("---------------------------");

        //int first = linkedStack.Pop();
        //Console.WriteLine("First = {0}", first);
        //Console.WriteLine("Count = {0}", linkedStack.Count);
        //Console.WriteLine(string.Join(", ", linkedStack.ToArray()));
        //Console.WriteLine("---------------------------");

        //linkedStack.Push(-7);
        //linkedStack.Push(-8);
        //linkedStack.Push(-9);
        //Console.WriteLine("Count = {0}", linkedStack.Count);
        //Console.WriteLine(string.Join(", ", linkedStack.ToArray()));
        //Console.WriteLine("---------------------------");

        //first = linkedStack.Pop();
        //Console.WriteLine("First = {0}", first);
        //Console.WriteLine("Count = {0}", linkedStack.Count);
        //Console.WriteLine(string.Join(", ", linkedStack.ToArray()));
        //Console.WriteLine("---------------------------");

        //linkedStack.Push(-10);
        //Console.WriteLine("Count = {0}", linkedStack.Count);
        //Console.WriteLine(string.Join(", ", linkedStack.ToArray()));
        //Console.WriteLine("---------------------------");

        //first = linkedStack.Pop();
        //Console.WriteLine("First = {0}", first);
        //Console.WriteLine("Count = {0}", linkedStack.Count);
        //Console.WriteLine(string.Join(", ", linkedStack.ToArray()));
        //Console.WriteLine("---------------------------");
    }
}


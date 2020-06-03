using System;

public class LinkedQueue<T>
{
    private class QueueNode<T>
    {
        public QueueNode(T value)
        {
            this.Value = value;
        }
        public T Value { get; private set; }
        public QueueNode<T> NextNode { get; set; }
        public QueueNode<T> PrevNode { get; set; }
    }
    public int Count { get; private set; }
    private QueueNode<T> head;
    private QueueNode<T> tail;


    public void Enqueue(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new QueueNode<T>(element);
        }
        else
        {
            var oldTail = this.tail;
            this.tail = new QueueNode<T>(element);
            this.tail.PrevNode = oldTail;
            oldTail.NextNode = this.tail;
        }

        this.Count++;
    }


    // Should throw InvalidOperationException if the queue is empty
    public T Dequeue()
    {
        T element;
        if (this.Count == 0)
        {
            throw new InvalidOperationException("LinkedQueue is Empty");
        }


        else if (this.Count == 1)
        {
            element = this.head.Value;
            this.head.PrevNode = null;
        }
        else
        {
            element = this.head.Value;
            this.head = this.head.NextNode;
            this.head.PrevNode = null;
        }

        this.Count--;
        return element;
    }

    public T[] ToArray()
    {
        var array = new T[this.Count];
        var index = 0;
        var currentNode = this.head;
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

        //LinkedQueue<int> queue = new LinkedQueue<int>();

        //queue.Enqueue(1);
        //queue.Enqueue(2);
        //queue.Enqueue(3);
        //queue.Enqueue(4);
        //queue.Enqueue(5);
        //queue.Enqueue(6);

        //Console.WriteLine("Count = {0}", queue.Count);
        //Console.WriteLine(string.Join(", ", queue.ToArray()));
        //Console.WriteLine("---------------------------");

        //int first = queue.Dequeue();
        //Console.WriteLine("First = {0}", first);
        //Console.WriteLine("Count = {0}", queue.Count);
        //Console.WriteLine(string.Join(", ", queue.ToArray()));
        //Console.WriteLine("---------------------------");

        //queue.Enqueue(-7);
        //queue.Enqueue(-8);
        //queue.Enqueue(-9);
        //Console.WriteLine("Count = {0}", queue.Count);
        //Console.WriteLine(string.Join(", ", queue.ToArray()));
        //Console.WriteLine("---------------------------");

        //first = queue.Dequeue();
        //Console.WriteLine("First = {0}", first);
        //Console.WriteLine("Count = {0}", queue.Count);
        //Console.WriteLine(string.Join(", ", queue.ToArray()));
        //Console.WriteLine("---------------------------");

        //queue.Enqueue(-10);
        //Console.WriteLine("Count = {0}", queue.Count);
        //Console.WriteLine(string.Join(", ", queue.ToArray()));
        //Console.WriteLine("---------------------------");

        //first = queue.Dequeue();
        //Console.WriteLine("First = {0}", first);
        //Console.WriteLine("Count = {0}", queue.Count);
        //Console.WriteLine(string.Join(", ", queue.ToArray()));
        //Console.WriteLine("---------------------------");
    }
}

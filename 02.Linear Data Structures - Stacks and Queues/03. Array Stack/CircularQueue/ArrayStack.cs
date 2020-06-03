using System;
using System.Linq;
public class ArrayStack<T>
{
    private const int InitialCapacity = 10;
    private T[] elements;
    public int Count { get; private set; }

    public ArrayStack(int capacity = InitialCapacity)
    {
        this.elements = new T[capacity];
    }

    public void Push(T element)
    {
        if (this.Count == this.elements.Length)
        {
            this.Grow();
        }

        this.elements[this.Count] = element;

        this.Count++;
    }

    private void Grow()
    {
        var newArr = new T[this.elements.Length * 2];
        for (int i = 0; i < this.elements.Length; i++)
        {
            newArr[i] = this.elements[i];
        }

        this.elements = newArr;
    }

    // Should throw InvalidOperationException if the queue is empty
    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty!");
        }

        this.Count--;
        var result = this.elements[this.Count];
        return result;
    }

    public T[] ToArray()
    {
        var array = new T[this.Count];
        Array.Copy(this.elements.Reverse().Skip(this.elements.Length - this.Count).ToArray(), array, this.Count);
        return array;
    }
}


public class Example
{
    public static void Main()
    {

        ArrayStack<int> arrayStack = new ArrayStack<int>();

        arrayStack.Push(1);
        arrayStack.Push(2);
        arrayStack.Push(3);
        arrayStack.Push(4);
        arrayStack.Push(5);
        arrayStack.Push(6);

        Console.WriteLine("Count = {0}", arrayStack.Count);
        Console.WriteLine(string.Join(", ", arrayStack.ToArray()));
        Console.WriteLine("---------------------------");

        int first = arrayStack.Pop();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", arrayStack.Count);
        Console.WriteLine(string.Join(", ", arrayStack.ToArray()));
        Console.WriteLine("---------------------------");

        arrayStack.Push(-7);
        arrayStack.Push(-8);
        arrayStack.Push(-9);
        Console.WriteLine("Count = {0}", arrayStack.Count);
        Console.WriteLine(string.Join(", ", arrayStack.ToArray()));
        Console.WriteLine("---------------------------");

        first = arrayStack.Pop();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", arrayStack.Count);
        Console.WriteLine(string.Join(", ", arrayStack.ToArray()));
        Console.WriteLine("---------------------------");

        arrayStack.Push(-10);
        Console.WriteLine("Count = {0}", arrayStack.Count);
        Console.WriteLine(string.Join(", ", arrayStack.ToArray()));
        Console.WriteLine("---------------------------");

        first = arrayStack.Pop();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", arrayStack.Count);
        Console.WriteLine(string.Join(", ", arrayStack.ToArray()));
        Console.WriteLine("---------------------------");
    }
}


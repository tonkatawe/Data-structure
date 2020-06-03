using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class LinkedList<T> : IEnumerable<T>
{
    public class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }
        public Node NextNode { get; set; }

    }

    public Node Head { get; private set; }
    public Node Tail { get; private set; }
    public int Count { get; private set; }

    public void AddFirst(T item)
    {
        var old = Head;
        this.Head = new Node(item);
        this.Head.NextNode = old;
        if (this.Count == 0)
        {
            this.Tail = this.Head;
        }
      

        Count++;
    }

    public void AddLast(T item)
    {
        var old = this.Tail;
        this.Tail = new Node(item);
        if (this.Count == 0)
        {
            this.Head = this.Tail;
        }
        else
        {
            old.NextNode = this.Tail;
        }

        Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
           throw new InvalidOperationException("List is empty");
        }

        T item = this.Head.Value;
        this.Head = this.Head.NextNode;
        this.Count--;
        if (this.Count ==0)
        {
            this.Tail = null;
        }

        return item;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("List is empty");
        }

        T item = this.Tail.Value;
        if (this.Count == 1)
        {
            this.Head = this.Tail= null;
        }
        else
        {
            Node newTail = this.GetSecondToLast();
            newTail.NextNode = null;
            this.Tail = newTail;
        }
        this.Count--;

        return item;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node currentNode = Head;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private  Node GetSecondToLast()
    {
        Node current = this.Head;

        while (current.NextNode != this.Tail)
        {
            current = current.NextNode;
        }

        return current;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class ReversedList<T> : IEnumerable<T>
{
    public int Count { get; private set; }
    private T[] elements;

    public ReversedList()
    {
        this.Capacity = 2;
        this.elements = new T[Capacity];
    }
    public T this[int index]
    {
        get
        {
            if (index >= this.Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            return this.elements[this.Count - index - 1];
        }

        set
        {
            if (index >= this.Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            this.elements[this.Count - 1 - index] = value;
        }
    }
    public int Capacity { get; set; }

    public void Add(T item)
    {
        if (elements.Length == this.Count)
        {
            this.Resize();
        }

        this.elements[this.Count++] = item;
    }

    public T RemoveAt(int index)
    {
        if (index < 0 || index >= this.Count)
        {
            throw new IndexOutOfRangeException();
        }

        T element = this[index];

        for (int i = this.Count - index - 1; i < this.Count - 1; i++)
        {
            this.elements[i] = this.elements[i + 1];
        }

        this.Count--;

        return element;
    }
    public void Resize()
    {
        var newElements = new T[this.Capacity * 2];
        Array.Copy(this.elements, newElements, this.Count);
        this.Capacity *= 2;
        this.elements = newElements;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Count - 1; i >= 0; i--)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

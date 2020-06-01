using System;
using System.Runtime.CompilerServices;

public class ArrayList<T>
{
    public int Count { get; private set; }
    private T[] elements;
    private const int capacity = 2;

    public ArrayList()
    {
        this.elements = new T[capacity];
    }
    public T this[int index]
    {
        get
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.elements[index];
        }

        set
        {
            if (index >= this.Count )
            {
                throw new ArgumentOutOfRangeException();
            }

            this.elements[index] = value;
        }
    }

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
        if (index >=this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        T element = this.elements[index];
        this.elements[index] = default(T);
        this.Shift(index);
        if (this.Count <= this.elements.Length/4)
        {
            this.Shrink();
        }
        this.Count--;
        return element;
    }

    public void Shrink()
    {
        T[] newArray = new T[this.elements.Length/2];
        for (int i = 0; i < this.Count; i++)
        {
            newArray[i] = this.elements[i];     
        }

        this.elements = newArray;
    }
    public void Shift(int index)
    {
        for (int i = index; i < this.Count; i++)
        {
            this.elements[i] = this.elements[i + 1];
        }
    }
    public void Resize()
    {
        T[] newArray = new T[this.elements.Length*2];
        for (int i = 0; i < this.elements.Length; i++)
        {
            newArray[i] = this.elements[i];
        }

        this.elements = newArray;
    }
}

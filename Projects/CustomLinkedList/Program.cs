using System.Collections;

try
{
    var linkedList = new CustomLinkedList<int>();

    //test Add
    linkedList.Add(0);
    linkedList.Add(1);
    linkedList.Add(2);

    //test AddToFront
    linkedList.AddToFront(3);

    //test AddToBack
    linkedList.AddToEnd(-1);

    //test IEnumerator
    foreach(var node in linkedList)
    {
        Console.WriteLine(node);
    }

    //test CopyTo
    var list = new int[5];
    linkedList.CopyTo(list, 0);

    //test Contains
    var isFalse = linkedList.Contains(-1);

    //test Remove
    var removeMid = linkedList.Remove(2);
    var removeLast = linkedList.Remove(-1);
    var removeHead = linkedList.Remove(3);
    var removeNonExistant = linkedList.Remove(4);
    //test Clear
    linkedList.Clear();


    

}
catch (Exception e)
{
    Console.WriteLine("Exception Msg:\n" + e.Message);
}
Console.WriteLine("Press any key to continue.");
Console.ReadKey();

public interface ILinkedList<T> : ICollection<T>
{
    void AddToFront(T item);
    void AddToEnd(T item);
}
public class CustomLinkedList<T> : ILinkedList<T> 
    where T : IEquatable<T>
{
    public int Count { get; private set; }
    private Node? _head;

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        ReadOnlyWarning();

        ++Count;
        var node = new Node(item);
        node.next = _head;
        _head = node;
    }

    public void AddToEnd(T item)
    {
        ReadOnlyWarning();

        ++Count;
        var seek = _head;
        while (seek.next is not null)
        {
            seek = seek.next;
        }
        var node = new Node(item);
        seek.next = node;
    }

    public void AddToFront(T item)
    {
        ReadOnlyWarning();
        Add(item);
    }

    public void Clear()
    {
        ReadOnlyWarning();

        _head = null;
        Count = 0;

    }

    public bool Contains(T item) 
    {
        var seek = _head;
        while(seek is not null)
        {
            if (seek.value.Equals(item))
            {
                return true;
            }
            seek = seek.next;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if(array == null) 
            throw new ArgumentNullException(
            $"{nameof(array)} is null");

        if (arrayIndex < 0) 
            throw new ArgumentOutOfRangeException(
            "array index is null");

        if (array.Length - arrayIndex < Count)
            throw new ArgumentException("Just no...");

        var seek = _head;
        while(seek is not null)
        {
            array[arrayIndex] = seek.value;
            arrayIndex++;
            seek = seek.next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {

        return new LinkedListEnumerator(_head);
    }

    public bool Remove(T item)
    {
        ReadOnlyWarning();
        if (_head is null) return false;

        if(_head.value.Equals(item))
        {
            _head = _head.next;
            --Count;
            return true;
        }

        var current = _head.next;
        var previous = _head;
        while(current is not null)
        {
            if (current.value.Equals(item))
            {
                previous.next = current.next;
                --Count;
                return true;
            }
            previous = current;
            current = current.next;
        }

        return false;

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void ReadOnlyWarning()
    {
        if (IsReadOnly)
        {
            throw new NotSupportedException("Not supported. " +
                $"{nameof(CustomLinkedList<T>)} is read-only");
        }
    }

    public class Node(T item)
    {
        public T value = item;
        public Node? next = null;
    }

    public class LinkedListEnumerator : IEnumerator<T>
    {
        private const int InitialPosition = -1;
        private int _currentPosition = InitialPosition;
        private readonly Node _node;

        public LinkedListEnumerator(Node n)
        {
            _node = n;
        }
        public T Current => _node.value;

        object IEnumerator.Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            ++_currentPosition;
            return _node.next == null;
        }

        public void Reset()
        {
            _currentPosition = InitialPosition;
        }

        public void Dispose()
        {
        }
    }

}
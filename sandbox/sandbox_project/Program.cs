using System;
using System.Collections;

public class Program
{
    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.

        Console.WriteLine("Hello Sandbox World!");

        var set1 = new HashSet<int>() { 1, 2, 3, 4 };

        var set2 = new HashSet<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };

        var set3 = new HashSet<int>();

        var set4 = new HashSet<int>() { 1, 1, 1, 1, 2, 2, 2, 2, 1567, 39902 };

        var set5 = new HashSet<int>() { 1, 2, 1567, 39902 };

        var setNull = new HashSet<int>();

        setNull = null;

        var newUnion = new Union(set1, set2);

        var unionResult = newUnion.GetUnion();

        var newUnion1 = new Union(set4, set5);

        var unionResult1 = newUnion1.GetUnion();

        // var newUnionNull = new Union(set4, setNull);

        // var unionNullResult = newUnionNull.GetUnion();

        Console.WriteLine("Union");

        Console.WriteLine("[{0}]", string.Join(", ", unionResult)); // Expected [1, 2, 3, 4, 5, 6, 7, 8].

        Console.WriteLine("Union 1");

        Console.WriteLine("[{0}]", string.Join(", ", unionResult1)); // Expected [1,2,1567,39902].

        // Console.WriteLine("Union null test");

        // Console.WriteLine("[{0}]", string.Join(", ", unionNullResult)); // Expected [An Exeption should be throwed].

        var newIntersection = new Intersection(set1, set2);

        var intersectionResult = newIntersection.GetIntersection();

        var newIntersection1 = new Intersection(set4, set5);

        var intersectionResult1 = newIntersection1.GetIntersection();

        Console.WriteLine("Intersection");

        Console.WriteLine("[{0}]", string.Join(", ", intersectionResult)); // Expected [1, 2, 3, 4].

        Console.WriteLine("Intersection 1");

        Console.WriteLine("[{0}]", string.Join(", ", intersectionResult1)); // Expected [1,2,1567,39902].

        // var newEmptyUnion = new Union(set1, set3);

        // Console.WriteLine("Empty set test for union");

        // var emptyUnionResult = newEmptyUnion.GetUnion();

        // Console.WriteLine("Empty set test for Intersection");

        // var emptyIntersection = new Intersection(set1, set3);

        // var emptyIntersectionResult = emptyIntersection.GetIntersection();

        var stack1 = new Stack();

        stack1.Push(1);
        stack1.Push(2);
        stack1.Push(3);
        stack1.Pop();

        Console.WriteLine("Stack Content");
        Console.WriteLine();
        Console.WriteLine(stack1.ToString()); // Expected {1, 2}.

        Console.WriteLine($"{stack1.IsEmpty()}"); // Expected False.

        stack1.Pop();
        stack1.Pop();

        Console.WriteLine($"{stack1.IsEmpty()}"); // Expected True.




    }
}

public class Union
{
    public HashSet<int> _set1;
    public HashSet<int> _set2;

    public Union(HashSet<int> set1, HashSet<int> set2)
    {
        _set1 = set1;
        _set2 = set2;
    }

    public int[] GetUnion()
    {
        if (_set1 != null && _set2 != null && _set1.Count > 0 && _set2.Count > 0)
        {

            var unionArray = new HashSet<int>();
            foreach (var item in _set1)
            {
                unionArray.Add(item);

            }

            foreach (var item in _set2)
            {
                unionArray.Add(item);

            }


            return unionArray.ToArray();
        }
        else
        {
            throw new InvalidOperationException("One or the two sets are null or empty");
            
        }
    }
}

public class Intersection
{
    public HashSet<int> _set1;
    public HashSet<int> _set2;

    public Intersection(HashSet<int> set1, HashSet<int> set2)
    {
        _set1 = set1;
        _set2 = set2;
    }

    public int[] GetIntersection()
    {

        if (_set1 != null && _set2 != null && _set1.Count > 0 && _set2.Count > 0)
        {

            var duplicates = new HashSet<int>();

            foreach (var item in _set1)
            {
                if (_set2.Contains(item))
                {
                    duplicates.Add(item);
                }
            }


            return duplicates.ToArray();
        }

        else
        {
            throw new InvalidOperationException("One or the two sets are null or empty");
        }
    }

}

// Implement a Stack using a Linked list.


public class Stack : IEnumerable<int>
{
    private LinkedListNode? _head;

    private LinkedListNode? _tail;

    public void Push(int value)
    {
        // Create new LinkedListNode.
        LinkedListNode newLinkedListNode = new(value);

        if (_head is null)
        {
            _head = newLinkedListNode;
            _tail = newLinkedListNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newLinkedListNode.Prev = _tail; // Connect new node to the previous head
            if (_tail != null) { _tail.Next = newLinkedListNode; } // Connect the previous head to the new node
            _tail = newLinkedListNode; // Update the head to point to the new node
        }
    }

    public void Pop()
    {
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }

        else if (_tail is not null)
        {
            var newtail = _tail.Prev;
            if (newtail is not null) { newtail.Next = null; }
            _tail = newtail;
        }
    }

    public LinkedListNode GetTop()
    {
        if (_tail != null)
        {
            return _tail;
        }
        else
        {
            throw new InvalidOperationException("The stack is empty");
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    public override string ToString()
    {
        return "<Stack>{" + string.Join(", ", this) + "}";
    }

    public bool IsEmpty()
    {
        return _head is null && _tail is null;
    }

    }

    public class LinkedListNode
    {
        public int Data { get; set; }
        public LinkedListNode? Next { get; set; }
        public LinkedListNode? Prev { get; set; }

        public LinkedListNode(int data)
    {
        this.Data = data;
    }
    }
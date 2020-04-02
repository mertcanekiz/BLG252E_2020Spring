# BLG252E - Object Oriented Programming
## Assignment 1

---

### IEnumerable & IEnumerator

`IEnumerable` is an interface in C# library which enables the derived class to be iterated over in a `foreach` statement. When you implement `IEnumerable`, you must also implement its corresponding `IEnumerator`. The methods that an `IEnumerator` needs to implement are:

* `object IEnumerator Current { get; }`: Returns the current element in the enumerable.
* `bool MoveNext()`: Sets `Current` to the next element and returns `false` if it has reached the end.
* `void Reset()`: Resets the iteration back to the beginning of the `IEnumerable`.

 [More information & examples on MSDN](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerable?view=netframework-4.8)

---

## Deque

A *deque* or *double-ended queue* is a data structure which allows insertion and deletion from both ends. The main operations that a deque needs to support are:

* **unshift**: Adds an item to the front of the deque
* **shift**: Removes an item from the front of the deque
* **push**: Adds an item to the end of the deque
* **pop**: Removes an item from the end of the deque
* **clear**: Removes all elements from the deque
* **size**: Returns the number of elements


In [Deque.cs](./Deque.cs), you are given two abstract classes called `Deque` and `DequeEnumerator`, which have some abstract methods and properties inside. The `Deque` class also inherits from the interface `IEnumerable`, and therefore we can do iteration over it using the foreach syntax:

```c#
foreach (var item in deque)
{
    Console.WriteLine(item);
}
```

However, this `Deque` class is an *abstract class*, which means it does not provide any details regarding the implementation of its methods and it cannot be instantiated. In order to use this class, we must first *implement* `Deque` and `DequeEnumerator` in another class. In [ArrayDeque.cs](./ArrayDeque.cs) you can find such an implementation. It uses an underlying data structure of type `List<int>`.

## Problem Statement

You are required to provide an implementation which uses a [doubly-linked list](https://en.wikipedia.org/wiki/Doubly_linked_list). There are lots of material on this data structure available online, regardless of the programming language. Study it, understand it, then move onto the implementation. You can refer to [ArrayDeque.cs](./ArrayDeque.cs) for an example on how to implement the abstract `Deque` class, but keep in mind that the underlying data structures, therefore the actual contents of the methods will be different.

You must also write a simple driver program in [Program.cs](./Program.cs) where you read whitespace-delimited integers from [integers.txt](./integers.txt), and store them inside your deque. After that, you need to iterate over this deque using a `foreach` statement and print out the contents.
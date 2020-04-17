# Week 8

We've seen in previous weeks and in our [Assignment 1](../assignment1/) that we can iterate over a collection using `foreach`. In fact, one of the main points of the assignment was to extend the use of `foreach` to our own class by implementing the interfaces `IEnumerable` and `IEnumerator`. However, today we will see another way of doing this in a cleaner way.

## yield

If we need to return an `IEnumerable` from a function, we have two options. We can populate a collection (for example, a `List<T>`), and return that:

```c#
public IEnumerable<int> GetNumbers()
{
    var list = new List<int>();
    for (int i = 0; i < 5; i++)
    {
        list.Add(i);
    }
    return list;
}

foreach (var num in GetNumbers())
{
    Console.WriteLine(num);
}
```

In this case, when the method `GetNumbers()` is called, the entire loop executes, fills the List with integers, and returns. Another way to do this is with `yield return` syntax. Here is an example:

```c#
IEnumerable<int> GetNumbersWithYield()
{
    for (int i = 0; i < 5; i++)
    {
        yield return i;
    }
}

foreach (var num in GetNumbersWithYield())
{
    Console.WriteLine(num);
}
```

Although at first these examples look and behave similarly, the underlying mechanisms are vastly different. In the second case, when the `GetNumbersWithYield()` method gets called, it creates an *iterator* to return the required `IEnumerable<T>`, rather than creating and returning it immediately. You can think of this as returning a blueprint to the enumerable, rather than the actual enumerable itself. Doing this has a couple of benefits for us.

First of all, now we don't even need the intermediate `List` that we needed before. So this way is more memory-efficient. Secondly, and probably the most important reason to use iterators is that *they are executed lazily*. This means that the `GetNumbersWithYield()` method does *not* get executed all at once. Let's look at another example to see this in action:

```c#
public IEnumerable<int> GetNumbers()
{
    var list = new List<int>();
    int i = 0;
    while (true)
    {
        list.Add(i);
        i++;
    }
    return list;
}

public IEnumerable<int> GetNumbersWithYield()
{
    int i = 0;
    while (true) {
        yield return i++;
    }
}

foreach (var num in GetNumbers().Take(5))
{
    Console.WriteLine(num);
}

foreach (var num in GetNumbersWithYield().Take(5))
{
    Console.WriteLine(num);
}
```

Now rather than going up to 5, the loops inside the functions are infinite loops. In the first method, since it tries to execute all of the function, it will get stuck inside that loop and run forever (or until the computer runs out of memory), therefore it will never get to return the numbers. The second method, however, is executed lazily, therefore it only gets executed when we iterate over it. And since we declare we want to `Take(5)`, it goes up to the fifth iteration, and pauses.

### Using yield in place of IEnumerator

We said that methods that use `yield` return iterators that are blueprints for the `IEnumerable` that they are supposed to return. Since an `IEnumerator` is also a type of iterator, we can use the `yield` syntax to replace the custom `IEnumerator`s that we wrote in Assignment 1.

```c#
public IEnumerator<T> GetEnumerator()
{
    Node current = head;
    while (current != null)
    {
        yield return current.data;
        current = current.next;
    }
}
```

The full example is in [dlinkdeque_yield](./dlinkdeque_yield/)

---

## Exception Handling

In C#, exception handling is done with `try-catch` statements.

A `try` block is used by C# programmers to partition code that might be affected by an exception. Associated `catch` blocks are used to handle any resulting exceptions. A `finally` block contains code that is run regardless of whether or not an exception is thrown inside the `try` block, such as releasing resources that are allocated in the `try` block. A `try` block requires one or more associated `catch` blocks, a `finally` block, or both.

For example, an attempt to divide a number by zero raises a `DivideByZeroException` exception.

```c#
try
{
    int num1 = 13;
    int num2 = 0;
    int result = num1 / num2;
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Exception caught: {ex}");
}
finally
{
    Console.WriteLine("This always gets executed");
}
```

If you don't want to handle an exception right away, you can use the `throw` keyword. When you use `throw` in a `catch` block, the exception gets passed back to the original caller. You can also use the `throw` keyword to create new exceptions. An example demonstrating this is available inside [4_throw](./4_throw/).
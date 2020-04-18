# Week 9

## Delegates

We've already seen the most common way to call or execute a method: use the `.` operator to access the method using its name. For example, `Console.WriteLine` tells the `Console` type to access its `WriteLine` method.

The other way to call or execute a method is to use a **delegate**. You can think of delegates as  function pointers in C.

For example, imagine there is a method in the `Person` class that must have a `string` type passed as its only parameter, and it returns an `int` type, as shown in the following code:

```c#
public int SomeMethod(string input)
{
    return input.Length; // it doesn't matter what this does
}
```

We can call this method on an instance of `Person` named `p1` like this:

```c#
int answer = p1.SomeMethod("Some String");
```

Alternatively, we can define a *delegate* with a matching signature to call the method indirectly. Note that the names of the parameters do not have to match. Only the *types* of the parameters and return values must match, as shown in the following code:

```c#
delegate int MyDelegate(string s);
```

Now, we can create an instance of the delegate, point it at the method, and finally, call the delegate (which calls the method), as shown in the following code:

```c#
// create a delegate instance that points to the method
var d = new MyDelegate(p1.SomeMethod);
// call the delegate, which calls the method
int answer2 = d("Some String");
```

You are probably thinking, "What's the point of that?" Well, it provides flexibility.

For example, we could use delegates to create a queue of methods that need to be called in order. Queuing actions that need to be performed is common in services to provide improved scalability.

Another example is to allow multiple actions to perform in parallel. Delegates have built-in support for asynchronous operations that run on a different thread, and that can provide improved responsiveness.

The most important example is that delegates allow us to implement **events** for sending messages between different object that do not need to know about each other.

Let's look at an example that builds upon the [1_filter](../week8/1_filter/) example from last week and will help us understand delegates better. In its current state, we explicitly wrote `if (item > 3)` inside our filter function for the filtering condition. What if we wanted more flexibility?

```c#
// Create a delegate that takes in an integer, and returns a bool
// This delegate is going to be a template for our filter method's parameter
delegate bool MyDelegate(int item);

// Take in an enumerable and a delegate
static IEnumerable<int> Filter(IEnumerable<int> input, MyDelegate condition)
{
    foreach (var item in input)
    {
        if (condition(item))
        {
            yield return item;
        }
    }
}

static bool GreaterThanThree(int item)
{
    return item > 3;
}

static void Main()
{
    var myList = new List<int> { 2, 3, 5, 8 };
    // Call the filter method with our list and predicate method.
    // Note that we do **not** invoke GreaterThanTree here, simply passing in its name:
    foreach (var item in Filter(myList, GreaterThanThree))
    {
        Console.WriteLine(item);
    }
}
```

This `Filter` method takes an `IEnumerable`, and a delegate `condition` that provides the condition for *when* to filter an element. In this case, we define that method as `GreaterThanTree`, and as the name suggests, it returns true only when the element is greater than three.

C# has built-in delegates that we can use instead of creating our own, two of which are:

* **`Func<T1, T2, ..., TResult>`**
  for a method with one or more input parameter of type `Tn` and with a return type of `TResult`

* **`Action<T>`**
  for a method that does not return a value (think void functions)

* **`Predicate<T>`**
for a method that takes one parameter and returns a bool value.

In our case, our delegate takes in one parameter and returns a bool, therefore we can use a `Predicate<T>` instead:

```c#
// We don't need to define a delegate anymore:
// delegate bool Condition(int item);

static IEnumerable<int> Filter(List<int> input, Predicate<int> predicate)
{
    // ...
}
```

We are creating and using the `GreaterThanThree` method here for setting the filtering condition. But what if we didn't want to create another method just to pass to our `Filter`?

## Lambda Expressions

Instead of having a separate method, you might sometimes want to just pass an anonymous method in place. This is where lambda expressions come handy, since they allow us to do exactly that. 

Previous example using lamba expressions:

```c#
static IEnumerable<int> Filter(List<int> input, Predicate<int> predicate)
{
    foreach (var item in input)
    {
        if (predicate(item))
        {
            yield return item;
        }
    }
}

static void Main()
{
    var myList = new List<int> { 2, 3, 5, 8 };
    foreach (var item in Filter(myList, x => x > 3))
    {
        Console.WriteLine(item);
    }
}
```

In this example, the `x => x > 3` part is the actual lambda expression that replaces the delegate from the last example. A lambda expression usually has the following shape:

`(input-parameters) => expression`

or

`(input-parameters) => { statements }`

where the parameters of a lambda and its body are separated with the `=>` operator.

A lambda expression can have multiple parameters:

```c#
(x, y) => x * y;
```

or it may have none:

```c#
() => Console.WriteLine("Hello lambda");
```

You can optionally specify types of parameters:

```c#
(Student s, int age) => s.Age >= age;
```

You can have multiple statements inside the lambda body if you use curly braces:

```c#
(s, age) =>
{
    Console.WriteLine("Lambda statement test");
    return s.Age >= age;
}
```

Note that the `return` keyword is required when you use this syntax, in contrast to the other examples.

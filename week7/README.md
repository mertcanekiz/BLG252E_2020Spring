# Week 7

## Assignment 1 Solution

Solution for Assignment 1 is uploaded to [assignment1/](./assignment1)

## .NET Core CLI

You can compile and run .NET Core programs from the command line using the CLI command `dotnet`. This is helpful in cases where you cannot or don't want to use Visual Studio IDE (like in macOS or Linux). Some of the useful commands are:

* `dotnet new console` Create a new console application project
* `dotnet build` Build your project and generate the executable
* `dotnet run` Build and run your application

More information on [MSDN](https://docs.microsoft.com/en-us/dotnet/core/tools/)

## Generics

Generic programming is the concept of designing classes and methods that are decoupled from the data types. This allows us to reuse code. In C#, generics are implemented by using a type parameter (usually called `T`).

But why are generics useful? Let's consider the `Deque` class and the `DLinkDeque` classes that we wrote for Assignment 1. These classes currently only support the `int` data type. But what if we wanted a `Deque` class that supports `string`s? We can write another class with a `string` type, but now most of the code is duplicated between the two classes. also, what if later on we want to support even more types? We cannot keep writing new classes forever. For this, we need to use generics.

Here is an example of non-generic way of implementing a hypotethical list class:

```c#
public class IntList {
    int[] data;
    
    void AddItem(string item)
    {
        // 
    }
}

public class StringList {
    string[] data;
    
    void AddItem(string item)
    {
        //
    }
}

static void Main(string[] args)
{
    IntList list1 = new IntList();
    list1.AddItem(1);

    StringList list2 = new StringList();
    list2.AddItem("Hello World");
}
```

And now, using generics:

```c#
public class MyList<T> {
    
    T[] data;

    void AddItem(T item)
    {
        //
    }
}

static void Main(string[] args)
{
    MyList<int> list1 = new MyList<int>();
    list1.addItem(1);

    MyList<string> list2 = new MyList<string>();
    list2.AddItem("string");
}
```

As you can see, using generics leads to way more concise code and avoids code duplication.

Also, notice that in order to designate the type, we used `<>` brackets (For example `<int>` and `<string>`). These should look familiar, since we have been using them to declare the types of lists and dictionaries in previous weeks. This is because in fact C#'s own collections use generics as well.

In [2_generic_deque](./2_generic_deque/), the `Deque`, `ArrayDeque`, and `DLinkDeque` classes are implemented using generics.
# Week 10

## Events

We have covered delegates on last week's lecture as a way of referencing and passing around methods. Now we're going to take a look at a scenario where delegates can be useful: decoupling. Decoupling is the act of separating two pieces of code from each other so that they are not dependent on each other. But why do we want to do this? Let's look at an example.

Let's imagine that we are writing a game, and that our `Player` class has a method called `Die()` which is run whenever a player's health is dropped below zero. And now imagine we have two separate classes, `Achievements` and `PlayerUI` which both need to know when a player dies, so that they can take their respective actions:

```c#
public class Player
{
    public void Die()
    {
        // Destroy player object
    }
}

public class Achievements
{
    public void OnPlayerDeath()
    {
        // Needs to get called when a player dies.
    }
}

public class UserInterface
{
    public void OnPlayerDeath()
    {
        // Needs to get called when a player dies.
    }
}
```

One way of achieving this is to have the `Player` class call each of the `OnPlayerDeath` methods of `Achievements` and `UserInterface` classes (and of possibly more classes that need to be aware of when a player dies). 

```c#
public class Player
{
    Achievements achievements;
    UserInterface userInterface;

    public void Die()
    {
        // ...
        achievements.OnPlayerDeath();
        userInterface.OnPlayerDeath();
    }
}
```

Now our `Player` class needs to be aware of both the `Achievements` and `UserInterface` classes, keep an object that points to each of them, and make sure to call their respective `OnPlayerDeath()` methods. Meaning our `Player` class has become dependent on other classes. Now we cannot remove any of theses classes from the project without breaking the `Player` class. Also, what happens if more actions are added, like firing a weapon, killing an enemy, etc. ? Our `Player` class can quickly become littered with unnecessary code that it has no job managing.

Another way to do this is we could have a _`DeathDelegate`_, and call that delegate instead of calling each method individually.

```c#
public class Player
{
    public delegate void DeathDelegate();
    public DeathDelegate deathDelegate;

    public void Die()
    {
        // ...
        if (deathDelegate != null) {
            deathDelegate();
        }
    }
}

public class Achievements
{
    public void OnPlayerDeath()
    {
        // Handle achievements related to player death
    }
}

public class UserInterface
{
    public void OnPlayerDeath()
    {
        // Handle UI related to player death
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var player = new Player();
        var achievements = new Achievements();
        var ui = new UserInterface();

        // "Subscribe" to the player.deathDelegate for both classes:
        player.deathDelegate += achievements.OnPlayerDeath;
        player.deathDelegate += ui.OnPlayerDeath;
    }
}
```

This is great, but there are two things that can go wrong: 

  - We can accidentally write `=` instead of `+=` when subscribing a method to the delegate. This would overwrite anyone else that has already subscribed to that delegate, and so they won't be notified.

  - Any class with a reference to the `Player` can invoke the delegate by simply writing `player.deathDelegate();`. Everyone who is subscribed to that delegate will now mistakenly think that the player is dead.

Neither of these things are an issue as long as we are careful when programming. However, mistakes do happen, and we want to give ourselves less opportunity to screw up. This is where events come in.

---

To convert a delegate to an event, we simply add the word `event` in front of the delegate instance. All of a sudden, classes other than the one in which the delegate is defined are no longer able to assign directly to the delegate -- they can only subscribe and unsubscribe using `+=` and `-=` operators. Furthermore, they are not able to invoke the delegate.

We have already seen `Action` and `Func` predefined delegates last week, and these can be used as events as well. So our code now becomes:

```c#
public class Player
{
    public event Action deathEvent;

    void Die()
    {
        if (deathEvent != null) {
            deathEvent();
        }
    }
}

// Achievements and UserInterface classes stay the same
```


> ### Side note: Null-conditional operator
> In C# 6.0 and later, a null-conditional operator was introduced, which allows us to write more concise `null` checks. It applies member access or element access to its operand only if that operand is *not* `null`. We have been writing
> ```c#
> if (deathEvent != null) {
>     deathEvent();
> }
> ```
> We can simplify this to the following one line of code:
> 
> ```c#
> deathEvent?.Invoke();
> ```


Although our events can be of any delegate type we want, it is convention in .NET to use the `EventHandler` and `EventHandler<T>` predefined delegates as events. Their signatures are simple, yet flexible, as shown in the following code:

```c#
public delegate void EventHandler(object sender, EventArgs e);

public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
```

Two examples that demonstrate the use of these are in [2_eventhandler](./2_eventhandler) and [3_eventargs](./3_eventargs).

## Extension Methods

If we want to add extra functionality to one of our classes, we can solve this by simply adding another method. But what if we want to add functionality to other classes that we didn't write? This may be third-party libraries, or even C# standard library as well. C# allows us to write extension methods to solve this problem.

Consider an example where we want to have a utility method called `Capitalize` which takes a string and returns the same string but with its first letter capitalized. If we want to use this method in different parts of our code, having a normal class and passing a reference to that object might not be the best solution and can clutter our code. Instead, we could make this method static and put it inside a `StringHelper` class:

```c#
public class StringHelper
{
    public static string Capitalize(string str)
    {
        char[] arr = str.ToCharArray();
        if (str.Length > 0) {
            char[0] = char[0].ToUpper();
        }
        return arr.ToString();
    }
}
```

Now we can call this static method from anywhere in our code as follows:

```c#
public static void Main(string[] args)
{
    var myString = "hello";
    var capitalized = StringHelper.Capitalize(myString);
    Console.WriteLine(capitalized);
}
```

But instead of having to separately call the method from the `StringHelper` class, we can make this a built-in method to C# strings by using an extension method. In order to convert our method to an extension method, two things need to be satisfied:

1. `StringHelper` class must be a `static class`
2. We need to add `this` keyword in front of the parameter type

```c#
public static class StringHelper
{
    public static string Capitalize(this string str)
    {
        char[] arr = str.ToCharArray();
        if (arr.Length > 0)
            arr[0] = char.ToUpper(arr[0]);
        return new string(arr);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("hello".Capitalize());
    }
}
```

As you can see, now we can call the `Capitalize` method as if it was a standard C# library function in the `string` type.

## LINQ

A very powerful tool in C# is the **L**anguage **In**tegrated **Q**ueries, or **LINQ**. It allows us to run queries or make manipulations and comes in very handy when working with data.

Without LINQ, you had to learn a different query language for each type of data source: SQL databases, XML documents, web services, and so on. With LINQ however, we get a consistent query experience for all of these.

The most obvioous part of LINQ that you will see is the query expression. By using this query syntax, you can perform filtering, ordering, and grouping operations on data sources with a minimum of code.

You can write LINQ queries in C# for SQL Server databases, XML documents, and any collection of objects that supports `IEnumerable` or `IEnumerable<T>` interface. LINQ support is also provided by third party libraries for many web services and other database implementations.

The following example shows the complete query operation. The complete operation includes creating a data source, defining the query expression, and executing the query in a `foreach` statement.

```c#
// Create a data source
int[] scores = new int[] { 85, 97, 81, 60 };

// Define the query expression
var scoreQuery =
    from score in scores       // required
    where score > 80           // optional
    orderby score descending   // optional
    select score;              // must end with select or group

// Execute the query
foreach (int i in scoreQuery)
{
    Console.WriteLine(i);
}
```

LINQ also has a method syntax if you prefer to use it that way:

```c#
var scoreQuery = scores.Where(score => score > 80).OrderByDescending(score => score);
```

The compiler actually compiles the query syntax to the method syntax, therefore these two pieces of code produce exactly the same result.

Some of the most used LINQ methods are:

* **`Take`**: Used for taking only the first `n` elements of a collection
* **`Where`**: Used for filtering a collection according to the predicate passed in.
* **`OrderBy`**: Allows us to execute a method for each and every element of a collection.

For a detailed list and examples on every available LINQ method, go to [this link](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable?view=netcore-3.1#methods) and click on one of the methods inside Enumerable > Methods list on the left-hand side.

For a video tutorial I recommend [Derek Banas' video](https://www.youtube.com/watch?v=gwD9awr3NNo) on the topic.

# Week 13

## Async / Await

Up until this point, we have seen "synchronous programming". In synchronous programming, all the operations are run one after the other, in sequence. One task cannot start until the task before it has finished.

This is very intuitive for humans to understand, and most of the time it is the preferred method. However, it has some serious drawbacks. If you have three tasks, Task A, Task B and Task C. And Task A takes two seconds to finish. The problem with this is that for the two seconds that Task A is running, no other task is allowed to run.

Now let's put that in more concrete terms. Say you have a GUI application. This application runs continuously until the user exits, and constantly draws the UI elements and handles events such as button clicks. If a task in your program takes more than a fraction of a second, the UI events and rendering will get delayed until that task finishes, and you will have an unresponsive program.

Another thing to consider is when your tasks do not depend on each other and do not need to be invoked one after the other. If Task B and C are independent, it's just a waste of time to wait for Task B to finish before executing Task C.

Asynchronous programming is the programming methodology that allows us to run multiple tasks simultaneously. It solves two problems that we stated above.

In C#, we can use asynchronous programming by using `async`/`await` keywords as well as the `Task` object.

See [example 1](./1_synchronous/) for a synchronous programming example.

Now, to convert this program into an asynchronous one, we need to specify `async` in their signatures, and change return type to `Task`. The main method also now becomes `async`, because it calls async methods inside.

See [example 2](./2_async/).

If we are returning something from an async method and we need to use it, or we want to wait for the async method to finish, we use the `await` keyword.

See [example 3](./3_await/).

Now this program will await the tasks in order, and if they have finished, it will print their results. The difference here is subtle, but notice that we did not wait 1 second for TaskB and 5 seconds for TaskC to finish, they were already started simultaneously with TaskA.

This may not be what you want, however, because there is still an order and we need to wait for the previous task to finish before we can await others. In this case, `WhenAll` and `WhenAny` methods of the `Task` class will help us.

See [example 4](./4_whenany/) and [example 5](./5_whenall/).

## File I/O

The classes in `System.IO` namespace allows us to do file input / output operations in C#. It's possible to check if a file exists, create a new file, write to an existing file or read from a file.

Some of the commonly used file and directory classes are:

* **`File`**: provides static methods for creating, copying, deleting, moving, and opening files, and helps create a `FileStream` object.
* **`FileInfo`**: provides instance methods for creating, copying, deleting, moving, and opening files, and helps creata a `FileStream` object.
* **`Directory`**: provides static methods for creating, moving, and enumerating through directories and subdirectories.
* **`DirectoryInfo`**: provides instance methods for creating, moving, and enumerating through directories and subdirectories.
* **`Path`**: provides methods and properties for processing directory strings in a cross-platform manner.

We will generally focus on `File` class.

Some common methods from the `File` class are:

* **`File.Create`**: Creates a new file and returns a `FileStream` object pointing to that file.
* **`File.Exists`**: Returns true if the specified file exists, false otherwise.
* **`File.ReadAllLines`**: Reads an existing file and returns each of the lines in that file inside a string array.
* **`File.ReadAllText`**: Reads an existing file and returns the whole file as a string.

NOTE: If you are trying to read a large file, it's not ideal to use `File.ReadAllText` or `File.ReadAllLines` methods, because they store the entire file in memory.

`System.IO` namespace also has `StreamReader` and `StreamWriter` classes that allow us to read files (`FileStream` objects) in a streamed fashion. This way, we do not have to read the entire file into memory.

In [example 6](./6_file/), you can see an example program that shows creating, reading, and writing files.

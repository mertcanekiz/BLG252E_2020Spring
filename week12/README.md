# Week 12

### Encapsulation

In [1_encapsulation](./1_encapsulation/), we have a simple program that has a `Student` class for handling student records. It has two fields: `id` and `name`. The simplest way to access these fields is to make them public:

```c#
public class Student
{
    public int id;
    public string name;
}

public class Program
{
    static void main(String[] args)
    {
        Student s1 = new Student();
        s1.name = "Osman"
        s1.id = 1234;
    }
}
```

Getters & setters:

```c#
public class Student
{
    private int id;
    private string name;

    public void setID(int id)
    {
        if (id > 0)
            this.id = id;
    }

    public int getID()
    {
        return this.id;
    }

    public void setName(string name)
    {
        if (name.Length > 0)
            this.name = name;
    }

    public string getName()
    {
        return this.name;
    }
}
```

C# Properties:

```c#
public class Student
{
    private int id;
    public int Id {
        get {
            return id;
        }
        set {
            if (value > 0) id = value;
        }
    }

    private string name;
    public string Name {
        get {
            return name;
        }
        set {
            if (value.Length > 0) name = value;
        }
    }
}
```

### Abstraction

Reduce complexity by hiding unnecessary details.

Let's look at an example in code. Suppose we have a `MailService` class that allows us to send emails. The implementation of such a service is complex and out of the scope of this lesson, but in short, we want to connect to a mail server, authenticate with the user's credentials, send the mail, and finally disconnect.

```c#
public class MailService
{
    public void SendEmail()
    {
        Connect();
        Authenticate();
        // Send the email here
        Disconnect();
    }

    public void Connect()
    {
        Console.WriteLine("Connect");
    }

    public void Disconnect()
    {
        Console.WriteLine("Disconnect");
    }

    public void Authenticate()
    {
        Console.WriteLine("Authenticate");
    }
}
```

Now when we create an instance of our mail service class, we have access to all the underlying implementation methods, but we only care about the `SendEmail()` method.

```c#
static void Main(string[] args)
{
    var mailService = new MailService();
    mailService.SendEmail();
    // The following methods are also available, but we don't want to use them here:
    // mailService.Connect();
    // mailService.Disconnect();
    // mailService.Authenticate();
}
```

We can hide these unnecessary complexity from the user by marking these implementation methods as `private`. Now the other classes only have acces to the `SendEmail` method.

### Inheritance

If two objects in our code share the same functionality, we can use inheritance in order to save time and reuse code.

For example, suppose we are writing a GUI library that has few UI elements such as `TextArea`, `Button`, and `Checkbox`. All of these elements need to support the operation `Click()`, and all of them has properties `IsActive` and `Text`. Instead of defining these in each element individually, we can simply create a base class called `UIElement` and have our elements inherit from that base class.


```c#
abstract class UIElement
{
    public bool IsActive { get; set; }
    public string Text { get; set; }

    public abstract void Click();
}

class TextArea : UIElement
{
    public override void Click()
    {
        // TextArea clicked
    }
}

class Button : UIElement
{
    public override void Click()
    {
        // Button clicked
    }
}

class Checkbox : UIElement
{
    public override void Click()
    {
        // Checkbox clicked
    }
}
```

The hierarchy of our classes may not always be as obvious as the above example. Let's now imagine that we want to add right-click functionality. We want our `TextArea` and `Checkbox` to be right-clickable, but our `Button` to not be right-clickable.

We can create a new class called `RightClickableElement` and have both our `TextArea` and `Checkbox` classes inherit from this second base class. But unfortunately, C# does not allow multiple inheritance from two different classes.

It does, however, allow multiple inheritance from interfaces. So we can have `IClickable` and `IRightClickable` interfaces and inherit from them accordingly:

```c#
abstract class UIElement
{
    public bool IsActive { get; set; }
    public string Text { get; set; }

    void Display()
    {
        Console.WriteLine(Text);
    }
}

interface IClickable
{
    void Click();
}

interface IRightClickable
{
    void RightClick();
}

class TextArea : UIElement, IClickable, IRightClickable
{
    public void Click()
    {
        Console.WriteLine("TextArea clicked");
    }

    public void RightClick()
    {
        Console.WriteLine("TextArea right clicked");
    }
}

class Button : UIElement, IClickable
{
    public void Click()
    {
        Console.WriteLine("Button clicked");
    }
}

class Checkbox : UIElement, IClickable, IRightClickable
{
    public void Click()
    {
        Console.WriteLine("Checkbox clicked");
    }

    public void RightClick()
    {
        Console.WriteLine("Checkbox right clicked");
    }
}
```

Apart from multiple inheritance, inheriting from (abstract) classes and implementing interfaces have few differences. Mainly:

* Inheritance describes an **is-a** relationship.
* Implementing describes a **can-do** relationship.

In our example, `TextArea` **is an** UI element, so it inherits from `UIElement` class, but it also **can do** click and right click actions, so it implements the `IClickable` and `IRightClickable` interfaces.

### Abstract vs. Virtual methods

An abstract method can only appear inside an abstract class, and it does not have a body, meaning it does not contain any implementation details. This **must** be overriden in a derived class.

A virtual method may appear in either abstract or non-abstract classes. They can have code, for example a default implementation. Any derived class **can** override the method.

### Polymorphism

In order to use objects that are inheriting from the same base class interchangeably, we use polymorphism. In the above examples, we created three types of UI elements which all inherit from the `UIElement` class. So we can simply use the base class `UIElement` as the type when we are referring to the objects that derive from it:

```c#
List<UIElement> uiElements = new List<UIElement>();

// ...

foreach (var elem in uiElements)
{
    Console.WriteLine(elem.Text);
}
```

Checking if an interface is implemented:

```c#
foreach (var element in uiElements)
{
    Console.WriteLine(element.Text);
    if (element is IRightClickable rightClickable) {
        rightClickable.RightClick();
    }
}
```

Iterating only over right clickable methods using LINQ:

```c#
foreach (var element in uiElements.OfType<IRightClickable>()) {
    element.RightClick();
}
```
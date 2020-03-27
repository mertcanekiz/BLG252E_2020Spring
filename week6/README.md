# Week 6

## Polymorphism

Polymorphism is one of the biggest design tools in object-oriented programming alongside encapsulation and inheritance. Polymorphism is a Greek word that means "many-shaped" and it has two distinct aspects:

* **Shape-shifting:** At run time, objects of a derived class may be treated as objects of a base class, in places such as method parameters and collections or arrays.

* **Virtual and override:** Base classes may define and implement *virtual* methods, and derived classes can *override* them, which means they provide their own definition and implementation. At run-time, when client code calls the method, the CLR looks up the run-time type of the object, and invokes that override of the virtual method. In your source code you can call a method on a base class, and cause a derived class's version of the method to be executed.

---

### Virtual members
When a derived class inherits from a base class, it gains all the methods, fields, properties, and events of the base class. The designer of the derived class can different choices for the behavior of virtual methods:

* The derived class may override virtual members in the base class, defining new behavior.

* The derived class inherit the closest base class method without overriding it, preserving the existing behavior but enabling further derived classes to override the method.

* The derived class may define new non-virtual implementation of those members that hide the base class implementations.

A derived class can override a base class member only if the base class member is declared as `virtual` or `abstract`. The derived member must use the `override` keyword to explicitly indicate that the method is intended to participate in virtual invocation. The following code provides an example:

```c#
public class BaseClass
{
    public virtual void DoWork()
    {
        Console.WriteLine("Base class");
    }
}

public class DerivedClass : BaseClass
{
    public override void DoWork()
    {
        Console.WriteLine("Derived class");
    }
}
```

Fields cannot be virtual, only methods, properties, events, and indexers can be virtual.

When a derived class overrides a virtual member, that member is called even when an instance of that class is being accessed as an instance of the base class.

---
### Base keyword

The `base` keyword is used to access members of the base class from within a derived class.

`base` cannot be used from within a static method.


A derived class that has replaced or overriden a method or property can still access the method or property on the base class using the `base` keyword.

```c#
public class Person
{
    string ssn;
    string name;

    public virtual void GetInfo()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"SSN: {ssn}");
    }
}

public class Employee : Person
{
    string id;

    public override void GetInfo()
    {
        // Calling the base class GetInfo method:
        base.GetInfo();
        Console.WriteLine($"Employee ID: {id}");
    }
}
```

`base` keyword is also used when calling the base class constructor from the derived class:

```c#
public class Person
{
    public Person(string name, string ssn) { }
}

public class Employee : Person
{
    // base(name, ssn) calls the Person constructor
    public Employee(string name, string ssn, string id) : base(name, ssn) {}
}
```

See the full example in [4_Employee](./4_Employee/).

---
### Polymorphism Usage

Suppose you have a drawing application. You do not know at compile time which specific types of shapes the user will create. However, the application has to keep track of all the various types of shapes that are created, and it has to update them in response to user mouse actions. You can use polymorphism to solve this problem in two basic steps:

1. Create a class hierarchy in which each specific shape class derives from a common base class.

2. Use a virtual method to invoke the appropriate method on any derived class through a single call to the base class method.

First, create a base class called `Shape`, and derived classes such as `Rectangle`, `Circle`, and `Triangle`. Give the `Shape` class a virtual method called `Draw`, and override it in each derived class to draw the particular shape that the class represents. Create a `List<Shape>` object and add a `Circle`, `Triangle`, and `Rectangle` to it.

```c#
public class Shape
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Height { get; set; }
    public int Width { get; set; }

    // Virtual method
    public virtual void Draw()
    {
        // Do draw operations common to all shapes
        Console.WriteLine("Base class Draw()");
    }
}

public class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a circle");
        base.Draw();
    }
}

public class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a rectangle");
        base.Draw();
    }
}

public class Triangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a triangle");
        base.Draw();
    }
}
```

To update the drawing surface, use a foreach loop to iterate through the list and call the `Draw` method on each `Shape` object in the list. Even though each object in the list has a declared type of `Shape`, it's the run-time type (the overriden version of the method in each derived class) that will be invoked.

```c#
// A Rectangle, Triangle and Circle can
// all be used wherever a Shape is expected.
// No cast is required because an implicit
// conversion exists from a derived class
// to its base class.
var shapes = new List<Shape>
{
    new Rectangle(),
    new Triangle(),
    new Circle()
};

// Although we are calling Draw() on a
// Shape class, the overriden version in
// the derived classes is invoked, not the
// base class.
foreach (var shape in shapes)
{
    shape.draw();
}
// OUTPUT:
//   Drawing a rectangle
//   Base class Draw()
//   Drawing a triangle
//   Base class Draw()
//   Drawing a circle
//   Base class Draw()
```

---
### New keyword

If you want your derived class to have a member with the same name as a member in a base class, you can use the `new` keyword to hide the base class member. The `new` keyword is put before the return type of a class member that is being replaced.

```c#
public class BaseClass
{
    public void DoWork() { WorkField++; }
    public int WorkField;
}

public class DerivedClass : BaseClass
{
    public new void DoWork() { WorkField--; }
    public new int WorkField;
}
```

In this case, note that the members are **not** virtual, therefore the usual polymorphism usage does not apply. Check the program in [3_New](./3_New/) for an example.

---
### Summary

* **virtual**: Indicates that a method may be overriden by an inheritor

* **override**: Overrides the functionality of a virtual method in a base class, providing different functionality.

* **new**: *hides* the original method (which doesn't have to be virtual), providing different functionality. This should only be used where it is absolutelty necessary.

* **base**: Allows accessing the base class members from within the derived class.

---
### CSV Example
Inside the folder [5_CSV](./5_CSV/) there is an example that demonstrates the use of polymorphism as well as how to read and parse CSV (Comma-Separated Value) files.
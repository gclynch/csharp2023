// demo of records
// immutable data classes by default, useful in concurrency, copy constructor
// reference types
// records can inherit from other records
// value semantics for equality (.Equals and ==)
// a record struct (value type) is possible in C# 10, or an explicit class record

using System;
namespace Human;

record Person
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
}

record Student(string Name, string Number);
// adds constructor + init only properties + deconstructor
// PascalCase
// immutable

record Developer : Person                                       // inheritance
{
    public string? FavouriteLanguage { get; init; }
}

static class Test
{
    public static void Main()
    {
        var p1 = new Person() { FirstName = "Gary", LastName = "Clynch" };
        Console.WriteLine(p1);                                  // ToString default implementation
        Person p2 = p1 with { FirstName = "Fred" };             // create copy, non-destructive mutation
        Person p3 = p2 with { FirstName = "Gary" };             // create copy

        // value equality as in structs
        Console.WriteLine(p1 == p3);                            // true
        Console.WriteLine(p1.Equals(p3));                       // true
        Console.WriteLine(p2 == p3);                            // false

        Student s1 = new Student("Jane Doe", "X0001111");       // no default constructor
        (_, string studentNumber) = s1;                         // deconstructor
        Console.WriteLine(studentNumber);

        Developer d1 = new Developer { FirstName = "Gary", LastName = "Clynch", FavouriteLanguage = "Rust" };
        Console.WriteLine(d1);
        Developer d2 = d1 with
        {
            FavouriteLanguage = "C#"
        };
        Console.WriteLine(d2);
    }
}
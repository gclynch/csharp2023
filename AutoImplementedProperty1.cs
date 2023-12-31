// demo of automatic properties

using System;
namespace Human;
public class Person
{
    // auto properties
    // no explicit fields defined, private anonymous backing fields added by compiler to correspond to properties

    // auto-implemented property
    public required string Name { get; set; }
    // default get generated by compiler using backing field _name, must be get; no body allowed
    // default set generated by compiler using backing field _name, must be set; no body allowed

    public int Age { get; set; }            // could be virtual, and overriden in subclass

    // use if no significant behaviour required from properties i.e. where they just encapsulate fields
    // and in future they may have specific behaviours defined

    // default constructor
    public Person() { }

    public override String ToString() => this.Name + " " + this.Age;        // gets

    // an abstract class can contain abstract properties
}

public static class Test
{
    static void Main()
    {
        // example of an object initialiser
        Person p1 = new Person { Name = "Gary Clynch", Age = 36 };			// default constructor called first, then setters

        Console.Write(p1.Name + " ");	            // get
        Console.WriteLine(p1.Age);	                // get

        p1.Age++;
        Console.WriteLine(p1.ToString());
    }
}
// demo of enumerators
using System.Collections;

// an enumerated type can be iterated over using a foreach loop
// a type can be made enumerable by implementing IEnumerable using an iterator
// an iterator is a section of code that returns an ordered sequence of values of the same type
// an iterator is a method that performs a custom iteration over a collection class by using the yield keyword

namespace Human;

class Person
{
    public required string Name { get; init; }
    public override string ToString() => Name;
}

// a Family class, can be iterated over using foreach loop
// this class has 2 iterators
class Family : IEnumerable<Person>          // an enumerable type
{
    private readonly List<Person> children;             // List<T> is enumerbale

    public Person Father { get; set; }
    public Person Mother { get; set; }


    // return an enumerator which iterates over the entire collection
    public IEnumerator<Person> GetEnumerator()          // type safe because of T
    {
        // create an iterator
        yield return Father;
        yield return Mother;
        foreach (Person p in children)
        {
            yield return p;
        }
    }

    // IEnumerable<T> inherits from IEnumerable which defines the following
    IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        // call generic implementation above
        return this.GetEnumerator();
    }

    public Family()
    {
        Father = new() { Name = "Adam" };
        Mother = new() { Name = "Eve" };
        children = new() { new() { Name = "Cain" }, new() { Name = "Abel" } };
    }
}

static class Test
{
    public static void Main()
    {
        Family family = new();

        foreach (var p in family)                    // calls IEnumerator<Person> GetEnumerator
        {
            Console.WriteLine(p);
        }
    }
}

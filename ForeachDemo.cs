namespace Animal;

class Dog
{
    // auto property
    public string Name { get; private set; }

    public Dog(string name)
    {
        this.Name = name;
    }
}

// test class
public static class Litter
{
    public static void Main()
    {

        Dog[] dogs = { new Dog("Pluto"), new Dog("Snoop"), new Dog("Scooby") };

        // create new generic collection
        List<Dog> litter = new(dogs);

        // collection must be enumerable (which generics are)
        foreach (Dog d in litter)
        {
            Console.WriteLine(d.Name);          // get 
        }

        // alternatively use indexer property in List<T>
        for (int i = 0; i < litter.Count; i++)
        {
            Console.WriteLine(litter[i].Name);
        }
    }
}
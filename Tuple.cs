// tuples
// multiple data items in a lightweight data structure
// mutable value types (System.ValueTuple)
// common use as a method return type instead of out params

using System;
using System.Linq;

namespace Tuples;

static class Demo
{

    // return type is a tuple type
    static (int min, int max) FindMinMax(int[] data)
    {
        int min = data.Min();
        int max = data.Max();
        return (min, max);
    }

    static void Main()
    {
        (double, int) t1 = (100.5, 3);                              // new tuple variable and tuple type
        Console.WriteLine($"{t1.Item1} {t1.Item2}");

        // named fields are optional
        (double sum, int count) t2 = (100.5, 3);
        Console.WriteLine($"{t2.sum} {t2.count}");

        int[] data = { 1, 2, -1, 5, 4, 2 };
        (int min, int max) stats = FindMinMax(data);
        Console.WriteLine($"min: {stats.min} max: {stats.max}");

        // deconstruct into separate variables
        (int min, int max) = FindMinMax(data);                  // or = stats
        Console.WriteLine($"min: {min} max: {max}");
    }

    // tuple can have up to 8 components
    // (string, string)		has Item1 and Item2 component names
}
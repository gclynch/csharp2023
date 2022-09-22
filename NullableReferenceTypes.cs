using System;

// nullable reference types
// try to avoid NullReferenceException
// enable nullable reference types 

#nullable enable                                // pragma which will generate warnings to avoid null reference exception

namespace NullableReferenceTypes
{
    static class NullableRef
    {
        static void Main()
        {
            string nonNullable = null;                                                      // warning
            string? nullable = null;                                                        // no warning
            Person p = new Person() { Dob = new DateTime(1, 1, 1980) };                     // warning about Name
        }
    }

    class Person
    {
        public string Name { get; set; }                                                    // string? will allow null and stop warning
        public DateTime Dob { get; set; }
    }
}

// set at project level in .csproj <Nullable>enable</Nullable>
// or use pragma as above
// string? means it is ok for string to have the value null and for the compiler not to generate warnings

// before C# 8 all reference types can have the value null i.e. all reference types are nullable
// since C# 8 we get a compiler warning if we use null with a reference type if nullable reference types is enabled

// ? used for nullable value and reference types to allow null value i.e. the value can be null

// it is possible to configure that warnings about null references become compiler errors
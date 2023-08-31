// C# 11 and .Net 7, VS 2022 or VS Code

// an assembly application (.exe), not a library (.dll)
// assemblies are applications or libraries

// in default (global) namespace
// class name does not have to match file name
using System;

static class HelloWorld				        // : System.Object, internal is default (within assembly visibility)
{
    // convention is CAPS to start a class name and method name
    private static void Main()			        // access modifier can be anything
    {

        const string message = "Hello there C# 11 and .NET 7 !";

        // alias for System.String, a reference type (on the heap)

        Console.WriteLine($"{message}");	            // placeholder, use comma	
        // or Console.WriteLine("{0}", message);	    // placeholder

        // System.Console.WriteLine.... if haven't said using System;
    }
}

// csc helloworld1.cs - produces HelloWorld.exe (a .NET PE)
// run & managed by the CLR - JITs IL into native code
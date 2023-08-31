// top-level statements

using System;

Console.WriteLine($"{Hello.SayHello()} there C# 11 and .NET 7 !");
Console.WriteLine(args.Length);                                         // args still available (conventionally named)

// must be after usings and before any type definitions

static class Hello
{
    public static string SayHello() => "hello";
}


// csc helloworld2.cs
// helloworld2
// helloworld1 1 2 3

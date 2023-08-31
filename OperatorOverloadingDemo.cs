// demo of operator overloading and structs

using System;

namespace OperatorOverloading;

// Time stores an accumulated amount of time in terms of hours, minutes and seconds
public struct Time
{
    readonly int hours;              // >=0
    readonly int minutes;            // 0 .. 59
    readonly int seconds;            // 0 .. 59

    // non-default constructor, must initialise all fields
    public Time(int hours, int minutes, int seconds)
    {
        // validate

        if ((hours >= 0))                   // no negatives
        {
            this.hours = hours;
        }
        else
        {
            throw new ArgumentException("Invalid value specified for hour: " + hours);
        }

        if ((minutes >= 0) && (minutes <= 59))
        {
            this.minutes = minutes;
        }
        else
        {
            throw new ArgumentException("Invalid value specified for minute: " + minutes);
        }

        if ((seconds >= 0) && (seconds <= 59))
        {
            this.seconds = seconds;
        }
        else
        {
            throw new ArgumentException("Invalid value specified for seocnd: " + seconds);
        }
    }


    // read only properties
    public int Hours => hours;
    public int Minutes => minutes;
    public int Seconds => seconds;

    // parse a integer containing a quantity of seconds to hours, minutes, and seconds
    public static Time Parse(int totalSeconds)
    {
        int hrs = totalSeconds / (60 * 60);
        totalSeconds -= hrs * 60 * 60;
        int mins = totalSeconds / 60;
        int secs = totalSeconds - (mins * 60);

        return new Time(hrs, mins, secs);
    }

    // overload + operator
    // operator overloads always static, no polymorphism
    static public Time operator +(Time left, Time right)                                   // + is binary so overload must be binary
    {
        int seconds1 = (left.Hours * 60 * 60) + (left.Minutes * 60) + left.Seconds;
        int seconds2 = (right.Hours * 60 * 60) + (right.Minutes * 60) + right.Seconds;
        int totalSeconds = seconds1 + seconds2;
        return Parse(totalSeconds);
    }

    // for VB.Net etc. which does not support operator overloading
    public static Time Add(Time left, Time right)
    {
        return left + right;
    }

    // overload - operator
    static public Time operator -(Time left, Time right)                                   // - is binary so overload must be binary
    {
        int seconds1 = (left.Hours * 60 * 60) + (left.Minutes * 60) + left.Seconds;
        int seconds2 = (right.Hours * 60 * 60) + (right.Minutes * 60) + right.Seconds;
        int totalSeconds = seconds1 - seconds2;
        if (totalSeconds < 0)
        {
            return Parse(0);                            // zero the time i.e. to 00:00:00
        }
        else
        {
            return Parse(totalSeconds);
        }
    }

    // for VB.Net
    public static Time Subtract(Time left, Time right)
    {
        return left - right;
    }

    // == and != defined for reference types and predefined value types to do reference and value type comparison

    // overload == to allow its use with this value type (i.e. not predefined)
    public static bool operator ==(Time left, Time right)
    {
        return left.Equals(right);
    }

    // overload !=
    public static bool operator !=(Time left, Time right)
    {
        return !left.Equals(right);
    }

    // inherited from System.Object
    public override string ToString() =>
        Hours.ToString("D2") + ":" + Minutes.ToString("D2") + ":" + Seconds.ToString("D2");

}

// test class
static class Test
{
    static void Main()
    {
        Time t1 = new Time(11, 59, 59);
        Time t2 = new(00, 00, 01);

        Console.WriteLine(t1 + t2);                     // overloaded op +
        Console.WriteLine(t1 - t2);                     // overloaded op -

        t2 = new(11, 59, 59);
        Time t3 = t2;                                   // copy, since value type
        Console.WriteLine(t1.Equals(t2));               // true          
        Console.WriteLine(t1 == t2);                    // true
        Console.WriteLine(t2 == t3);                    // true

        // .Equals by default tests reference equality for reference types and value equality (based on binary representation) for value types
        // == is overriden in Time struct to do same as .Equals
        // in String class (a reference type) - .Equals customised to do value comparison and == overloaded to call it
    }
}
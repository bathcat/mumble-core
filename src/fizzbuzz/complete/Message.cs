using System;

namespace MumbleCore.FizzBuzz.Complete;

public class Message
{
    public static string FromIndex(byte index)
    {
        if (index == 0 || index > 100)
        {
            throw new ArgumentException("Index must be greater than 0 and less than 101");
        }

        if (index % 15 == 0)
        {
            return "fizzbuzz";
        }

        if (index % 3 == 0)
        {
            return "fizz";
        }

        if (index % 5 == 0)
        {
            return "buzz";
        }

        return index.ToString();

    }
}
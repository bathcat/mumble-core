using System;

namespace MC.FizzBuzz.Console;


public record BuzzResponse(int Index, string Message);
public class Message
{
    public static BuzzResponse FromIndex(byte index) => index switch
    {
        < 1 => throw new ArgumentException("Index must be greater than 0."),
        > 100 => throw new ArgumentException("Index must be less than 101."),
        _ when (index % 15 == 0) => new BuzzResponse(index, "FizzBuzz"),
        _ when (index % 3 == 0) => new BuzzResponse(index, "Fizz"),
        _ when (index % 5 == 0) => new BuzzResponse(index, "Buzz"),
        _ => new BuzzResponse(index, index.ToString()),
    };

    public static string FromIndexOldSchool(byte index)
    {
        if (index == 0 || index > 100)
        {
            throw new ArgumentException("Index must be greater than 0 and less than 101");
        }

        if (index % 15 == 0)
        {
            return "FizzBuzz";
        }

        if (index % 3 == 0)
        {
            return "Fizz";
        }

        if (index % 5 == 0)
        {
            return "Buzz";
        }

        return index.ToString();

    }
}
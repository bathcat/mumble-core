﻿using System;

namespace MumbleCore.FizzBuzz.Console.Complete;

public class Message
{
    public static string FromIndex(byte index) => index switch
    {
        _ when (index == 0) => throw new ArgumentException("Index must be greater than 0."),
        _ when (index > 100) => throw new ArgumentException("Index must be less than 101."),
        _ when (index % 15 == 0) => "FizzBuzz",
        _ when (index % 3 == 0) => "Fizz",
        _ when (index % 5 == 0) => "Buzz",
        _ => index.ToString(),
    };

    public static string FromIndexOldSchool(byte index)
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
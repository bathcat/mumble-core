namespace MumbleCore.FizzBuzz.Console.Complete;

using System;

internal class Program
{
    private static void Main(string[] args)
    {
        for (byte b = 1; b < 101; b++)
        {
            Console.WriteLine(Message.FromIndex(b));
        }
    }
}
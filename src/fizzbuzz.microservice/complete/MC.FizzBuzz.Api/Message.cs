namespace MC.FizzBuzz.Api;

public static class Message
{
    public static string FromIndex(byte index) => index switch
    {
        0 => throw new ArgumentException("Index must be greater than 0."),
        > 100 => throw new ArgumentException("Index must be less than 101."),
        _ when (index % 15 == 0) => "FizzBuzz",
        _ when (index % 3 == 0) => "Fizz",
        _ when (index % 5 == 0) => "Buzz",
        _ => index.ToString(),
    };
}

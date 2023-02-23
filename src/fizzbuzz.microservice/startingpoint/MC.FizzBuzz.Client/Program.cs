namespace MC.FizzBuzz.Client;

internal class Program
{

    private const string url = "http://localhost:5013";
    static async Task<int> AsyncMain(string[] args)
    {
        using var client = new HttpClient();
        using var response = await client.GetAsync(url);
        var message = await response.Content.ReadAsStringAsync();
        Console.WriteLine(message);
        Console.ReadKey();
        return 0;
    }

    public static int Main(string[] args)
        => AsyncMain(args).Result;

}
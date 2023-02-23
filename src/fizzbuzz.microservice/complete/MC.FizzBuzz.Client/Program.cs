using System.Net.Http.Json;

namespace MC.FizzBuzz.Client;

internal class Program
{
    static async Task<int> AsyncMain(string[] args)
    {
        using var client = new HttpClient();
        using var response = await client.GetAsync("http://localhost:5013/messages");
        var messages = await response.Content.ReadFromJsonAsync<IEnumerable<string>>();
        foreach (var message in messages!)
        {
            Console.WriteLine(message);
        }
        Console.ReadKey();
        return 0;
    }

    public static int Main(string[] args)
        => AsyncMain(args).Result;

}
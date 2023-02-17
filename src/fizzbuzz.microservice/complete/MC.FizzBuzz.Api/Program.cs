using MC.FizzBuzz.Api;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/messages/{index}", Message.FromIndex);

app.MapGet("/messages",
    () => Enumerable.Range(1, 100)
                    .Select(i => (byte)i)
                    .Select(Message.FromIndex)

);


app.Run();
﻿using Microsoft.AspNetCore.Builder;

namespace H4cme.Lab.Cors.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();
        app.UseDefaultFiles();
        app.UseStaticFiles();
        app.Run();
    }
}

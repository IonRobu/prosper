using ObjCRuntime;
using UIKit;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Prosper
{
    public static class Program
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            var builder = MauiApp.CreateBuilder();

            // Add services, handlers, etc. as needed

            builder.UseMauiApp<App>();

            var app = builder.Build();
            MauiProgram.Run(app);
        }
    }
}


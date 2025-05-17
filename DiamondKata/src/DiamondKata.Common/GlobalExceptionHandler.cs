using System;

namespace DiamondKata.Common;

public static class GlobalExceptionHandler
{
    public static void Initialize()
    {
        AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;
    }

    private static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs args)
    {
        var exception = (Exception)args.ExceptionObject;
        Console.WriteLine($"\nAn unexpected error occurred: {exception.Message}");
        
        if (exception.InnerException != null)
        {
            Console.WriteLine($"Inner exception: {exception.InnerException.Message}");
        }
        
        Environment.Exit(1);
    }

    public static void HandleException(Exception ex, bool exitApplication = true)
    {
        Console.WriteLine($"\nAn error occurred: {ex.Message}");
        
        if (ex.InnerException != null)
        {
            Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
        }

        if (exitApplication)
        {
            Environment.Exit(1);
        }
    }
} 
using DiamondKata.Application.Interfaces;
using DiamondKata.Common.Models;
using DiamondKata.Console;
using DiamondKata.Domain.Models;
using DiamondKata.Common;
using DiamondKata.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

// Configure services
var services = new ServiceCollection();
services.AddDiamondKataServices();
var serviceProvider = services.BuildServiceProvider();

// Initialize global exception handler
GlobalExceptionHandler.Initialize();

try
{
    var generator = serviceProvider.GetRequiredService<IDiamondGeneratorService>();
    var inputHandler = serviceProvider.GetRequiredService<IInputHandler>();

    while (true)
    {
        Console.Write("\nEnter a letter (A-Z) or 'q' to quit: ");
        var inputResult = inputHandler.GetInput();

        if (!inputResult.IsSuccess)
        {
            Console.WriteLine($"\nError: {inputResult.Error}");
            continue;
        }

        var input = inputResult.Value;
        if (inputHandler.ShouldQuit(input))
        {
            Console.WriteLine("Goodbye!");
            break;
        }

        var result = generator.GenerateDiamond(input);
        if (result.IsSuccess)
        {
            Console.WriteLine("\n" + string.Join("\n", result.Value!.Lines));
        }
        else
        {
            Console.WriteLine($"\nError: {result.Error}");
        }
    }
}
catch (Exception ex)
{
    GlobalExceptionHandler.HandleException(ex);
}

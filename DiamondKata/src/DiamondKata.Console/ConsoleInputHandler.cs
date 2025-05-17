using DiamondKata.Common.Models;
using DiamondKata.Infrastructure.Services;

namespace DiamondKata.Console;

public class ConsoleInputHandler : IInputHandler
{
    public Result<char> GetInput()
    {
        var input = System.Console.ReadLine()?.Trim().ToLower();
        
        if (string.IsNullOrEmpty(input))
        {
            return Result.Failure<char>("No input provided. Please enter a letter (A-Z) or 'q' to quit.");
        }

        if (input.Length != 1)
        {
            return Result.Failure<char>("Please enter a single character.");
        }

        return Result.Success(input[0]);
    }

    public bool ShouldQuit(char input)
    {
        return input == 'q';
    }
} 
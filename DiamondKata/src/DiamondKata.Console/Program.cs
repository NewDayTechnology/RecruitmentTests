using DiamondKata;
using DiamondKata.Services;

var generator = new DiamondGenerator(new DiamondPatternService());

Console.WriteLine("Welcome to the Diamond Generator!");
Console.WriteLine("Enter a letter (A-Z) to generate a diamond pattern, or 'Q' to quit.");

while (true)
{
    Console.Write("\nEnter a letter: ");
    var input = Console.ReadLine()?.Trim().ToUpper();

    if (string.IsNullOrEmpty(input) || input == "Q")
    {
        Console.WriteLine("Goodbye!");
        break;
    }

    if (input.Length != 1 || !char.IsLetter(input[0]))
    {
        Console.WriteLine("Please enter a single letter (A-Z).");
        continue;
    }

    try
    {
        var diamond = generator.GenerateDiamond(input[0]);
        Console.WriteLine("\nGenerated Diamond Pattern:");
        Console.WriteLine(diamond);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

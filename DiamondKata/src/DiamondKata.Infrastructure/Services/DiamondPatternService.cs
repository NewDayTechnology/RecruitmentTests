using DiamondKata.Domain.Interfaces;
using DiamondKata.Common.Models;

namespace DiamondKata.Infrastructure.Services;

/// <summary>
/// Implementation of the diamond pattern generation service.
/// </summary>
public class DiamondPatternService : IDiamondPatternService
{
    private readonly char _spaceCharacter;
    private readonly string _lineEnding;
    private readonly bool _trimTrailingSpaces;

    public DiamondPatternService(
        char spaceCharacter = ' ',
        string lineEnding = "\n",
        bool trimTrailingSpaces = true)
    {
        _spaceCharacter = spaceCharacter;
        _lineEnding = lineEnding;
        _trimTrailingSpaces = trimTrailingSpaces;
    }

    /// <inheritdoc />
    public Result<string> GenerateDiamondPattern(char letter)
    {
        if (!char.IsLetter(letter))
        {
            return Result.Failure<string>($"Invalid input: '{letter}'. Please enter a letter (A-Z).");
        }

        var lines = new List<string>();
        var targetChar = char.ToUpper(letter);
        
        // Generate top half including middle
        for (char c = 'A'; c <= targetChar; c++)
        {
            var lineResult = GenerateLine(c, targetChar, _spaceCharacter);
            if (!lineResult.IsSuccess)
            {
                return lineResult;
            }
            lines.Add(lineResult.Value!);
        }

        // Generate bottom half (excluding middle)
        for (char c = (char)(targetChar - 1); c >= 'A'; c--)
        {
            var lineResult = GenerateLine(c, targetChar, _spaceCharacter);
            if (!lineResult.IsSuccess)
            {
                return lineResult;
            }
            lines.Add(lineResult.Value!);
        }

        // Join lines with the correct line ending
        return Result.Success(string.Join(_lineEnding, lines));
    }

    /// <inheritdoc />
    public Result<string> GenerateLine(char currentChar, char targetChar, char spaceChar)
    {
        if (currentChar < 'A' || currentChar > 'Z')
        {
            return Result.Failure<string>($"Invalid character: '{currentChar}'. Must be between A and Z.");
        }

        if (targetChar < 'A' || targetChar > 'Z')
        {
            return Result.Failure<string>($"Invalid target character: '{targetChar}'. Must be between A and Z.");
        }

        var distance = targetChar - currentChar;
        var leadingSpaces = new string(spaceChar, distance);
        var middleSpacesCount = (currentChar - 'A') * 2 - 1;
        var middleSpaces = middleSpacesCount >= 0 ? new string(spaceChar, middleSpacesCount) : string.Empty;

        var line = currentChar == 'A'
            ? $"{leadingSpaces}{currentChar}"
            : $"{leadingSpaces}{currentChar}{middleSpaces}{currentChar}";

        if (_trimTrailingSpaces)
        {
            return Result.Success(line.TrimEnd());
        }
        else
        {
            // Pad the line to the full width of the diamond
            int width = 2 * (targetChar - 'A') + 1;
            return Result.Success(line.PadRight(width));
        }
    }
} 
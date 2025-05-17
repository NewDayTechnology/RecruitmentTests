using System;
using System.Collections.Generic;
using System.Linq;

namespace DiamondKata.Services;

/// <summary>
/// Service responsible for generating diamond patterns.
/// </summary>
public class DiamondPatternService
{
    /// <summary>
    /// Generates a diamond pattern for the given letter.
    /// </summary>
    /// <param name="letter">The letter to generate the diamond for (A-Z).</param>
    /// <returns>A string array representing the diamond pattern.</returns>
    public string[] GeneratePattern(char letter)
    {
        if (!char.IsLetter(letter))
        {
            throw new ArgumentException("Input must be a letter", nameof(letter));
        }

        letter = char.ToUpper(letter);
        var size = letter - 'A' + 1;
        var width = 2 * size - 1;
        var pattern = new List<string>();

        for (int i = 0; i < size; i++)
        {
            var currentChar = (char)('A' + i);
            var spaces = new string(' ', size - i - 1);
            if (i == 0)
            {
                pattern.Add((spaces + currentChar).PadRight(width));
            }
            else
            {
                var middleSpaces = new string(' ', 2 * i - 1);
                pattern.Add((spaces + currentChar + middleSpaces + currentChar).PadRight(width));
            }
        }

        // Add the bottom half (mirror of top half, excluding the middle)
        for (int i = size - 2; i >= 0; i--)
        {
            pattern.Add(pattern[i]);
        }

        return pattern.ToArray();
    }
} 
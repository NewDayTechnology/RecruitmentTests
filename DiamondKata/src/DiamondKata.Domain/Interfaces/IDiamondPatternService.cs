using DiamondKata.Common.Models;

namespace DiamondKata.Domain.Interfaces;

/// <summary>
/// Defines the contract for generating diamond patterns.
/// </summary>
public interface IDiamondPatternService
{
    /// <summary>
    /// Generates a diamond pattern for the given letter.
    /// </summary>
    /// <param name="letter">The letter to generate the diamond for (A-Z).</param>
    /// <returns>A Result containing the diamond pattern or an error message.</returns>
    Result<string> GenerateDiamondPattern(char letter);

    /// <summary>
    /// Generates a single line of the diamond pattern.
    /// </summary>
    /// <param name="currentChar">The current character for the line.</param>
    /// <param name="targetChar">The target character (maximum letter).</param>
    /// <param name="spaceChar">The character to use for spaces.</param>
    /// <returns>A Result containing the line or an error message.</returns>
    Result<string> GenerateLine(char currentChar, char targetChar, char spaceChar);
} 
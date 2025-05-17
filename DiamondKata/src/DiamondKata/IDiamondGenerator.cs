namespace DiamondKata;

/// <summary>
/// Defines the contract for generating diamond patterns from letters.
/// </summary>
public interface IDiamondGenerator
{
    /// <summary>
    /// Generates a diamond pattern for the given letter.
    /// </summary>
    /// <param name="letter">The letter to generate the diamond for (A-Z).</param>
    /// <returns>A string representing the diamond pattern.</returns>
    string GenerateDiamond(char letter);
} 
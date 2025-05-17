using DiamondKata.Common.Models;
using DiamondKata.Domain.Models;

namespace DiamondKata.Application.Interfaces;

/// <summary>
/// Application service for generating diamond patterns.
/// </summary>
public interface IDiamondGeneratorService
{
    /// <summary>
    /// Generates a diamond pattern for the given letter.
    /// </summary>
    /// <param name="letter">The letter to generate the diamond for (A-Z).</param>
    /// <returns>A Result containing the diamond pattern or an error message.</returns>
    Result<DiamondPattern> GenerateDiamond(char letter);
} 
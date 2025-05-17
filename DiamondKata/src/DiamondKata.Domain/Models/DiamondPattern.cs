namespace DiamondKata.Domain.Models;

/// <summary>
/// Represents a diamond pattern in the domain.
/// </summary>
public class DiamondPattern
{
    public char TargetLetter { get; }
    public IReadOnlyList<string> Lines { get; }

    public DiamondPattern(char targetLetter, IReadOnlyList<string> lines)
    {
        TargetLetter = targetLetter;
        Lines = lines;
    }
} 
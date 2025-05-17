using DiamondKata.Services;

namespace DiamondKata;

/// <summary>
/// Implementation of IDiamondGenerator that generates diamond patterns.
/// </summary>
public class DiamondGenerator : IDiamondGenerator
{
    private readonly DiamondPatternService _patternService;

    public DiamondGenerator(DiamondPatternService? patternService = null)
    {
        _patternService = patternService ?? new DiamondPatternService();
    }

    /// <inheritdoc />
    public string GenerateDiamond(char letter)
    {
        var pattern = _patternService.GeneratePattern(letter);
        return string.Join("\n", pattern);
    }
} 
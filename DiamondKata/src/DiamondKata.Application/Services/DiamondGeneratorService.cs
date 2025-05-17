using DiamondKata.Application.Interfaces;
using DiamondKata.Common.Models;
using DiamondKata.Domain.Interfaces;
using DiamondKata.Domain.Models;

namespace DiamondKata.Application.Services;

/// <summary>
/// Implementation of the diamond generator application service.
/// </summary>
public class DiamondGeneratorService : IDiamondGeneratorService
{
    private readonly IDiamondPatternService _patternService;

    public DiamondGeneratorService(IDiamondPatternService patternService)
    {
        _patternService = patternService ?? throw new ArgumentNullException(nameof(patternService));
    }

    public Result<DiamondPattern> GenerateDiamond(char letter)
    {
        if (!char.IsLetter(letter))
        {
            return Result.Failure<DiamondPattern>($"Invalid input: '{letter}'. Please enter a letter (A-Z).");
        }

        var patternResult = _patternService.GenerateDiamondPattern(char.ToUpper(letter));
        if (!patternResult.IsSuccess)
        {
            return Result.Failure<DiamondPattern>(patternResult.Error!);
        }

        var lines = patternResult.Value!.Split('\n');
        return Result.Success(new DiamondPattern(char.ToUpper(letter), lines));
    }
} 
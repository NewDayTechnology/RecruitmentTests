using DiamondKata.Application.Interfaces;
using DiamondKata.Application.Services;
using DiamondKata.Common.Models;
using DiamondKata.Domain.Interfaces;
using DiamondKata.Domain.Models;
using Moq;
using Xunit;

namespace DiamondKata.Tests;

public class DiamondGeneratorServiceTests
{
    private readonly Mock<IDiamondPatternService> _patternServiceMock;
    private readonly IDiamondGeneratorService _generatorService;

    public DiamondGeneratorServiceTests()
    {
        _patternServiceMock = new Mock<IDiamondPatternService>();
        _generatorService = new DiamondGeneratorService(_patternServiceMock.Object);
    }

    [Theory]
    [InlineData('A', "A")]
    [InlineData('B', " A\nB B\n A")]
    [InlineData('C', "  A\n B B\nC   C\n B B\n  A")]
    public void GenerateDiamond_WithValidLetter_ReturnsSuccessResult(char letter, string expectedPattern)
    {
        // Arrange
        _patternServiceMock.Setup(x => x.GenerateDiamondPattern(letter))
            .Returns(Result.Success(expectedPattern));

        // Act
        var result = _generatorService.GenerateDiamond(letter);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(letter, result.Value!.TargetLetter);
        Assert.Equal(expectedPattern.Split('\n'), result.Value.Lines);
    }

    [Theory]
    [InlineData('1')]
    [InlineData('@')]
    [InlineData(' ')]
    public void GenerateDiamond_WithInvalidInput_ReturnsFailureResult(char invalidInput)
    {
        // Act
        var result = _generatorService.GenerateDiamond(invalidInput);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("Invalid input", result.Error);
    }

    [Fact]
    public void GenerateDiamond_WhenPatternServiceFails_ReturnsFailureResult()
    {
        // Arrange
        var errorMessage = "Pattern generation failed";
        _patternServiceMock.Setup(x => x.GenerateDiamondPattern('A'))
            .Returns(Result.Failure<string>(errorMessage));

        // Act
        var result = _generatorService.GenerateDiamond('A');

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(errorMessage, result.Error);
    }
} 
using Xunit;
using DiamondKata.Infrastructure.Services;
using DiamondKata.Common.Models;

namespace DiamondKata.Tests;

public class DiamondGeneratorTests
{
    [Theory]
    [InlineData('A', "A")]
    [InlineData('B', " A\nB B\n A")]
    [InlineData('C', "  A\n B B\nC   C\n B B\n  A")]
    [InlineData('D', "   A\n  B B\n C   C\nD     D\n C   C\n  B B\n   A")]
    public void GenerateDiamond_WithValidLetter_ReturnsSuccessResult(char letter, string expected)
    {
        var generator = new DiamondPatternService();
        var result = generator.GenerateDiamondPattern(letter);
        
        Assert.True(result.IsSuccess);
        Assert.Equal(expected, result.Value);
    }

    [Theory]
    [InlineData('a')]
    [InlineData('b')]
    [InlineData('c')]
    public void GenerateDiamond_WithLowerCaseLetter_ReturnsUpperCaseDiamond(char letter)
    {
        var generator = new DiamondPatternService();
        var result = generator.GenerateDiamondPattern(letter);
        
        Assert.True(result.IsSuccess);
        Assert.Equal(generator.GenerateDiamondPattern(char.ToUpper(letter)).Value, result.Value);
    }

    [Theory]
    [InlineData('1')]
    [InlineData('@')]
    [InlineData(' ')]
    public void GenerateDiamond_WithInvalidInput_ReturnsFailureResult(char invalidInput)
    {
        var generator = new DiamondPatternService();
        var result = generator.GenerateDiamondPattern(invalidInput);
        
        Assert.False(result.IsSuccess);
        Assert.Contains("Invalid input", result.Error);
    }

    [Fact]
    public void GenerateDiamond_WithCustomSpaceCharacter_ReturnsCorrectDiamond()
    {
        var generator = new DiamondPatternService(spaceCharacter: '*');
        var expected = "**A\n*B*B\nC***C\n*B*B\n**A";
        var result = generator.GenerateDiamondPattern('C');
        
        Assert.True(result.IsSuccess);
        Assert.Equal(expected, result.Value);
    }

    [Fact]
    public void GenerateDiamond_WithCustomLineEnding_ReturnsCorrectDiamond()
    {
        var generator = new DiamondPatternService(lineEnding: "\r\n");
        var expected = " A\r\nB B\r\n A";
        var result = generator.GenerateDiamondPattern('B');
        Assert.True(result.IsSuccess);
        Assert.Equal(expected, result.Value);
    }

    [Fact]
    public void GenerateDiamond_WithoutTrimTrailingSpaces_ReturnsCorrectDiamond()
    {
        var generator = new DiamondPatternService(trimTrailingSpaces: false);
        var expected = " A \nB B\n A ";
        var result = generator.GenerateDiamondPattern('B');
        
        Assert.True(result.IsSuccess);
        Assert.Equal(expected, result.Value);
    }
} 
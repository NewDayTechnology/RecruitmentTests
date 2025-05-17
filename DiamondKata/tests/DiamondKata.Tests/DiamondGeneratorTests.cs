using Xunit;
using DiamondKata;
using DiamondKata.Services;

namespace DiamondKata.Tests;

public class DiamondGeneratorTests
{
    private readonly IDiamondGenerator _generator;

    public DiamondGeneratorTests()
    {
        _generator = new DiamondGenerator(new DiamondPatternService());
    }

    [Theory]
    [InlineData('A', "A")]
    [InlineData('B', " A \nB B\n A ")]
    [InlineData('C', "  A  \n B B \nC   C\n B B \n  A  ")]
    [InlineData('D', "   A   \n  B B  \n C   C \nD     D\n C   C \n  B B  \n   A   ")]
    public void GenerateDiamond_WithValidLetter_ReturnsCorrectDiamond(char letter, string expected)
    {
        // Act
        var result = _generator.GenerateDiamond(letter);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData('a')]
    [InlineData('b')]
    [InlineData('c')]
    public void GenerateDiamond_WithLowerCaseLetter_ReturnsUpperCaseDiamond(char letter)
    {
        // Act
        var result = _generator.GenerateDiamond(letter);

        // Assert
        Assert.Equal(_generator.GenerateDiamond(char.ToUpper(letter)), result);
    }

    [Theory]
    [InlineData('1')]
    [InlineData('@')]
    [InlineData(' ')]
    public void GenerateDiamond_WithInvalidInput_ThrowsArgumentException(char invalidInput)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => _generator.GenerateDiamond(invalidInput));
    }
} 
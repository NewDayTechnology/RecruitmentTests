using Xunit;
using DiamondKata;

namespace DiamondKata.Tests;

public class DiamondGeneratorTests
{
    [Fact]
    public void GenerateDiamond_WithA_ReturnsSingleLineWithA()
    {
        // Arrange
        var generator = new DiamondGenerator();
        
        // Act
        var result = generator.GenerateDiamond('A');
        
        // Assert
        var expected = "A";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GenerateDiamond_WithB_ReturnsThreeLineDiamond()
    {
        // Arrange
        var generator = new DiamondGenerator();
        
        // Act
        var result = generator.GenerateDiamond('B');
        
        // Assert
        var expected = " A \nB B\n A ";
        Assert.Equal(expected, result);
    }
} 
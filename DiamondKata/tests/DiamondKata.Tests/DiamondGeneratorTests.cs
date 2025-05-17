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
} 
using Xunit;
using DiamondKata.Common.Models;
using DiamondKata.Console;
using DiamondKata.Infrastructure.Services;

namespace DiamondKata.Tests;

public class ConsoleInputHandlerTests
{
    private readonly IInputHandler _handler;

    public ConsoleInputHandlerTests()
    {
        _handler = new ConsoleInputHandler();
    }

    [Theory]
    [InlineData('q')]
    [InlineData('Q')]
    public void ShouldQuit_WithQuitCharacter_ReturnsTrue(char input)
    {
        Assert.True(_handler.ShouldQuit(char.ToLower(input)));
    }

    [Theory]
    [InlineData('a')]
    [InlineData('b')]
    [InlineData('z')]
    public void ShouldQuit_WithNonQuitCharacter_ReturnsFalse(char input)
    {
        Assert.False(_handler.ShouldQuit(input));
    }

    [Fact]
    public void GetInput_WithEmptyInput_ReturnsFailure()
    {
        // Arrange
        var input = string.Empty;
        using var reader = new StringReader(input);
        System.Console.SetIn(reader);

        // Act
        var result = _handler.GetInput();

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("No input provided", result.Error);
    }

    [Fact]
    public void GetInput_WithMultipleCharacters_ReturnsFailure()
    {
        // Arrange
        var input = "abc";
        using var reader = new StringReader(input);
        System.Console.SetIn(reader);

        // Act
        var result = _handler.GetInput();

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Contains("single character", result.Error);
    }

    [Theory]
    [InlineData("a")]
    [InlineData("B")]
    [InlineData("z")]
    public void GetInput_WithValidLetter_ReturnsSuccess(string input)
    {
        // Arrange
        using var reader = new StringReader(input);
        System.Console.SetIn(reader);

        // Act
        var result = _handler.GetInput();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(char.ToLower(input[0]), result.Value);
    }
} 
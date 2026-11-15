namespace GuessingGame.Tests;

using GuessingGame;
using Xunit;

public class InputParserTests
{
    [Fact]
    public void TryParseGuess_ValidNumber_ReturnsTrue()
    {
        Assert.True(InputParser.TryParseGuess("42", 1, 100, out int value));
        Assert.Equal(42, value);
    }

    [Fact]
    public void TryParseGuess_WithWhitespace_ReturnsTrue()
    {
        Assert.True(InputParser.TryParseGuess("  42  ", 1, 100, out int value));
        Assert.Equal(42, value);
    }

    [Fact]
    public void TryParseGuess_BelowMin_ReturnsFalse()
    {
        Assert.False(InputParser.TryParseGuess("0", 1, 100, out _));
    }

    [Fact]
    public void TryParseGuess_AboveMax_ReturnsFalse()
    {
        Assert.False(InputParser.TryParseGuess("101", 1, 100, out _));
    }

    [Fact]
    public void TryParseGuess_NonNumeric_ReturnsFalse()
    {
        Assert.False(InputParser.TryParseGuess("abc", 1, 100, out _));
    }

    [Fact]
    public void TryParseGuess_EmptyString_ReturnsFalse()
    {
        Assert.False(InputParser.TryParseGuess("", 1, 100, out _));
    }

    [Fact]
    public void TryParseGuess_NullInput_ReturnsFalse()
    {
        Assert.False(InputParser.TryParseGuess(null, 1, 100, out _));
    }

    [Fact]
    public void TryParseGuess_AtBoundaries_ReturnsTrue()
    {
        Assert.True(InputParser.TryParseGuess("1", 1, 100, out int low));
        Assert.Equal(1, low);
        Assert.True(InputParser.TryParseGuess("100", 1, 100, out int high));
        Assert.Equal(100, high);
    }
}

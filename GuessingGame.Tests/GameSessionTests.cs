namespace GuessingGame.Tests;

using GuessingGame;
using Xunit;

public class GameSessionTests
{
    [Fact]
    public void Guess_BelowSecret_ReturnsTooLow()
    {
        var session = new GameSession(secret: 50, maxTries: 5);

        Assert.Equal(GuessResult.TooLow, session.Guess(10));
    }

    [Fact]
    public void Guess_AboveSecret_ReturnsTooHigh()
    {
        var session = new GameSession(secret: 50, maxTries: 5);
        Assert.Equal(GuessResult.TooHigh, session.Guess(96));
    }

    [Fact]
    public void Guess_EqualToSecret_ReturnsCorrectAndWins()
    {
        var session = new GameSession(secret: 50, maxTries: 5);
        Assert.Equal(GuessResult.Correct, session.Guess(50));
        Assert.True(session.IsWon);
        Assert.True(session.IsOver);
    }

    [Fact]
    public void Guess_UsesUpOneTryEachTime()
    {
        var session = new GameSession(secret: 50, maxTries: 5);

        session.Guess(1);
        session.Guess(2);

        Assert.Equal(2, session.AttemptUsed);
        Assert.Equal(3, session.AttemptsRemaining);
        Assert.False(session.IsOver);
    }

    [Fact]
    public void WrongGuesses_UntilTriesRunOut_EndsRoundAsLoss()
    {
        var session = new GameSession(secret: 50, maxTries: 3);

        session.Guess(1);
        session.Guess(2);
        session.Guess(3);

        Assert.True(session.IsOver);
        Assert.False(session.IsWon);
        Assert.Equal(0, session.AttemptsRemaining);
    }

    [Fact]
    public void CorrectGuessOnFinalTry_CountsAsWin()
    {
        var session = new GameSession(secret: 50, maxTries: 5);

        session.Guess(1);
        session.Guess(50);

        Assert.True(session.IsWon);
        Assert.Equal(2, session.AttemptUsed);
    }

    [Fact]
    public void GuessAfterGameIsOver_Throws()
    {
        var session = new GameSession(secret: 50, maxTries: 1);
        session.Guess(50);

        Assert.Throws<InvalidOperationException>(() => session.Guess(99));
    }

    [Fact]
    public void InvalidMaxTries_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new GameSession(secret: 50, maxTries: 0));
    }
}

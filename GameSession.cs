

using System;

namespace GuessingGame;

// the outcome of a single guess.

public enum GuessResult
{
    TooLow,
    TooHigh,
    Correct
}

    public class GameSession
    {

// game session method
public GameSession(int secret, int maxTries)
    {
        if (maxTries < 1)

        throw new ArgumentOutOfRangeException(nameof(maxTries), "maxTries must be at least 1.");

        Secret = secret;
        MaxTries = maxTries;

    }

        //getters
        public int Secret { get; private set; }
        
        public int MaxTries { get; private set; }

        public int AttemptUsed {get; private set;}

        public bool IsWon {get; private set;}


        public int AttemptsRemaining => MaxTries - AttemptUsed;

        // The round ends when the player wins or uns out of tries

        public bool IsOver => IsWon || AttemptsRemaining <= 0;


        // checks a guess, uses up one try, and report the result.

        public GuessResult Guess(int guess)
    {
        if (IsOver)
        throw new InvalidOperationException("The round is aleady over.");

    AttemptUsed++;


    if(guess == Secret)
        {
            IsWon = true;
            return GuessResult.Correct;
        }

        return guess < Secret ? GuessResult.TooLow : GuessResult.TooHigh;
    }
        
        
    }


    

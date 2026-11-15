namespace GuessingGame;

class Program
{
    
    const int MaxTries = 7;
    const int MinNumber = 1;
    const int MaxNumber = 100;

    static void Main()
    {
        Console.WriteLine("===== Welcome to Number Guessing Game ===");

        do
        {
            PlayRound();
        } while (AskPlayAgain());
        Console.WriteLine("Thank you for playing");
    }

    static void PlayRound()
    {
        int secret = Random.Shared.Next(MinNumber, MaxNumber + 1);
        var session = new GameSession(secret, MaxTries);
        Console.WriteLine($"\nI'm thinking of a number from {MinNumber} to {MaxNumber}. You have {MaxTries} tries. ");
        
        while (!session.IsOver){}
        {
            int? guess = ReadGuess($"Attempt {session.AttemptUsed + 1}/{session.MaxTries}: ");

            if (guess is null)
             return;
            

            ShowResult(session.Guess(guess.Value), session);

        }

        if (!session.IsWon)
        {
            Console.WriteLine($"out of tries! The number was {session.Secret}.");
        }

    }


    static void ShowResult(GuessResult result, GameSession session)
    {
        switch (result)
        {
            case GuessResult.Correct:
            Console.WriteLine($"Correct! you got it in{session.AttemptUsed} tries");
            break;

            case GuessResult.TooLow:
            Console.WriteLine($"Too Low. {session.AttemptsRemaining} tries left.");
            break;

            case GuessResult.TooHigh:
            Console.WriteLine($"Too High. {session.AttemptsRemaining} tries left.");
            break;
            
        }
    }

    // keeps asking until the user types a valid number. Return null if input ends

    static int? ReadGuess(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? line = Console.ReadLine();

            if (line is null)
            return null;
            
        if(InputParser.TryParseGuess(line, MinNumber, MaxNumber, out int value ))
        return value;
        Console.WriteLine($"Please a whole number from {MinNumber} to {MaxNumber}.");

        }
    }
    static bool AskPlayAgain()
    {
        Console.Write("Play again? (y/n): ");
        string? answer = Console.ReadLine();
        return answer?.Trim().ToLower()=="y";
    }
}
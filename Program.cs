using System;

class Program
{
    
    const int MaxTries = 7;
    const int MinNumber = 1;
    const int MaxNumber = 100;

    static void Main()
    {
        Console.WriteLine("===== Number Guessing Game ===");

        do
        {
            PlayRound();
        } while (AskPlayAgain());
        Console.WriteLine("Thank you for playing");
    }

    static void PlayRound()
    {
        int secret = Random.Shared.Next(MinNumber, MaxNumber + 1);
    }
}
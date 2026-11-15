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
        Console.WriteLine($"\nI'm thinking of a number from {MinNumber} to {MaxNumber}. You have {MaxTries} tries. ");
        
        for (int attempt = 0; attempt <= MaxTries; attempt++)
        {
            int guess = ReadInt($"Attempt {attempt}/{MaxTries}:", MinNumber , MaxNumber);
            
            if(guess == secret)
            {
                Console.WriteLine($"Correct! you got it in {attempt} tries.");
                return; //leaves playRound entirely
            }
            else if (guess > secret)
            {
                Console.WriteLine("Too low.");
            }
            else
            {
                Console.WriteLine("Too High.");
            }
        }
        Console.WriteLine($"Out of tires! The number was {secret}.");
    }
}
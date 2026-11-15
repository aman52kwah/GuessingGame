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

    static int ReadInt(string prompt, int min , int max)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int value) && value >= min && value <= max)
            
                return value;
            Console.WriteLine($"Please enter a whole number from {min} to {max}. ");

        }
    }
    
}
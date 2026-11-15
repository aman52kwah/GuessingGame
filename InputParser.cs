

namespace GuessingGame;

// Turns raw text typed by user into a validated number

    public static class InputParser
    {
        
// returns true only when the text is a whole number between min and max
//leading and trailing spaces are ignored.

    public static bool TryParseGuess(string ? input, int min , int max, out int value)
    {
        value = 0;

        if(string.IsNullOrWhiteSpace(input))
        return false;

        if(!int.TryParse(input.Trim(), out int parsed))
        return false;

        if (parsed < min || parsed > max)
        {
            return false;
        }

        value = parsed;
        return true;
    }


    }

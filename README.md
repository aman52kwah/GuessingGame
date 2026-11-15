# GuessingGame

A console-based Number Guessing Game written in C#.

## Overview

The computer picks a secret number between 1 and 100, and you try to guess it. You get feedback after each guess ("Too High" or "Too Low") and have a limited number of tries to find the right number. After each round, you can choose to play again.

## Features

- Random secret number generation (1–100)
- 7 attempts per round
- High/Low feedback on every guess
- Tracks attempts used and attempts remaining
- Play-again loop — keep playing as many rounds as you like
- Input validation — rejects non-numeric and out-of-range entries

## Project Structure

| File | Purpose |
|------|---------|
| `Program.cs` | Console UI: welcome message, game loop, input reading, result display, play-again prompt |
| `GameSession.cs` | Core game logic: `GameSession` class, `GuessResult` enum, guess evaluation |
| `InputParser.cs` | Input validation: parses and validates user-entered guesses |
| `GuessingGame.csproj` | .NET project configuration |
| `GuessingGame.Tests/GameSessionTests.cs` | xUnit tests for `GameSession` (8 tests) |
| `GuessingGame.Tests/InputParserTests.cs` | xUnit tests for `InputParser` (8 tests) |
| `GuessingGame.Tests/GuessingGame.Tests.csproj` | Test project configuration |

## Classes

### `GameSession`

Manages a single round of the game.

**Constructor:**
```csharp
public GameSession(int secret, int maxTries)
```

**Properties:**
- `Secret` — the secret number (read-only after construction)
- `MaxTries` — maximum number of attempts allowed
- `AttemptUsed` — number of guesses made so far
- `IsWon` — whether the player has guessed correctly
- `AttemptsRemaining` — tries left (`MaxTries - AttemptUsed`)
- `IsOver` — whether the round is finished (won or out of tries)

**Method:**
```csharp
public GuessResult Guess(int guess)
```
Submits a guess, consumes one attempt, and returns `TooLow`, `TooHigh`, or `Correct`. Throws `InvalidOperationException` if the round is already over.

### `GuessResult`

Enum describing the outcome of a guess:
- `TooLow` — guess is below the secret number
- `TooHigh` — guess is above the secret number
- `Correct` — guess matches the secret number

### `InputParser`

Static helper for validating user input.

**Method:**
```csharp
public static bool TryParseGuess(string? input, int min, int max, out int value)
```
Returns `true` if `input` is a whole number within `[min, max]`; otherwise `false`. Leading/trailing whitespace is ignored.

## Requirements

- [.NET SDK](https://dotnet.microsoft.com/download) (targets `net10.0`)

## Build & Run

```bash
# Build the project
dotnet build

# Run the game
dotnet run
```

## Testing

The project includes 16 xUnit tests covering `GameSession` and `InputParser`. All tests pass.

```bash
# Run from the GuessingGame directory
dotnet test GuessingGame.Tests/GuessingGame.Tests.csproj

# Or from inside the test project directory
cd GuessingGame.Tests
dotnet test
```

**Test results:** 16 passed, 0 failed.

## Example Session

```
===== Welcome to Number Guessing Game ===

I'm thinking of a number from 1 to 100. You have 7 tries. 
Attempt 1/7: 
50
Too High. 6 tries left.
Attempt 2/7: 
25
Too Low. 5 tries left.
Attempt 3/7: 
37
Correct! you got it in 3 tries.
Play again? (y/n): n
Thank you for playing
```

## License

This project is provided as-is for learning and educational purposes.

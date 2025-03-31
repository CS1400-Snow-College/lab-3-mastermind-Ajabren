// See https://aka.ms/new-console-template for more information
using System;

class GuessingGame
{
    static void Main()
    {
        Console.Clear();
        Console.WriteLine("Hello, World!");

        Random rand = new Random();  // Random number generator
        
        // Generates a random 4-character word between letters 'a' and 'g'
        string secret = "";
        while (secret.Length < 4)
        {
            char attemp = (char)rand.Next(97, 104); // Generates a random letter between 'a' and 'g' (ASCII 97 to 103)
            
            // Ensure no repeating letters in the secret word
            if (!secret.Contains(attemp))
            {
                secret += attemp;
            }
        }

        // Game loop
        int guessCount = 1;
        string guess;
        while (true)
        {
            // Prompt user for a guess
            Console.WriteLine($"Guess #{guessCount}: Please guess a sequence of 4 lowercase letters with no repeats.");
            guess = Console.ReadLine().ToLower();  // Get the guess from the player

            // Validate input (make sure it’s exactly 4 letters, lowercase, and no repeats)
            if (guess.Length != 4 || guess[0] < 'a' || guess[0] > 'g' || guess[1] < 'a' || guess[1] > 'g' ||
                guess[2] < 'a' || guess[2] > 'g' || guess[3] < 'a' || guess[3] > 'g')
            {
                Console.WriteLine("Invalid guess. Make sure your guess is 4 lowercase letters with no repeats.");
                continue;
            }

            // Check for duplicates
            bool hasDuplicates = false;
            for (int i = 0; i < guess.Length; i++)
            {
                for (int j = i + 1; j < guess.Length; j++)
                {
                    if (guess[i] == guess[j])
                    {
                        hasDuplicates = true;
                        break;
                    }
                }
                if (hasDuplicates) break;
            }

            if (hasDuplicates)
            {
                Console.WriteLine("Invalid guess. Make sure there are no repeating letters.");
                continue;
            }

            // Check the guess and provide feedback
            int correctPositions = 0;
            int wrongPositions = 0;
            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == secret[i])
                {
                    correctPositions++;  // Letter in the correct position
                }
                else if (secret.Contains(guess[i]))
                {
                    wrongPositions++;  // Letter in the wrong position
                }
            }

            // Output feedback
            Console.WriteLine($"{correctPositions} in the right positions");
            Console.WriteLine($"{wrongPositions} in the wrong positions");

            // Check if the guess is correct
            if (guess == secret)
            {
                Console.WriteLine($"You did it! You guessed my secret ({secret}) in {guessCount} guesses.");
                break;  // Exit the loop if the guess is correct
            }

            guessCount++;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGuess
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string[] secretWords = { "AIRPLANE", "HAMBURGER", "GIRAFFE", "TELEVISION", "HUNGARY" };
            Random random = new Random();
            string secretWord = secretWords[random.Next(secretWords.Length)];
            char[] printArray = new char[secretWord.Length];
            string printString = "";
            int lives = 5;

            for (int i = 0; i < secretWord.Length; i++)
            {
                printArray[i] += '*';
            }


            Console.WriteLine("Welcome to Word Guesser!");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"Your secret word has {secretWord.Length.ToString()} characters. Every asterisk represents a letter: ");
            Console.WriteLine(String.Concat(printArray));
            Console.WriteLine();

            while (printString != secretWord)
            {
                Console.WriteLine($"Number of remaining lives: {lives}");
                Console.WriteLine();
                Console.WriteLine("Guess a letter: ");
                string letterGuess = Console.ReadLine();
                Console.WriteLine();

                bool guessTest = letterGuess.All(Char.IsLetter);
                while (guessTest == false || letterGuess.Length != 1)
                {
                    Console.WriteLine("Please enter one letter!");
                    Console.Write("Guess a letter: ");
                    letterGuess = Console.ReadLine();

                }

                char letterChar = Convert.ToChar(letterGuess.ToUpper());

                if (!secretWord.Contains(letterChar))
                {
                    Console.WriteLine($"There is no {letterChar} letter in the word.");
                    Console.WriteLine();
                    lives--;
                    if (lives == 0)
                    {
                        break;
                    }
                }
                else if (printArray.Contains(letterChar))
                {
                    Console.WriteLine($"The word already contains the letter {letterChar}");
                }
                else
                {
                    for (int i = 0; i < secretWord.Length; i++)
                    {
                        if (secretWord[i] == letterChar)
                        {
                            printArray[i] = letterChar;
                            printString = String.Concat(printArray);
                            
                        }

                    }
                    Console.WriteLine("Letter found!");
                    Console.WriteLine(printString);
                    Console.WriteLine();
                }
            }


            if (lives == 0)
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("GAME OVER!!!!!!");
                Console.WriteLine("----------------------------");

            }
            else if (printString == secretWord)
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("YOU WON!!!!!!");
                Console.WriteLine("----------------------------");
            }

            Console.ReadLine();

        }
    }
}

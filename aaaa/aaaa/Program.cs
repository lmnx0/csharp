using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaaa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 11);
            int tries = 0;
            bool guessedCorrectly = false;

            while (!guessedCorrectly && tries < 5)
            {
                Console.Write($"Enter a number (Tries left: {5 - tries}): ");
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    if (number == randomNumber)
                    {
                        Console.WriteLine("You are correct!");
                        guessedCorrectly = true;
                    }
                    else if (number < randomNumber)
                    {
                        Console.WriteLine("Try a higher number.");
                    }
                    else
                    {
                        Console.WriteLine("Try a lower number.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                tries++;
            }

            if (!guessedCorrectly)
            {
                Console.WriteLine($"You've reached the maximum number of tries. The correct number was {randomNumber}.");
            }
        }
    }
}

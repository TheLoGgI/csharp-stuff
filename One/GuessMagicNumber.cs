using System.Runtime.CompilerServices;

namespace One;

public class GuessMagicNumber : IMagicNumber
{
    public static int MagicNumber()
    {
        var rand = new Random();
        return rand.Next(0, 100);
    }

    public static int Guess()
    {
        var rand = new Random();

        var magicNumber = rand.Next(0, 100);
        var magicNumberGuess = -1;
        var round = 0;
        bool guessIsNumber = true;

        while (magicNumber != magicNumberGuess)
        {
            if (round > 0 && guessIsNumber) Console.WriteLine("Try agian");
            Console.WriteLine("Guess a magic number, between 0 and 100");
            round++;
            guessIsNumber = true;
            try
            {
                var guess = Console.ReadLine();
                if (guess != null) magicNumberGuess = int.Parse(guess);
        
                if (magicNumberGuess == magicNumber)
                {
                    Console.WriteLine("Congrats, you guested correct");
                } else if (magicNumberGuess > magicNumber)
                {
                    Console.WriteLine("Your guess is higher then the magic number and is " + Math.Abs(magicNumberGuess - magicNumber) + " from the correct number");
                }
                else
                {
                    Console.WriteLine("Your guess is lower then the magic number and is " + Math.Abs(magicNumberGuess - magicNumber) + " from the correct number");
                }
            }
            catch(Exception)
            {
                guessIsNumber = false;
                Console.WriteLine("Guess was not a number, try again.");
            }
            
        }
        
        return magicNumber;
    }
    
   
}
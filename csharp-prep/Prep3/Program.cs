using System;

class Program
{
    static void Main(string[] args)
    {        
        Random magicalNumber = new Random();
        int randomNumber = magicalNumber.Next(1,100);
        int number;
        string guess;     
        
        while (true)
        {        
        Console.Write("What is your guess? ");
         guess = Console.ReadLine();
         number = int.Parse(guess);        
        
        if (number > randomNumber)
        {
            Console.WriteLine("Higer");
        }
        else if (number < randomNumber)
        {
            Console.WriteLine("Lower");
        }
        else 
        {
            Console.WriteLine("Very well you guessed it!!");
            break;
        }
        }


    }
}
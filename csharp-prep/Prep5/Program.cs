using System;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome(); 
        string name = PromptUserName();
        int number = PromptUserNumber();
        int squaNumber = SquareNumber(number);                
        DisplayResult(name , squaNumber);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string favoriteNumber = Console.ReadLine();
        int number = int.Parse(favoriteNumber);
        return number;
    }
    static int SquareNumber(int number)
    {
        int squareNumber = number * number;
        return squareNumber;
    }
    static void DisplayResult(string name, int squaNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaNumber}");        
    }

}
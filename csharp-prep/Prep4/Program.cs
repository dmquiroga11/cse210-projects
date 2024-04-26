using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int>numbers = new List<int>();
        int number;
        string nuewNumber;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while(true)

        {
        Console.Write("Enter number: ");
        string newNumber = Console.ReadLine();
        number = int.Parse(newNumber);

       

        if (number != 0)
        {
            numbers.Add(number);            
        } 
        else
        {
            int numbersum = numbers.Sum();
            Console.WriteLine($"The sum is: {numbersum}");

            double averageList = numbers.Average();
            Console.WriteLine($"The saverage is: {averageList}");

            int maxnumber = numbers.Max();
            Console.WriteLine($"The sum is: {maxnumber}");
            break;
        }     
        }
    }
}
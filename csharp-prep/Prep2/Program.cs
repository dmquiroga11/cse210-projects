using System;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage?: ");
        string gradePercentage = Console.ReadLine();
        int number = int.Parse(gradePercentage);
        string letter;

        if (number >= 90)
        {
            letter = "A";
        }
        else if (number >= 80)
        {
            letter = "B";          
        }
        else if (number >= 70)
        {
            letter = "C";            
        }
        else if (number >= 60)
        {
            letter = "D";
                    
        }
        else if (number < 60)
        {
            letter = "F";            
        }
        else
        {
            letter= "F";
        }

        Console.WriteLine($"Your calification is: {letter}");

        if (number >=70)
        {
            Console.WriteLine("Congratulation you just passed this course!");
        }
        else
        {
            Console.WriteLine("Your average is very low for to passed the course. Please we encourage to try again");
        }

    }
}
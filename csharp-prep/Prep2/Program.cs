using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage?: ");
        string gradePercentage = Console.ReadLine();
        int number = int.Parse(gradePercentage);

        if (number >= 90)
        {
            Console.WriteLine("Your letter calification is: A ");
        }
        else if (number >= 80)
        {
            Console.WriteLine("Your letter calification is: B ");           
        }
        else if (number >= 70)
        {
            Console.WriteLine(" Your letter calification is: C");            
        }
        else if (number >= 60)
        {
            Console.WriteLine(" Your letter calification is: D");            
        }
        else if (number < 60)
        {
            Console.WriteLine(" Your letter calification is: F");            
        }

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
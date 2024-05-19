using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        
        while (true)
        {
            Console.Clear();

            Console.WriteLine("Welcome to the Mindfulness program. Let's get started:");
            Console.WriteLine();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select an option from the menu: ");
            string option = Console.ReadLine();

            Console.Clear();

            Activity activity = new Activity();
           
            if (option == "1")            
            {
                activity.ShowDescription("Breathing", "This activity will help you relax by guiding you through slow inhales and exhales. Clear your mind and focus on your breath.");
                activity.Countdown(activity.GetDurationTime());                
                
                Activity.BreathingActivity breathingActivity = new Activity.BreathingActivity(30);
                breathingActivity.Run();                                                         
                              
                activity.endingMessage();
                  
            }
            else if (option == "2")
            {
                activity.ShowDescription("Reflecting", "This activity will help you reflect on moments in your life when you've shown strength and resilience. Recognize your power and how to use it in other aspects of your life.");
                activity.Countdown(activity.GetDurationTime());

                Activity.ListingActivity listactivity = new Activity.ListingActivity();
                listactivity.Run(30);  

                activity.endingMessage();
            }
            else if (option == "3")
            {
                activity.ShowDescription("Listing", "This activity will help you reflect on the good things in your life by listing as many positive aspects as you can in a certain area.");
                activity.Countdown(activity.GetDurationTime());

                Activity.ReflectingActivity reflectactivity = new Activity.ReflectingActivity();
                reflectactivity.Run();  

                activity.endingMessage();
            }
            else if (option == "4")
            {
                break;
            }
        }
    }
}

class Activity
{
    private string _activityName;
    private string _description;
    private int _durationTime;
    private int _startActivity;
    private int _endActivity;

    
    public string GetActivityName()
    {
        return _activityName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetDurationTime()
    {
        return _durationTime;
    }
    public int GetStartActivity()
    {
        return _startActivity;
    }
    public int GetEndActivity()
    {
        return _endActivity;
    }
    

    public void ShowDescription(string activityName, string description)//Starting message
    {
        _activityName = activityName;
        _description = description;

        Console.WriteLine($"Welcome to the {_activityName} Activity");
        Console.WriteLine();
        Console.WriteLine(_description); 
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session?: ");
        string seconds = Console.ReadLine();
        int durationTime = int.Parse(seconds);
        

        Console.Clear();
    }    

   public void Countdown(int totalDuration)
    {
        Console.WriteLine("Get ready...");
        showSpinner(1);       
        Console.WriteLine();

       Random random = new Random();
        int totalTime = 0;

        while (totalTime < totalDuration)
        {
             int _startActivity = random.Next(1, 6); 
             int _endActivity = random.Next(1, 6);    

            totalTime += _startActivity;
            totalTime += _endActivity;

            if (totalTime >= totalDuration)
            break;                         
        }
         
    }
    public void endingMessage()
    {
        Console.WriteLine();
        Thread.Sleep(2000);
        Console.WriteLine("Well done!!");
        Thread.Sleep(2000);
        Console.WriteLine($"You have completed another {GetDurationTime()} seconds of the {GetActivityName()} Activity");
        
    }

    public void showSpinner(int seconds)
    {
        List<string> animation = new List<string>();
        animation.Add("|");
        animation.Add("/");
        animation.Add("");
        animation.Add("-");
        animation.Add("\\");
        animation.Add("|");
        animation.Add("/");
        animation.Add("-");
        animation.Add("-");
        animation.Add("\\");

        foreach (string s in animation)
        {
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    
    public class BreathingActivity : Activity 
    { 
    public BreathingActivity(int totalDuration)
    {  
        int inhaleDuration = 3; 
        int exhaleDuration = 6; 

        int numIterations = totalDuration / (inhaleDuration + exhaleDuration);

    for (int x = 0; x < numIterations; x++)
    {
        Console.WriteLine($"Breathe in... {inhaleDuration} seconds");
        Thread.Sleep(inhaleDuration * 1000);

        Console.WriteLine($"Now Breathe out... {exhaleDuration} seconds");
        Thread.Sleep(exhaleDuration * 1000);
        Console.WriteLine();
    }
    }        
    public void Run()
    {
    } 
    }

    

    public class ListingActivity : Activity
    {
        private int _count;
        private List<string> _prompts;

        public int GetCount()
        {
        return _count;
        }
         public List<string> GetPrompts()
        {
         return _prompts;
        }      

        public List<string> GetListPrompts()
        {
         return _listprompts;
        }    
        private List<string> _listprompts;
    
        public ListingActivity() 
            {
                _listprompts = new List<string>
                {
                 "Think about a time when you stood up for someone else.",
                 "Think about a time when you did something really difficult.",
                 "Think about a time when you helped someone in need.",
                 "Think about a time when you did something truly selfless."                
                };
            }            

            public string GetRandomPrompt(Random random)
            {
                int index = random.Next(_listprompts.Count); 
                return _listprompts[index];
            }
        
        public void Run(int durationInSeconds)
        {
             ListingActivity activity = new ListingActivity();
             string randomPrompt1 = activity.GetRandomPrompt(new Random());
             Console.WriteLine("Consider the following prompt:");
             Console.WriteLine($"---{randomPrompt1}---");
             Console.WriteLine("When you have something in mind, press ENTER to continue.");
             Console.ReadLine();

             Console.WriteLine("Now ponder on each of the following questions as they related with this experience.");
             Console.Write("You may begin in  ");
             for (int i =3; i>0;i--)
             {
                Console.Write(i);
                Thread.Sleep(1000);
                 Console.Write("\b \b");
             }
             Console.Clear();

            Random random2 = new Random();
            DateTime endTime = DateTime.Now.AddSeconds(durationInSeconds);      
    
            Console.WriteLine("What is your favorite thing about this experience?");
            Thread.Sleep(8000);

            Console.WriteLine("What did you learn about yourself through this experience?");
            Thread.Sleep(6000);
            Console.WriteLine();
        

       List<string> GetListFromUser()
       {
        return new List<string>();
       }
    }
    } 


    public class ReflectingActivity : Activity
      {
        private List<string>_prompts;
        private List<string>_questions;

        public ReflectingActivity()
        {
            _prompts = new List<string>
            {
                
            };
            _questions = new List<string>
           {
            "Who are people that you appreciate?", 
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?", 
            "When have you felt the Holy Ghost this month",            
           };
        }

        public void Run()
        {
            
          Console.WriteLine("List as many responses as you can to the following prompt:");
          Console.WriteLine($"---{GetRandomQuestion()}---");

          Console.Write($"You may begin in {GetDurationTime()} seconds. ");
         for (int i = GetDurationTime(); i > 0; i--)
         {
             Console.Write(i);
             Thread.Sleep(1000);
             Console.Write("\b \b");
         }
           Console.WriteLine();

          int itemCount = 0;

          DateTime endTime = DateTime.Now.AddSeconds(30);
          while (DateTime.Now < endTime)
         {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(item))
             continue; 
             _prompts.Add(item);
            itemCount++;
         }
         
         Console.WriteLine($"You listed {itemCount} items.");            
        }

        public string GetRandomPrompt()
        {
            Random random = new Random();
            int index = random.Next(_prompts.Count);
            return _prompts[index];
        }

        public string GetRandomQuestion()
        {
            Random random = new Random();
            int index = random.Next(_questions.Count);
            return _questions[index];
        }

        public void DisplayPrompt()
        {
            Random random = new Random();
            string randomPrompt = GetRandomPrompt();
            Console.WriteLine(randomPrompt);
        }

        public void DisplayQuestions()
        {
            foreach (string question in _questions)
            {
                Console.WriteLine(question);
            }
        }
    } 
}
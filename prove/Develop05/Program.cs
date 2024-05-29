using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Collections.Specialized;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.XPath;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.start();                 
    }
}

 public abstract class Goal
{
    protected string _shortName;
    protected string _description;
	protected string _points;
  
    

    public string GetShortName()
    {
        return _shortName;
    }
    public string GetPoints()
    {
        return _points;
    }    

   
public string GetDescription()
    {
        return _description;
    }

    public Goal(string name, string description,string points)
    {       
        _shortName = name;
	    _description = description;
	    _points = points;
        
	}


    public abstract void  RecordEvent();
    public  abstract bool IsComplete();
    
    public virtual string GetDetailsString()
    {        
        return $"[ ] {GetShortName()} {GetDescription()} ";
    }
    public  virtual string GetStringRepresentation()
    {
        return $"{ GetShortName()},{GetDescription()},{GetPoints()}";
    }
    
}



 class GoalManager
{
    public List<string> Goals = new List<string>();    
    int _score;
    bool _isComplete;
    public List<string> SimpleDetails = new List<string>();
    public List<string> EternalDetails = new List<string>();
    public List<string> CheckDetails = new List<string>();
    

    public GoalManager()
    {
        Goals = new List<string>{};       
        _score = 0; 
        _isComplete = false;              
    }    
    public void start()
    {       
        Console.Clear();
        while (true)
        {             
            Console.WriteLine($"You have {_score} points");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choise from the menu: ");
            string option = Console.ReadLine();    
           
            if (option == "1")            
            {                
                CreateGoal();                                
            }
            else if (option == "2")
            {
                Console.WriteLine("The goals are: ");
                for (int i = 0; i < Goals.Count; i++)
                {
                  Console.WriteLine($"{i + 1}. {Goals[i]}");                              
                }           
                
            }
            else if (option == "3")
            {                         
                SaveGoals();                                                            
            }
            else if (option == "4")
            { 
                LoadGoals();        
            }
            else if (option == "5")
            {
                RecordEvent();
                
            }
            else if (option == "6")
            {
                break;
            }
            else
            {  
                Console.WriteLine("PLEASE WRITE A CORRECT OPTION!");              
            } 
        }           
    } 
    
       
    public string ListGoalDetails()
    {
        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>
        {
            {"SimpleDetails", SimpleDetails},
            {"EternalDetails", EternalDetails},
            {"CheckDetails", CheckDetails},            
        };

        string result =" " ;
        
        foreach (var item in dict)
        {
             if (item.Value.Count >= 4)
             {
            result += string.Format("{0}: {1}, ({2}), {3} \n", item.Value[0], item.Value[1], item.Value[2], item.Value[3]);
             }
        }
  
        return result;        
    }

    public void CreateGoal()
    {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Wich type of goal would you like to create: ");
            string _typegoal = Console.ReadLine();                     

            if (_typegoal == "1")
            {
                _typegoal = "Simple Goal";
                SimpleDetails.Add(_typegoal);

                Console.Write("What is the name of your goal?: ");
                string simplename = Console.ReadLine();
                SimpleDetails.Add(simplename);      
                 
                Console.Write("What is a short description of it?: ");
                string simpledescription = Console.ReadLine();
                SimpleDetails.Add(simpledescription);

                Console.Write("What is the amount of points associate with this goal?: ");
                string simplegoalpoints = Console.ReadLine();
                SimpleDetails.Add(simplegoalpoints);

                SimpleGoal newgoal = new SimpleGoal(simplename, simpledescription,simplegoalpoints);
                newgoal.IsComplete();
                string goalnew = newgoal.GetStringRepresentation();                
                Goals.Add(goalnew);
                start();
            }
            else if (_typegoal == "2")
            {
                _typegoal = "Eternal Goal";
                EternalDetails.Add(_typegoal);

                Console.Write("What is the name of your goal?: ");
                string eternalname = Console.ReadLine(); 
                EternalDetails.Add(eternalname); 

                Console.Write("What is a short description of it?: ");
                string eternaldescription = Console.ReadLine();
                EternalDetails.Add(eternaldescription);

                Console.Write("What is the amount of points associate with this goal?: ");
                string eternalgoalpoints = Console.ReadLine();
                EternalDetails.Add(eternalgoalpoints);

                EternalGoal newgoal2 = new EternalGoal (eternalname, eternaldescription,eternalgoalpoints);
                newgoal2.IsComplete();
                string goalnew2 = newgoal2.GetStringRepresentation();                
                Goals.Add(goalnew2);
                start();
            }
            else if (_typegoal == "3")
            {
                _typegoal = "Checklist Goal";
                CheckDetails.Add(_typegoal);

                Console.Write("What is the name of your goal?: ");
                string checkname = Console.ReadLine(); 
                CheckDetails.Add(checkname);

                Console.Write("What is a short description of it?: ");
                string checkdescription = Console.ReadLine();
                CheckDetails.Add(checkdescription);  

                Console.Write("What is the amount of points associate with this goal?: ");
                string checkgoalpoints = Console.ReadLine();
                CheckDetails.Add(checkgoalpoints);

                Console.Write("How many times does this goal need to be accomplished?: ");
                string checktarget = Console.ReadLine();
                int checkinttarget = int.Parse(checktarget);
                CheckDetails.Add(checktarget);
                

                Console.Write("What is the bonus for accomplishing it that many times?: ");
                string bonus = Console.ReadLine();
                int checkintbonus = int.Parse(bonus);
                CheckDetails.Add(bonus);

                ChecklistGoal newgoal3 = new ChecklistGoal(checkname, checkdescription,checkgoalpoints,checkinttarget, checkintbonus );
                newgoal3.IsComplete();
                string goalnew3 = newgoal3.GetStringRepresentation();
                Goals.Add(goalnew3);
                start();
            }
            else
            {  
                Console.WriteLine("PLEASE WRITE A CORRECT OPTION!");              
            } 
        }
    public void RecordEvent() 
    { 
        Console.Write("Wich goal did you acomplish?: ");
        string typegoal =Console.ReadLine();

        if (typegoal == "1")
        { 
            Console.WriteLine($"¡Congratulation! you win {SimpleDetails[3]} points.");
            int simpledetails = int.Parse(SimpleDetails[3]);
            _score += simpledetails;
        }

        else if (typegoal == "2")
        {
            Console.WriteLine($"¡Congratulation! you win {EternalDetails[3]}  points.");
            int eternaldetails = int.Parse(EternalDetails[3]);
             _score += eternaldetails;
        } 

         else if(typegoal == "3")
         {
            Console.WriteLine($"¡Congratulation! you win {CheckDetails[3]}  points.");
            int checkdetails = int.Parse(CheckDetails[3]);
            _score += checkdetails;
         } 
    }       
     public void SaveGoals()
     {        
        Console.Write("What is the filename for the goal fiel?: ");
         string filename = Console.ReadLine();       
 
        using (StreamWriter sw = new StreamWriter(filename))
        {
          sw.WriteLine ($"{_score}");                                 
          sw.WriteLine ($"{ListGoalDetails()}");
                             
         } 
        Console.WriteLine($"The goals are saved in the filename: {filename}.");
     }
    public void LoadGoals()
    { 
         Console.Write("What is the file for the goal file?: ");
         string filename = Console.ReadLine();

         using (StreamReader sr = new StreamReader(filename))
         {
            string score = sr.ReadLine();
            Console.WriteLine($"You score is: {score}");

            string line;
            while ((line = sr.ReadLine()) != null)
            {
              Console.WriteLine($"{line}");
            }
         }
    
    }
}
class SimpleGoal:Goal
{
    bool _isComplete;
    public SimpleGoal(string name, string description, string points) : base(name,description,points) 
    { 
        _isComplete = false;
    }    

    public override void RecordEvent()
    {
        _isComplete = true;
    }
    public override bool IsComplete()
    {
        return _isComplete;
    }
    public override string GetStringRepresentation()
    {
       
         return $"[ ] {GetShortName()} ({GetDescription()})";
    }    
}
class EternalGoal : Goal 
{
    public EternalGoal(string name, string description, string points) : base(name,description,points) {}
    public override void RecordEvent(){}
    public override bool IsComplete()
    {
        return true;
    }
    public override string GetStringRepresentation()
    {
        
        return $"[ ] {GetShortName()} ({GetDescription()})";
    }

}
class ChecklistGoal : Goal
{
     int _amountComplete;
     int _target;
     int _bonus;

     public ChecklistGoal(string name, string description, string points, int target, int bonus):base (name,description,points)
     {
        _amountComplete = 0;
        _target = target;
        _bonus = bonus;
     }

    public override void RecordEvent()
    {
        _amountComplete++;
    }
    public  override bool IsComplete()
    {
        return _amountComplete >= _target;
    }
    public override string GetDetailsString()
    {
        return $" {_amountComplete}/{_target} ";
    }
    public override string GetStringRepresentation()
    {      
         return $"[ ] {GetShortName()} ({GetDescription()}) --- Currently completed: {GetDetailsString()}";
    }
}
























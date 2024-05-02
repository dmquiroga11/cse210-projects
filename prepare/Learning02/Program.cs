using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1 ._jobTitle = " Sofware Enginer";
        job1 ._companyName = " (Microsoft)";
        job1 ._startYear = 2023;
        job1 ._endYear = 2024;

        Job job2 = new Job();
        job2 ._jobTitle = " Manager";
        job2 ._companyName= " (Apple)";
        job2 ._startYear = 2023;
        job2 ._endYear = 2024;
        

        //job1.DisplayJobDetails();
        //job2.DisplayJobDetails();

        Resume person1 = new Resume();
        person1 ._personName = "Alison Rose";
        Resume._listOfJobs.Add(job1); 
        Resume._listOfJobs.Add(job2);

        person1.DisplayResumeDetails();
   
    }

    
    public class Job
    {
        public string _jobTitle = "";
        public  string _companyName ="";
        public int _startYear;
        public int _endYear; 

        public  void DisplayJobDetails()
        {
            Console.WriteLine($"{_jobTitle} {_companyName} {_startYear} - {_endYear}");            
        }
    }

    public class Resume
    {
        public string _personName;        
        public static List<Job> _listOfJobs = new List<Job>(); 

        public  void DisplayResumeDetails() 
        {
            Console.WriteLine($"Name: {_personName}");
            Console.WriteLine("Jobs:");
            
            foreach (Job job in Resume._listOfJobs)
            {
               job.DisplayJobDetails();
            } 
        }                 
    }

}



 
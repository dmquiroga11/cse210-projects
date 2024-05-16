using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Assignment workhome = new Assignment("Diana Mera" , "Matematic" );
        string generalwork = workhome.GetSummary();
        Console.WriteLine(generalwork);

        MathAssignment mathwork = new MathAssignment( "Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(mathwork.GetSummary());
        Console.WriteLine(mathwork.GetHomeworkList());

        WritingAssignment writework = new WritingAssignment("The Causes of World War II by Mary Waters","Mary Waters", "European History" );
        Console.WriteLine(writework.GetSummary());
        string writing = writework.GetWritingInformation();
        Console.WriteLine(writing);

    }

    class Assignment
    {
       private string _studentName;
       private string _topic;

       public Assignment(string studentName , string topic)
       {
        _studentName = studentName;
        _topic = topic;
       }

       public string GetStudentName()
    {
        return _studentName;
    }

    public string GetTopic()
    {
        return _topic;
    }

       public string GetSummary()
       {
        return _studentName +" - "+ _topic; 

       }
    }

     class  MathAssignment : Assignment
    {
        private string _textbookSection;
        private string _problems;

        public MathAssignment(string studentName, string topic, string textbookSection, string problems): base(studentName, topic)
        {
            _textbookSection = textbookSection;
            _problems = problems;
        }
        public string  GetHomeworkList()
        {
            return $"{_textbookSection} Problems {_problems}";
        }

    }

    class WritingAssignment : Assignment
    {
         private string _title;

         public WritingAssignment(string title, string studentName, String topic): base(studentName, topic)
        {
            _title = title;            
        }
        public string GetWritingInformation()
        {
            string studentName = GetStudentName();
            return $"{_title} by {studentName}" ;
        }


    }
}
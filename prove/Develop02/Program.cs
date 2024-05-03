using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1.Write an entry:");
            Console.WriteLine("2. Display the journal:");
            Console.WriteLine("3. Load the journal: ");
            Console.WriteLine("4. Save the journal: ");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();
            
            if(option == "1")
            {
                 string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    Entry newEntry = new Entry
                    {
                        _Date = DateTime.Now.ToString(),
                        _PromptText = prompt,
                        _EntryText = response
                    };

                    journal.AddEntry(newEntry);                   
            }

            else if (option == "2")
            {
                journal.Display();
            }

            else if (option =="3")
            {
                Console.Write("What is the filename: ");
                string loadFilename = Console.ReadLine();
                journal.LoadFromFile(loadFilename);
                Console.WriteLine("Loading the file...");
                
            }

            else if (option == "4")
            {
                Console.Write("Enter the filename: ");
                string saveFilename = Console.ReadLine();
                journal.SaveToFile(saveFilename);
                Console.WriteLine("Saving the file...");                
            }

            else if (option == "5")
            {
                exit = true;
            }

            else
            {
                Console.WriteLine("Please try again.This option does not exist");
                    break;               
                
            }
        }
    }
}

public class Journal
{
    public List<Entry> Entries;

    public Journal()
    {
        Entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        Entries.Add(newEntry);
    }

    public void Display()
    {
        foreach (var entry in Entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (var entry  in Entries)
            {
                sw.WriteLine($"{entry._Date}~{entry._PromptText}~{entry._EntryText}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        Entries.Clear();
        using (StreamReader sr = new StreamReader(filename))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                Entry entry = new Entry
                {
                    _Date = parts[0],
                    _PromptText = parts[1],
                    _EntryText = parts[2]
                };
                Entries.Add(entry);
            }
        }
    }
}

public class Entry
{
    public string _Date;
    public string _PromptText;
    public string _EntryText;

    public void Display()
    {
        Console.WriteLine($"Date: {_Date}");
        Console.WriteLine($"Prompt: {_PromptText}");
        Console.WriteLine($"Entry: {_EntryText}");
        Console.WriteLine();
    }
}

public  class PromptGenerator
{
    public List<string> Prompts;

    public PromptGenerator()
    {
        Prompts = new List<string>
        { 
            "Have you seen God's help in your life today, how?: ",
            "Which was the activity more important of your day?:",
            "What did your learn in your study of scriptures today?: ",
            "How do you feel that you fulfilled your agreements with God today?:" 
        };
    }

    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(Prompts.Count);
        return Prompts[index];
    }
}
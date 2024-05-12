using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
       Reference reference = new Reference("2 Nephi", 31, 11);
       string verseText = "And the Father said: Repent ye, repent ye, and be baptized in the name of my Beloved Son.";
        Scripture scripture = new Scripture(reference, verseText);


        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());            
            Console.WriteLine("\nPress Enter to hide a word or type 'exit' to end the program.");
            string input = Console.ReadLine();
            if (input.ToLower() == "exit")
            {
                break;
            }
            else
            {
                scripture.HideRandomWords(6);
            }
        }
        Console.Clear();
        Console.WriteLine("All the words are hidden. The program has ended.");
    }
}

class Scripture
{
    private Reference _reference;
    private List<Words> _words;

    public Scripture(Reference reference, string verse)
    {
        _reference = reference;
        _words = new List<Words>();
        foreach (string word in verse.Split(' '))
        {
            _words.Add(new Words(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random randomGenerator = new Random();
        for (int i = 0; i < numberToHide; i++)
        {
            int index = randomGenerator.Next(_words.Count);
            _words[index].Hide();
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + "\n";
        foreach (Words word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText;
    }

    public bool IsCompletelyHidden()
    {
        foreach (Words word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}

class Words
{
    private string _text;
    private bool _isHidden;

    public Words(string word)
    {
        _text = word;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new String('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}

class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = -1;
    }

    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_endVerse == -1)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine();
        Console.WriteLine("Description Event # 1:");
        Console.WriteLine();
        Lecture lecture = new Lecture("Conference title", "Conference description", DateTime.Now, "10:00 AM", new Address("street 25 N", "City", "State", "Postal Code"), "Speaker Name", 20);
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine(lecture.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Description Event # 2:");
        Console.WriteLine();
        Reception reception = new Reception("Reception Title", "Reception Description", DateTime.Now, "2:00 PM", new Address("Street 70 ", "City", "State", "Postal Code"), "eleggua_11@hotmail.com.com");
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine(reception.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Description Event # 3:");
        Console.WriteLine();
        Outdoor outdoor = new Outdoor("Outdoor Meeting Title", "Outdoor Meeting Description", DateTime.Now, "5:00 PM", new Address("Street 211", "City", "State", "Postal Code"), "Rainy");
        Console.WriteLine(outdoor.GetStandardDetails());
        Console.WriteLine(outdoor.GetFullDetails());
        Console.WriteLine(outdoor.GetShortDescription());
        Console.WriteLine();
    }
}

public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _postal;

    public Address(string street, string city, string state, string postal)
    {
        _street = street;
        _city = city;
        _state = state;
        _postal = postal;
    }

    public override string ToString()
    {
        return $"{_street}, {_city}, {_state}, {_postal}";
    }
}

public abstract class Event
{
    protected string _title;
    private string _description;
    protected DateTime _date;
    private string _time;
    private Address _address;

    public Event(string title, string description, DateTime date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    public string GetStandardDetails()
    {
        return $"{_title}\n{_description}\n{_date.ToString("d")}\n{_time}\n{_address.ToString()}";
    }

    public abstract string GetFullDetails();
    public abstract string GetShortDescription();
}

public class Lecture : Event
{
    private string _speaker;
    private int _capacity;

    public Lecture(string title, string description, DateTime date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\n Event Type: Conference\n Speaker: {_speaker}\n Capacity: {_capacity}";
    }

    public override string GetShortDescription()
    {
        return $"Conference: {_title} in {_date.ToString("d")}";
    }
}

public class Reception : Event
{
    private string _rsvpEmail;

    public Reception(string title, string description, DateTime date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        _rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\n Event Type : Reception\n Email for RSVP: {_rsvpEmail}";
    }

    public override string GetShortDescription()
    {
        return $"Reception: {_title} in {_date.ToString("d")}";
    }
}

public class Outdoor : Event
{
    private string _weatherForecast;

    public Outdoor(string title, string description, DateTime date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        _weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\n Event Type: Outdoor meeting \n Weather forecast: {_weatherForecast}";
    }

    public override string GetShortDescription()
    {
        return $"Outdoor meeting: {_title} in {_date.ToString("d")}";
    }
}


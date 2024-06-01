using System;

class Program
{
    static void Main()
    {
        var activities = new Activity[]
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 3), 30, 9.7),
            new Swimming(new DateTime(2022, 11, 3), 30, 60)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}



class Activity
{
    private DateTime _date;
    protected int _durationMinutes;

    public Activity(DateTime date, int durationMinutes)
    {
        _date = date;
        _durationMinutes = durationMinutes;
    }

    public virtual double GetDistance()
    {
        return 0; 
    }

    public virtual double GetSpeed()
    {
        return 0; 
    }

    public virtual double GetPace()
    {
        return 0; 
    }

    public string GetSummary()
    {
        return $"{_date.ToShortDateString()} {GetType().Name} ({_durationMinutes} min): " +
               $"Distance {GetDistance():F1} km, Speed {GetSpeed():F1} km/h, Pace: {GetPace():F2} min/km";
    }
}

class Running : Activity
{
    private double _distanceKm;

    public Running(DateTime date, int durationMinutes, double distanceKm)
        : base(date, durationMinutes)
    {
        _distanceKm = distanceKm;
    }

    public override double GetDistance()
    {
        return _distanceKm;
    }

    public override double GetSpeed()
    {
        return _distanceKm / (_durationMinutes / 60.0);
    }

    public override double GetPace()
    {
        return _durationMinutes / _distanceKm;
    }
}

class Cycling : Activity
{
    private double _speedKph;

    public Cycling(DateTime date, int durationMinutes, double speedKph)
        : base(date, durationMinutes)
    {
        _speedKph = speedKph;
    }

    public override double GetSpeed()
    {
        return _speedKph;
    }

    public override double GetDistance()
    {
        return _speedKph * (_durationMinutes / 60.0);
    }

    public override double GetPace()
    {
        return 60.0 / _speedKph;
    }
}

class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int durationMinutes, int laps)
        : base(date, durationMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50.0 / 1000.0; 
    }

    public override double GetSpeed()
    {
        return GetDistance() / (_durationMinutes / 60.0);
    }

    public override double GetPace()
    {
        return _durationMinutes / GetDistance();
    }
}




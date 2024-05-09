using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Fraction one = new Fraction();
        Console.WriteLine(one.GetFraction());

        Fraction two = new Fraction(6);
        Console.WriteLine(two.GetFraction());  

        Fraction three = new Fraction(6,7);       
                
        three.SetTopNumber(3);
        three.SetBottomNumber(4);
        Console.WriteLine(three.GetFraction());
        Console.WriteLine(three.GetTopNumber());
        Console.WriteLine(three.GetBottomNumber());
        Console.WriteLine(three.GetFraction());
        Console.WriteLine(three.GetDecimalValue(3,4));


    }

    public class Fraction
    {
        private int _topNumber;
        private int  _bottomNumber;

        public int GetTopNumber()
        {
            return _topNumber;
        }
        public void SetTopNumber(int value)
        {
            _topNumber = value;
        }

        public int GetBottomNumber()
        {
            return _bottomNumber;
        }
        public void SetBottomNumber(int value)
        {
            _bottomNumber = value;
        }
        
        public  Fraction() // Constructor
        {          
           _bottomNumber = 1;
           _topNumber = 1;
        }

        public Fraction(int topNumber) //Constructor
        {
            _topNumber = topNumber;
            _bottomNumber = 1 ;
        }

        public string  GetFraction()
        {
            return _topNumber.ToString() + "/" + _bottomNumber.ToString();
        }       
    
        

        public  Fraction(int topNumber, int bottomNumber)//Constructor
        {
            _topNumber = topNumber;
            _bottomNumber = bottomNumber;
        }
        public string GetAnotherFraction(int _topNumber, int bottomNumber)
        {
            return  _topNumber.ToString()+ "/" + _bottomNumber.ToString();
        }

        public double GetDecimalValue(int _topNumber, int _bottomNumber)
        {
            return (double)_topNumber / _bottomNumber;
        }    


    }
}
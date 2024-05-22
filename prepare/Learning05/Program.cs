using System;
using System.Drawing;
using System.Formats.Asn1;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        Square figure1 = new Square("Blue", 2);
        /*Console.WriteLine(figure1.GetColor());
        Console.WriteLine(figure1.GetArea());*/

        Rectangle figure2 = new Rectangle ("Yellow",5,2);
        /*Console.WriteLine(figure2.GetColor());
        Console.WriteLine(figure2.GetArea());*/

        Circle figure3 = new Circle ("Green", 6);
        /*Console.WriteLine(figure3.GetColor());
        Console.WriteLine(figure3.GetArea());*/

        List<Shape> listfigures = new List<Shape>();
        listfigures.Add(figure1);
        listfigures.Add(figure2);
        listfigures.Add(figure3);

        foreach (Shape figure in listfigures)
        {
            string colorshape = figure.GetColor();
            double totarea = figure.GetArea();
            Console.WriteLine($"The color of the figure is {colorshape} and the area is {totarea}");
        }

    }
     public class Shape
    {
        private string _color;

        public Shape(string color)
        {
            _color = color;
        }

        public string GetColor()
        {
            return _color;
        }
        public void SetColor(string color)
        {
            _color = color;
        }
        public virtual double GetArea()
        {
            return  0;
        }

    }
     public class Square : Shape
    {
        private double _side;      

        public Square (string color, int side): base (color)
        {
            _side = side;
        }

        public override double GetArea()
        {
            double _area = _side *_side;
            return _area;
        }
    }
    class Rectangle: Shape
    {
        private double _length;
        private double _width;
        public Rectangle ( string color, double length, double width): base (color)
        {
            _length = length;
            _width = width;
        }

         public  override double GetArea()
         {
            double _area = _width * _length;
            return _area; 
         }
    }
    public class Circle: Shape
    {
        private double _radius;

        public Circle (string color , double radius) : base(color)
        {
            _radius = radius;         
        }       

         public override double GetArea()
         {
            double _area = Math.PI * (_radius * _radius);
            return _area;
         }
    }
}
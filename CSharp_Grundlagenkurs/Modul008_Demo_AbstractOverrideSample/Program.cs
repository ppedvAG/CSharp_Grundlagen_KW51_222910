using System.Data.SqlTypes;

namespace Modul008_Demo_AbstractOverrideSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Shape shape = new Shape();  -> Cannot create an instance of the abstract class or interface 'interface'

            Circle circle = new Circle(5);
            Console.WriteLine(circle.GetArea());

            Quatrat quatrat = new Quatrat(4, 5);
            Console.WriteLine(quatrat.GetArea());
        }
    }


    //Abstrakte Klassen sind Schablonen und können nicht als Objekt instanziiert werden.
    public abstract class Shape
    {
        public virtual double GetAreaWithVirtual()
        {
            //Minimale Implemtierung würde hier kein Sinn ergeben 
            return double.NaN;
        }

        public virtual string GetShapeInfo()
        {
            return $"Ist eine Shape";
        }


        //Abstrakte Methoden dürfen nur in abstrakten Klassen existieren und definieren nur
        ///eine Signatur. Die erbenden Klassen werden gezwungen eine Implementierung vorzunehmen
        public abstract double GetArea();
    }

    public class Quatrat : Shape
    {
        public Quatrat(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }   
        public double Y { get; set; }   

        public override double GetArea()
        {
            return X * Y;
        }
    }

    public class Circle : Shape
    {
        public double X { get; set; }

        public Circle(double x)
        {
            X = x;
        }

        public override double GetArea()
        {
            return Math.PI * X * X;
        }
    }
}
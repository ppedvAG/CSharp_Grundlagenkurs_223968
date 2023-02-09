using System.Runtime.CompilerServices;

namespace Modul008_Abstract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double flaecheAllerGeoFormen = 0;
            Quatrat q1 = new Quatrat(5, 4);
            Console.WriteLine(q1.ShapeOutput());
            flaecheAllerGeoFormen += q1.GetArea();

            Circle c1 = new Circle(12.5);
            Console.WriteLine(c1.ShapeOutput());
            flaecheAllerGeoFormen += c1.GetArea();

            Zylinder zylinder = new Zylinder(11.3, 5.6);
            flaecheAllerGeoFormen += zylinder.GetArea();

            Console.WriteLine(zylinder.ShapeOutput());

            Console.WriteLine($"Fläche alle Geoformen {flaecheAllerGeoFormen}");
        }
    }

    //Eine abstrakte Klasse ist eine Schablonme und kann nicht als Objekt instanziiert werden 
    public abstract class Shape
    {
        //Abstrakte Methoden dürfen nur in abstrakten Klassen existieren und definieren nur
        //eine Signatur.
        //Die erbenden Klassen werden gezwungen eine Implementierung vorzunehmen
        public abstract double GetArea(); //MUSS-IMPLEMENTIERUMG 

        public virtual string ShapeOutput()
        {
            EinePrivateMethode();
            return "Ist eine Shape";
        }

        private void EinePrivateMethode()
        {
            //Macht irgendwas
        }
    }

    public class Quatrat : Shape
    {
        public Quatrat(double x, double y)        {
            X = x;
            Y = y;

        }

        public double X { get; set; }
        public double Y { get; set; }


        public override double GetArea()
        {
            return X * Y;
        }

        public override string ShapeOutput()
        {
            return $"Ein Quatrat mit X={X} Y={Y} mit einer Fläche von {GetArea()}";
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


        public override string ShapeOutput()
        {
            return $"Ein Krteis mit X={X} mit einer Fläche von {GetArea()}";
        }
    }


    public class Zylinder : Shape
    {
        public double X { get; set; } 
        public double Hoehe { get; set; }

        public Zylinder(double x, double hoehe)
        {
            X = x;
            Hoehe = hoehe;
        }

        public override double GetArea()
        {
            return Math.PI * X * X * Hoehe * 4;
        }
    }





}
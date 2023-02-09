namespace Modul009_Polymorphie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Was ist eine Liste
            List<string> cityNames = new List<string>();
            cityNames.Add("Berlin");
            cityNames.Add("Wien");
            cityNames.Add("München");

            foreach (string cityName in cityNames)
            {
                Console.WriteLine(cityName);
            }

            List<string> otherListWithCities = new List<string>();
            otherListWithCities.AddRange(cityNames.ToArray()); //Fügen den Inhalt von der Liste cityNames in die Liste otherListWithCitites 
            #endregion

            #region Liste mit Integers
            List<int> intergerListe = new List<int>();
            intergerListe.Add(123);
            #endregion


            //Hier dürfen alle vererbten Klassen, die in der Vererbungshierachy von Shape sich befinden hinzugefügt werden 
            List<Shape> shapeListe = new List<Shape>();

            shapeListe.Add(new Quatrat(4, 5));
            shapeListe.Add(new Zylinder(5, 4));
            shapeListe.Add(new Circle(7));
            shapeListe.Add(new Circle(3));

            double areaOfAll = 0;
            foreach (Shape currentShape in shapeListe)
            {
                areaOfAll += currentShape.GetArea();
                Console.WriteLine(currentShape.ShapeOutput());
            }

            Console.WriteLine(areaOfAll);
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
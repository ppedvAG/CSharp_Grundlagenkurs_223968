using System.Security.Cryptography.X509Certificates;

namespace Modul003_Array_Conditions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Arrays 
            int[] zahlen = { 11, 22, 33, 44 };

            Console.WriteLine($"Wieviele Elemente hat das Array {zahlen.Length}?"); //4

            //Zugriff auf das Array 

            //via Index
            zahlen[0] = 12;
            zahlen[1] = 24;
            Console.WriteLine($"Ausgaben des ersten Elementes eines Arrays" + zahlen[0]);

            //Via Linq-Function -> using System.Linq 
            Console.WriteLine($"Ausgabe des ersten Elementes eines Arrays " + zahlen.First()); //Gebe das Erste Element in der Arrayaufzählung aus
            Console.WriteLine($"Ausgabe des ersten Elementes eines Arrays " + zahlen.Last());

            int summerAllerEinträge = zahlen.Sum();

            int gebeMirDieHoehsteZahlEinesArraysZurueck = zahlen.Max();
            int gebeMirDieKleinsteZahlEinesArrayZurueck = zahlen.Min();

            //Array-Deklaration ohne direkte Initialisierung der Positionen (Größe muss angegeben werden)
            string[] worte = new string[5];

            //Verwendung einer weiteren Funktion -> Contains. 
            //Containts überprüft, ob ein bestimmter Eintrag im Array schon vorhanden ist. 

            Console.WriteLine(zahlen.Contains(33));
            Console.WriteLine(zahlen.Contains(41));


            //Mehrdimensionales Array

            int[,] zweiDimArray = new int[3, 5];

            //x: 0, 1, 2
            for (int x = 0; x < 3; x++)
            {
                //0,1,2,3,4
                for (int y = 0; y < 5; y++)
                {
                    zweiDimArray[x, y] = x * y;
                }
            }

            #endregion

            #region If-Statement - Bedingung

            int a = 23;
            int b = 23;

            //IF-ELSEIF-ELSE-Block
            ///Das Programm wird den ersten Block ausführen, bei welchem er auf eine wahre Bedingung trifft und dann am Ende des Blocks mit
            ///dem Code weiter machen
            
            if (a < b)
            {
                Console.WriteLine("A ist kleiner als B");
                //... 
            }
            else if (b < a)
            {
                Console.WriteLine("B ist kleiner als A");
                //...
            }
            else
                Console.WriteLine("A ist gleich B");



            //Kurznotation 

            string ergebnis = (a == b) ? "A ist gleich B" : "A ist ungleich B";



            string name1 = "Hans";
            string name2 = "Hans";

            if (name1.Equals(name2))
            {
                Console.WriteLine("name1 und name2 sind gleich");
            }
            #endregion

            #region Operatoren
            //Modulo - Operator
            int zahl = 91;
            if (zahl % 2 == 0) //91 : 2 = Rest: 0? 
            {
                Console.WriteLine("Zahl ist durch 2 Teilbar");
            }
            #endregion
        }
    }
}
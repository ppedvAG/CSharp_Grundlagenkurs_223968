namespace Modul008_Virtual
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Artikel obst = new Artikel("O-12345", 2.99m, 0);

            Console.WriteLine(obst.ArtikelAusgabe());

            ElektroArtikel notebook = new ElektroArtikel("E-12345", 599, 5);
            Console.WriteLine(notebook.ArtikelAusgabe());


            BrettspielArtikel risikoBrettspiel = new BrettspielArtikel("M-12345", 20, 0);
            Console.WriteLine(risikoBrettspiel.ArtikelAusgabe());


            NETVirtualMethods myClass = new NETVirtualMethods();

            Console.WriteLine(myClass.ToString());
             
        }
    }


    public class Artikel
    {
        private decimal price { get; set; }
        
        
        
        public virtual string ArtikelNr { get; set; }

        public int Garantie { get; set; } = 0;

        public decimal Price
        {
            set
            {
                if (value > 0)
                    price = value;
                else
                    throw new Exception("Preis kann keinen negativen Wert annehmen");
            }

            get
            {
                return price;
            }
        }


        public Artikel(string artikelNr, decimal price, int garantie)
        {
            ArtikelNr = artikelNr;  
            Price = price;
            Garantie = garantie;
        }

        public virtual string ArtikelAusgabe()
        {
            return Garantie != 0 ? $"ArtikelNr {ArtikelNr} hat einen Preis von  {Price} und eine Garantie von {Garantie}" 
                                 : $"ArtikelNr: {ArtikelNr} hat eine Preis von {Price}";
        }

    }


    public class ElektroArtikel : Artikel
    {
        public ElektroArtikel(string artikelNr, decimal price, int garantie=2)
            :base(artikelNr, price, garantie) 
        {

        }

        //ArtikelNr soll dieses Format verwenden -> E-12345
        public override string ArtikelNr 
        {
            get
            {
                return base.ArtikelNr;
            }

            set
            {
                if (value.StartsWith("E-"))
                    base.ArtikelNr = value;
            }
        }

        public override string ArtikelAusgabe()
        {
            //Es ist auch Möglich ArtikelAusgabe von der Basis-Klasse mitzuverwenden und hier zu erweitern.
            //string artikelAusgabeVonBase = base.ArtikelAusgabe();

            return $"Elektro-Artikel: {ArtikelNr} hate eine Garantie von {Garantie} - (oder mindestens 2 Jahre) und kostet {Price}";
        }

    }


    public class SpielwarenArtikel : Artikel
    {
        public SpielwarenArtikel(string artikelNr, decimal price, int garantie = 2)
           : base(artikelNr, price, garantie)
        {

        }
    }

    public class BrettspielArtikel : SpielwarenArtikel
    {
        public BrettspielArtikel(string artikelNr, decimal price, int garantie = 2)
           : base(artikelNr, price, garantie)
        {

        }

        //Gibt es eine ArtikelAusgabe? Wenn nein, schaue ich eine Klasse weiter oben (Basísklasse = SpielwarenArtikel) 
    }

    //Die oberste Basisklasse alle KLASSEN ist die Klasse 'object' 
    public class NETVirtualMethods
    {
        public override string ToString()
        {
            return "Hallo liebe Teilnehmer";
        }
    }


}
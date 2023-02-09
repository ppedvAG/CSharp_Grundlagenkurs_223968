using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace Modul008_Vererbung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Adresse adresse = new Adresse("Im Leutchturm 1", "D-12345", "Friesland");
            Mensch mensch = new Mensch(new DateTime(1983, 5, 7), 80, "Sushi", 2, 4, "homosapien", "Milch", "Otto", "Walkes", adresse);
           
        }
    }


    public class Human
    {
        

        [Required]
        public string Url { get; set; }

        [Range(0.1, 2)]
        public int Hoehe { get; set; }
     }

    public class Lebewesen
    {
        #region Member Variablen
        //C++ Member-Variable oder Klassen-Variable
        //Andere Begriffe: Felder / Field / Backfield
        private DateTime _geburtstag;
        private double _gewicht;
        private string _lieblingsnahrung;
        private double _breite;
        private double _hoehe;

        private string _secret = "123";

        private string farbe;
        #endregion

        #region Konstruktor

        //Es können mehrere Konstruktoren definiert werden, welche unterschiedliche Übergabeparameter haben (Überladung).
        //Ein Konstruktor, der keineÜbergabeparameter hat, wird als Default-Konstruktor bezeichnet
        public Lebewesen()
        {
            //Hinterlegen von Default-Werten
            //Wir sprechen immer die Properties an, weil wir die Möglichkeit des Setters nicht hergeben wollen 

            //Geburtstag = new DateTime();// Jesus-Geburt 
            AnzahlLebewesen++; //erhöhe um ein Lebewesen
        }

        public Lebewesen(DateTime geburtstag, double gewicht, string lieblingsnahrung)
            : this()
        {
            Geburtstag = geburtstag;
            Gewicht = gewicht;
            Lieblingsnahrung = lieblingsnahrung;
        }


        //Verketten von Konstruktoren 
        public Lebewesen(DateTime geburtstag, double gewicht, string lieblingsnahrung, double breite, double hoehe)
            : this(geburtstag, gewicht, lieblingsnahrung)
        {
            Breite = breite;
            Hoehe = hoehe;
        }

        public Lebewesen(DateTime geburtstag, double gewicht, string lieblingsnahrung, double breite, double hoehe, string bezeichnung)
          : this(geburtstag, gewicht, lieblingsnahrung, breite, hoehe)
        {

            Bezeichnung = bezeichnung;
        }

        //public Lebewesen(string farbe)
        //{
        //    this.farbe = farbe;
        //}

        //Kopier-Konstrukot übergibt seine Werte in ein neues Objekt -> es stellt eine Kopie 
        public Lebewesen(Lebewesen lebewesen)
        {
            Geburtstag = lebewesen.Geburtstag;
            Gewicht = lebewesen.Gewicht;
            Lieblingsnahrung = lebewesen.Lieblingsnahrung;
            Hoehe = lebewesen.Hoehe;
            Breite = lebewesen.Breite;


            //Ausnahme das man hier eine Private Variablen zuweisen kann 
            _secret = lebewesen._secret;
        }


        //Der DESTRUKTOR wird von der GarbageCollection aufgerufen, wenn das Objekt nicht
        //mehr referenziert ist. Hier können Aktionen definiert werden,
        //welche zusätzlich zur 'Zerstörung' erfolgen sollen.
        ~Lebewesen()
        {
            //https://learn.microsoft.com/de-de/dotnet/csharp/programming-guide/classes-and-structs/finalizers
            //Ab .NET 5.0 wird bei einem Programm-Ende nicht der Dekonstruktor aufgerufen. 
            AnzahlLebewesen--;
        }

        #endregion

        #region Properties
        //Properties ist der Zugriffmechanismus auf Member-Variablen einer Klasse

        //EIGENSCHAFTEN (Properties) definieren mittels Getter/Setter den Lese-/Schreibzugriff für jeweils ein Feld.
        ///In den Eigenschaften können bestimmte Bedingungen für das Lesen und Schreiben der Felder gesetzt werden, sowie der Zugriff
        ///für Lesen und Schreiben einzeln angepasst werden
        //Snippet: propfull + tab + tab
        public double Gewicht
        {

            //Das Schlüsselwort VALUE beschreibt in einer Set-Methode den übergebenen Wert
            set
            {


                //Jeder Setter hat eine interne variable Namens 'value'
                //hier muss man gegen 'value' prüfen

                if (value < 0)
                {
                    //Eine Fehlermeldung geben wir aus

                    //Oder

                    //wir weißen 0.1 an Gewicht hinzu (Default - Zuweisung) 
                }

                _gewicht = value;
            }

            get
            {
                return _gewicht;
            }
        }

        //Property für Geburtstag
        public DateTime Geburtstag
        {
            set
            {
                _geburtstag = value;
            }

            get => _geburtstag;
        }

        //Read-only Property mit Rückbezug auf andere Property
        //Readonly Property-> basiert auf Geburtstag, ist davon abgeleitet -> Alter in Jahre 
        public int AlterInJahre
        {
            get
            {
                if (Geburtstag == DateTime.MinValue)
                {
                    //Fehlermeldung Geburtstag wurde nicht gesetzt!!!!
                }

                return ((DateTime.Now - Geburtstag).Days / 365);
            }
        }

        //Lieblingsnahrung Property mit String-Validierung
        public string Lieblingsnahrung
        {
            get
            {
                return _lieblingsnahrung;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                    _lieblingsnahrung = value;
            }
        }

        //Auto-Properties -> erstellen eine Member-Variable _bezeichnung beim Kompilieren. 


        //snippet: prop + tab + tab
        //Wird in einer Eigenschaft keine Spezifizierung angegeben, generiert das Programm das entsprechende Feld unsichtbar im Hintergrund
        public string Bezeichnung { get; set; }
        public double Breite
        {
            get => _breite;
            set => _breite = value;
        }

        public double Hoehe
        {
            get => _hoehe;
            set => _hoehe = value;
        }
        #endregion

        #region Methoden
        public void Atmen()
        {

        }


        public void FeiereGeburtstag()
        {
            Console.WriteLine($"Lebewesen feiert Geburtstag und ist {AlterInJahre} alt.");
        }

        
        #endregion

        #region statische Variablen und Methoden
        //Variablen: Metainformationen zu Lebewesn

        public static int AnzahlLebewesen { get; set; } = 0; //Defaultwert 

        public static string ZeigeAnzahlLebewesen()
        {

            return $"Es gibt {AnzahlLebewesen} Lebewesen.";
        }
        //Methoden: Hilfsmethoden zu dem Datentyp Lebewesen 


        #endregion
    }

    public class Säugetiere : Lebewesen
    {
        //Wir haben Zugriff auf alle Public Methoden und Properties aus der Klasse Lebewesen 
        public string NachwuchsNahrung { get; set; }

        public Säugetiere(DateTime geburtstag, double gewicht, string lieblingsnahrung, double breite, double hoehe, string bezeichnung, string nahrungNachwuchs)
            : base(geburtstag, gewicht,lieblingsnahrung,breite,hoehe, bezeichnung)
        {
            NachwuchsNahrung = nahrungNachwuchs;
        }

        public Lebewesen GebähreLebewesen()
        {
            return new Lebewesen(DateTime.Now, 2, "Milch", 1, 1, this.Bezeichnung);
        }
    }

    #region Mensch
    public class Mensch : Säugetiere
    {
        //Menschtypische Eigenschaften und Methoden hinzufügen
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public Adresse Adresse { get; set; }

        public Mensch(DateTime geburtstag, double gewicht, string lieblingsnahrung, double breite, double hoehe, string bezeichnung, string nahrungNachwuchs, string fname, string lname, Adresse adresse)
            :base(geburtstag, gewicht, lieblingsnahrung, breite, hoehe, bezeichnung, nahrungNachwuchs)
        {
            FirstName = fname;
            LastName = lname;
            Adresse = adresse;
        }
        

        public void Spricht(string text)
        {
            Console.WriteLine($"Mensch sprich: {text}");
        } 
    }

    public class Adresse
    {
        public string Anschrift;
        public string PLZ;
        public string Ort;

        public Adresse(string anschrift, string plz, string ort)
        {
            Anschrift = anschrift;
            PLZ = plz;
            Ort = ort;
        }
    }
    #endregion

    #region Reptilien

    public class Reptilien : Lebewesen
    {
        public void LegeEier()
        {
            Console.WriteLine($"{Bezeichnung} legt {new Random().Next(1, 5)} Eier ");
        }
    }

    //Mit Sealed geben wir an, dass von der Klasse Krokodil nicht vererbt werden kann.
    public sealed class Krokodil : Reptilien
    {
        //Spinnenspezifische Properties und Methoden

        public void TodesRolleBeimJagen()
        {
            Console.WriteLine("Beim Jagen kann es eine Rolle mit der Beute im Wasser durchführen");
        }
    }

    


    #endregion


}
using System.ComponentModel.DataAnnotations;

namespace Modul006_class_properties_fields_constructor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Deklaration und Instanziierung der Klasse Lebewesen 
            //Definition: Lebewesen lebewesen -> Speicher wird reserviert 
            //Instanziierung: lebewesen = new Lebewesen(); -> Erstellen eines Objektes von Lebewesen 

            Lebewesen_withGetSetMethoden lebewesen = new Lebewesen_withGetSetMethoden();
            lebewesen.SetGewicht(10);  //Old School -> kommt von C++ 
            lebewesen.Atmen(); //Methoden eine Logik beinhalten haben mit den Set/Get-Methoden wenig gemeinsam.
                               //Diese Schreibweise ist OBSELETE


            Lebewesen lebewesen1 = new Lebewesen();

            Lebewesen lebewesen2 = new Lebewesen(DateTime.Now, 10, "Lassange");

            Lebewesen lebewesen3 = new Lebewesen(DateTime.Now, 10, "Lassange", 2, 5, "Katze");


            // Hier wird die Speicheradresse übergeben. Modifikationen bei Lebewesen4 wirken sich auf Lebewesen 3 aus 
            Lebewesen lebewesen4 = lebewesen3;

            lebewesen4.Lieblingsnahrung = "Pizza"; //lebewesen3 erhält wegen der selben Sepicheradresse auch den Wert "Pizza"
            Console.WriteLine(lebewesen3.Lieblingsnahrung); //Pizza 


            //Das Gleiche mit einem Kopier-Konstruktor
            //Lebewesen5 resviert und kopiert sich alle Member-Variablen(via Properties) rein. 
            Lebewesen lebewesen5 = new Lebewesen(lebewesen4);
            lebewesen5.Lieblingsnahrung = "Wiener Schnitzler"; //keine Auswirkung auf Lebewesen4 

            
            Lebewesen lebewesen6 = lebewesen3.GebähreLebewesen();
        }

        public static void DisplayLebewesen(Lebewesen lebewesen)
        {
            //Hier können wir nur die Public Methoden ansprechen 
        }
            
    }

    //Eine Klasse ist eine Vorlage für Objekte. Sie bestimmen Eigenschaften und Methoden
    public class Lebewesen
    {
        private DateTime _geburtstag;
        private double _gewicht;
        private string _lieblingsnahrung;
        private double _breite;
        private double _hoehe;
       
        private string _secret = "123";

        #region Konstruktor

        //Es können mehrere Konstruktoren definiert werden, welche unterschiedliche Übergabeparameter haben (Überladung).
        //Ein Konstruktor, der keineÜbergabeparameter hat, wird als Default-Konstruktor bezeichnet
        public Lebewesen()
        {
            //Hinterlegen von Default-Werten
            //Wir sprechen immer die Properties an, weil wir die Möglichkeit des Setters nicht hergeben wollen 
            
            Geburtstag = new DateTime();// Jesus-Geburt 
        }

        public Lebewesen(DateTime geburtstag, double gewicht, string lieblingsnahrung)
        {
            Geburtstag = geburtstag;
            Gewicht = gewicht;
            Lieblingsnahrung = lieblingsnahrung;
        }

        
        //Verketten von Konstruktoren 
        public Lebewesen(DateTime geburtstag, double gewicht, string lieblingsnahrung, double breite, double hoehe)
            :this(geburtstag, gewicht, lieblingsnahrung)
        {
            Breite = breite;
            Hoehe = hoehe;
        }

        public Lebewesen(DateTime geburtstag, double gewicht, string lieblingsnahrung, double breite, double hoehe, string bezeichnung)
          : this(geburtstag, gewicht, lieblingsnahrung, breite, hoehe)
        {
            Bezeichnung = bezeichnung;
        }

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

                if(value < 0)
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

        }

        public Lebewesen GebähreLebewesen()
        {
            return new Lebewesen(DateTime.Now, 2, "Milch", 1, 1, this.Bezeichnung);
        }
        #endregion
    }





    //Eine Klasse ist eine Vorlage für Objekte. Sie bestimmen Eigenschaften und Methoden
    public class Lebewesen_withGetSetMethoden
    {
        //Membervariablen 
        private DateTime _geburtstag;
        private double _gewicht;


        #region Früher wurde auf die Member-Variablen mithilfe von Get/Set - METHODEN zugegriffen 
        public void SetGeburtstag(DateTime geburtstag)
        {
            _geburtstag = geburtstag;
        }

        public DateTime GetGeburtstag()
        {
            return _geburtstag;
        }

        public void SetGewicht(double gewicht)
        {
            //Unsere Set-Methode hat die Möglichkeit, eine Validierung für die Zuordnung des Gewichtes einzubauen 
            if (gewicht < 0)
            {
                // Geben wir eine Fehlermeldung
            }
            _gewicht = gewicht; 
        }
           

        public double GetGewicht()
            => _gewicht;
        #endregion

        public void FeiereGeburtstag()
        {
            //Wir feiern Geburtstag
        }

        public void Atmen()
        {

        }

    }
}
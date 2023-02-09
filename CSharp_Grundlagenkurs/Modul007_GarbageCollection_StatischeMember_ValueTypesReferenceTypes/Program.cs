namespace Modul007_GarbageCollection_StatischeMember_ValueTypesReferenceTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }


    //Eine Klasse ist eine Vorlage für Objekte. Sie bestimmen Eigenschaften und Methoden
    public class Lebewesen
    {
        #region Member-Variablen
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
            
        }

        public Lebewesen GebähreLebewesen()
        {
            return new Lebewesen(DateTime.Now, 2, "Milch", 1, 1, this.Bezeichnung);
        }
        #endregion


        #region statische Methoden und Variablen
        #endregion
    }
}
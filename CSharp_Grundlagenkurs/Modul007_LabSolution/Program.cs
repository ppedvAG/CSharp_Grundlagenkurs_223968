namespace Modul007_LabSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LadeMeineFahrzeugSimulation();

            GC.Collect();
            GC.WaitForPendingFinalizers();


            Console.WriteLine(Fahrzeug.ZeigeAnzahlFahrzeuge());
        }

        public static void LadeMeineFahrzeugSimulation()
        {
            Fahrzeug fahrzeug;

            for(int i=0; i < 1000; i++)
            {
                fahrzeug = new Fahrzeug("BMW", 230, 25999.99);
            }

            Console.WriteLine(Fahrzeug.ZeigeAnzahlFahrzeuge());
        }
    }


    public class Fahrzeug
    {
        private int _aktGeschwindigkeit;
        #region Lab 06: Properties, Methoden, Konstruktor

        //Properties
        public string Name { get; set; }
        public int MaxGeschwindigkeit { get; set; }
        public int AktGeschwindigkeit
        {
            get
            {
                return _aktGeschwindigkeit;
            }
            set
            {
                _aktGeschwindigkeit = value;
            }
        }
        public double Preis { get; set; }
        public bool MotorLäuft { get; set; }



        public static int AnzahlFahrzeuge { get; set; } = 0;

        //ctor + tab + tab -> Konstruktor
        public Fahrzeug()
        {
            AnzahlFahrzeuge++;
        }

        //Konstruktor mit Übergabeparametern und Standartwerten
        public Fahrzeug(string name, int maxG, double preis)
            :this()
        {
            this.Name = name;
            this.MaxGeschwindigkeit = maxG;
            this.Preis = preis;
            this.AktGeschwindigkeit = 0;
            this.MotorLäuft = false;
        }

        ~Fahrzeug()
        {
            Console.WriteLine($"{this.Name} wurde gerade verschrottet.");
            AnzahlFahrzeuge--;
        }


        public static string ZeigeAnzahlFahrzeuge()
        {
            return $"Es wurden {AnzahlFahrzeuge} Fahrzeuge gebaut.";
        }

        //Methode zur Ausgabe von Objektinformationen
        public string Info()
        {
            if (this.MotorLäuft)
                return $"{this.Name} kostet {this.Preis}€ und fährt momentan mit {this.AktGeschwindigkeit} von maximal {this.MaxGeschwindigkeit}km/h.";
            else
                return $"{this.Name} kostet {this.Preis}€ und könnte maximal {this.MaxGeschwindigkeit}km/h fahren.";
        }

        //Methode zum Starten des Motors
        public void StarteMotor()
        {
            if (this.MotorLäuft)
                Console.WriteLine($"Der Motor von {this.Name} läuft bereits.");
            else
            {
                this.MotorLäuft = true;
                Console.WriteLine($"Der Motor von {this.Name} wurde gestartet.");
            }
        }

        //Methode zum Stoppen des Motors
        public void StoppeMotor()
        {
            if (!MotorLäuft)
                Console.WriteLine($"Der Motor von {this.Name} ist bereits gestoppt");
            else if (this.AktGeschwindigkeit > 0)
                Console.WriteLine($"Der Motor kann nicht gestoppt werden, da sich {this.Name} noch bewegt");
            else
            {
                this.MotorLäuft = false;
                Console.WriteLine($"Der Motor von {this.Name} wurde gestoppt.");
            }
        }

        //Methode zum Beschleunigen und Bremsen
        public void Beschleunige(int offset)
        {
            if (this.MotorLäuft)
            {
                if (this.AktGeschwindigkeit + offset > this.MaxGeschwindigkeit)
                    this.AktGeschwindigkeit = this.MaxGeschwindigkeit;
                else if (this.AktGeschwindigkeit + offset < 0)
                    this.AktGeschwindigkeit = 0;
                else
                    this.AktGeschwindigkeit += offset;

                Console.WriteLine($"{this.Name} bewegt sich jetzt mit {this.AktGeschwindigkeit}km/h");
            }
        }


        public void BremsenIntervall()
        {
            if (this.MotorLäuft)
            {
                if (this.AktGeschwindigkeit - 20 > 0)
                    AktGeschwindigkeit -= 20;
                else
                    AktGeschwindigkeit = 0;
            }
        }

        public void BremseKomplett()
        {
            //Diese Logik wäre in der Klasse Fahrzeug in einer Methode FahrzeugAnhalten() besser aufgehoben
            while (this.AktGeschwindigkeit != 0)
            {
                this.BremsenIntervall();
            }

        }

        #endregion
    }
}
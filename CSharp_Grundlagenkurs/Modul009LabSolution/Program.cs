using System.Reflection.Emit;

namespace Modul009LabSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fahrzeug[] fahrzeuge = new Fahrzeug[10];

            for (int i = 0; i < fahrzeuge.Length; i++)
            {
                fahrzeuge[i] = Fahrzeug.GeneriereFahrzeug($"_{i}");
            }

            int pkwCounter, schiffCounter, flugzeugCounter;
            //beim initialisieren können wir Variablen, die den selben Wert erhalten, in dieser Schreibform praktizieren. 
            pkwCounter = schiffCounter = flugzeugCounter = 0;

            foreach (Fahrzeug currentFahrzeug in fahrzeuge) 
            {
                
                Console.WriteLine(currentFahrzeug.ToString());

                if (currentFahrzeug is PKW)
                {
                    pkwCounter++;
                }
                else if (currentFahrzeug is Schiff)
                {
                    schiffCounter++;
                }
                else if (currentFahrzeug is Flugzeug)
                {
                    flugzeugCounter++;
                }
                else
                    throw new Exception($"Objekt {currentFahrzeug.GetType()} ist kein unterstützter Datentyp");
            }

            Console.WriteLine($"PKW-Anzahl: {pkwCounter}");
            Console.WriteLine($"Schiff-Anzahl: {schiffCounter}");
            Console.WriteLine($"Schiff-Anzahl: {flugzeugCounter}");
        }
    }


    public abstract class Fahrzeug
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
            : this()
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

        public abstract void Hupen();
        public static string ZeigeAnzahlFahrzeuge()
        {
            return $"Es wurden {AnzahlFahrzeuge} Fahrzeuge gebaut.";
        }

        
        public static Fahrzeug GeneriereFahrzeug(string nameSuffix = "")
        {
            Random generator = new();

            switch (generator.Next(1, 4))
            {
                //Instanziierung der jeweiligen spezifischen Fahrzeuge
                case 1:
                    return new PKW("Mercedes" + nameSuffix, 210, 23000, 5);
                case 2:
                    return new Schiff("Titanic" + nameSuffix, 40, 25000000, Schiff.SchiffsTreibstoff.Dampf);
                default:
                    return new Flugzeug("Boing" + nameSuffix, 350, 90000000, 9800);
            }
        }

        //Methode zur Ausgabe von Objektinformationen
        public virtual string Info()
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

        public override string ToString()
        {
            return $"{Name} ist ein {this.GetType()}";
        }

    }


    public class Schiff : Fahrzeug
    {
        //Klasseneigener Enum
        public enum SchiffsTreibstoff { Diesel = 0, Dampf, Wind, Muskelkraft }

        //Klasseneigene Property
        public SchiffsTreibstoff Treibstoff { get; set; }

        //Konstruktor mit Bezug auf den Konstruktor der Mutterklasse (base)
        public Schiff(string name, int maxG, double preis, SchiffsTreibstoff treibstoff)
        //: base(name, maxG, preis)
        {
            this.Treibstoff = treibstoff;
            this.Name = name;
            this.MaxGeschwindigkeit = maxG;
            this.Preis = preis;
            this.AktGeschwindigkeit = 0;
            this.MotorLäuft = false;
        }

        //Überxchreibung der Info()-Methode mit Bezug auf die Methode der Mutterklasse (base)
        public override string Info()
        {
            return "Das Schiff " + base.Info() + $" Es fährt mit {this.Treibstoff}.";
        }

        public override void Hupen()
        {
            Console.WriteLine("Tööööööhhht");
        }
    }

    //vgl. Schiff
    public class PKW : Fahrzeug
    {
        public int AnzahlTueren { get; set; }

        public PKW(string name, int maxG, double preis, int anzTueren)
        {
            this.AnzahlTueren = anzTueren;

            this.Name = name;
            this.MaxGeschwindigkeit = maxG;
            this.Preis = preis;
            this.AktGeschwindigkeit = 0;
            this.MotorLäuft = false;
        }

        public override string Info()
        {
            return "Der PKW " + base.Info() + $" Er hat {this.AnzahlTueren} Türen.";
        }

        public override void Hupen()
        {
            Console.WriteLine("Huuuuup");
        }
    }

    //vgl. Schiff
    public class Flugzeug : Fahrzeug
    {
        public int MaxFlughöhe { get; set; }

        public Flugzeug(string name, int maxG, double preis, int maxFH) : base(name, maxG, preis)
        {
            this.MaxFlughöhe = maxFH;
        }

        public override string Info()
        {
            return "Das Flugzeug " + base.Info() + $" Es kann bis auf {this.MaxFlughöhe}m aufsteigen.";
        }

        public override void Hupen()
        {
            Console.WriteLine("Piep Piep");
        }
    }
}
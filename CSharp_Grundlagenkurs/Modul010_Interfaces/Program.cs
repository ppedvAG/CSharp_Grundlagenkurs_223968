using Microsoft.Data.SqlClient;

namespace Modul010_Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region HJahrmarktBeispiel
            int alterVonFritzchen = 17;
            List<Jahrmarktstand> meineToDoListInDisneyLand = new List<Jahrmarktstand>();

            meineToDoListInDisneyLand.Add(new AutoScooter(4, "Karl Ottos Autoscooter", 160, 5));
            meineToDoListInDisneyLand.Add(new HorrorCabinett(6, "Süss war gestern", 100, 5));
            meineToDoListInDisneyLand.Add(new Wildwasserbahn(12, "Wildwasser GmbH", 200, 10));
            meineToDoListInDisneyLand.Add(new Streichelzoo(2, "Freunde des Veggies", 60, 10));


            #region Typ-Prüfung
            AutoScooter scooter = new AutoScooter(4, "Karl Ottos Autoscooter", 160, 5);


            //Instanz 'scooter' bist du vom Typ AutoScooter
            if (scooter.GetType() == typeof(AutoScooter))
            {
                Console.WriteLine("Ist ein Autoscooter");
            }

            if (scooter is AutoScooter)
            {
                Console.WriteLine("Ist AutoScooter");
            }


            JahrmarktstandAusgabe(scooter);
            #endregion

            

            foreach (Jahrmarktstand aktuellerJahrmarktStand in meineToDoListInDisneyLand)
            {

                //Prüfe die Klasse, ob IFSK18 - Interface vorhanden ist, wenn ja Caste diese und mache mir CheckAge-Zugänglich
                if (aktuellerJahrmarktStand is IFSK18 standMitPruefung)
                {
                    
                    if (standMitPruefung.CheckAge(alterVonFritzchen))
                    {
                        Console.WriteLine("Darf fahren");
                    }
                    else
                        Console.WriteLine($"Fritzchen darf den Stand von {aktuellerJahrmarktStand.Bezeichnung} nicht fahren. er ist keine 18 Jahre alt");
                }
            }
            #endregion


            using (SqlConnection conn = new SqlConnection())
            {
                //Machwas -> Query
            } //IDispose -> hier wird die Connection abgebaut, beim Verlassen des Code-Blockes

            using (FileStream fs = new FileStream("abt.txt", FileMode.Open))
            {

            }

            //using benötigt ein IDisposeable
            using (MyJahrmarktstand myJahrmarktstand = new MyJahrmarktstand())
            {

            }
        }


        public static void JahrmarktstandAusgabe (object obj)
        {
            

            if (obj is AutoScooter autoScooter)
            {
                
                Console.WriteLine(autoScooter.Bezeichnung);
            }
        }
    }


    public class MyJahrmarktstand : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Gebe die Ressourcen frei...");
        }
    }

    //Inteface Prefix 'I'
    //Interface ist eine Schablone und 'muss' in der Implementierten Klasse ausimplementiert werden 
    //Wir können in einer Klasse mehrere Interface hinzufügen 


    public interface IFSK18
    {
        

        public virtual bool CheckAge(int age)
        {
            return age >= 18 ? true : false;
        }
    }

    public interface IWeiteresInterface : IFSK18
    {
        public void ZweiteMethode();
    }

    public class PseudoClass : IWeiteresInterface
    {
        public bool CheckAge(int age)
        {
            return true; 
        }

        public void ZweiteMethode()
        {
            
        }
    }

    public class Jahrmarktstand
    {
      

        public int Mitarbeiter { get; set; }
        public string Bezeichnung { get; set; }

        public double Flaeche { get; set; }

        public Jahrmarktstand(int mitarbeiter, string bezeichnung, double flaeche)
        {
            Mitarbeiter = mitarbeiter;
            Bezeichnung = bezeichnung;
            Flaeche = flaeche;
        }
    }


   

    public class AutoScooter : Jahrmarktstand
    {
        public AutoScooter(int mitarbeiter, string bezeichnung, double flaeche, int autoAnzahl) 
            : base(mitarbeiter, bezeichnung, flaeche)
        {
            AnzahlAutos = autoAnzahl;
        }

        public int AnzahlAutos { get; set; }
    }

    public class HoechsteAchterbahnDerWelt : Jahrmarktstand, IFSK18
    {
        public int FahrstreckeLaenge { get; set; }

        public HoechsteAchterbahnDerWelt(int mitarbeiter, string bezeichnung, double flaeche, int fahrstreckeLaenge)
            : base(mitarbeiter, bezeichnung, flaeche)
        {
            FahrstreckeLaenge = fahrstreckeLaenge;
        }

      
    }

    public class Wildwasserbahn : Jahrmarktstand
    {
        public int HoeheDerWildwasser { get; set; }

        public Wildwasserbahn(int mitarbeiter, string bezeichnung, double flaeche, int hoeheDerWildwasser)
            : base(mitarbeiter, bezeichnung, flaeche)
        {
            HoeheDerWildwasser = hoeheDerWildwasser;
        }
    }

    public class HorrorCabinett : Jahrmarktstand, IFSK18
    {
        public int SchockerAnzahl { get; set; }

        public HorrorCabinett(int mitarbeiter, string bezeichnung, double flaeche, int schockerAnzahl)
            : base(mitarbeiter, bezeichnung, flaeche)
        {
            SchockerAnzahl = schockerAnzahl;
        }


        

       
    }

    public class Streichelzoo: Jahrmarktstand
    {
        public int Tieranzahl { get; set; }

        public Streichelzoo(int mitarbeiter, string bezeichnung, double flaeche, int tieranzahl)
            : base(mitarbeiter, bezeichnung, flaeche)
        {
            Tieranzahl = tieranzahl;
        }
    }
}
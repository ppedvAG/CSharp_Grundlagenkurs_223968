//Mittels der USING Anweisung kann ein vereinfachter Zugriff auf Programm-Externe Klassen ermöglichen. 
//Ohne die USING Anweisung müssten wir expliziet den Namespace(System) zusätzlich mit angeben.
//Beispiel: System.Console.WriteLine("abc");
using System;
using System.ComponentModel;

//NAMESPACE: Ist die Umgebund des aktuellen Programms: Alles innerhalb eines Namespaces gehört zum Programm
//NAMESPACE: Kann man auch als ein Wörtbuch sehen, in dem Klassen/Enums/Delegates oder Typ per Name eindeutig definieren kann. 
namespace Modul002_Variablen_Konventierung_Operatoren
{

    //Programm-Klasse beinhaltet den Einstiegspunkt des Programms. Enweder wird die Main-Methode für den Einstieg verwenden ODER das Top Level Statment (ursprüngluch aus Phyton kommend) 
    internal class Program
    {
        //Die Main-Methode ist der Einsteigspunkt jedes C# Programms: Hier beginnt das Programm IMMER 
        static void Main(string[] args)
        {
            //DEKLARATION einer Variable. 'Hier wird der Speicherplatz für die Variable 'Alter´' vom Datentyp Integer (int) im Speicher reserviert. 
            int alter;

            // INITIALSIIERUNG: Zuordnen eines Wertes. Wenn wir eine Integer Variable nicht Initalisieren, wird als Default der Wert '0' genommen
            alter = 39;


            //Gleichzeitige Deklaration und Initialisierung einer String Variable 
            string city = "Berlin"; 

            Console.WriteLine(alter);
            Console.WriteLine(city);

            int doppeltesAlter = alter * 2;
            Console.WriteLine(doppeltesAlter);

            //Shortcut für Console.WriteLine -> cw + tab + tabl
            Console.WriteLine(alter + doppeltesAlter);

            #region Variablentypen

            #region String / Char
            //STRINGS
            string eineZeichenketteMitNull;
            string eineZeichenkette = "";
            string eineZeichenkette2 = string.Empty;

            string burghausenCity = "Burghausen " + " in Bayern " + " an der Salzach";
            Console.WriteLine(burghausenCity);


            //Char

            char textzeichen = 'A';
            Console.WriteLine(textzeichen);
            #endregion


            #region Ganzzahlige Datentypen
            short shortzahl = 123;
            short minShortNumber = short.MinValue;
            short maxShortNumber = short.MaxValue;


            int integerZahl = 123;
            int minIntergerNumber = int.MinValue;
            int maxIntergerNumber = int.MaxValue;

            long longZahl = 1234345;
            long minLongNumber = long.MinValue;
            long maxLongNumber = long.MaxValue;

            //0...255
            byte nyteZahl = 12;
            byte minByteZahl = byte.MaxValue;


            #region Extra-Unsigned Datatype im Vergleich
            ushort unsignedShortNumber = ushort.MinValue;
            ushort unsignedLongNumber = ushort.MaxValue;
            #endregion
            #endregion


            #region Gleitkommazahlen


            float floatNumber = 123.456f; //Feste Zuweisung einer Zahl muss mit einem Suffix 'f' beendet werden. 

            double doubleNumber = 123.456;

            decimal forMoneyValues = 456.99m;//Feste Zuweisung einer Zahl muss mit einem Suffix 'm' beendet werden. 

            #endregion

            #region Boolean

            //boolean hat zwei Zustände (True oder 1/False oder 0)

            bool booleanBariable = true; 
            booleanBariable = false;
            #endregion
            #endregion


            #region Ausgaben von Strings und Variablen
            string term = "Ich bin " + alter + " Jahre alt und wohne in " + city;
            Console.WriteLine(term);

            Console.WriteLine("Ich bin " + alter + " Jahre alt und wohne in " + city);

            //Ausgabe im Stile und Sinne des Printf-Befehls aus C 
            Console.WriteLine("Ich bin {0} Jahre alt und wohn in {1}", alter, city);
            
            //$-Operator (Variablen werde direkt in {}-Klammern geschrieben)
            Console.WriteLine($"Ich bin {alter} Jahre alt und wohne in {city}");

            //Weiteres Beispiel
            int a = 64;
            int b = 20;

            Console.WriteLine($"{a} + {b} = {a+b}");


            //Pdafangaben via Strings

            string oldschoolPath = "C:\\Windows\\Temp";

            // https://learn.microsoft.com/en-us/cpp/c-language/escape-sequences?view=msvc-170
            string withEscapeSequenzen = "Dies ist ein \t Tabulator und dies ein \n Zeilenumbruch ";




            //Verbatim-String 
            string withoutEscapeSequenzen = @"Dies ist ein \t Tabulator und dies ein \n Zeilenumbruch ";

            Console.WriteLine(withEscapeSequenzen);
            Console.WriteLine(withoutEscapeSequenzen);

            //Verbatim-String 
            string betterWindowsPath = @"C:\Windows\Temp";

            string verbatim = @$"Dies ist ein    Tabulator und dies ein 
Zeilenumbruch {city}";

            #endregion


            #region Eingaben + Typumwandlung (Casten) 

            //Beispiel 1: Eingabe eines Namens
            Console.Write("Bitte geben Sie einen Namen ein: ");
            string eingabe = Console.ReadLine();
            Console.WriteLine($"Dein Name ist {eingabe}");


            //Beispiel2: Eingabe einer Zahl(als Stirng) + Umwandlung: von String in eine Zahl

            Console.Write("Bitte gib deine Lieblingzahl ein: ");
            string zahlAlsString = Console.ReadLine();

            //Variante 1 (alte Variante mit Convert-Klasse) 
            int zahl1 = Convert.ToInt32(zahlAlsString);

            //Variante 2 (int.Parse oder noch besser -> int.TryParse
            int zahl2 = int.Parse(zahlAlsString);
            //int.TryParse



            #endregion


            #region Implzietes und Explizietes Casten 

            short myShortNumber = 123;
            int myIntegerNumber = myShortNumber; //Implizietes Umwandeln (MyShortNumber passt in den Integer-Zahlenraum


            decimal gleitkommaZahlMitDecimal = 19.99m;
            int gleitkommaZahlAlsIntegerWert = (int)gleitkommaZahlMitDecimal;


            Console.WriteLine(Math.Round(gleitkommaZahlMitDecimal));
            Console.WriteLine(Math.Floor(gleitkommaZahlMitDecimal));


            
            #endregion

        }
    }
}
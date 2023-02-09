namespace DrittanbieterDll
{
    public enum Anrede { Herr, Frau, Divers }

    public enum Wochentag { Mo, Di, Mi, Do, Fr, Sa, So}

    public enum Jahreszeiten {  Frühling, Sommer, Herbst, Winter }


    public class Person
    {
    }
}

namespace DrittanbieterDll.Common
{
    public enum Anrede { Herr, Frau, Divers }

    //public class Anrede { } -> würde ein Fehler ergeben -> Anrede ist schon in DrittanbieterDll.Common vergeben 
}
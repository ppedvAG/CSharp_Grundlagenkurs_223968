namespace Wiederholung_und_Extentions_zu_Tag1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Nullable Variablen

            int alter; //Variable nimmt hier den Wert 0 an. 

            //Nullable Datatypes können den Wert NULL besitzen
            int? myAge = null;

            //if (myAge != null)
            if (myAge.HasValue)
            {
                Console.WriteLine(myAge.Value);
            }


            string? nullableString = null;
            nullableString = string.Empty;

            if (!string.IsNullOrEmpty(nullableString))
            {

            }

            if (string.IsNullOrWhiteSpace(nullableString))
            {

            }


            #endregion



            #region BitFlag
            FischartenInMeinenSee selektierteFischSorten = FischartenInMeinenSee.Zander | FischartenInMeinenSee.Karpfen | FischartenInMeinenSee.Hecht;

            

            foreach (FischartenInMeinenSee currentFischSorte in Enum.GetValues(typeof(FischartenInMeinenSee)))
            {
                if (selektierteFischSorten.HasFlag(currentFischSorte) && currentFischSorte != FischartenInMeinenSee.KeineFische)
                {
                    Console.WriteLine($"{currentFischSorte} befindet sich in deinem See");
                }
            }
            #endregion


        }
    }
    
    public enum Jahrezeiten
    {
        Frühling = 0,
        Sommer = 1,
        Herbst = 2,
        Winter = 4
    }

    [Flags]
    public enum FischartenInMeinenSee
    {
        KeineFische = 0,
        Forelle = 1,
        Hecht = 2,
        Zander = 4,
        Karpfen = 8,
        Barsch = 16,
        Wels = 32
    }
}
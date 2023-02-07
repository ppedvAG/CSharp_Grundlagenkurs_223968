namespace Modul003_NET6Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (DateTime.IsLeapYear(2016))
                Console.WriteLine("Schaltjahr");
            else
                Console.WriteLine("KeinSchaltjahr");
        }
    }
}
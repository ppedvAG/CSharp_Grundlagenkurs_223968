namespace InterfaceSegregationPrinciple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    #region Sample1
    public interface IVehicle
    {
        public void Fly();
        public void Drive();
        public void Swim();

    }


    public class Vehicle : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("kann fahren");
        }

        public void Fly()
        {
            Console.WriteLine("kann fliegen");
        }

        public void Swim()
        {
            Console.WriteLine("kann schwimmen");
        }
    }

    public class AmphibischesVehicle : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("fahren");
        }

        public void Fly()
        {
            throw new NotImplementedException();
        }

        public void Swim()
        {
            Console.WriteLine("schwimmen");
        }
    }
    #endregion

    

    public interface IDrive
    {
        public void Drive();
    }

    public interface IFly
    {
        public void Fly();
    }

    public interface ISwim
    {
        public void Swim();
    }

    public class AmphibischesVehicle2 : IDrive, ISwim
    {
        public void Drive()
        {
            //fahre
        }

        public void Swim()
        {
            //Schwimme
        }
    }
}
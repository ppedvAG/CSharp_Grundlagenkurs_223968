namespace DependencyInversion
{
    

    #region BadCode


    //Programmierer A: 5 Tage (Anfangen von tag 1 bist Tag 5) 
    public class BadCar
    {
        public int Id { get; set; }
        public string Brand { get; set; }   
        public string Model { get; set; }

        public int ConstructionYear { get; set; }
    }


    public class BadCarV2 : BadCar
    {
        public string Farbe { get; set; }
    }
    //Programmierer B: 3 Tage (Anfang von Tag 5 bis 8)
    public class BadCarService
    {
        public void Repair(BadCar car) //Feste Kopplung 
        {
            //auto wird repariert 

            if (car.ConstructionYear < 1980)
            {
                //reparatur benötigt 2 Tage länger -> wegen Werkzeuge 
            }
        }
    }
    #endregion


    #region Good Code

    public interface ICar
    {
        int Id { get; set; }
        string Brand { get; set; }
        string Model { get; set; }
        int ConstructionYear { get; set; }
    }

    public interface ICarVersion2 : ICar
    {
        public string Farbe { get; set; }
    }


    public interface ICarService
    {
        void Repair(ICar car);
    }

    public interface ICarServiceVersion2 : ICarService
    {
        void Repair(ICarVersion2 car);
    }



    //Programmierer A: 5 Tage (Tag1 bis Tag5)

    public class Car : ICarVersion2
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ConstructionYear { get; set; }
        public string Farbe { get; set; }
    }

    

    //Programmierer B: 3 Tage (Tag1 bis Tag 3)
    public class CarService : ICarServiceVersion2
    {
        public void Repair(ICar car)
        {
            //repariere Auto 
        }

        public void Repair(ICarVersion2 car)
        {
           
            //Lackierung Farbe Dauer 2 Stunden mehr 
        }
    }

    //Programmierer B: Schreibt innerhalb einer Stunde ein Mock-Object
    public class MockCar : ICar
    {
        public int Id { get; set; } = 123;
        public string Brand { get; set; } = "VW";
        public string Model { get; set; } = "Polo";
        public int ConstructionYear { get; set; } = 2021;
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            ICarServiceVersion2 carService = new CarService();


            carService.Repair(new Car());
            carService.Repair(new MockCar());   

        }
    }

    #endregion
}
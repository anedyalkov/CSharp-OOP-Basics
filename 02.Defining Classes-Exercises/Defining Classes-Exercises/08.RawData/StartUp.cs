namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            
            var cars = new List<Car>();

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                var tires = new List<Tire>();
                var model = input[0];
                var engineSpeed = int.Parse(input[1]);
                var enginePower = int.Parse(input[2]);
                var cargoWeight = int.Parse(input[3]);
                var cargoType = input[4];

                input = input.Skip(5).ToArray();

                for (int j = 0; j < input.Length - 1; j+=2)
                {
                    var currentTirePressure = double.Parse(input[j]);
                    var currentTireAge = int.Parse(input[j + 1]);
                    var tire = new Tire(currentTirePressure, currentTireAge);
                    tires.Add(tire);
                }
                
                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoWeight, cargoType);
                var car = new Car(model, engine, cargo, tires);
                cars.Add(car);
               
            }

            var command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars)
                {
                    if (car.Cargo.Type == "fragile" && car.Tires.Any(t => t.Pressure < 1))
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else if (command == "flamable")
            {
                cars
                 .Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250)
                 .ToList()
                 .ForEach(c => Console.WriteLine($"{c.Model}"));
            }
        }
    }
}

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

                var model = input[0];
                var fuelAmount = double.Parse(input[1]);
                var fuelConsumptionFor1km = double.Parse(input[2]);
                if (!cars.Any(c => c.Model == model))
                {
                    Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);
                    cars.Add(car);
                }
                

            }
            string secondInput;
            while ((secondInput = Console.ReadLine()) != "End")
            {
                var commands = secondInput.Split().ToArray();
                var carModel = commands[1];
                var amountOfKM = double.Parse(commands[2]);

                var car = cars.FirstOrDefault( c => c.Model == carModel);
                bool isMoved = car.Drive(amountOfKM);

                if (!isMoved)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }
           
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}

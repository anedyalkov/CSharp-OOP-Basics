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
            var engines = new List<Engine>();
            var cars = new List<Car>();

            for (int i = 0; i < lines; i++)
            {
                var tokens = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

                var model = tokens[0];
                var power = int.Parse(tokens[1]);
                var engine = new Engine(model, power);

                if (tokens.Length < 4)
                {
                    if (tokens.Length == 2)
                    {
                        engines.Add(engine);
                        continue;
                    }
                    else
                    {
                        if (int.TryParse(tokens[2], out int number))
                        {
                            var displacement = number;
                            engine.Displacement = displacement;
                        }
                        else
                        {
                            var efficiency = tokens[2];
                            engine.Efficiency = efficiency;
                        }
                    }
                }
                else if (tokens.Length == 4)
                {
                    engine.Displacement = int.Parse(tokens[2]);
                    engine.Efficiency = tokens[3];
                }
                engines.Add(engine);
            }

            lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var tokens = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

                var model = tokens[0];
                var engine = tokens[1];
                Engine existingEngine = engines.FirstOrDefault(e => e.Model == engine);
                var car = new Car(model, existingEngine);
                if (tokens.Length < 4)
                {
                    if (tokens.Length == 2)
                    {
                        cars.Add(car);
                        continue;
                    }
                    else
                    {
                        if (int.TryParse(tokens[2], out int number))
                        {
                            var weight = number;
                            car.Weight = weight;
                        }
                        else
                        {
                            var color = tokens[2];
                            car.Color = color;
                        }
                    }
                }
                else if (tokens.Length == 4)
                {
                    car.Weight = int.Parse(tokens[2]);
                    car.Color = tokens[3];
                }
                cars.Add(car);
            }

            foreach (var car  in cars)
            {
                Console.Write(car);
            }
        }
    }
}

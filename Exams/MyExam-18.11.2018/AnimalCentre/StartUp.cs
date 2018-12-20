using AnimalCentre.Core;
using System;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Core.AnimalCentre animalCentre = new Core.AnimalCentre();
            var engine = new Engine(animalCentre);
            engine.Run();
        }
    }
}

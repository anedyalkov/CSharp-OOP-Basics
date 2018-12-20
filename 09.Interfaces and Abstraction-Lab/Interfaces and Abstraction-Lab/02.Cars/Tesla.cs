﻿namespace Cars
{
    public class Tesla : IElectricCar
    {

        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }
        public int Battery { get; private set; }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public string Start()
        { 
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{Color} {GetType().Name} {Model} with {Battery} Batteries";
        }
    }
}

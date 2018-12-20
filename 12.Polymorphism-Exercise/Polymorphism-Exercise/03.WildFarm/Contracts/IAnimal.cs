﻿namespace _03.WildFarm.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }
        string ProduceSound();
        void Eat(IFood food);
    }
}
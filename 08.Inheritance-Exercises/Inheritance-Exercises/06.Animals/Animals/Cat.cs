﻿namespace _06.Animals.Animals
{
    using System;

    public class Cat : Animal
    {
        public Cat(string name, int age, string gender) : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "Meow meow";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

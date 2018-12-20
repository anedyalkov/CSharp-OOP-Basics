namespace _03.Ferrari.Core
{
    using System;
    using _03.Ferrari.Contracts;
    using _03.Ferrari.Models;



    public class Engine
    {
        public void Run()
        {
            string driverName = Console.ReadLine();
            ICar ferrari = new Ferrari(driverName);
            Console.WriteLine(ferrari);
        }
    }
}

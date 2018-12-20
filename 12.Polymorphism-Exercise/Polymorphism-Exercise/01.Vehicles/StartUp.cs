namespace _01.Vehicles
{
    using _01.Vehicles.Core;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}

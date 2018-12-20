namespace _04.Telephony.Core
{
    using _04.Telephony.Models;
    using System;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            var numbers = Console.ReadLine().Split().ToList();
            var urls = Console.ReadLine().Split().ToList();
            var smartPhone = new Smartphone(numbers, urls);
            Console.WriteLine(smartPhone);
        }
    }
}

using System;

namespace P03_StudentSystem
{
    public class StartUp
    {
        public static void Main()
        {
            StudentSystem studentSystem = new StudentSystem();
            string command;
            while ((command = Console.ReadLine()) != "Exit")
            {
                studentSystem.ParseCommand(command);
            }
        }
    }
}

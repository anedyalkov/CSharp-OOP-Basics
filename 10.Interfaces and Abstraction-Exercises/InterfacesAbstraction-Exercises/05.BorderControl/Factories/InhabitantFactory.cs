namespace _05.BorderControl.Factories
{
    using _05.BorderControl.Contracts;
    using _05.BorderControl.Models;
    using System.Linq;

    public class InhabitantFactory
    {
        public IInhabitant CreateInhabitant(string input)
        {
            var inputArgs = input.Split().ToArray();

            if (inputArgs.Length == 3)
            {
                return new Citizen(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2]);
            }
            else
            {
                return new Robot(inputArgs[0], inputArgs[1]);
            }
        }
    }
}

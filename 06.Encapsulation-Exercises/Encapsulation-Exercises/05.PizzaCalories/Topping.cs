namespace _05.PizzaCalories
{
    using System;

    public class Topping
    {
        const string InvalidTypeMessage = "Cannot place {0} on top of your pizza.";
        const string InvalidToppinghWeightMessage = "{0} weight should be in the range [1..50].";
        const int ToppingMaxWeight = 50;
        const int ToppingMinWeight = 1;

        private string type;
        private double weight;
        private double caloriesPerGram;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
            caloriesPerGram = 2;
        }


        public string Type
        {
            get { return type; }
            private set
            {
                if (value != "meat" && value != "veggies" && value != "cheese" && value != "sauce")
                {
                    var valueName = value[0].ToString().ToUpper() + value.Substring(1);
                    throw new ArgumentException(string.Format(InvalidTypeMessage,valueName));
                }
                type = value;
            }
        }

        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value < ToppingMinWeight || value > ToppingMaxWeight)
                {
                    var valueName = this.type[0].ToString().ToUpper() + this.type.Substring(1);
                    throw new ArgumentException(string.Format(InvalidToppinghWeightMessage, valueName));
                }
                weight = value;
            }
        }
        public double CalculateCaloriesPerGram()
        {
            var typeModifier = 0.0;
            var result = 0.0;
            switch (Type)
            {
                case "meat":
                    typeModifier = 1.2;
                    break;
                case "veggies":
                    typeModifier = 0.8;
                    break;
                case "cheese":
                    typeModifier = 1.1;
                    break;
                case "sauce":
                    typeModifier = 0.9;
                    break;
                default:
                    break;
            }
            result = (caloriesPerGram * weight) * typeModifier;
            return result;
        }
    }
}

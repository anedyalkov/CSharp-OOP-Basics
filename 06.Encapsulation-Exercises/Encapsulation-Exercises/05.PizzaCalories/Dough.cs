namespace _05.PizzaCalories
{
    using System;

    public class Dough
    {
        const string InvalidTypeOfDoughMessage = "Invalid type of dough.";
        const string InvalidDoughWeightMessage= "Dough weight should be in the range [1..200].";
        const int DoughMaxWeight = 200;
        const int DoughMinWeight = 1;

        private string flourType;
        private string bakingTechnique;
        private double weight;
        private double caloriesPerGram;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
            caloriesPerGram = 2;
        }

        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (value != "white" && value != "wholegrain")
                {
                    throw new ArgumentException(string.Format(InvalidTypeOfDoughMessage));
                }
                flourType = value;
            }
        }

       
        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                if (value != "crispy" && value != "chewy" && value != "homemade")
                {
                    throw new Exception(string.Format(InvalidTypeOfDoughMessage));
                }
                bakingTechnique = value;
            }
        }

        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value < DoughMinWeight || value > DoughMaxWeight)
                {
                    throw new ArgumentException(string.Format(InvalidDoughWeightMessage));
                }
                weight = value;
            }
        }

        public double CalculateCaloriesPerGram()
        {
            var flourModifier = 0.0;
            var bakingTechniqueModifier = 0.0;
            var result = 0.0;
            switch (FlourType)
            {
                case "white":
                    flourModifier = 1.5;
                    break;
                case "wholegrain":
                    flourModifier = 1;
                    break;
                default:
                    break;
            }

            switch (BakingTechnique)
            {
                case "crispy":
                    bakingTechniqueModifier = 0.9;
                    break;
                case "chewy":
                    bakingTechniqueModifier = 1.1;
                    break;
                case "homemade":
                    bakingTechniqueModifier = 1;
                    break;
                default:
                    break;
            }

            result = (caloriesPerGram * weight) * flourModifier * bakingTechniqueModifier;
            return result;
        }

    }
}

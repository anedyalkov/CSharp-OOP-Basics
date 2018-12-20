namespace _05.PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        const int MaxLength = 15;
        const int ToppingsMaxCount = 10;
        const string InvalidPizzaNameMessage = "Pizza name should be between 1 and 15 symbols.";
        const string InvalidNumberOfToppingsMessage = "Number of toppings should be in range [0..10].";

        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public List<Topping> Toppings
        {
            get { return toppings; }
        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > MaxLength)
                {
                    throw new ArgumentException(string.Format(InvalidPizzaNameMessage));
                }
                name = value;
            }
        }
       
        public Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }

        public void AddTopping(Topping topping)
        {
            if (Toppings.Count > ToppingsMaxCount)
            {
                throw new ArgumentException(string.Format(InvalidNumberOfToppingsMessage));
            }

            Toppings.Add(topping);
        }

        private double GetTotalCalories()
        {
            var totalCalories = 0.0;
            var totalToppingsCalories = Toppings.Sum(t => t.CalculateCaloriesPerGram());

            totalCalories += Dough.CalculateCaloriesPerGram() + totalToppingsCalories;
            return totalCalories;
        }

        public override string ToString()
        {
            return $"{Name} - {GetTotalCalories():F2} Calories.";
        }
    }
}

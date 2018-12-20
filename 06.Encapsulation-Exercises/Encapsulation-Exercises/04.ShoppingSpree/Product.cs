using System;
using System.Collections.Generic;
using System.Text;

namespace _04.ShoppingSpree
{
    public class Product
    {
        const string InvalidNameMessage = "{0} cannot be empty";
        const string InvalidCostMessage = "{0} cannot be negative";
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(InvalidNameMessage,nameof(Name)));
                }
                name = value;
            }
        }

        public decimal Cost
        {
            get { return cost; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(InvalidCostMessage, nameof(Cost)));
                }
                cost = value;
            }
        }
    }
}

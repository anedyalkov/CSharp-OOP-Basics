namespace _04.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Person
    {
        const decimal MinValue = 0;
        const string InvalidNameMessage = "{0} cannot be empty";
        const string InvalidMoneyMessage = "{0} cannot be negative";
        const string InsufficientFundsMessage = "{0} can't afford {1}";
        private string name;
        private decimal money;
        private List<Product> bag;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bag = new List<Product>();
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(InvalidNameMessage, nameof(Name)));
                }
                name = value;
            }
        }

        public IReadOnlyCollection<Product> Bag => bag.AsReadOnly();

        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < MinValue)
                {
                    throw new ArgumentException(string.Format(InvalidMoneyMessage, nameof(Money)));
                }
                money = value;
            }
        }

        public void Buy(Product product)
        {

            if (money < product.Cost)
            {
                throw new ArgumentException(string.Format(InsufficientFundsMessage,this.Name,product.Name));
            }
            else
            {
                money -= product.Cost;
                bag.Add(product);
            }
        }
        public override string ToString()
        {
            if (bag.Count == 0)
            {
                return $"{name} - Nothing bought";
            }
            else
            {
                return $"{name} - {string.Join(", ", bag.Select(p => p.Name))}";
            }
        }
    }
}

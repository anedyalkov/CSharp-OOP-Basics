namespace BankAccount
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Person
    {
        private string name;
        private int age;
        private List<BankAccount> accounts;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public Person(string name, int age, List<BankAccount> accounts)
            : this(name, age)
        {
            this.accounts = accounts;
        }

        public decimal GetBalance()
        {
            var result = accounts.Sum(a => a.Balance);

            return result;
        }
    }
}

namespace BankAccount
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private const string UnexistingAccount = "Account does not exist";

        public static void Main()
        {
 
            var accounts = new Dictionary<int, BankAccount>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split().ToArray();
                var command = tokens[0];
                if (command == "Create")
                {
                    CreateAccount(tokens, accounts);
                }
                else if (command == "Deposit")
                {
                    var id = int.Parse(tokens[1]);
                    var amount = decimal.Parse(tokens[2]);
                    if (!accounts.ContainsKey(id))
                    {
                        Console.WriteLine(UnexistingAccount);
                    }
                    else
                    {
                        accounts[id].Deposit(amount);
                    }
                }
                else if (command == "Withdraw")
                {
                    var id = int.Parse(tokens[1]);
                    var amount = decimal.Parse(tokens[2]);

                    if (!accounts.ContainsKey(id))
                    {
                        Console.WriteLine(UnexistingAccount);
                    }
                    else
                    {
                        accounts[id].Withdraw(amount);
                    }
                }
                else if (command == "Print")
                {
                    var id = int.Parse(tokens[1]);
                    if (!accounts.ContainsKey(id))
                    {
                        Console.WriteLine(UnexistingAccount);
                    }
                    else
                    {
                        Console.WriteLine(accounts[id]);
                    }
                    
                }
            }
           
        }

        private static void CreateAccount(string[] input, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(input[1]);
            if (!accounts.ContainsKey(id))
            {
                accounts[id] = new BankAccount() { Id = id};
            }
            else
            {
                Console.WriteLine(UnexistingAccount);
            }
        }
    }
}

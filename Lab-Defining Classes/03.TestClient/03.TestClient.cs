using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {

        var accounts = new Dictionary<int, BankAccount>();

        var input = Console.ReadLine();

        while (input != "End")
        {
            var inputParams = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var command = inputParams[0];
            var accountId = int.Parse(inputParams[1]);
           // AccountExists(accounts, accountId);
            switch (command)
            {
                case "Create":
                    if (!accounts.ContainsKey(accountId))
                    {
                        accounts[accountId] = new BankAccount { Id = accountId };
                    }
                    else
                    {
                        Console.WriteLine("Account already exists");
                    }
                    break;
                case "Deposit":
                    if (AccountExists(accounts, accountId))
                    {
                        accounts[accountId].Deposit(decimal.Parse(inputParams[2]));
                    }
                    break;
                case "Withdraw":
                    if (AccountExists(accounts, accountId))
                    {
                        accounts[accountId].Withdraw(decimal.Parse(inputParams[2]));
                    }
                    break;
                case "Print":
                    if (AccountExists(accounts, accountId))
                    {
                        Console.WriteLine(accounts[accountId]);
                    }
                    break;
                default:
                    break;
            }

            input = Console.ReadLine();
        } 
    }


    public static bool AccountExists(Dictionary<int, BankAccount> accounts, int accountId)
    {

        if (accounts.ContainsKey(accountId))
        {
            return true;
        }
        else
        {
            Console.WriteLine("Account does not exist");
            return false;
        }
    }
}


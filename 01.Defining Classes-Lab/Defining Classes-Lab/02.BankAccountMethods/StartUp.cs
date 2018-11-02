namespace BankAccount
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var account = new BankAccount();
            account.Id = 1;
            account.Deposit(300);
            account.Withdraw(200);

            Console.WriteLine(account);
        }
    }
}

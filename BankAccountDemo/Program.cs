using BankAccount;

BankAccount.BankAccount ba = new("Chaniel Mays", 999.99f);
ba.Deposit(40.01f);
Console.WriteLine(ba.AccountHolder + " has a balance of " + ba.Balance);
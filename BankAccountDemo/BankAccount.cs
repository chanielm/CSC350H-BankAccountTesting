/*
Class: BankAccount
    Fields:
    - id: string
    - balance: float
    - transactions: List<float>
    Properties:
    + ID: string
    + Balance: float
    + Transactions: List<float>
    Methods:
    + Deposit(float): bool
    + Withdraw(float): bool
*/

namespace BankAccount
{
    public class BankAccount
    {
        string accountholder;
        float balance;
        List<float> transactions;

        public string AccountHolder { get { return accountholder; } }
        public float Balance { get { return balance; } }
        public List<float> Transactions { get { return transactions; } }

        public BankAccount(string? name, float initbal)
        {
            
            if (name != null) name = name.Replace(" ", null);
            if (name != null) accountholder = name; else accountholder = "N/A";

            this.balance = initbal;
            this.transactions = [];
        }

        public bool Deposit(float amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("FAILED: Cannot deposit a negative amount!");
                return false;
            }

            balance += amount;
            Console.WriteLine("DEPOSIT SUCCESS.");
            transactions.Add(amount);
            return true;
        }

        public bool Withdraw(float amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("FAILED: Cannot withdraw a negative amount!");
                return false;
            }

            if (balance < amount)
            {
                Console.WriteLine("FAILED: Insufficient Funds!");
                return false;
            }


            balance -= amount;
            Console.WriteLine("WITHDRAW SUCCESS.");
            transactions.Add(-amount);
            return true;
        }
    }
}
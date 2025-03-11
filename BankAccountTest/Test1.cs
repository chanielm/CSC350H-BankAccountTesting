using BankAccount;
namespace BankAccountTest;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestInitialBalance() {
        var account = new BankAccount.BankAccount("Mays", 99.99f);
        Assert.AreEqual(99.99f, account.Balance);
    }
    
    [TestMethod]
    public void TestAccountHolder() {
        var account = new BankAccount.BankAccount("Mays", 0);
        Assert.AreEqual("Mays", account.AccountHolder);

        var nullAcc = new BankAccount.BankAccount(null, 0);
        Assert.AreEqual("N/A", nullAcc.AccountHolder);
    }

    [TestMethod]
    public void TestDeposit() {
        var account = new BankAccount.BankAccount(null, 0);

        // deposit positive
        Assert.IsTrue(account.Deposit(2763.99f));
        Assert.AreEqual(2763.99f, account.Balance);
        Assert.AreEqual(2763.99f, account.Transactions[0]);

        // deposit zero
        Assert.IsTrue(account.Deposit(0));
        Assert.AreEqual(2763.99f, account.Balance);
        Assert.AreEqual(0f, account.Transactions[1]);

        // deposit negative
        Assert.IsFalse(account.Deposit(-1));
        Assert.AreEqual(2763.99f, account.Balance);
    }

    [TestMethod]
    public void TestWithdraw() {
        var account = new BankAccount.BankAccount(null, 1000);

        // withdraw positive && less than balance
        Assert.IsTrue(account.Withdraw(300));
        Assert.AreEqual(700f, account.Balance);
        Assert.AreEqual(-300, account.Transactions[0]);

        // withdraw positive && greater than balance
        Assert.IsFalse(account.Withdraw(2763));
        Assert.AreEqual(700f, account.Balance);

        // withdraw zero
        Assert.IsTrue(account.Withdraw(0));
        Assert.AreEqual(700f, account.Balance);
        Assert.AreEqual(0, account.Transactions[1]);

        // withdraw negative
        Assert.IsFalse(account.Withdraw(-20));
        Assert.AreEqual(700f, account.Balance);
    }
}

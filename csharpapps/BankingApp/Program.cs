using System;

public class BankAccount
{
    // Properties
    public string AccountHolderName { get; private set; }
    public string AccountNumber { get; private set; }
    private decimal Balance { get; set; }

    // Constructor
    public BankAccount(string accountHolderName, string accountNumber, decimal initialBalance)
    {
        AccountHolderName = accountHolderName;
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    // Getter method for Balance
    public decimal GetBalance()
    {
        return Balance;
    }

    // Setter method for Balance with validation logic
    public void SetBalance(decimal amount)
    {
        if (amount < 0)
        {
            Console.WriteLine("Invalid balance amount.");
            return;
        }
        Balance = amount;
    }

    // Method to deposit funds into the account
    public virtual void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid deposit amount.");
            return;
        }
        Balance += amount;
        Console.WriteLine($"Deposited {amount:C}. New balance: {Balance:C}");
    }

    // Method to withdraw funds from the account
    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid withdrawal amount.");
            return;
        }
        if (amount > Balance)
        {
            Console.WriteLine("Insufficient funds!");
            return;
        }
        Balance -= amount;
        Console.WriteLine($"Withdrawn {amount:C}. New balance: {Balance:C}");
    }
}

public class SavingsAccount : BankAccount
{
    // Property
    public decimal InterestRate { get; set; }

    // Constructor
    public SavingsAccount(string accountHolderName, string accountNumber, decimal initialBalance, decimal interestRate)
        : base(accountHolderName, accountNumber, initialBalance)
    {
        InterestRate = interestRate;
    }

    // Override Deposit method to calculate and add interest on deposit
    public override void Deposit(decimal amount)
    {
        base.Deposit(amount);
        decimal interest = amount * InterestRate / 100;
        base.Deposit(interest);
        Console.WriteLine($"Interest of {interest:C} added. New balance: {GetBalance():C}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a SavingsAccount object and demonstrate deposit functionality with interest calculation
        SavingsAccount savingsAccount = new SavingsAccount("John Doe", "123456789", 1000.00m, 0.05m);
        savingsAccount.Deposit(500.00m); // Deposit $500 with interest calculation

        // Create an array of BankAccount objects and iterate through them, calling the Deposit method (polymorphism in action)
        BankAccount[] accounts = new BankAccount[]
        {
            new BankAccount("Jane Smith", "987654321", 2000.00m),
            new SavingsAccount("Alice Brown", "567890123", 1500.00m, 0.03m)
        };

        foreach (var account in accounts)
        {
            account.Deposit(100.00m); // Deposit $100
        }
    }
}

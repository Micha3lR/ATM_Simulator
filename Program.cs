using System.Runtime.CompilerServices;

namespace ATM_Simulator
{
    internal class Program
    {
        static Account userAccount = new Account();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("ATM Main Menu:");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Withdraw Cash");
                Console.WriteLine("3. Deposit Cash");
                Console.WriteLine("4. View Transaction History");
                Console.WriteLine("5. Exit");
                Console.Write("Please choose an option (1-5): ");
                switch (Console.ReadLine())
                {
                    case "1":
                        userAccount.CheckBalance();
                        break;
                    case "2":
                        Console.WriteLine();
                        Console.Write("Enter the amount to withdraw: ");
                        string withdrawInput = Console.ReadLine();
                        userAccount.Withdraw(withdrawInput);
                        break;
                    case "3":
                        Console.WriteLine();
                        Console.Write("Enter the amount to deposit: ");
                        string depositInput = Console.ReadLine();
                        userAccount.Deposit(depositInput);
                        break;
                    case "4":
                        userAccount.ViewTransactionHistory();
                        break;
                    case "5":
                        Console.WriteLine();
                        Console.WriteLine("Thank you for using the ATM. Goodbye!");
                        return;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid option. Choose 1-5.");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Press Enter to Continue...");
                Console.ReadLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Simulator
{
    internal class Account
    {
        public decimal Balance { get; private set; }
        public List<string> TransactionHistory { get; private set; }

        public Account()
        {
            Balance = 100;
            TransactionHistory = new List<string>();
        }

        public void CheckBalance()
        {
            Console.WriteLine();
            Console.WriteLine($"Your current balance is: ${Balance.ToString("F2")}");
        }

        public void Withdraw(string input)
        {
            string cleanedInput = CleanAmountInput(input);
            if (decimal.TryParse(cleanedInput, out decimal amount))
            {
                if (amount <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid amount.");
                }
                else if (amount > Balance)
                {
                    Console.WriteLine();
                    Console.WriteLine("Insufficient funds.");
                }
                else
                {
                    Balance -= amount;
                    AddTransaction($"Withdrew ${amount.ToString("F2")}");
                    Console.WriteLine();
                    Console.WriteLine($"You have successfully withdrawn ${amount.ToString("F2")}");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        
        public void Deposit(string input)
        {
            string cleanedInput = CleanAmountInput(input);
            if (decimal.TryParse(cleanedInput,out decimal amount))
            {
                if (amount <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid amount.");
                }
                else 
                {
                    Balance += amount;
                    AddTransaction($"Deposited ${amount.ToString("F2")}");
                    Console.WriteLine();
                    Console.WriteLine($"You have successfully deposited ${amount.ToString("F2")}");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }               
        }

        private string CleanAmountInput(string input)
        {
            return input.Replace("$", "").Trim();
        }

        public void AddTransaction(string transaction)
        {
            TransactionHistory.Add($"{DateTime.Now}: {transaction}");
        }

        public void ViewTransactionHistory()
        {
            if (TransactionHistory.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("No transactions to display.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Transaction History:");
                foreach (string transaction in TransactionHistory)
                {
                    Console.WriteLine(transaction);
                }
            }
        }
    }
}
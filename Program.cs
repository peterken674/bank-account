﻿/*****************************************************************
Program Name: BankAccount
Description : A bank account application where the user can deposit, withdraw and view account summary.
Programmer : Peter Kennedy
Date : 7/17/2021
******************************************************************/

using System;

namespace BankAccount

{
    // Bank account class
    class BankAccount{
        // Declare the class members 
        private string fullName, accountNumber;
        private decimal initialBalance, currentBalance;

        // Getter and setters for the instance variables
        public string FullName{
            get{
                return fullName;
            }
            set{
                fullName = value;
            }
        }
        public string AccountNumber{
            get{
                return accountNumber;
            }
            set{
                accountNumber = value;
            }
        }
        public decimal InitialBalance{
            get{
                return initialBalance;
            }
            set{
                if (value <= 0){
                    initialBalance = 0;
                }else{
                    initialBalance = value;
                }
            }
        }
        public decimal CurrentBalance{
            get{
                return currentBalance;
            }
            set{
                currentBalance = value;
            }  
        }

        // Constructor containing the full names, account number and the initial balance.
        public BankAccount(string fullName, string accountNumber, decimal initialBalance){
            this.fullName = fullName;
            this.accountNumber = accountNumber;
            this.initialBalance = initialBalance;
            this.currentBalance = initialBalance;
        }

        // Method for depositing into the account.
        public void Deposit(decimal depositAmount){
            this.currentBalance = initialBalance + depositAmount;
        }

        // Method for withdrawing from the account.
        public void Withdraw(decimal withdrawalAmount){
            if (withdrawalAmount > currentBalance){
                Console.WriteLine("\nYou do not have sufficient funds to complete this transaction.");
            }else{
                this.CurrentBalance = initialBalance - withdrawalAmount;
            }
        }

        // Method for displaying the account information
        public void Display(){
            Console.WriteLine("\n-----ACCOUNT SUMMARY-----");
            Console.WriteLine("Account holder's name\t: {0}", this.FullName);
            Console.WriteLine("Account number\t: {0}", this.AccountNumber);
            Console.WriteLine("Account balance\t: ${0}", this.CurrentBalance);
        }
    }
    
    class BankAccountTest
    {
        static void Main(string[] args)
        {
            // Prompt the user for the full name, account number, and initial balance.
            Console.Write("Enter full name: ");
            string fullName = Console.ReadLine();

            Console.Write("Enter the account number:");
            string accountNumber = Console.ReadLine();

            Console.Write("Initial balance: ");
            decimal initialBalance = Convert.ToDecimal(Console.ReadLine());

            // Create a new instance of the BankAccount class using the details provided by the user.
            BankAccount account1 = new BankAccount(fullName, accountNumber, initialBalance);

            // Display the details of the new account.
            account1.Display();


            // Prompt the user to select an action
            Console.WriteLine(" ");
            Console.WriteLine("Select an option.\n1. Deposit \n2. Withdraw");
            Console.Write("Selection: ");

            int selection = Convert.ToInt32(Console.ReadLine()); //Convert selection to int

            // Deposit if selection is 1
            if (selection == 1){
                Console.WriteLine("\n---DEPOSITING---");
                Console.Write("Enter amount to deposit: ");
                decimal depositAmount = Convert.ToDecimal(Console.ReadLine());

                account1.Deposit(depositAmount);

                account1.Display();
            }

            // Withdraw if selection is 2
            else if (selection == 2){
                Console.WriteLine("\n---WITHDRAWING---");
                Console.Write("Enter amount to withdraw: ");
                decimal withdrawalAmount = Convert.ToDecimal(Console.ReadLine());

                account1.Withdraw(withdrawalAmount);

                account1.Display();
            }

            // Alert the use if the selection they made is not a valid option
            else {
                Console.WriteLine("Invalid selection.");
                account1.Display();
            }          
        }
    }
}

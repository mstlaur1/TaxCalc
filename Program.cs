using System;
using static System.Console;

namespace TaxCalc
{
    class Constants
    {
        public const decimal TAX_RATE = 1.14975m;
    }

    class Program
    {
        static void Main(string[] args)
        {
            decimal subtotal;
            decimal grandTotal;
            decimal userMoney;

            WriteLine("Do you have enough money?");
            WriteLine("*************************");

            subtotal = GetSubtotal();
            grandTotal = GetGrandTotal(subtotal);
            WriteLine(" Subtotal: {0} \r\n Grand Total: {1} ", subtotal.ToString("c2"), grandTotal.ToString("c2"));
            userMoney = GetUserMoney();

            if (userMoney < grandTotal)
                WriteLine("You're short by {0}", (grandTotal - userMoney).ToString("c2"));
            else
                WriteLine("Congrats! You got enough.");
        }

        static decimal GetSubtotal()
        {
            decimal itemSum = 0;
            decimal tmp;
            uint numProducts;

            Write("Please enter the total number of products: ");

            while (!uint.TryParse(ReadLine(), out numProducts))
                Write("Error: You may have typed a negative number of products. " +
                   "or a letter. \r\n Try again: ");

            for (uint i = 0; i < numProducts; i++)
            {
                WriteLine("Please enter the price of product {0}", i + 1);

                while (!decimal.TryParse(ReadLine(), out tmp) || tmp < 0)
                    Write("Error, did you enter a negative? Try again: ");

                itemSum += tmp;
            }

            return itemSum;
        }

        static decimal GetGrandTotal(decimal subtotal)
        {
            return subtotal * Constants.TAX_RATE;
        }

        static decimal GetUserMoney()
        {
            decimal userMoney;

            WriteLine("Please enter the amount of cash you have: ");

            while (!decimal.TryParse(ReadLine(), out userMoney) || userMoney < 0)
                Write("Error: Please enter a positive numerical value. Try again: ");

            return userMoney;
        }
    }
}

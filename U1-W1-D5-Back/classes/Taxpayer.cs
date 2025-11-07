using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace U1_W1_D5_Back.classes
{
    public class Taxpayer
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string TaxID { get; set; }
        public string Gender { get; set; }
        public string Residence { get; set; }
        public decimal AnnualIncome { get; set; }

        public decimal TotalTax { get; set; }

        public Taxpayer()
        {
            TotalTax = 0;
        }



        public static string ReadInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static void Menu()
        {

            Taxpayer Payer = new Taxpayer();



            string chose = ReadInput("""

             MENU

               1.: Register New Taxpayer & Calculate Tax
               2.: Exit Application

               Please select an option (1-2):

             """);

            switch (chose)
            {
                case "1":
                    Payer.InsertData();
                    break;
                case "2":
                    Console.WriteLine("Exit...");
                    Environment.Exit(0);
                    break;

                default:

                    break;

            }
            Menu();
        }


        public void InsertData()
        {
            try
            {



                FirstName = ReadInput(" Name :");
                LastName = ReadInput(" Lastname :");
                DateOfBirth = ReadInput(" Birth Date :");
                TaxID = ReadInput(" TaxID :");
                Gender = ReadInput(" Gender :");
                Residence = ReadInput(" Residence :");
                string Income = ReadInput(" Annual Income :");
                AnnualIncome = Math.Round(decimal.Parse(Income), 2);

                if (FirstName == "" || LastName == "" || DateOfBirth == "" || TaxID == "" || Gender == "" || Residence == "")
                {
                    throw new Exception("You must fill all fields to calculate Tax!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Menu();
            }
            TotalTax = CalculateTax();
            PrintTax();
        }


        public void PrintTax()
        {

            Console.WriteLine($"""
                
                      ==================================================

                        Tax Calculation :
                        Taxpayer: {FirstName} {LastName},
                        Born in: {DateOfBirth} {Gender},
                        Residing in: {Residence},
                        Tax ID: {TaxID},
                        Declared Income: {AnnualIncome}
                        Tax Due: $ {TotalTax}

                
                """);
        }

        public decimal CalculateTax()
        {
            decimal income = AnnualIncome;
            decimal totalTax;


            if (income <= 15000)
            {
                totalTax = income * 0.23m;
            }
            else if (income <= 28000)
            {
                decimal exess = income - 15000;
                totalTax = 3450m + (exess * 0.27m);
            }
            else if (income <= 55000)
            {
                decimal exess = income - 28000;
                totalTax = 6960m + (exess * 0.38m);
            }
            else if (income <= 75000)
            {
                decimal exess = income - 55000;
                totalTax = 17220m + (exess * 0.41m);
            }
            else
            {
                decimal exess = income - 75000;
                totalTax = 25420m + (exess * 0.43m);
            }

            return totalTax;
        }


    }
}

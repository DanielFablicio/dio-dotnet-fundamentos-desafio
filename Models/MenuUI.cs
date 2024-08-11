using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Dio_Dotnet_Fundamentos_Desafio.Models
{
    public static class Menu
    {
        public static string Input {get; set;} = "";
        private static readonly string invalidValueMessage = "Invalid value.";
        
        public static (decimal, decimal) WelcomeMenu() {
            Console.WriteLine("Welcome to parking lot system!");
            
            Console.WriteLine("Enter the starting price: ");
            decimal inicialPrice = SetDecimalValue(); 
            
            Console.WriteLine("Now enter the price/hour: ");
            decimal pricePerHour = SetDecimalValue();
            
            var price = (inicialPrice, pricePerHour);

            return price;
        }

        public static void ShowOptions() {
            Console.WriteLine(
                "Enter an option: \n" +
                "1 - Register Vehicle\n" +
                "2 - Remove Vehicle\n" +
                "3 - List Vehicles \n" +
                "4 - Finish"
            );
        }


        
        public static bool ReadInput() {
            string? userInput = Console.ReadLine();
            
            if (userInput != null) {
                userInput = userInput.Trim();
                if(userInput != "") {
                    Input = userInput;
                    Console.WriteLine("");
                    return true;
                }
            }
            Console.WriteLine("User do not entered a value. \n");
            
            return false;
        }


        public static decimal SetDecimalValue() {
            while (true){
                if (ReadInput()) {
                    if (decimal.TryParse(Input, out decimal value)) {
                        if (value >= 0) {
                            return value;
                        }
                    }
                    Console.WriteLine(invalidValueMessage);
                }
            }
        }
    }
}
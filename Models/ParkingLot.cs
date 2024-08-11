using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Dio_Dotnet_Fundamentos_Desafio.Models
{
    public class ParkingLot()
    {
        public required decimal InicialPrice { get; set; }
        public required decimal PricePerHour { get; set; }
        public List<string> Vehicles { get; set; } = [];


        public void AddVehicle(string licensePlate) {
            string treatedLicensePlate = PadronizePlate(licensePlate);
            Vehicles.Add(treatedLicensePlate);
            Console.WriteLine("Vehicle license Plate " + treatedLicensePlate + " registered.");
        }

        public void RemoveVehicle(string licensePlate) {
            
            string treatedLicensePlate = PadronizePlate(licensePlate);
            if (!Vehicles.Remove(treatedLicensePlate)) {
                Console.WriteLine("Vehicle not registered");
            } else {
                TakePayment();
                Console.WriteLine("Vehicle " + treatedLicensePlate + " removed.");
            };
        }

        public void RemoveVehicle(int licensePlateIndex) {
            
            int index = licensePlateIndex - 1;
            if (index >= 0 && index < Vehicles.Count) {
                TakePayment();
                Console.WriteLine("Vehicle " + Vehicles[index] + " removed.");
                Vehicles.RemoveAt(index);
            }
            else {
                Console.WriteLine("Inexistent index.");
            }
        }

        public void ListVehicles() {
            uint counter = 1;
            foreach(string vehicle in Vehicles) {
                Console.WriteLine($"[{counter}] {vehicle}");
                counter++;
            }
            Console.WriteLine("");
        }
        
        private void TakePayment() {
            Console.WriteLine("How many hours was the vehicle parked?");
            decimal timeParked = Menu.SetDecimalValue();
            Console.WriteLine($"Total price = {(InicialPrice + timeParked * PricePerHour).ToString("C")}");
        }

        public bool IsEmpty() {
            bool verify = Vehicles.Count == 0;
            if (verify) {
                Console.WriteLine("Parking lot is empty.");
            }
            return verify;
        }

        public bool IsLicensePlateAlreadyOnSystem(string licensePlate) {
            bool response = Vehicles.Contains(licensePlate);
            if (response) {
                Console.WriteLine("License plate already registered");
            }
            return response;
        }

        public static bool IsValueAValidLicensePlate(string value) {
            //First 3 chars have to be letters and the rest
            //have to be numbers, ignoring ' - ' 
            string trimValue = value.Trim();
            
            if (trimValue.Length == 7 || trimValue.Length == 8) {
                string plate = trimValue;
                    
                if (trimValue.Contains('-')) {
                    plate = trimValue.Remove(trimValue.IndexOf('-'), 1);
                }
                
                if (plate.Length != 8) {
                    if (plate[..3].All(char.IsLetter)){
                        if (plate[3..].All(char.IsNumber)) {
                            return true;
                        }
                    }
                }
            }
            Console.WriteLine("Invalid license plate.");
            return false;
        }

        public static string PadronizePlate(string licensePlate) {
            string plate = licensePlate;
            if (!plate.Contains('-')) {
                try {
                plate = plate.Insert(3, "-");
                } finally {}
            }
            return plate.ToUpper();
        }
    }
}
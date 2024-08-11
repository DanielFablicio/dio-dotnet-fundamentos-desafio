using System.Collections;
using Dio_Dotnet_Fundamentos_Desafio.Models;

var (inicialPrice, pricePerHour) = Menu.WelcomeMenu();
ParkingLot parkingLot = new ParkingLot() {
    InicialPrice = inicialPrice,
    PricePerHour = pricePerHour
};


bool isValidOption = false;

do {
    if (isValidOption) {Console.Clear();}
    
    Menu.ShowOptions();

    byte option = 0;
    if (Menu.ReadInput()) {
        _ = byte.TryParse(Menu.Input, out option);
    }
    
    
    if (option > 0 && option <= 4 ) {
        
        switch (option) {
            case 1: 
                Console.WriteLine("Enter the vehicle license plate to park: ");
                
                if (Menu.ReadInput()) {
                    if (ParkingLot.IsValueAValidLicensePlate(Menu.Input)) {
                        if (!parkingLot.IsLicensePlateAlreadyOnSystem(Menu.Input)) {
                            parkingLot.AddVehicle(Menu.Input);
                        }
                    }
                }
                break;
            
            case 2:
            
                if (!parkingLot.IsEmpty()) {
                    Console.WriteLine("Enter the index or the vehicle license plate to remove: \n");
                    parkingLot.ListVehicles();

                    if (Menu.ReadInput()) {
                        if (int.TryParse(Menu.Input, out int indexInput)) {
                            parkingLot.RemoveVehicle(indexInput);
                        } else {
                            parkingLot.RemoveVehicle(Menu.Input);
                        }
                    }
                }
                break;
            
            case 3:
                if (!parkingLot.IsEmpty()) {
                    parkingLot.ListVehicles();
                }
                break;
            
            case 4:
                Console.WriteLine("Program finished.");
                Environment.Exit(0);
                break;
        }
        isValidOption = true;
    }
    else
    {
        Console.WriteLine("Invalid option. Try again.");
        isValidOption = false;
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadLine();

} while(true);


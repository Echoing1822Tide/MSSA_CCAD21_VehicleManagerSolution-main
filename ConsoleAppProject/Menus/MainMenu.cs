using ConsoleHelpers;
using VehicleModels;

namespace ConsoleAppProject.Menus;

public class MainMenu
{
    //private variables for various menus

    //TODO: Inject Menu Dependencies
    public MainMenu()
    {
    }

    public async Task ShowAsync()
    {
        bool shouldContinue = true;
        while (shouldContinue)
        {
            Console.Clear();

            string[] menuOptions = GetMenuOptions();

            var menuText = MenuGenerator.GenerateMenu("Main Menu", "Please select an operation", menuOptions, 40);

            // Show menu and get user choice
            int choice = InputHelpers.GetInputAsInt(menuText, confirm: true, min: 1, max: menuOptions.Length);

            try
            {
                shouldContinue = await HandleMenuChoiceAsync(choice);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }

    //handle user choice
    private async Task<bool> HandleMenuChoiceAsync(int choice)
    {
        switch (choice)
        {
            //TODO: Switch this to use Vehicle methods
            //      - Add a Vehicle
            //      - List Vehicles
            //      - Get a single vehicle details
            //      - Update a vehicle
            //      - Remove a vehicle
            //      - Save Vehicles to file
            //      - Load Vehicles from file
            case 1:
                VehicleTest();
                break;
            case 2:
                CarAndTruckTesting();
                break;
            default:
                return false;
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        return true;
    }

    //get menu options
    private string[] GetMenuOptions()
    {
        return new string[] {
            "Vehicle Test",
            "Car and Truck Testing",
            "Exit"
        };
    }

    private void VehicleTest()
    {
        // Construct a vehicle and display it
        var myVehicle = new Vehicle(2022, "Ford", "Maverick", 20000, true);
        var myOtherVehicle = new Vehicle();

        myOtherVehicle.Year = 2018;
        myOtherVehicle.Make = "Chevy";
        myOtherVehicle.Model = "Camaro";
        myOtherVehicle.Mileage = 0.5;
        myOtherVehicle.IsAutomatic = false;




        Console.WriteLine(OutputHelpers.BoxedMessageWithTitle("Your Vehicle",myVehicle.ToString()));
        Console.WriteLine(OutputHelpers.BoxedMessageWithTitle("Your Vehicle",myOtherVehicle.ToString()));
    }

    private void CarAndTruckTesting()
    {
        var car1 = new Car(2000, "Honda", "Civic", 1000, true, true, BodyType.Coupe);
        Console.WriteLine(OutputHelpers.BoxedMessageWithTitle("Your Vehicle", car1.ToString()));

        var truck1 = new Truck(2025, "Ford", "F150", 10, true, 8, 2000);
        Console.WriteLine(OutputHelpers.BoxedMessageWithTitle("Your Vehicle", truck1.ToString()));
    }





}

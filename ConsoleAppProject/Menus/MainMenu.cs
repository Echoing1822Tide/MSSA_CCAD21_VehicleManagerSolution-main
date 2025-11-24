using ConsoleHelpers;

namespace ConsoleAppProject.Menus;

public class MainMenu
{
    //private variables for various menus

    //TODO: Inject Menu Dependencies
    public MainMenu()
    {
    }

    private void ShowFormattedMessages()
    {
        var prompt = "What is your vehicle?";
        var response = InputHelpers.GetInputAsString(prompt);
        Console.WriteLine(OutputHelpers.BoxedMessage(response, '*'));
        Console.WriteLine(OutputHelpers.BoxedMessage(response, '-'));
        Console.WriteLine(new string('~', 40));

        Console.WriteLine(OutputHelpers.BoxedMessageWithTitle("Welcome", response));
    }

    private void ShowInputHelpers()
    {
        string prompt = "Please enter your favorite constant";
        double min = 0;
        double max = 100;
        
        double result = InputHelpers.GetInputAsDouble(prompt, min, max, true);
        Console.WriteLine($"You entered {result}");

        prompt = "Guess a number between 1 and 7";
        int intMin = 1;
        int intMax = 7;
        int intResult = InputHelpers.GetInputAsInt(prompt, intMin, intMax, true);
        Console.WriteLine($"You guessed {intResult}");

        prompt = "Would you like to continue?";
        bool boolResult = InputHelpers.GetInputAsBool(prompt, true);
        Console.WriteLine($"continue: {(boolResult? "yes" : "no")}");

        var prompt2 = "IS C# the best language?";
        bool boolResult2 = InputHelpers.GetInputAsBool(prompt2);
        Console.WriteLine($"give up: {(boolResult2? "yes" : "no")}");

        // String method
        var prompt3 = "What is your name?";
        string stringResult = InputHelpers.GetInputAsString(prompt3);
        Console.WriteLine($"Hello {stringResult}!");

        var prompt4 = "Enter your name again";
        string stringResult2 = InputHelpers.GetInputAsString(prompt4, true);
        Console.WriteLine($"Hello again {stringResult2}!");
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
            case 1:
                VehicleTest();
                break;
            case 2:
                ShowInputHelpers();
                break;
            case 3:
                // Exit
                return false;
            default:
                Console.WriteLine("Invalid choice.");
                break;
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
            "Show Input Helpers",
            "Exit"
        };
    }
    private void VehicleTest()
    {
        var myVehicle = new Vehicle(1969, "Oldsmobile", "Cutlass 442", 50000, false);
        var myOtherVehicle = new Vehicle();

        myOtherVehicle.Year = 2018;
        myOtherVehicle.Make = "Toyota";
        myOtherVehicle.Model = "Corolla";
        myOtherVehicle.Mileage = 80000;
        myOtherVehicle.IsAutomatic = true;

        Console.WriteLine(ConsoleHelpers.OutputHelpers.BoxedMessageWithTitle("Your Vehicle", myVehicle.ToString()));
        Console.WriteLine(ConsoleHelpers.OutputHelpers.BoxedMessageWithTitle("Your Other Vehicle", myOtherVehicle.ToString())); 
    }
}

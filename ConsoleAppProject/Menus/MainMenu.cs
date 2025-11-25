using System.Threading.Tasks;
using ConsoleHelpers;      // InputHelpers, OutputHelpers, MenuGenerator
using VehicleModels;

namespace ConsoleAppProject.Menus
{
    // Keep MainMenu thin: it shows a menu and routes to actions.
    public interface IMenuActions
    {
        Task VehicleTestAsync();
        Task CarAndTruckTestingAsync();
        Task AddVehicleAsync();
        Task ShowVehiclesAsync();
    }

    public sealed class MainMenu
    {
        private readonly IMenuActions _actions;
        public MainMenu(IMenuActions actions) => _actions = actions;

        public async Task ShowAsync()
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                Console.Clear();

                string[] options = new[]
                {
                    "Vehicle Test",
                    "Car and Truck Testing",
                    "Add a Vehicle",
                    "Show Vehicles",
                    "Exit"
                };

                string menu = MenuGenerator.GenerateMenu(
                    "Main Menu",
                    "Please select an operation",
                    options,
                    50
                );

                int choice = InputHelpers.GetInputAsInt(menu, confirm: true, min: 1, max: options.Length);

                switch (choice)
                {
                    case 1: await _actions.VehicleTestAsync();       break;
                    case 2: await _actions.CarAndTruckTestingAsync(); break;
                    case 3: await _actions.AddVehicleAsync();         break;
                    case 4: await _actions.ShowVehiclesAsync();       break;
                    case 5: keepGoing = false;                        break;
                }

                if (keepGoing)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true);
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
}

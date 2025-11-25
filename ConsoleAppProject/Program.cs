using ConsoleAppProject.Menus;

namespace VehicleManager
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var app  = new Application();           // implements IMenuActions
            var menu = new MainMenu(app);           // thin UI shell
            await menu.ShowAsync();
        }
    }
}

using ConsoleAppProject.Menus;     // IMenuActions
using ConsoleHelpers;              // InputHelpers, OutputHelpers
using VM = VehicleModels;          // <-- alias the class library
using IH = ConsoleHelpers.InputHelpers;
using OH = ConsoleHelpers.OutputHelpers;

namespace VehicleManager
{
    public sealed class Application : IMenuActions
    {
        // Keep your state in ONE place, using the library types
        private readonly List<VM.Vehicle> _garage = new();

        // 1) Simple base-type demo
        public Task VehicleTestAsync()
        {
            var v1 = new VM.Vehicle(2022, "Ford",  "Maverick", 20000, isAutomatic: true);
            var v2 = new VM.Vehicle(2018, "Chevy", "Camaro",   12000, isAutomatic: false);

            Console.WriteLine(OH.BoxedMessageWithTitle("Your Vehicle", v1.ToString()));
            Console.WriteLine(OH.BoxedMessageWithTitle("Your Vehicle", v2.ToString()));
            return Task.CompletedTask;
        }

        // 2) Car & Truck polymorphism demo
        public Task CarAndTruckTestingAsync()
        {
            var car   = new VM.Car  (2000, "Honda", "Civic",  1000,  isConvertible: true,  bodyType: VM.BodyType.Coupe);
            var truck = new VM.Truck(2025, "Ford",  "F150",   10,    bedLengthFeet: 8.0,   payloadCapacityLbs: 2000);

            Console.WriteLine(OH.BoxedMessageWithTitle("Car",   car.ToString()));
            Console.WriteLine(OH.BoxedMessageWithTitle("Truck", truck.ToString()));
            return Task.CompletedTask;
        }

        // 3) Add a vehicle (compose first, then add)
        public Task AddVehicleAsync()
        {
            Console.WriteLine(OH.BoxedMessageWithTitle("Add a Vehicle", "1) Car\n2) Truck"));
            int which = IH.GetInputAsInt("Choose 1 or 2: ", 1, 2, confirm: true);

            VM.Vehicle toAdd = (which == 1) ? ComposeCar() : ComposeTruck();
            _garage.Add(toAdd);

            Console.WriteLine(OH.BoxedMessageWithTitle("Added", toAdd.ToString()));
            return Task.CompletedTask;
        }

        // 4) Show vehicles
        public Task ShowVehiclesAsync()
        {
            if (_garage.Count == 0)
            {
                Console.WriteLine(OH.BoxedMessageWithTitle("Vehicles", "No vehicles in the garage yet."));
                return Task.CompletedTask;
            }

            Console.WriteLine(OH.BoxedMessageWithTitle("Vehicles", $"Total: {_garage.Count}"));
            for (int i = 0; i < _garage.Count; i++)
                Console.WriteLine($"[{i + 1}] {_garage[i]}");

            return Task.CompletedTask;
        }

        // -------- helpers (single, non-duplicated versions) --------

        private static VM.BodyType ChooseBodyType()
        {
            var values = (VM.BodyType[])Enum.GetValues(typeof(VM.BodyType));
            Console.WriteLine("Select Body Type:");
            for (int i = 0; i < values.Length; i++)
                Console.WriteLine($"{i + 1}) {values[i]}");

            int idx = IH.GetInputAsInt("Choice: ", 1, values.Length, confirm: true) - 1;
            return values[idx];
        }

        private VM.Car ComposeCar()
        {
            Console.WriteLine(OH.BoxedMessageWithTitle("Compose Car", "Enter car details"));
            int    year   = IH.GetInputAsInt("Year: ", 1886, 2100, confirm: true);
            string make   = IH.GetInputAsString("Make: ", confirm: true);
            string model  = IH.GetInputAsString("Model: ", confirm: true);
            int    miles  = IH.GetInputAsInt("Mileage (whole number): ", 0, int.MaxValue, confirm: true);
            bool   isConv = IH.GetInputAsBool("Is convertible? (Y/N): ", confirm: false);
            var    body   = ChooseBodyType();

            // Matches your library constructor: (year, make, model, mileage, isConvertible, bodyType)
            return new VM.Car(year, make, model, miles, isConv, body);
        }

        private VM.Truck ComposeTruck()
        {
            Console.WriteLine(OH.BoxedMessageWithTitle("Compose Truck", "Enter truck details"));
            int    year     = IH.GetInputAsInt("Year: ", 1886, 2100, confirm: true);
            string make     = IH.GetInputAsString("Make: ", confirm: true);
            string model    = IH.GetInputAsString("Model: ", confirm: true);
            int    miles    = IH.GetInputAsInt("Mileage (whole number): ", 0, int.MaxValue, confirm: true);
            double bedFt    = IH.GetInputAsDouble("Bed length (feet): ", 0, 30, confirm: true);
            int    payload  = IH.GetInputAsInt("Payload capacity (lbs): ", 0, 20_000, confirm: true);

            // Matches your library constructor: (year, make, model, mileage, bedLengthFeet, payloadCapacityLbs)
            return new VM.Truck(year, make, model, miles, bedFt, payload);
        }
    }
}

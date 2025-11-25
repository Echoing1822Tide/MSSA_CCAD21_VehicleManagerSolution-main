namespace VehicleModels
{
    public class Vehicle
    {
        public int Year { get; set; }
        public string Make { get; set; } = "";
        public string Model { get; set; } = "";
        public int Mileage { get; set; }
        public bool IsAutomatic { get; set; }

        public Vehicle() {}

        public Vehicle(int year, string make, string model, int mileage, bool isAutomatic)
        {
            Year = year;
            Make = make;
            Model = model;
            Mileage = mileage;
            IsAutomatic = isAutomatic;
        }

        public virtual string Describe()
            => $"{Year} {Make} {Model} | {Mileage:n0} mi | {(IsAutomatic ? "Automatic" : "Manual")}";

        public override string ToString() => Describe();
    }
}

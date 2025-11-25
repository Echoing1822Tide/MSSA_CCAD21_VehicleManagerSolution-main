namespace VehicleModels
{
    public class Car : Vehicle
    {
        public bool IsConvertible { get; set; }
        public BodyType BodyType { get; set; }

        public Car() {}

        public Car(int year, string make, string model, int mileage, bool isConvertible, BodyType bodyType, bool isAutomatic = true)
            : base(year, make, model, mileage, isAutomatic)
        {
            IsConvertible = isConvertible;
            BodyType = bodyType;
        }

        public override string Describe()
            => base.Describe() + $" | {(IsConvertible ? "Convertible" : "Hardtop")} | Body: {BodyType}";
    }
}

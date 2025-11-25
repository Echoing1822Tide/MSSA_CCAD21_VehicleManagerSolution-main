namespace VehicleModels
{
    public class Truck : Vehicle
    {
        public double BedLengthFeet { get; set; }
        public int PayloadCapacityLbs { get; set; }

        public Truck() {}

        public Truck(int year, string make, string model, int mileage, double bedLengthFeet, int payloadCapacityLbs, bool isAutomatic = true)
            : base(year, make, model, mileage, isAutomatic)
        {
            BedLengthFeet = bedLengthFeet;
            PayloadCapacityLbs = payloadCapacityLbs;
        }

        public override string Describe()
            => base.Describe() + $" | Bed: {BedLengthFeet:0.##} ft | Payload: {PayloadCapacityLbs:n0} lbs";
    }
}

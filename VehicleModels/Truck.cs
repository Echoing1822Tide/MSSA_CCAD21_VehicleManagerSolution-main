namespace VehicleModels;

public class Truck: Vehicle
{
    public double BedLength {get;set;}

    public double PayloadCapacity {get; set;}

    public Truck(): base()
    {

    }

    public Truck (int year, string make, string model, double mileage, 
                bool isAutomatic, double bedLength, double payloadCapacity) 
                :base(year, make, model, mileage, isAutomatic)
    {
        BedLength = bedLength;
        PayloadCapacity = payloadCapacity;
    }

    public override string ToString()
    {
        return $"{base.ToString()}  Bed length: {BedLength} ft  Payload capacity: {PayloadCapacity} lbs";
    }
}
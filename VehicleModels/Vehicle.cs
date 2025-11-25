namespace VehicleModels;

public class Vehicle
{
    // Properties
    public int Year { get; set; }
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    //    public string Color { get; set; } = string.Empty;
    public double Mileage { get; set; }
    public bool IsAutomatic { get; set; }

    // Constructors
    public Vehicle()
    {

    }

    public Vehicle(int year, string make, string model, double mileage, bool isAnAutomatic)
    {
        Year = year;
        Make = make;
        Model = model;
        Mileage = mileage;
        IsAutomatic = isAnAutomatic;
    }

    // Methods

    public override string ToString()
    {
        return $"Year: {Year}\tMake: {Make}\t" +
                                    $"Model: {Model}\tMileage: {Mileage}\t" +
                                    $"Is automatic: {(IsAutomatic ? "Yes" : "No")}"; ;
    }

    // more methods
    // needs access myVehicle

    // Method to determine next oil change
}

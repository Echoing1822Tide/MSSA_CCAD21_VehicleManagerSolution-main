namespace VehicleModels;

public class Car: Vehicle
{
    public bool IsConvertible {get; set;}
    public BodyType BodyType { get; set; }
    
    public Car (int year, string make, string model, double mileage, 
                bool isAutomatic, bool isConvertible, BodyType bodyType)
                : base(year, make, model, mileage, isAutomatic)
    {
        IsConvertible = isConvertible;
        BodyType = bodyType;
    }

    public Car() : base()
    {

    }

    public override string ToString()
    {
        return $"{base.ToString()}  Convertible: {(IsConvertible? "Yes" : "No")}  Body Type: {BodyType}";
    }
    


    
}
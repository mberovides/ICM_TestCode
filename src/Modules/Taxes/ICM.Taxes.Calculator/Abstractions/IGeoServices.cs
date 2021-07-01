namespace ICM.Taxes.Calculator.Abstractions
{
    public interface IGeoServices
    {
        Models.GeoLocation GetLocation(string zipCode);
    }
}
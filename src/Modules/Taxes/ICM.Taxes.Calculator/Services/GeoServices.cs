using System.Collections.Generic;
using ICM.Taxes.Calculator.Models;

namespace ICM.Taxes.Calculator
{
    public class GeoServices : Abstractions.IGeoServices
    {
        private Dictionary<string, GeoLocation> myGeo = new Dictionary<string, GeoLocation>
        {
            { "90404", new Models.GeoLocation { City = "Santa Monica", ZipCode = "90404", State = "CA" } },
            { "07001", new Models.GeoLocation { City = "Avenel", ZipCode = "07001", State = "NJ" } },
            { "07446", new Models.GeoLocation { City = "Ramsey", ZipCode = "07446", State = "NJ" } },
            { "33024", new Models.GeoLocation { City = "Hollywood", ZipCode = "33024", State = "FL" } },
            { "33027", new Models.GeoLocation { City = "Pembroke Pines", ZipCode = "33027", State = "FL" } }
        };

        public Models.GeoLocation GetLocation(string zipCode)
        {
            if (myGeo.ContainsKey(zipCode))
                return myGeo[zipCode];
            else return null;
        }
    }
}
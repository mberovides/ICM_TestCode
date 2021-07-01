using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICM.Taxes.Calculator.Models;

namespace ICM.Taxes.Calculator
{
    public class GeoServices : Abstractions.IGeoServices
    {
        private Dictionary<string, GeoLocation> myGeo = new Dictionary<string, GeoLocation>
        {
            { "90404", new GeoLocation { City = "Santa Monica", ZipCode = "90404" } }
        };

        public Models.GeoLocation GetLocation(string zipCode)
        {
            if (myGeo.ContainsKey(zipCode))
                return myGeo[zipCode];
            else return null;
        }
    }
}

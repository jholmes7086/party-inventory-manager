using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInventoryManger.Models
{
    public class Currency
    {
        public string Name { get; set; }
        public double ConvertionRateToStandard { get; set; }
        public long Id { get; set; }

        /// <summary>
        /// Defines a piece of currency that is in the system
        /// </summary>
        /// <param name="name">Name of the currency</param>
        /// <param name="convertionRate">The convertion rate to the stanard of the currancy system</param>
        public Currency (string name, double convertionRate)
        {
            Name = name;
            ConvertionRateToStandard = convertionRate;
        }
    }
}

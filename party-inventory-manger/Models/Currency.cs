using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInventoryManger.Models
{
    /// <summary>
    /// A particular piece of currency. ex gold piece, credit
    /// </summary>
    public class Currency
    {
        public string Name { get; set; }
        public double ConversionRateToStandard { get; set; }
        public long Id { get; set; }
        public long EconomyId { get; set; }
        public string Color { get; set; }

        /// <summary>
        /// Defines a piece of currency that is in the system
        /// </summary>
        /// <param name="name">Name of the currency</param>
        /// <param name="convertionRate">The convertion rate to the stanard of the currancy system</param>
        public Currency (string name, double convertionRate)
        {
            Name = name;
            ConversionRateToStandard = convertionRate;
        }

        public Currency(long id, string name, long economyId, double conversionRateToStandard, string color)
        {
            Id = id;
            Name = name;
            EconomyId = economyId;
            ConversionRateToStandard = conversionRateToStandard;
            Color = color;
        }
    }
}

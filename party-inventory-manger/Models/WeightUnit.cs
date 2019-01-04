using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInventoryManger.Models
{
    /// <summary>
    /// used to measure the size of an item
    /// </summary>
    public class WeightUnit
    {
        public string Name { get; set; }
        public long Id { get; private set; }
        public string DisplayName { get; set; }
        public double ConvertionRateToStandard { get; set; }
    }
}

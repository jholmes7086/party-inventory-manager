using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInventoryManger.Models
{

    /// <summary>
    /// A collection of all the weights in the system and their relation ship
    /// </summary>
    public class Weights
    {
        public long Id { get; set; }
        public List<WeightUnit> WeightUnits { get; set; }

    }
}

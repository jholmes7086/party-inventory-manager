using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInventoryManger.Models
{
    /// <summary>
    /// An item that can be in the inventory
    /// </summary>
    public class Item
    {
        public string Name { get; set; }
        public long Id { get; private set; }
        public Dictionary<WeightUnit, double> Weight;
        public Dictionary<Currency, double> Price;
    }
}

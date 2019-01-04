using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInventoryManger.Models
{
    /// <summary>
    /// an item that can contain one or more items
    /// </summary>
    public class Container : Item
    {
        public double WeightCapacity;
    }
}

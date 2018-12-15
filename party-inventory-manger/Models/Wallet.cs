using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInventoryManger.Models
{
    public class Wallet
    {
        public long EconomyId { get; private set; }
        public Dictionary<Currency, int> Funds { get; set; }
        public long Id { get; private set; }
    }
}

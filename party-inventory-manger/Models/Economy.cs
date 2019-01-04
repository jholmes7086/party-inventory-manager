using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInventoryManger.Models
{
    /// <summary>
    /// holds the types of money
    /// </summary>
    public class Economy
    {
        public long StandardCurrencyId { get; private set; }
        public long Id { get; set; }
        public List<Currency> Currencies { get; set; }

        /// <summary>
        /// Sets a economic system that is made up of curencies
        /// </summary>
        /// <param name="id">The ID of the economy</param>
        /// <param name="standardCurrencyId">The ID for the standard currency that is the base of the economy</param>
        public Economy (long id,long standardCurrencyId, List<Currency> currencies)
        {
            Id = id;
            StandardCurrencyId = standardCurrencyId;
            Currencies = currencies;
        }
    }
}

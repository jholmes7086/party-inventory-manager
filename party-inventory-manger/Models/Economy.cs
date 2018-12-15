using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInventoryManger.Models
{
    public class Economy
    {
        public long StandardCurrencyId { get; private set; }
        public List<Currency> Currencies { get; set; }
        public long Id { get; private set; }

        /// <summary>
        /// Sets a economic system that is made up of curencies
        /// </summary>
        /// <param name="standardCurrencyId">The ID for the standard currency that is the base of the economy</param>
        public Economy (long standardCurrencyId)
        {
            StandardCurrencyId = standardCurrencyId;
            Currencies = new List<Currency>();
        }

        /// <summary>
        /// Sets a economic system that is made up of curencies
        /// </summary>
        /// <param name="standardCurrencyId">The ID for the standard currency that is the base of the economy</param>
        /// <param name="currencies">The list of currencies used in the economy</param>
        public Economy(long standardCurrencyId, List<Currency> currencies)
        {
            StandardCurrencyId = standardCurrencyId;
            Currencies = currencies;
        }
    }
}

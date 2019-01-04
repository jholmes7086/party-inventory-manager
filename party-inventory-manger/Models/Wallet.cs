using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInventoryManger.Models
{
    /// <summary>
    /// Holds the money quantity and type
    /// </summary>
    public class Wallet
    {
        public long EconomyId { get; private set; }
        public List<CurrencyCount> Funds { get; set; }
        public long Id { get; private set; }

        /// <summary>
        /// creates a new wallet with an id and economy id
        /// </summary>
        /// <param name="id">the unique ID of the wallet</param>
        /// <param name="economyId">the unique ID of the economy used by the wallet</param>
        public Wallet (long id, long economyId, List<CurrencyCount> currencyCounts)
        {
            Id = id;
            EconomyId = economyId;
            Funds = currencyCounts;
        }

        /// <summary>
        /// gets the sum of the currency in the wallet in the standard currency
        /// </summary>
        /// <returns>returns the total currency in the wallet as a double</returns>
        //public double ConvertToStandard()
        //{
        //    double countingTotal = 0;

        //    foreach(KeyValuePair<Currency, int> cash in Funds)
        //    {
        //        countingTotal = countingTotal + cash.Value * cash.Key.ConversionRateToStandard;
        //    }

        //    return countingTotal;
        //}
    }
}

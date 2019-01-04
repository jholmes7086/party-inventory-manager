using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyInventoryManger.Models
{
    public class CurrencyCount
    {
        public long Id { get; set; }
        public long WalletId { get; set; }
        public long CurrencyId { get; set; }
        public int Quantity { get; set; }
        public Currency Currency { get; set; }

        /// <summary>
        /// create a new count of a specific type fo currency
        /// </summary>
        /// <param name="id">the unique id for this count</param>
        /// <param name="walletId">the wallet that this count goes in</param>
        /// <param name="currencyId">the id of the type of currency this count represents</param>
        /// <param name="quantity">the quantity of the currency</param>
        public CurrencyCount(long id, long walletId, Currency currency, int quantity)
        {
            Id = id;
            WalletId = walletId;
            Currency = currency;
            Quantity = quantity;
        }

    }
}

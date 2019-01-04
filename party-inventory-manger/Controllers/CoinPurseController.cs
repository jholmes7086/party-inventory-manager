using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInventoryManger.Models;
using PartyInventoryManger.Services;

namespace PartyInventoryManger.Controllers
{
    public class CoinPurseController : Controller
    {
        public ActionResult Home()
        {
            Wallet wallet = WalletService.GetWallet(0);

            return View(wallet);
        }

        [HttpPost]
        public ActionResult Home(CurrencyCount currencyCount)
        {
            return View();
        }

        public static double GetTotalFunds(Wallet wallet)
        {
            double runningTotal = 0;
            
            foreach( CurrencyCount currencyCount in wallet.Funds)
            {
                runningTotal = runningTotal + currencyCount.Quantity * currencyCount.Currency.ConversionRateToStandard;
            }
            return runningTotal;
        }
    }
}
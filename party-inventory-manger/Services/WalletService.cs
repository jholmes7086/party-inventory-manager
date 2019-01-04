using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.SqlClient;
using PartyInventoryManger.Models;

namespace PartyInventoryManger.Services
{
    public class WalletService
    {
        /// <summary>
        /// Saves provided wallet instance to the database
        /// </summary>
        /// <param name="wallet">Instance of Wallet class to save</param>
        public static void Save(Wallet wallet)
        {
            Debug.WriteLine("I'm writing to the wallet table w/ sql");

            SqlConnection sql = DatabaseService.GetSqlConnection();

            try
            {
                //update
                string update = "UPDATE dbo.WalletTable WHERE Id=@id SET EconomyId=@economyId;";
                SqlCommand command = new SqlCommand(update, sql);
                command.Parameters.AddWithValue("@economyId", wallet.EconomyId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if(ex.HResult == ErrorCodes.RowDoesntExist)
                {
                    //add
                    string add = "INSERT dbo.WalletTable WHERE Id=@id SET EconomyId=@economyId;";
                    SqlCommand command = new SqlCommand(add, sql);
                    command.Parameters.AddWithValue("@economyId", wallet.EconomyId);
                    command.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
            finally
            {
                sql.Close();
            }
        }

        /// <summary>
        /// creates an instance of the wallet class from the database
        /// </summary>
        /// <param name="walletId">Id of the wallet to create the class of</param>
        /// <returns>Instance of Wallet class with the provided ID</returns>
        public static Wallet GetWallet(long walletId)
        {
            Debug.WriteLine("I'm fetching the wallet with the ID of " + walletId +" from the wallet table");

            Wallet wallet = null;

            SqlConnection sql = DatabaseService.GetSqlConnection();

            //fetch the row
            string fetch = "SELECT * FROM dbo.WalletTable WHERE Id =@Id;";
            SqlCommand command = new SqlCommand(fetch, sql);
            command.Parameters.AddWithValue("@Id", walletId);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    wallet = new Wallet((long)reader["Id"],  (long)reader["EconomyId"], CurrencyCountsInWallet(walletId));
                }
            }

            sql.Close();
            return wallet;
        }

        private static List<CurrencyCount> CurrencyCountsInWallet(long walletId)
        {
            List<CurrencyCount> currencyCounts = new List<CurrencyCount>();

            SqlConnection sql = DatabaseService.GetSqlConnection();
            string fetch = "SELECT * FROM dbo.CurrencyCountTable WHERE WalletId=@walletId";
            SqlCommand command = new SqlCommand(fetch, sql);
            command.Parameters.AddWithValue("@walletId", walletId);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                
                while (reader.Read())
                {
                    currencyCounts.Add(CurrencyCountService.GetCurrencyCount((long)reader["Id"]));
                }
            }

            List<CurrencyCount> sortedCurrencyCounts = currencyCounts.OrderByDescending(c => c.Currency.ConversionRateToStandard).ToList();
            sql.Close();
            return sortedCurrencyCounts;

        }
    }
}

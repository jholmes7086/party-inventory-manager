using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using PartyInventoryManger.Models;

namespace PartyInventoryManger.Services
{
    public class CurrencyCountService
    {
        /// <summary>
        /// Saves the provided instance of CurrencyCount class to database
        /// </summary>
        /// <param name="currencyCount">Instance of CurrencyCount class to save</param>
        public static void Save(CurrencyCount currencyCount)
        {
            Debug.WriteLine("I'm writing to the currency count table w/ sql");

            SqlConnection sql = DatabaseService.GetSqlConnection();

            try
            {
                //update
                string update = "UPDATE dbo.CurrencyCountTable WHERE Id=@id SET WalletId=@walletId, CurrencyId=@curencyId, Quantity=@quantity;";
                SqlCommand command = new SqlCommand(update, sql);
                command.Parameters.AddWithValue("@id", currencyCount.Id);
                command.Parameters.AddWithValue("@walletId", currencyCount.WalletId);
                command.Parameters.AddWithValue("@currencyId", currencyCount.Currency.Id);
                command.Parameters.AddWithValue("@quantity", currencyCount.Quantity);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.HResult == ErrorCodes.RowDoesntExist)
                {
                    //add instead
                    string add = "INSERT dbo.CurrencyCountTable WHERE Id=@id SET WalletId=@walletId, CurrencyId=@curencyId, Quantity=@quantity;";
                    SqlCommand command = new SqlCommand(add, sql);
                    command.Parameters.AddWithValue("@id", currencyCount.Id);
                    command.Parameters.AddWithValue("@walletId", currencyCount.WalletId);
                    command.Parameters.AddWithValue("@currencyId", currencyCount.Currency.Id);
                    command.Parameters.AddWithValue("@quantity", currencyCount.Quantity);
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
        /// gets a currencyCOunt of the provided ID from the database
        /// </summary>
        /// <param name="currencyCountId">ID of the count to fetch</param>
        /// <returns>instance of the CurrencyCount class matching the database</returns>
        public static CurrencyCount GetCurrencyCount (long currencyCountId)
        {
            Debug.WriteLine("I'm fetching the currency count with the ID of " + currencyCountId +" from CurrencyCount table");

            CurrencyCount currencyCount = null;

            SqlConnection sql = DatabaseService.GetSqlConnection();

            //fetch the row
            string fetch = "SELECT * FROM dbo.CurrencyCountTable WHERE Id =@Id;";
            SqlCommand command = new SqlCommand(fetch, sql);
            command.Parameters.AddWithValue("@Id", currencyCountId);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    currencyCount = new CurrencyCount((long)reader["Id"], (long)reader["WalletId"], CurrencyService.GetCurrency((long)reader["CurrencyId"]), (int)reader["Quantity"]);
                }
            }

            sql.Close();
            return currencyCount;
        }
    }
}

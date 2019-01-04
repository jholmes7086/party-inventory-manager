using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using PartyInventoryManger.Models;

namespace PartyInventoryManger.Services
{
    public class EconomyService
    {
        /// <summary>
        /// Will same the instance of the Economy class to the database
        /// </summary>
        /// <param name="economy">Instance of Economy class to save</param>
        public void Save(Economy economy)
        {
            Debug.WriteLine("I'm writing to the economy table w/ sql");
            SqlConnection sql =DatabaseService.GetSqlConnection();

            try
            {
                //udate
                string update = "UPDATE dbo.EconomyTable WHERE Id=@Id SET StandardCurrencyId=@StandardId;";
                SqlCommand command = new SqlCommand(update, sql);
                command.Parameters.AddWithValue("@Id", economy.Id);
                command.Parameters.AddWithValue("@StandardId", economy.StandardCurrencyId);
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                if (ex.HResult == ErrorCodes.RowDoesntExist)
                {
                    string add = "INSERT dbo.EconomyTable WHERE Id=@Id SET StandardCurrencyId=@StandardId;";
                    SqlCommand command = new SqlCommand(add, sql);
                    command.Parameters.AddWithValue("@Id", economy.Id);
                    command.Parameters.AddWithValue("@StandardId", economy.StandardCurrencyId);
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
        /// Gets an instance of the Economy class populated out of the database
        /// </summary>
        /// <param name="economyId">The ID for the economy to create</param>
        /// <returns>an instance of the Economy class with the provided ID</returns>
        public Economy GetEconomy(long economyId)
        {
            Debug.WriteLine("I'm fetching the economy with the ID of " + economyId + " from economy table");
            Economy economy = null;
            List<Currency> currencies = new List<Currency>();

            SqlConnection sql = DatabaseService.GetSqlConnection();

            //fetch the row
            string fetch = "SELECT * FROM dbo.EconomyTable WHERE Id =@Id;";
            SqlCommand command = new SqlCommand(fetch, sql);
            command.Parameters.AddWithValue("@Id", economyId);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    economy = new Economy((long)reader["Id"], (long)reader["StandardCurrencyId"], GetCurrencies(economyId));
                }
            }

            sql.Close();
            return economy;
        }

        private List<Currency> GetCurrencies(long economyId)
        {
            List<Currency> currencies = new List<Currency>();

            SqlConnection sql = DatabaseService.GetSqlConnection();
            string fetch = "SELECT * FROM dbo.Currency WHERE EconomyId=@economyId";
            SqlCommand command = new SqlCommand(fetch, sql);
            command.Parameters.AddWithValue("@economyId", economyId);

            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    currencies.Add(CurrencyService.GetCurrency((long)reader["Id"]));
                }
            }

            sql.Close();

            List<Currency> sortedCurrencies = currencies.OrderByDescending(c => c.ConversionRateToStandard).ToList();

            return sortedCurrencies;
        }
    }
}

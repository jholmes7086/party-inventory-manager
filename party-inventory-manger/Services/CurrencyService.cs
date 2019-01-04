using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.SqlClient;
using PartyInventoryManger.Models;
using PartyInventoryManger.Services;

namespace PartyInventoryManger.Services
{
    public class CurrencyService
    {
        public static void Save(Currency currency)
        {
            Debug.WriteLine("I'm writing to the currency table w/ sql");

            //establish the sql conneciton
            SqlConnection sql = DatabaseService.GetSqlConnection();

            //see if currency already exists
            try
            {
                //update the currency
                string update = "UPDATE dbo.CurrencyTable WHERE Id=@Id SET Name=@Name, ConversionRateToStandard=@ConversionRate, EconomyId=@EconomyId;";
                SqlCommand command = new SqlCommand(update, sql);
                command.Parameters.AddWithValue("@Id", currency.Id);
                command.Parameters.AddWithValue("@Name", currency.Name);
                command.Parameters.AddWithValue("@ConversionRate", currency.ConversionRateToStandard);
                command.Parameters.AddWithValue("@EconomyId", currency.EconomyId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //if update failed add instead
                if (ex.HResult == ErrorCodes.RowDoesntExist)
                {
                    string add = "INSERT dbo.CurrencyTable WHERE Id=@Id SET Name=@Name, ConversionRateToStandard=@ConversionRate, EconomyId=@EconomyId;";
                    SqlCommand command = new SqlCommand(add, sql);
                    command.Parameters.AddWithValue("@Id", currency.Id);
                    command.Parameters.AddWithValue("@Name", currency.Name);
                    command.Parameters.AddWithValue("@ConversionRate", currency.ConversionRateToStandard);
                    command.Parameters.AddWithValue("@EconomyId", currency.EconomyId);
                    command.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception(ex.Message);
                }

            }
            finally
            {
                //close conneciton
                sql.Close();
            }

        }

        public static Currency GetCurrency(long currencyID)
        {
            Debug.WriteLine("I'm fetching the currency with the ID of " + currencyID + " from currency table");
            Currency currency = null;

            //open sql connection
            SqlConnection sql = DatabaseService.GetSqlConnection();

            //fetch the row
            string fetch = "SELECT * FROM dbo.CurrencyTable WHERE Id =@Id;";
            SqlCommand command = new SqlCommand(fetch, sql);
            command.Parameters.AddWithValue("@Id", currencyID);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    currency = new Currency((long)reader["Id"], (string)reader["Name"], 
                        (long)reader["EconomyId"], (double)reader["ConversionRateToStandard"], (string)reader["Color"]);
                }
            }

            sql.Close();
            return currency;
            //set fetched row as new currency instance
            
        }
    }
}

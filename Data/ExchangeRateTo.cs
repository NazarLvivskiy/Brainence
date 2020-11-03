using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorApp2.Data
{
    public class ExchangeRateTo
    {
        IRepository Repository;

        public ExchangeRateTo()
        {
            Repository = new Repository();
        }

        public CurrentExchange CurrentExchange { get; set; }

        private async Task GetCurrentExchangeAsync(string moneyCode)
        {
            using (FileStream fs = new FileStream("https://api.exchangeratesapi.io/latest?base=" + moneyCode, FileMode.OpenOrCreate))
            {
                CurrentExchange = await JsonSerializer.DeserializeAsync<CurrentExchange>(fs);
            }
        }

        public decimal GetMoneyTo(string moneyCodeFrom, string moneyCodeTo, decimal amountFrom )
        {
            _ = GetCurrentExchangeAsync(moneyCodeFrom);
            var coefficient = CurrentExchange.rates[moneyCodeTo];
            var amountTo = coefficient * amountFrom;
            Repository.POST(new ExchangeHistory(moneyCodeFrom, amountFrom, moneyCodeTo, amountTo, DateTime.Now));
            return amountTo;
        }
    }
}

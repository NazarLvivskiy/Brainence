using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
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

        private void GetCurrentExchange(string moneyCode)
        {
            string str = "https://api.exchangeratesapi.io/latest?base=" + moneyCode;
            WebClient webClient = new WebClient();
            if (webClient == null)
            {
                webClient = new WebClient();
            }
            else
            {
                webClient.Dispose();
                webClient = null;
                webClient = new WebClient();
            }

            //Set Header  
            webClient.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            //Download Content  
            string JsonSting = webClient.DownloadString(str);
            CurrentExchange = JsonSerializer.Deserialize<CurrentExchange>(JsonSting);
        }

        public decimal GetMoneyTo(string moneyCodeFrom, string moneyCodeTo, decimal amountFrom, ref decimal coef)
        {
            if (moneyCodeFrom == null)
            {
                moneyCodeFrom = "USD";
            }

            if (moneyCodeTo == null)
            {
                moneyCodeTo = "EUR";
            }

            GetCurrentExchange(moneyCodeFrom);

            coef = CurrentExchange.rates[moneyCodeTo];

            var amountTo = coef * amountFrom;

            Repository.POST(new ExchangeHistory(moneyCodeFrom, amountFrom, moneyCodeTo, amountTo, DateTime.Now));

            return amountTo;
        }
    }
}

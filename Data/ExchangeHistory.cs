using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Data
{
    public class ExchangeHistory
    {
        [Key]
        public int Id { get; set; }

        public string FromCurrency { get; set; }

        public decimal FromAmount { get; set; }

        public string ToCurrency { get; set; }

        public decimal ToAmount { get; set; }

        public DateTime Date { get; set; }

        public ExchangeHistory(string _FromCurrency, decimal _FromAmount, string _ToCurrency, decimal _ToAmount, DateTime _Date)
        {
            FromAmount = _FromAmount;
            FromCurrency = _FromCurrency;
            ToAmount = _ToAmount;
            ToCurrency = _ToCurrency;
            Date = _Date;
        }
    }
}

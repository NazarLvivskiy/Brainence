using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Data
{
    public interface IRepository
    {
        void POST(ExchangeHistory exchangeHistory);

        ExchangeHistory GET(int id);

        List<ExchangeHistory> GET(string FromCurrency);

        List<ExchangeHistory> GET();

        public List<ExchangeHistory> SortByFromCurrency();

        public List<ExchangeHistory> SortByFromAmount();

        public List<ExchangeHistory> SortByToCurrency();

        public List<ExchangeHistory> SortByToAmount();

        public List<ExchangeHistory> SortByDate();

        void PUT(ExchangeHistory exchangeHistory);

        void DELETE(int id);

        void Save();
    }
}

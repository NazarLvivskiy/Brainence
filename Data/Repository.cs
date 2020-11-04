using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Data
{
    public class Repository : IRepository
    {
        private AppContext context;

        public Repository()
        {
            context = new AppContext();
        }

        public void DELETE(int id)
        {
            context.Histories.Remove(GET(id));
            Save();
        }

        public ExchangeHistory GET(int id)
        {
            return context.Histories.Find(id);
        }

        public List<ExchangeHistory> GET()
        {
            return context.Histories.ToList();
        }

        public List<ExchangeHistory> GET(string FromCurrency)
        {
            return context.Histories.ToList().FindAll(delegate (ExchangeHistory history)
            {
                return history.FromCurrency == FromCurrency;
            }
            );
        }

        public void POST(ExchangeHistory exchangeHistory)
        {
            context.Histories.Add(exchangeHistory);
            Save();
        }

        public void PUT(ExchangeHistory exchangeHistory)
        {
            context.Histories.Update(exchangeHistory);
            Save();
        }

       

        public void Save()
        {
            context.SaveChanges();
        }

        public List<ExchangeHistory> SortByFromCurrency()
        {
            return context.Histories.OrderBy(h => h.FromCurrency).ToList();
        }

        public List<ExchangeHistory> SortByFromAmount()
        {
            return context.Histories.OrderBy(h => h.FromAmount).ToList();
        }

        public List<ExchangeHistory> SortByToCurrency()
        {
            return context.Histories.OrderBy(h => h.ToCurrency).ToList();
        }

        public List<ExchangeHistory> SortByToAmount()
        {
            return context.Histories.OrderBy(h => h.ToAmount).ToList();
        }

        public List<ExchangeHistory> SortByDate()
        {
            return context.Histories.OrderBy(h => h.Date).ToList();
        }
    }
}

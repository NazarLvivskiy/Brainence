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
    }
}

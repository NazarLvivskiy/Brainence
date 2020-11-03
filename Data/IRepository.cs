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

        List<ExchangeHistory> GET();

        void PUT(ExchangeHistory exchangeHistory);

        void DELETE(int id);

        void Save();
    }
}

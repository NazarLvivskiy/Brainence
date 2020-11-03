using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp2.Data
{
    public class CurrentExchange
    {
        public Dictionary<string,decimal> rates { get; set; }

        public string Base { get; set; }

        public string Date { get; set; }

        public CurrentExchange()
        {
            rates = new Dictionary<string, decimal>();
        }
    }
}

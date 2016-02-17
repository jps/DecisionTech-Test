using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionTech.Model;

namespace DecisionTech.Service.DTO
{
    public class BasketCalculatorResult
    {
        private IList<Offer> AppliedOffers { get; set; }
        private Basket Basket { get; set; }

        public decimal Gross { get; set; }

        public decimal Discount { get; set; }

        public decimal Net { get; set; }
    }
}

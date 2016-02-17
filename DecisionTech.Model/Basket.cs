using System.Collections.Generic;

namespace DecisionTech.Model
{
    public class Basket : IEntity<long>
    {
        public long Id { get; set; }
        public List<BasketItem>  BasketItems { get; set; }
    }
}

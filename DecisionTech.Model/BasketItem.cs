namespace DecisionTech.Model
{
    //This doesn't inherit from entity because it's only going to be a prop in Basket.cs, if we were going down the SQL
    //ORM route this would end up needing to be an entity
    public class BasketItem
    {
        public Product Product { get; set;  }
        public int Quantity { get; set; }
    }
}
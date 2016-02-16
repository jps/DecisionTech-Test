﻿namespace DecisionTech.Model
{
    public class Offer
    {
        public Product PurchaseProduct { get; set; } //May want this to be products plural

        public Product DiscountProduct { get; set; } //Again may want this be a products plural

        public int RequiredPurchaseQuantity { get; set; }

        public float PercentDiscount { get; set; }
    }
}

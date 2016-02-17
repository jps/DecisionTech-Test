namespace DecisionTech.Service.DTO
{
    public class BasketCalculatorResult
    {
        public readonly decimal Gross;

        public BasketCalculatorResult(decimal gross, decimal discount)
        {
            Gross = gross;
            Discount = discount;
        }

        public readonly decimal Discount;

        public decimal Net => Gross + Discount;
    }
}

using DecisionTech.Model;
using DecisionTech.Service.DTO;

namespace DecisionTech.Service.Interfaces
{
    public interface IBasketCalculator
    {
        BasketCalculatorResult Calculate(Basket basket);
    }
}

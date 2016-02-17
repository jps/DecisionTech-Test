using DecisionTech.Model;
using DecisionTech.Service.DTO;

namespace DecisionTech.Service.Interfaces
{
    public interface IBasketCalculatorService
    {
        BasketCalculatorResult Calculate(Basket basket);
    }
}

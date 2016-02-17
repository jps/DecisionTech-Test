using DecisionTech.Model;

namespace DecisionTech.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product, int>
    {
        Product GetByName(string name); 
    }
}

using Pizzas.BL.Model;

namespace Pizzas.BL.Interfaces
{
    public interface IAnalyzator
    {
        void GivePizzasName(Orders orders);

        List<PizzaOrdersView> GetTopTen(Orders orders);
    }
}

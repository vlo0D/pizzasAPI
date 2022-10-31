using Pizzas.BL.Interfaces;
using Pizzas.BL.Model;

namespace Pizzas.BL.Services
{
    public class AnalyzatorService : IAnalyzator
    {
        public void GivePizzasName(Orders orders)
        {
            var pizzas = orders.Pizzas;

            if (pizzas != null)
            {
                foreach (var pizza in pizzas)
                {
                    var str = "";
                    foreach (var top in pizza.Toppings)
                    {
                        str += top.Substring(0, 2);
                    }

                    pizza.Name = str;
                }
            }
        }

        public List<PizzaOrdersView> GetTopTen(Orders orders)
        {
            var pizzas = orders.Pizzas;

            List <PizzaOrdersView> topTen = new List<PizzaOrdersView>();

            var topTenGroup = (from pizza in pizzas
                               group pizza by pizza.Name into g
                               orderby g.Count() descending
                               select new
                               {
                                   Name = g.Key,
                                   Count = g.Count(),
                               }).Take(10);

            foreach (var pizza in topTenGroup)
            {
                var tempPiz = pizzas.First(x => x.Name == pizza.Name);

                topTen.Add(new PizzaOrdersView(tempPiz, pizza.Count));
            }

            return topTen;
        }
    }
}

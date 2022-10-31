using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzas.BL.Model
{
    public class PizzaOrdersView
    {
        public PizzaOrdersView(Pizza pizza, int ordersCount)
        {
            Pizza = pizza;
            OrdersCount = ordersCount;
        }

        public Pizza Pizza { get; set; }

        public int OrdersCount { get; set; }
    }
}

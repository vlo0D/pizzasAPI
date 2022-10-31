using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizzas.BL.Interfaces;
using Pizzas.BL.Model;

namespace Pizzas.WEB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PizzaOrdersController : ControllerBase
    {
        private readonly ISerializator _serializ;
        private readonly IAnalyzator _analyzator;
        private readonly IConfiguration _configuration;

        public PizzaOrdersController(ISerializator serializ, IAnalyzator analyz, IConfiguration configuration)
        {
            _serializ = serializ;
            _analyzator = analyz;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetTop10")]
        public async Task<IEnumerable<PizzaOrdersView>> GetTopTen()
        {
            Orders orders = new Orders();
            string path = _configuration["PathToJson"];
            orders.Pizzas = await _serializ.DeserializeFromFile(path);
            _analyzator.GivePizzasName(orders);
            return _analyzator.GetTopTen(orders);
        }
    }
}

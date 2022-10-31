using Pizzas.BL.Interfaces;
using Pizzas.BL.Model;
using System.Text.Json;

namespace Pizzas.BL.Services
{
    public class SerializatorService : ISerializator
    {
        public async Task<List<Pizza>> DeserializeFromFile(string fileName)
        {
            List<Pizza> allPizzas = new List<Pizza>();

            try
            {
                using FileStream openStream = File.OpenRead(fileName);
                allPizzas = await JsonSerializer.DeserializeAsync<List<Pizza>>(openStream);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            return allPizzas;
        }
    }
}

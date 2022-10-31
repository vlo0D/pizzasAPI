using Pizzas.BL.Model;

namespace Pizzas.BL.Interfaces
{
    public interface ISerializator
    {
        Task<List<Pizza>> DeserializeFromFile(string fileName);
    }
}
